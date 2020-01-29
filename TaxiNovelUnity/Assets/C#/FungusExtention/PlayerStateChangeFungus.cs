using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using ConstValues;

namespace Fungus
{
    [CommandInfo("Scripting", "Player State Change Fungus", "Fungusで車のStateを切り替える")]
    public class PlayerStateChangeFungus : Command
    {
        [Tooltip("移行先のシーン名")] [SerializeField] protected PlayerState playerState;

        public override void OnEnter()
        {
            PlayerStateOwner.Instance.ChangePlayerState(playerState);

            GameObject minimapUI = Minimap.Instance.gameObject;
            EditorDebug.Log(minimapUI == null);
            
            if (playerState == PlayerState.Stopping)
            {
                minimapUI.SetActive(false);
            }
            else if (playerState == PlayerState.Driving)
            {
                minimapUI.SetActive(true);
            }
            
            Continue();
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }
        
        public override string GetSummary()
        {
            string summary = "PlayerState : " + playerState.ToString() ;

            return summary;
        }
    }
}