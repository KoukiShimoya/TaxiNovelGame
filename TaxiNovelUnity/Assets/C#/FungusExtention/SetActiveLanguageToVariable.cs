using UnityEngine;

namespace Fungus
{
    [CommandInfo("Scripting", "Set Active Language To Variable", "StaticのActiveLanguageを変更する")]

    public class SetActiveLanguageToVariable : Command
    {
        [VariableProperty(typeof(StringVariable))] [SerializeField]
        protected StringVariable stringVariable;

        public override void OnEnter()
        {
            stringVariable.Value = NowActiveLanguage.GetSetLanguageCode.ToString();
            Continue();
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }
    }
    
}