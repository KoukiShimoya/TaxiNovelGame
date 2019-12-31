using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fungus
{
    public abstract class ChoiceCondition : Condition
    {
        [SerializeField]
        protected ChoiceData choiceData;

        protected override bool EvaluateCondition()
        {
            if (choiceData == null)
            {
                return false;
            }

            bool condition = false;

            ChoiceDataHolder choiceDataHolder = ChoiceDataHolder.Instance;

            foreach (var choiceData in choiceDataHolder.choiceDataList)
            {
                if (choiceData.key == this.choiceData.key)
                {
                    if (choiceData.choiceNumber == this.choiceData.choiceNumber)
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
            return (choiceData != null);
        }

        public override string GetSummary()
        {
            if (choiceData == null)
            {
                return "Error: No variable selected";
            }

            string summary = choiceData.key + " : " + choiceData.choiceNumber;

            return summary;
        }

        public override Color GetButtonColor()
        {
            return new Color32(253, 253, 150, 255);
        }
    }
}
