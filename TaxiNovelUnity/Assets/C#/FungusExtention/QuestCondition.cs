using UnityEngine;
using System.Collections.Generic;

namespace Fungus
{
    public abstract class QuestCondition : Condition
    {
        [SerializeField]
        protected QuestData questData;
        
        protected override bool EvaluateCondition()
        {
            if (questData == null)
            {
                return false;
            }

            bool condition = false;

            QuestDataHolder questDataHolder = QuestDataHolder.Instance;

            foreach (var questData in questDataHolder.questDataList)
            {
                if (questData.key == this.questData.key)
                {
                    if (questData.progress == this.questData.progress)
                    {
                        condition = true;
                    }
                    else
                    {
                        condition = false;
                    }

                    break;
                }
            }

            return condition;
        }
        
        protected override bool HasNeededProperties()
        {
            return (questData != null);
        }
        
        public override string GetSummary()
        {
            if (questData == null)
            {
                return "Error: No variable selected";
            }
            
            string summary = questData.key + " : " + questData.progress;

            return summary;
        }

        public override Color GetButtonColor()
        {
            return new Color32(253, 253, 150, 255);
        }
    }
}
