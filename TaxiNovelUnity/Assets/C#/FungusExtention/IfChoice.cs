using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fungus
{
    [CommandInfo("Flow",
        "If Choice",
        "選択肢データからif分岐.")]
    [AddComponentMenu("")]
    public class IfChoice : ChoiceCondition
    {
        public override Color GetButtonColor()
        {
            return new Color32(253, 253, 150, 255);
        }
    }
}
