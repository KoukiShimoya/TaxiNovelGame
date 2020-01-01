using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ConstValues;

namespace IsGameSceneCheck
{
    public static class GameSceneCheck
    {
        public static bool Check()
        {
            if (SceneManager.GetActiveScene().name == SceneName.InitializeScene)
            {
                return false;
            }

            if (SceneManager.GetActiveScene().name == SceneName.StartScene)
            {
                return false;
            }

            return true;
        }
    }
}
