using UnityEngine;

namespace Fungus
{
    [CommandInfo("Steam", 
        "Save Steam Stats Fungus", 
        "Steamの実績を解除する")]
    [AddComponentMenu("")]
    public class SaveSteamStatsFungus : Command
    {
        [Tooltip("実績の種類")] [SerializeField] private StatsType statsType;

        public override void OnEnter()
        {
            SaveSteamStats saveSteamStats = SaveSteamStats.Instance;

            switch (statsType)
            {
                case StatsType.End1:
                    saveSteamStats.Save_End1();
                    break;
                case StatsType.End6:
                    saveSteamStats.Save_End6();
                    break;
                case StatsType.End6_3:
                    saveSteamStats.Save_END6_3();
                    break;
                case StatsType.AnyEnd:
                    saveSteamStats.Save_AnyEnd();
                    break;
                default:
                    break;
            }

            Continue();
        }

        public override Color GetButtonColor()
        {
            return new Color32(190,140, 245, 255);
        }
        
        public override string GetSummary()
        {
            string summary = statsType.ToString() +"の実績を解除する";

            return summary;
        }

        private enum StatsType
        {
            End1,
            End6,
            End6_3,
            AnyEnd
        }
    }
}