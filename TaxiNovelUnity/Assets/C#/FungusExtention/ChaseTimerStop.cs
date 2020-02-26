using UnityEngine;
using UnityEngine.Serialization;
using System.Collections.Generic;

namespace Fungus
{
    /// <summary>
    /// Displays a timer bar and executes a target block if the player fails to select a menu option in time.
    /// </summary>
    [CommandInfo("Narrative", 
                 "Chase Timer Stop", 
                 "タイマーを止める.")]
    [AddComponentMenu("")]
    [ExecuteInEditMode]
    public class ChaseTimerStop : Command
    {
        [Tooltip("MenuDialog_Timer")] [SerializeField]
        protected GameObject menuDialog_Timer;
        public override void OnEnter()
        {
            var menuDialog = menuDialog_Timer.GetComponent<MenuDialog>();
            menuDialog.StopAllCoroutines();

            Continue();
        }
        public override string GetSummary()
        {
            return "Chase Timer Stop";
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }
    }
}