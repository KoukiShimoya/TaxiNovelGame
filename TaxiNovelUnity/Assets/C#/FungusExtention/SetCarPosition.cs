using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using ConstValues;

namespace Fungus
{
    [CommandInfo("Scripting", "Set Car Position", "タクシーの位置を指定座標にする")]
    public class SetCarPosition : Command
    {
        [Tooltip("移動場所")] [SerializeField] protected Vector2 position;

        public override void OnEnter()
        {
            PlayerStateOwner.Instance.gameObject.transform.position = position;
            
            Continue();
        }

        public override Color GetButtonColor()
        {
            return new Color32(235, 191, 217, 255);
        }
        
        public override string GetSummary()
        {
            string summary = "X : " + position.x.ToString() + ", Y : " + position.y.ToString() ;

            return summary;
        }
    }
}