using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ConstValues;
using ConstValues;

public class StartSceneToGameScene : MonoBehaviour
{
    public void SceneChangeToGameScene()
    {
        List<QuestData> questDataList = QuestDataHolder.Instance.questDataList;

        //JK
        foreach (var questData in questDataList)
        {
            if (questData.key == QuestKey.JK)
            {
                if (questData.progress == -1 || questData.progress == 0)
                {
                    SceneChange.Instance.SceneChangeFunction(SceneName.JK_North_Scene);
                    return;
                }
            }
        }

        //小学生
        foreach (var questData in questDataList)
        {
            if (questData.key == QuestKey.Element)
            {
                if (questData.progress == -1 || questData.progress == 0)
                {
                    SceneChange.Instance.SceneChangeFunction(SceneName.Element_BeforeThugs_Scene);
                    return;
                }
            }
        }

        //OL
        foreach (var questData in questDataList)
        {
            if (questData.key == QuestKey.OL)
            {
                if (questData.progress == -1 || questData.progress == 0)
                {
                    SceneChange.Instance.SceneChangeFunction(SceneName.OL_Central_Scene);
                    return;
                }
            }
        }
        
        //チンピラ
        foreach (var questData in questDataList)
        {
            if (questData.key == QuestKey.Thugs)
            {
                if (questData.progress == -1 || questData.progress == 0)
                {
                    List<ChoiceData> choiceDataList = ChoiceDataHolder.Instance.choiceDataList;
                    foreach (var choiceData in choiceDataList)
                    {
                        if (choiceData.key == ChoiceKey.NoMeetThugs_MeetThugs)
                        {
                            if (choiceData.choiceNumber == 1)
                            {
                                SceneChange.Instance.SceneChangeFunction(SceneName.Thugs_Central_Scene);
                                return;
                            }
                        }
                    }
                }
            }
        }
        
        //店員
        foreach (var questData in questDataList)
        {
            if (questData.key == QuestKey.Clerk)
            {
                if (questData.progress == -1 || questData.progress == 0)
                {
                    SceneChange.Instance.SceneChangeFunction(SceneName.Clerk_Central_Scene);
                    return;
                }
            }
        }
        
        //リーマン
        foreach (var questData in questDataList)
        {
            if (questData.key == QuestKey.Worker)
            {
                if (questData.progress == -1 || questData.progress == 0)
                {
                    SceneChange.Instance.SceneChangeFunction(SceneName.Worker_South_Scene);
                    return;
                }
            }
        }
    }
}