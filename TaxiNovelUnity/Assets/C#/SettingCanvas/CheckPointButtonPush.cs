using System.Collections;
using System.Collections.Generic;
using ConstValues;
using UnityEngine;

public class CheckPointButtonPush : MonoBehaviour
{
    [SerializeField] private QuestKey key;

    public void OnClick()
    {
        switch (key)
        {
            case QuestKey.JK:
                SceneChange.Instance.SceneChangeFunction(SceneName.JK_North_Scene);
                break;
            case QuestKey.Element:
                SceneChange.Instance.SceneChangeFunction(SceneName.Element_BeforeThugs_Scene);
                break;
            case QuestKey.OL:
                SceneChange.Instance.SceneChangeFunction(SceneName.OL_Central_Scene);
                break;
            case QuestKey.Thugs:
                SceneChange.Instance.SceneChangeFunction(SceneName.Thugs_Central_Scene);
                break;
            case QuestKey.Clerk:
                SceneChange.Instance.SceneChangeFunction(SceneName.Clerk_Bridge_Scene);
                break;
            case QuestKey.Worker:
                SceneChange.Instance.SceneChangeFunction(SceneName.Worker_South_Scene);
                break;
            default:
                EditorDebug.LogError("QuestKeyが設定されていません");
                break;
        }
    }
}
