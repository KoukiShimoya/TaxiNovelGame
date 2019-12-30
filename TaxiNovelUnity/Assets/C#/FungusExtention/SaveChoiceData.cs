// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

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
        [SerializeField] protected string key = "";
        
        [Tooltip("保存する値")]
        [VariableProperty(typeof(IntegerVariable))]
        [SerializeField] protected Variable variable;

        #region Public members

        public override void OnEnter()
        {
            if (key == "" ||
                variable == null)
            {
                Continue();
                return;
            }
            
            var flowchart = GetFlowchart();
            
            // Prepend the current save profile (if any)
            string prefsKey = SetSaveProfile.SaveProfile + "_" + flowchart.SubstituteVariables(key);
            
            System.Type variableType = variable.GetType();

            if (variableType == typeof(IntegerVariable))
            {
                IntegerVariable integerVariable = variable as IntegerVariable;
                if (integerVariable != null)
                {
                    SaveLoadCsvFile.SaveChoice(new ChoiceData(key, integerVariable.Value));
                }
            }
            
            Continue();
        }
        
        public override string GetSummary()
        {
            if (key.Length == 0)
            {
                return "Error: No stored value key selected";
            }
            
            if (variable == null)
            {
                return "Error: No variable selected";
            }
            
            return variable.Key + " into '" + key + "'";
        }
        
        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }

        public override bool HasReference(Variable in_variable)
        {
            return this.variable == in_variable || base.HasReference(in_variable);
        }

        #endregion
        #region Editor caches
#if UNITY_EDITOR
        protected override void RefreshVariableCache()
        {
            base.RefreshVariableCache();

            var f = GetFlowchart();

            f.DetermineSubstituteVariables(key, referencedVariables);
        }
#endif
        #endregion Editor caches
    }
}
