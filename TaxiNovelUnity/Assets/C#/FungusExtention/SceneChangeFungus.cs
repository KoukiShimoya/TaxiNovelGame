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

        public override void OnEnter()
        {
            //function();
            Continue();
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }
        
        public override string GetSummary()
        {
            string summary = "";

            return summary;
        }
    }
}