using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDataHolder : SingletonMonoBehaviour<QuestDataHolder>
{
    [SerializeField] public List<QuestData> questDataList;

    private void Start()
    {
        questDataList = SaveLoadCsvFile.LoadQuestData();
    }
}
