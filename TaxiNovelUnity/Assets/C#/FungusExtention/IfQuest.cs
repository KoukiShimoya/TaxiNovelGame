using UnityEngine;

namespace Fungus
{
    [CommandInfo("Flow", 
        "If Quest", 
        "クエストデータからif分岐.")]
    [AddComponentMenu("")]
    public class IfQuest : QuestCondition
    {
        public override Color GetButtonColor()
        {
            return new Color32(253, 253, 150, 255);
        }
    }
}