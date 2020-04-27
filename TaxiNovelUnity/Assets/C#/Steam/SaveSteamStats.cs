using JetBrains.Annotations;
using UnityEngine;
using Steamworks;

public class SaveSteamStats :SingletonMonoBehaviour<SaveSteamStats>
{

    private const string END1_Stats = "END1_Stats";
    private const string END2_Stats = "END2_Stats";
    private const string END3_Stats = "END3_Stats";
    private const string END4_Stats = "END4_Stats";
    private const string END5_Stats = "END5_Stats";
    private const string END6_1_Stats = "END6-1_Stats";
    private const string END6_2_Stats = "END6-2_Stats";
    private const string END6_3_Stats = "End6-3_Stats";
    private const string AllEnd_Stats = "AllEnd_Stats";
    
    private void Start() {
        
        if (SteamManager.Initialized) 
        {
            string name = SteamFriends.GetPersonaName();
            EditorDebug.Log(SteamUtils.GetAppID());
            
            //実績をリセットする場合は、下の二行をアクティブにする
            //SteamUserStats.ResetAllStats(true);
            //SteamUserStats.RequestCurrentStats();
            bool end1Achieved = false;
            bool end2Achieved = false;
            bool end3Achieved = false;
            bool end4Achieved = false;
            bool end5Achieved = false;
            bool end6_1Achieved = false;
            bool end6_2Achieved = false;
            bool end6_3Achieved = false;
            bool allEndAchieved = false;
            
            SteamUserStats.GetAchievement(END1_Stats, out end1Achieved);
            SteamUserStats.GetAchievement(END2_Stats, out end2Achieved);
            SteamUserStats.GetAchievement(END3_Stats, out end3Achieved);
            SteamUserStats.GetAchievement(END4_Stats, out end4Achieved);
            SteamUserStats.GetAchievement(END5_Stats, out end5Achieved);
            SteamUserStats.GetAchievement(END6_1_Stats, out end6_1Achieved);
            SteamUserStats.GetAchievement(END6_2_Stats, out end6_2Achieved);
            SteamUserStats.GetAchievement(END6_3_Stats, out end6_3Achieved);
            SteamUserStats.GetAchievement(AllEnd_Stats, out allEndAchieved);
            EditorDebug.Log("End1 : " + end1Achieved + ", End2 : " + end2Achieved + ", End3 : " + end3Achieved +
                            ", End4 : " + end4Achieved + ", End5 : " + end5Achieved + ", End6_1 : " + end6_1Achieved +
                            "End6_2 : " + end6_2Achieved + ", End6_3 : " + end6_3Achieved +
                            ", AllEnd : " + allEndAchieved);
        }
        
    }

    public void Save_End1()
    {
        bool isAchieved = false;
        SteamUserStats.GetAchievement(END1_Stats, out isAchieved);
        if (!isAchieved)
        {
            EditorDebug.Log("End1実績を解放");
            SteamUserStats.SetAchievement(END1_Stats);
        }
    }

    public void Save_End2()
    {
        bool isAchieved = false;
        SteamUserStats.GetAchievement(END2_Stats, out isAchieved);
        if (!isAchieved)
        {
            EditorDebug.Log("End2実績を解放");
            SteamUserStats.SetAchievement(END2_Stats);
        }
    }
    
    public void Save_End3()
    {
        bool isAchieved = false;
        SteamUserStats.GetAchievement(END3_Stats, out isAchieved);
        if (!isAchieved)
        {
            EditorDebug.Log("End3実績を解放");
            SteamUserStats.SetAchievement(END3_Stats);
        }
    }
    
    public void Save_End4()
    {
        bool isAchieved = false;
        SteamUserStats.GetAchievement(END4_Stats, out isAchieved);
        if (!isAchieved)
        {
            EditorDebug.Log("End4実績を解放");
            SteamUserStats.SetAchievement(END4_Stats);
        }
    }
    
    public void Save_End5()
    {
        bool isAchieved = false;
        SteamUserStats.GetAchievement(END5_Stats, out isAchieved);
        if (!isAchieved)
        {
            EditorDebug.Log("End5実績を解放");
            SteamUserStats.SetAchievement(END5_Stats);
        }
    }

    public void Save_End6_1()
    {
        bool isAchieved = false;
        SteamUserStats.GetAchievement(END6_1_Stats, out isAchieved);
        if (!isAchieved)
        {
            EditorDebug.Log("End6-1実績を解放");
            SteamUserStats.SetAchievement(END6_1_Stats);
        }
    }
    
    public void Save_End6_2()
    {
        bool isAchieved = false;
        SteamUserStats.GetAchievement(END6_2_Stats, out isAchieved);
        if (!isAchieved)
        {
            EditorDebug.Log("End6-2実績を解放");
            SteamUserStats.SetAchievement(END6_2_Stats);
        }
    }

    public void Save_END6_3()
    {
        bool isAchieved = false;
        SteamUserStats.GetAchievement(END6_3_Stats, out isAchieved);
        if (!isAchieved)
        {
            EditorDebug.Log("End6_3実績を解放");
            SteamUserStats.SetAchievement(END6_3_Stats);
        }
    }

    public void Save_AllEnd()
    {
        bool isAchieved = false;
        SteamUserStats.GetAchievement(AllEnd_Stats, out isAchieved);
        if (!isAchieved)
        {
            EditorDebug.Log("AllEnd実績を解放");
            SteamUserStats.SetAchievement(AllEnd_Stats);
        }
    }
}