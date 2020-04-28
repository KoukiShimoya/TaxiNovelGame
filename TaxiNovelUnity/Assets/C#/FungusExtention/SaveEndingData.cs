using UnityEngine;

namespace Fungus
{
    [CommandInfo("Save", 
        "Save Ending Data", 
        "エンディングのクリア状況を保存する")]
    [AddComponentMenu("")]
    public class SaveEndingData : Command
    {
        [Tooltip("保存するキー名")]
        [SerializeField] protected EndingKey endingKey;
        
        [Tooltip("保存する値")]
        [SerializeField] protected int variable;

        public override void OnEnter()
        {
            if (variable == null)
            {
                Continue();
                return;
            }

            SaveLoadCsvFile.SaveEnding(new EndingData(endingKey, variable));
            
            Continue();
        }

        public override Color GetButtonColor()
        {
            return new Color32(94, 200, 150, 255);
        }
        
        public override string GetSummary()
        {
            string summary = endingKey.ToString();

            summary += " : " + variable;

            return summary;
        }
    }
}