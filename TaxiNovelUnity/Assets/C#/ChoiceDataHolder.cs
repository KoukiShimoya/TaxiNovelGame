using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceDataHolder : SingletonMonoBehaviour<ChoiceDataHolder>
{
    public List<ChoiceData> choiceDataList;

    private void Start()
    {
        choiceDataList = SaveLoadCsvFile.LoadChoiceData();
    }
}

[System.Serializable]
public class ChoiceData
{
    public ChoiceKey key;
    public int choiceNumber;

    public ChoiceData(ChoiceKey key, int choiceNumber)
    {
        this.key = key;
        this.choiceNumber = choiceNumber;
    }
}

[System.Serializable]
public enum ChoiceKey
{
    None,
    Something_Book,
    NoMeetThugs_MeetThugs,
    Letter_Courage,
    JapaneseSweets_Cake,
    TastyCandy_SaveCandy,
    Cute_LowRisk
}