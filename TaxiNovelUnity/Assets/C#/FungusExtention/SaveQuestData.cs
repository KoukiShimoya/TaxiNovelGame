using UnityEngine;

namespace Fungus
{
    [CommandInfo("Save", 
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
            return new Color32(94, 200, 150, 255);
        }
        
        public override string GetSummary()
        {
            string summary = questKey.ToString();

            summary += " : " + variable;

            return summary;
        }
    }
}
