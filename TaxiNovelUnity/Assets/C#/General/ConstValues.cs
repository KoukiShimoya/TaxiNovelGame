using UnityEngine;

namespace ConstValues
{
    public struct General
    {
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

    public enum SceneName
    {
        GameScene,
        StartScene,
        InitializeScene,
        TutorialScene,
        JK_North_Scene,
        JK_Bridge_Scene,
        JK_Central_Scene,
        Element_BeforeThugs_Scene,
        Element_Bridge_Scene,
        Element_East_Scene,
        Element_AfterThugs_Scene,
        OL_Central_Scene,
        OL_Bridge_Scene,
        OL_East_Scene,
        Thugs_Central_Scene,
        Thugs_Bridge_Scene,
        Clerk_Central_Scene,
        Ending_1
    }

    public struct TagName
    {
        public const string Car = "Car";
        public const string Signal = "Signal";
        public const string Player = "Player";
    }

    public class PathData
    {
        public static string ResourcesPath = MultiPathCombine.Combine(Application.dataPath ,General.Resources);
        public static string TextDataPath = Application.dataPath;
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
            public const string ChoiceData = "ChoiceData";
            public const string QuestData = "QuestData";
        }
    }

}