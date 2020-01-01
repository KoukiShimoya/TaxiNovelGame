using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceDataHolder : SingletonMonoBehaviour<ChoiceDataHolder>
{
    [SerializeField] public List<ChoiceData> choiceDataList;

    private void Start()
    {
        choiceDataList = SaveLoadCsvFile.LoadChoiceData();
    }
}
