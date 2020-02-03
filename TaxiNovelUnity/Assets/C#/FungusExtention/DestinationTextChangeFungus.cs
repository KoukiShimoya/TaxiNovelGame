using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using ConstValues;

namespace Fungus
{
    [CommandInfo("Scripting", "Destination Text Change Fungus", "Fungusで目的地UIの名称を切り替える")]
    public class DestinationTextChangeFungus : Command
    {
        [Tooltip("日本語名")] [SerializeField] protected string JP;
        [Tooltip("英語名")] [SerializeField] protected string EN;

        public override void OnEnter()
        {
            DestinationTextObject.Instance.ChangeDestinationText(JP, EN);
            
            Continue();
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }
        
        public override string GetSummary()
        {
            string summary = "目的地 : " + JP + ", " + EN;

            return summary;
        }
    }
}