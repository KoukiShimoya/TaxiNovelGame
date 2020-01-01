using UnityEngine;

namespace Fungus
{
    [CommandInfo("Variable", 
                 "Save Choice Data", 
                 "選択肢を保存する")]
    [AddComponentMenu("")]
    public class SaveChoiceData : Command
    {
        [Tooltip("保存するキー名")]
        [SerializeField] protected ChoiceKey choiceKey;
        
        [Tooltip("保存する値")]
        [SerializeField] protected int variable;

        public override void OnEnter()
        {
            if (variable == null)
            {
                Continue();
                return;
            }
            
            SaveLoadCsvFile.SaveChoice(new ChoiceData(choiceKey, variable));
            
            Continue();
        }
        
        public override string GetSummary()
        {
            string summary = choiceKey.ToString();

            summary += " : " + variable;

            return summary;
        }
        
        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }
        
    }
}
