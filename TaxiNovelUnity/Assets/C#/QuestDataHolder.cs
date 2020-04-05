using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDataHolder : SingletonMonoBehaviour<QuestDataHolder>
{
    public List<QuestData> questDataList;

    private void Start()
    {
        questDataList = SaveLoadCsvFile.LoadQuestData();
    }
}

[System.Serializable]
public class QuestData
{
    public QuestKey key;
    public int progress;

    public QuestData(QuestKey key, int progress)
    {
        this.key = key;
        this.progress = progress;
    }
}

[System.Serializable]
public enum QuestKey
{
    None,
    JK,
    Elementary,
    OL,
    Thugs,
    Clerk,
    Worker
}