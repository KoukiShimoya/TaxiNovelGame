using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Fungus;
using UnityEngine;
using ConstValues;
using UnityEngine.Experimental.XR;

namespace Fungus
{
    [CommandInfo("Scripting", "General Car State Change Fungus", "Fungusで一般車全てのStateを切り替える")]
    public class GeneralCarStateChange : Command
    {
        [Tooltip("移行先のState")] [SerializeField] protected GeneralCarState changeState;

        public override void OnEnter()
        {
            var gameObjects = Resources.FindObjectsOfTypeAll(typeof(GameObject))
                .Select(c => c as GameObject)
                .Where(c => c.hideFlags != HideFlags.NotEditable && c.hideFlags != HideFlags.HideAndDontSave);
            
            foreach(var item in gameObjects)
            {
                if (item.HasComponent<GeneralCarStateHolder>())
                {
                    GeneralCarStateHolder generalCarStateHolder = item.GetComponent<GeneralCarStateHolder>();
                    generalCarStateHolder.generalCarState = changeState;
                }
            }
            
            Continue();
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }
        
        public override string GetSummary()
        {
            string summary = "GeneralCarState : " + changeState.ToString() ;

            return summary;
        }
    }
}