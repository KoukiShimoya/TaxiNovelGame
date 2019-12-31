using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

namespace Fungus
{
    [CommandInfo("Scripting", "Set Active Language", "StaticなActiveLanguageを変更する")]
    public class SetActiveLanguage : Fungus.Command
    {
        [SerializeField] private NowActiveLanguage.LanguageCode languageCode;

        public override void OnEnter()
        {
            NowActiveLanguage.GetSetLanguageCode = languageCode;
            Continue();
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }
    }
}
