using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingDataHolder : SingletonMonoBehaviour<EndingDataHolder>
{
    public List<EndingData> endingDataList;

    private void Start()
    {
        endingDataList = SaveLoadCsvFile.LoadEndingData();
    }
}

[System.Serializable]
public class EndingData
{
    public EndingKey key;
    public int progress;

    public EndingData(EndingKey key, int progress)
    {
        this.key = key;
        this.progress = progress;
    }
}

[System.Serializable]
public enum EndingKey
{
    Ending_1,
    Ending_2,
    Ending_3,
    Ending_4,
    Ending_5,
    Ending_6_1,
    Ending_6_2,
    Ending_6_3
}