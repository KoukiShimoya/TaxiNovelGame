// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

 using UnityEngine;
using UnityEngine.Serialization;

namespace Fungus
{
    /// <summary>
    /// Set the active language for the scene. A Localization object with a localization file must be present in the scene.
    /// </summary>
    [CommandInfo("Narrative", 
                 "Set Language", 
                 "Set the active language for the scene. A Localization object with a localization file must be present in the scene.")]
    [AddComponentMenu("")]
    [ExecuteInEditMode]
    public class SetLanguage : Command
    {
        [Tooltip("Code of the language to set. e.g. ES, DE, JA")]
        [SerializeField] protected NowActiveLanguage.LanguageCode languageCode; 

        #region Public members

        public static string mostRecentLanguage = "";

        public override void OnEnter()
        {
            Localization localization = GameObject.FindObjectOfType<Localization>();
            if (localization != null)
            {
                localization.SetActiveLanguage(languageCode.ToString(), true);

                // Cache the most recently set language code so we can continue to 
                // use the same language in subsequent scenes.
                mostRecentLanguage = languageCode.ToString();
            }

            Continue();
        }

        public override string GetSummary()
        {
            return languageCode.ToString();
        }

        public override Color GetButtonColor()
        {
            return new Color32(184, 210, 235, 255);
        }

        #endregion
    }
}