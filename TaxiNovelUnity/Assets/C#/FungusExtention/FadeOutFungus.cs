﻿using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using ConstValues;

namespace Fungus
{
    [CommandInfo("Scripting", "Fade Out Fungus", "Fungusでフェードアウト")]
    public class FadeOutFungus : Command
    {
        [Tooltip("フェードタイプ")] [SerializeField] protected SceneChange.FadeType fadeType;
        
        [Tooltip("フェード時間")] [SerializeField] protected float fadeTime = 1f;

        public override void OnEnter()
        {
            SceneChange.Instance.FadeOut(fadeType, fadeTime);
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