using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.UI;

namespace Fungus
{
    [CommandInfo("UI", "UI Fade InOut", "Boolに応じてUIのα値を変える")]
    public class UIFadeInOut : Command
    {
        [Tooltip("最初に発火するまでの待ち時間")]
        [SerializeField] protected float waitTime = 0.001f;

        [Tooltip("フェード速度")] [SerializeField] protected float changeValue = 0.02f;
        [Tooltip("フェード下限")] [SerializeField] protected float fadeMin = 0f;
        [Tooltip("フェード上限")] [SerializeField] protected float fadeMax = 1f;
        [Tooltip("Bool変数")]
        [VariableProperty(typeof(BooleanVariable))]
        [SerializeField] protected Variable variable;
        [Tooltip("UI")]
        [SerializeField] protected List<GameObject> uiList;

        public override void OnEnter()
        {
            StartCoroutine(FadeAnimation());
            Continue();
        }

        private IEnumerator FadeAnimation()
        {
            bool upDown = true;
            float elapsedTime = 0f;
            BooleanVariable booleanVariable = (variable as BooleanVariable);
            booleanVariable.Apply( SetOperator.Assign, true);
            
            while (true)
            {
                
                if (elapsedTime < waitTime)
                {
                    elapsedTime += Time.deltaTime;
                    
                    if (!booleanVariable.Value)
                    {
                        foreach (var gameObject in uiList)
                        {
                            var image = gameObject.GetComponent<Image>();
                            if (image != null)
                            {
                                Color color = image.color;
                                color.a = 0;
                                image.color = color;
                            }

                            var text = gameObject.GetComponent<Text>();
                            if (text != null)
                            {
                                Color color = text.color;
                                color.a = 0;
                                text.color = color;
                            }
                        }
                        yield break;
                    }
                    
                    yield return null;
                    continue;
                }

                if (booleanVariable.Value && elapsedTime > waitTime)
                {
                    if (upDown)
                    {
                        foreach (var gameObject in uiList)
                        {
                            var image = gameObject.GetComponent<Image>();
                            if (image != null)
                            {
                                Color color = image.color;
                                color.a += changeValue;

                                if (color.a > fadeMax)
                                {
                                    color.a = fadeMax;
                                    upDown = false;
                                }

                                image.color = color;
                            }

                            var text = gameObject.GetComponent<Text>();
                            if (text != null)
                            {
                                Color color = text.color;
                                color.a += changeValue;

                                if (color.a > fadeMax)
                                {
                                    color.a = fadeMax;
                                    upDown = false;
                                }

                                text.color = color;
                            }
                        }
                    }
                    else
                    {
                        foreach (var gameObject in uiList)
                        {
                            var image = gameObject.GetComponent<Image>();
                            if (image != null)
                            {
                                Color color = image.color;
                                color.a -= changeValue;

                                if (color.a < fadeMin)
                                {
                                    color.a = fadeMin;
                                    upDown = true;
                                }

                                image.color = color;
                            }

                            var text = gameObject.GetComponent<Text>();
                            if (text != null)
                            {
                                Color color = text.color;
                                color.a -= changeValue;

                                if (color.a < fadeMin)
                                {
                                    color.a = fadeMin;
                                    upDown = true;
                                }

                                text.color = color;
                            }
                        }
                    }
                    yield return null;
                }
                else
                {
                    foreach (var gameObject in uiList)
                    {
                        var image = gameObject.GetComponent<Image>();
                        if (image != null)
                        {
                            Color color = image.color;
                            color.a = 0;
                            image.color = color;
                        }

                        var text = gameObject.GetComponent<Text>();
                        if (text != null)
                        {
                            Color color = text.color;
                            color.a = 0;
                            text.color = color;
                        }
                    }
                    yield break;
                }
            }
        }

        public override Color GetButtonColor()
        {
            return new Color32(180, 250, 250, 255);
        }

        public override string GetSummary()
        {
            string summary = "待機時間：" + waitTime + ", フェード速度：" + changeValue + ", ターゲットUI：";
            if (uiList != null)
            {
                foreach (var gameObject in uiList)
                {
                    if (gameObject != null)
                    {
                        summary += gameObject.name + " ";
                    }
                }
            }

            if (variable != null)
            {
                summary += ", ターゲット変数：" + variable.Key;
            }

            return summary;
        }
        
    }
}