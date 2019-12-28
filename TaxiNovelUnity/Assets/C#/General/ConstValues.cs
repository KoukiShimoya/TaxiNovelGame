﻿using UnityEngine;

namespace ConstValues
{
    public struct General
    {
        public const string EncodingType = "UTF-8";
        public const string csv = ".csv";
        public const int cameraZ = -1;
        public const char crlf = '\n';
        public const char comma = ',';
        public const string Resources = "Resources";
    }

    public struct CharaName
    {
        //public const string Ally = "Ally";
    }

    public struct ObjectName
    {
        public const string DDOLRoot = "DDOLRoot";
    }

    public struct SceneName
    {
        public const string GameScene = "GameScene";
        public const string StartScene = "StartScene";
        public const string InitializeScene = "InitializeScene";
    }

    public struct TagName
    {
        public const string Car = "Car";
        public const string Signal = "Signal";
        public const string Player = "Player";
    }

    public class Path
    {
        public static string ResourcesPath = MultiPathCombine.Combine(Application.dataPath, General.Resources);
        public static string PluginsPath = MultiPathCombine.Combine(Application.dataPath, "Plugins");

        public struct ResourcesFolder
        {
            public const string DontDestroyOnLoad = "DontDestroyOnLoad";
            public const string TextData = "TextData";
        }

        /*public struct PluginsFolder
        {
            public const string Fade = "Fade";
        }*/

        public struct TextFolder
        {
            public const string PlayTime = "PlayTime";
        }
    }

}