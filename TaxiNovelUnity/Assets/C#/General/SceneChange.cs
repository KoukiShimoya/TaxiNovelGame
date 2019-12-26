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
        RightToLeftCircle,
        CheckExpansion
    }

    private FadeImage fadeImage;
    [SerializeField] private List<FadeTypeAndTexture> fadeTypeAndTexture;

    private void Start()
    {
        fadeImage = gameObject.GetComponent<FadeImage>();
        SceneManager.sceneLoaded += SceneLoadFinish;
    }

    /// <summary>
    ///     シーン切り替えのコルーチンを起動
    /// </summary>
    /// <param name="fadeType"></param>
    /// <param name="fadeTime">フェード時間。ない場合はデフォルト値の1。</param>
    /// <param name="sceneName">ConstValues.SceneName。ない場合はシーン遷移なしでエフェクトだけ。</param>
    public void FadeAllTextureDetect(FadeType fadeType, string sceneName = "", float fadeTime = 1f)
    {
        for (var i = 0; i < fadeTypeAndTexture.Count; i++)
        {
            if (fadeType == fadeTypeAndTexture[i].fadeType)
            {
                StartCoroutine(FadeAllTimeElapsed(fadeTypeAndTexture[i].texture, fadeTime, sceneName));
                break;
            }
        }
    }

    /// <summary>
    ///     途中までフェードアウトしていき、一定場所に到達したらフェードイン
    /// </summary>
    /// <param name="fadeType"></param>
    /// <param name="fadeChangeRate">0~1まで。どこでフェードを切り替えるのか</param>
    /// <param name="fadeTime">フェード時間。デフォルト値は1。</param>
    public void FadeMiddleTextureDetect(FadeType fadeType, float fadeChangeRate, float fadeTime = 1f)
    {
        for (var i = 0; i < fadeTypeAndTexture.Count; i++)
        {
            if (fadeType == fadeTypeAndTexture[i].fadeType)
            {
                StartCoroutine(FadeMiddleTimeElapsed(fadeTypeAndTexture[i].texture, fadeChangeRate, fadeTime));
                break;
            }
        }
    }

    ///指定時間かけてフェードをかける。その後sceneNameが入っている場合はシーン遷移。
    private IEnumerator FadeAllTimeElapsed(Texture2D fadeTexture, float fadeTime, string sceneName)
    {
        var processing = true;
        fadeImage.SetMaskTexture = fadeTexture;
        while (processing)
        {
            var rate = Time.deltaTime / fadeTime;
            var postProcessPercentage = fadeImage.Range + rate;
            fadeImage.Range = postProcessPercentage;
            if (postProcessPercentage > 1)
            {
                fadeImage.Range = 1;
                processing = false;
                if (sceneName == "")
                {
                    yield break;
                }

                if (sceneName != SceneManager.GetActiveScene().name)
                {
                    SceneManager.LoadScene(sceneName);
                }

                yield break;
            }

            yield return null;
        }
    }

    /// <summary>
    ///     ポストエフェクト無しのシーン切り替え
    /// </summary>
    /// <param name="sceneName"></param>
    public void NoPostEffectSceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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
        fadeImage.Range = 0f;
    }

    [Serializable]
    public struct FadeTypeAndTexture
    {
        public FadeType fadeType;
        public Texture2D texture;
    }
}