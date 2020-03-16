using UnityEngine;

namespace Fungus
{
    [CommandInfo("Scripting", "Active Language Initialize By Load", "StaticのActiveLanguageを変更する")]

    public class ActiveLanguageInitializeByLoad : Command
    {

        public override void OnEnter()
        {
            NowActiveLanguage.LanguageCode code = NowActiveLanguage.GetSetLanguageCode;
            
            Localization localization = GameObject.FindObjectOfType<Localization>();
            if (localization != null)
            {
                localization.SetActiveLanguage(code.ToString(), true);
            }

            Continue();
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }
    }
    
}