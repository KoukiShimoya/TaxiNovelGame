using UnityEngine;

namespace Fungus
{
    [CommandInfo("Variable", 
                 "Save Quest Data", 
                 "クエストのクリア状況を保存する")]
    [AddComponentMenu("")]
    public class SaveQuestData : Command
    {
        [Tooltip("保存するキー名")]
        [SerializeField] protected string key = "";
        
        [Tooltip("保存する値")]
        [SerializeField] protected bool variable;

        public override void OnEnter()
        {
            if (key == "" ||
                variable == null)
            {
                Continue();
                return;
            }

            SaveLoadCsvFile.SaveQuest(new QuestData(key, variable));
            
            Continue();
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }
        
        public override string GetSummary()
        {
            string summary = "";

            if (key == null)
            {
                summary = "<None>";
            }
            else
            {
                summary = key;
            }

            summary += " : " + variable;

            return summary;
        }
    }
}
