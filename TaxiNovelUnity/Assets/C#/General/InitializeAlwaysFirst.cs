using ConstValues;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class InitializeAlwaysFirst
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void RuntimeInitialize()
    {
        EditorDebug.Log("Accurate. Runtime Initialize.");
        SceneManager.LoadScene(SceneName.InitializeScene);
    }
}