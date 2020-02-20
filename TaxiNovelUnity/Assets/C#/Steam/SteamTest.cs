using UnityEngine;
using Steamworks;

public class SteamTest : MonoBehaviour {
    void Start() {
        if(SteamManager.Initialized) {
            string name = SteamFriends.GetPersonaName();
            EditorDebug.Log(SteamUtils.GetAppID());
        }
    }
}