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
        [SerializeField] protected float waitTime;

        [Tooltip("フェード速度")] [SerializeField] protected float changeValue = 0.02f;
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
            bool startFade = false;
            
            while (true)
            {
                BooleanVariable booleanVariable = (variable as BooleanVariable);
                if (elapsedTime < waitTime)
                {
                    elapsedTime += Time.deltaTime;
                    yield return null;
                    continue;
                }
                else
                {
                    if (!startFade)
                    {
                        if (variable == null)
                        {
                            EditorDebug.LogError("Bool変数がセットされていません");
                        }
                        booleanVariable.Apply( SetOperator.Assign, true);
                        startFade = true;
                    }
                    startFade = true;
                }

                if (booleanVariable.Value)
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

                                if (color.a > 1)
                                {
                                    color.a = 1;
                                    upDown = false;
                                }

                                image.color = color;
                            }

                            var text = gameObject.GetComponent<Text>();
                            if (text != null)
                            {
                                Color color = text.color;
                                color.a += changeValue;

                                if (color.a > 1)
                                {
                                    color.a = 1;
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

                                if (color.a < 0)
                                {
                                    color.a = 0;
                                    upDown = true;
                                }

                                image.color = color;
                            }

                            var text = gameObject.GetComponent<Text>();
                            if (text != null)
                            {
                                Color color = text.color;
                                color.a -= changeValue;

                                if (color.a < 0)
                                {
                                    color.a = 0;
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
            string summary = "待機時間：" + waitTime + ", フェード速度：" + changeValue + ", ターゲット変数：" + variable.Key + ", ターゲットUI：";
            foreach (var gameObject in uiList)
            {
                summary += gameObject.name + " ";
            }

            return summary;
        }
    }
}