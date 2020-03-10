using JetBrains.Annotations;
using UnityEngine;
using Steamworks;

public class SaveSteamStats :SingletonMonoBehaviour<SaveSteamStats>
{

    private const string END1_Stats = "END1_Stats";
    private const string END6_Stats = "END6_Stats";
    private const string END6_3_Stats = "End6-3_Stats";
    private const string AnyEnd_Stats = "AnyEnd_Stats";
    
    private void Start() {
        if(SteamManager.Initialized) {
            string name = SteamFriends.GetPersonaName();
            EditorDebug.Log(SteamUtils.GetAppID());
        }
    }

    public void Save_End1()
    {
        bool isAchieved = false;
        SteamUserStats.GetAchievement(END1_Stats, out isAchieved);
        if (!isAchieved)
        {
            SteamUserStats.SetAchievement(END1_Stats);
        }
    }

    public void Save_End6()
    {
        bool isAchieved = false;
        SteamUserStats.GetAchievement(END6_Stats, out isAchieved);
        if (!isAchieved)
        {
            SteamUserStats.SetAchievement(END6_Stats);
        }
    }

    public void Save_END6_3()
    {
        bool isAchieved = false;
        SteamUserStats.GetAchievement(END6_3_Stats, out isAchieved);
        if (!isAchieved)
        {
            SteamUserStats.SetAchievement(END6_3_Stats);
        }
    }

    public void Save_AnyEnd()
    {
        bool isAchieved = false;
        SteamUserStats.GetAchievement(AnyEnd_Stats, out isAchieved);
        if (!isAchieved)
        {
            SteamUserStats.SetAchievement(AnyEnd_Stats);
        }
    }
}