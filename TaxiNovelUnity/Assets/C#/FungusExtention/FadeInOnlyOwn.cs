using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.UI;

namespace Fungus
{
    [CommandInfo("UI", "Fade In Only Own", "自身のオブジェクトのみフェードインアウトする")]
    public class FadeInOnlyOwn : Command
    {
        [Tooltip("フェード速度")] [SerializeField] protected float changeValue = 0.02f;

        [Tooltip("フェード目標値")] [SerializeField]
        protected float fadeTargetValue = 0f;

        [Tooltip("UI")] [SerializeField] protected GameObject gameObject;

        public override void OnEnter()
        {
            StartCoroutine(FadeAnimation());
            Continue();
        }

        private IEnumerator FadeAnimation()
        {
            bool upDown = true;

            var image = gameObject.GetComponent<Image>();
            if (image != null)
            {
                float nowAlpha = image.color.a;
                if (nowAlpha < fadeTargetValue)
                {
                    upDown = true;
                }
                else if (nowAlpha > fadeTargetValue)
                {
                    upDown = false;
                }
                else
                {
                    yield break;
                }
            }

            var text = gameObject.GetComponent<Text>();
            if (text != null)
            {
                float nowAlpha = text.color.a;
                if (nowAlpha < fadeTargetValue)
                {
                    upDown = true;
                }
                else if (nowAlpha > fadeTargetValue)
                {
                    upDown = false;
                }
                else
                {
                    yield break;
                }
            }

            while (true)
            {
                if (upDown)
                {
                    if (image != null)
                    {
                        Color color = image.color;
                        color.a += changeValue;

                        if (color.a > fadeTargetValue)
                        {
                            color.a = fadeTargetValue;
                            image.color = color;
                            yield break;
                        }

                        image.color = color;
                    }

                    if (text != null)
                    {
                        Color color = text.color;
                        color.a += changeValue;

                        if (color.a > fadeTargetValue)
                        {
                            color.a = fadeTargetValue;
                            text.color = color;
                            yield break;
                        }

                        text.color = color;
                    }
                }
                else
                {
                    if (image != null)
                    {
                        Color color = image.color;
                        color.a -= changeValue;

                        if (color.a < fadeTargetValue)
                        {
                            color.a = fadeTargetValue;
                            image.color = color;
                            yield break;
                        }

                        image.color = color;
                    }

                    if (text != null)
                    {
                        Color color = text.color;
                        color.a -= changeValue;

                        if (color.a < fadeTargetValue)
                        {
                            color.a = fadeTargetValue;
                            text.color = color;
                            yield break;
                        }

                        text.color = color;
                    }
                }

                yield return null;
            }
        }

        public override Color GetButtonColor()
        {
            return new Color32(180, 250, 250, 255);
        }


        public override string GetSummary()
        {
            string summary = "フェード速度：" + changeValue + ", フェード目標値：" + fadeTargetValue;
            if (gameObject != null)
            {
                summary += ", ターゲットUI：" + gameObject.name;
            }
            return summary;
        }
        
    }
}