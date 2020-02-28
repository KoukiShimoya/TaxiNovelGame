using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using ConstValues;

namespace Fungus
{
    [CommandInfo("Scripting", "Fade Middle Fungus", "Fungusでフェードインアウト")]
    public class FadeMiddleFungus : Command
    {
        [Tooltip("フェードタイプ")] [SerializeField] protected SceneChange.FadeType fadeType;

        [Tooltip("フェード切り替え率")] [SerializeField]
        protected float sceneChangeRate = 0.5f;
        
        [Tooltip("フェード時間")] [SerializeField] protected float fadeTime = 1f;

        public override void OnEnter()
        {
            SceneChange.Instance.FadeMiddleTexture(fadeType, sceneChangeRate, fadeTime);
            Continue();
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }
        
        public override string GetSummary()
        {
            string summary = "フェードタイプ : " + fadeType.ToString() + ", フェード切り替え率 : " + sceneChangeRate.ToString() + ", フェード時間 : " + fadeTime ;

            return summary;
        }
    }
}