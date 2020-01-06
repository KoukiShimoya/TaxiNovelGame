using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using ConstValues;

namespace Fungus
{
    [CommandInfo("Scripting", "Scene Change Fungus", "Fungusでシーンを切り替える")]
    public class SceneChangeFungus : Command
    {
        [Tooltip("移行先のシーン名")] [SerializeField] protected SceneName nextScene;
        [Tooltip("フェードタイプ")] [SerializeField] protected SceneChange.FadeType fadeType;
        [Tooltip("フェード時間")] [SerializeField] protected float fadeTime = 1f;

        public override void OnEnter()
        {
            SceneChange.Instance.FadeTextureAndSceneChange(fadeType, nextScene, fadeTime);
            Continue();
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }
        
        public override string GetSummary()
        {
            string summary = "フェードタイプ : " + fadeType.ToString() + ", シーン名 : " + nextScene.ToString() + ", フェード時間 : " + fadeTime ;

            return summary;
        }
    }
}