using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using ConstValues;

namespace Fungus
{
    [CommandInfo("Scripting", "Fade In Fungus", "Fungusでフェードイン")]
    public class FadeInFungus : Command
    {
        [Tooltip("フェードタイプ")] [SerializeField] protected SceneChange.FadeType fadeType;
        
        [Tooltip("フェード時間")] [SerializeField] protected float fadeTime = 1f;
        
        [Tooltip("フェードインの始点")] [SerializeField] protected float fadeStartPosition = 1f;
        
        [Tooltip("フェードインの終点")] [SerializeField] protected float fadeFinishPosition = 0f;
        
        

        public override void OnEnter()
        {
            SceneChange.Instance.FadeIn(fadeType, fadeTime, fadeStartPosition, fadeFinishPosition);
            Continue();
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }
        
        public override string GetSummary()
        {
            string summary = "フェードタイプ : " + fadeType.ToString() + ", フェード時間 : " + fadeTime ;

            return summary;
        }
    }
}