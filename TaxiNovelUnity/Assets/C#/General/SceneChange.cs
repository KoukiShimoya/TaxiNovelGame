using System;
using System.Collections;
using System.Collections.Generic;
using ConstValues;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : SingletonMonoBehaviour<SceneChange>
{
    public enum FadeType
    {
        CarConcentrateLine,
        Circle,
        None
    }

    private FadeImage fadeImage;
    [SerializeField] private List<FadeTypeAndTexture> fadeTypeAndTexture;

    private void Start()
    {
        SceneManager.sceneLoaded += SceneLoadFinish;
    }

    public void SceneChangeFunction(SceneName sceneName)
    {
        SceneManager.LoadScene(sceneName.ToString());
    }

    public void FadeOut(FadeType fadeType, float fadeTime)
    {
        if (fadeType == FadeType.None)
        {
            return;
        }
        
        for (var i = 0; i < fadeTypeAndTexture.Count; i++)
        {
            if (fadeType == fadeTypeAndTexture[i].fadeType)
            {
                StartCoroutine(FadeOutAllTime(fadeTypeAndTexture[i].texture, fadeTime));
            }
        }
    }

    public void FadeIn(FadeType fadeType, float fadeTime)
    {
        if (fadeType == FadeType.None)
        {
            return;
        }
        
        for (var i = 0; i < fadeTypeAndTexture.Count; i++)
        {
            if (fadeType == fadeTypeAndTexture[i].fadeType)
            {
                StartCoroutine(FadeInAllTime(fadeTypeAndTexture[i].texture, fadeTime));
            }
        }
    }

    /// <summary>
    ///     途中までフェードアウトしていき、一定場所に到達したらフェードイン
    /// </summary>
    /// <param name="fadeType"></param>
    /// <param name="fadeChangeRate">0~1まで。どこでフェードを切り替えるのか</param>
    /// <param name="fadeTime">フェード時間。デフォルト値は1。</param>
    public void FadeMiddleTexture(FadeType fadeType, float fadeChangeRate, float fadeTime = 1f)
    {
        if (fadeType == FadeType.None)
        {
            return;
        }
        
        for (var i = 0; i < fadeTypeAndTexture.Count; i++)
        {
            if (fadeType == fadeTypeAndTexture[i].fadeType)
            {
                StartCoroutine(FadeMiddleTimeElapsed(fadeTypeAndTexture[i].texture, fadeChangeRate, fadeTime));
                break;
            }
        }
    }

    private IEnumerator FadeOutAllTime(Texture2D fadeTexture, float fadeTime)
    {
        var processing = true;
        fadeImage.SetMaskTexture = fadeTexture;
        fadeImage.Range = 0f;
        while (processing)
        {
            var rate = Time.deltaTime / fadeTime;
            var postProcessPercentage = fadeImage.Range + rate;
            fadeImage.Range = postProcessPercentage;
            if (postProcessPercentage > 1f)
            {
                fadeImage.Range = 1f;
                processing = false;

                yield break;
            }

            yield return null;
        }
    }

    private IEnumerator FadeInAllTime(Texture2D fadeTexture, float fadeTime)
    {
        var processing = true;
        fadeImage.SetMaskTexture = fadeTexture;
        fadeImage.Range = 1f;
        while (processing)
        {
            var rate = Time.deltaTime / fadeTime;
            var postProcessPercentage = fadeImage.Range - rate;
            fadeImage.Range = postProcessPercentage;
            if (postProcessPercentage <= 0)
            {
                fadeImage.Range = 0f;
                processing = false;

                yield break;
            }

            yield return null;
        }
    }

    /// <summary>
    ///     fadeChangeRateまではフェードアウト、それ以降はフェードイン
    /// </summary>
    /// <param name="fadeTexture"></param>
    /// <param name="fadeChangeRate"></param>
    /// <param name="fadeTime"></param>
    /// <returns></returns>
    private IEnumerator FadeMiddleTimeElapsed(Texture2D fadeTexture, float fadeChangeRate, float fadeTime)
    {
        var processing = true;
        var middleTime = fadeTime / 2;
        var elapsedTime = 0f;
        fadeImage.SetMaskTexture = fadeTexture;
        while (processing)
        {
            elapsedTime += Time.deltaTime;
            var rate = Time.deltaTime / middleTime * fadeChangeRate;
            if (elapsedTime < middleTime)
            {
                fadeImage.Range += rate;
            }
            else
            {
                fadeImage.Range -= rate;
            }

            if (elapsedTime >= fadeTime)
            {
                processing = false;
                fadeImage.Range = 0f;
                yield break;
            }

            yield return null;
        }
    }


    /// <summary>
    ///     シーンのロードが完了した際に呼ばれる
    /// </summary>
    /// <param name="nextScnene"></param>
    /// <param name="mode"></param>
    private void SceneLoadFinish(Scene nextScnene, LoadSceneMode mode)
    {
        fadeImage = FadeImageCanvas.Instance.gameObject.GetComponent<FadeImage>();
    }

    [Serializable]
    public struct FadeTypeAndTexture
    {
        public FadeType fadeType;
        public Texture2D texture;
    }
}