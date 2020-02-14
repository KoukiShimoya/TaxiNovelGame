using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using ConstValues;

namespace Fungusf
{
    [CommandInfo("Scripting", "Scene Change Fungus", "Fungusでシーンを切り替える")]
    public class SceneChangeFungus : Command
    {
        [Tooltip("移行先のシーン名")] [SerializeField] protected SceneName nextScene;

        public override void OnEnter()
        {
            SceneChange.Instance.SceneChangeFunction(nextScene);
            Continue();
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }
        
        public override string GetSummary()
        {
            string summary = "シーン名 : " + nextScene.ToString();

            return summary;
        }
    }
}