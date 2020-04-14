using UnityEngine;
using System.Collections.Generic;

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
                case StatsType.End2:
                    saveSteamStats.Save_End2();
                    break;
                case StatsType.End3:
                    saveSteamStats.Save_End3();
                    break;
                case StatsType.End4:
                    saveSteamStats.Save_End4();
                    break;
                case StatsType.End5:
                    saveSteamStats.Save_End5();
                    break;
                case StatsType.End6_1:
                    saveSteamStats.Save_End6_1();
                    break;
                case StatsType.End6_2:
                    saveSteamStats.Save_End6_2();
                    break;
                case StatsType.End6_3:
                    saveSteamStats.Save_END6_3();
                    break;
                case StatsType.AllEnd:
                    List<EndingData> endingDataList = EndingDataHolder.Instance.endingDataList;
                    bool isAllEndingCompleted = true;
                    
                    foreach (var endingData in endingDataList)
                    {
                        if (endingData.progress == -1)
                        {
                            isAllEndingCompleted = false;
                            break;
                        }
                    }

                    if (isAllEndingCompleted)
                    {
                        saveSteamStats.Save_AllEnd();
                    }

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
            End2,
            End3,
            End4,
            End5,
            End6_1,
            End6_2,
            End6_3,
            AllEnd
        }
    }
}