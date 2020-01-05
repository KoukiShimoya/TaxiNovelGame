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
        [SerializeField] protected QuestKey questKey;
        
        [Tooltip("保存する値")]
        [SerializeField] protected int variable;

        public override void OnEnter()
        {
            if (variable == null)
            {
                Continue();
                return;
            }

            SaveLoadCsvFile.SaveQuest(new QuestData(questKey, variable));
            
            Continue();
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }
        
        public override string GetSummary()
        {
            string summary = questKey.ToString();

            summary += " : " + variable;

            return summary;
        }
    }
}
