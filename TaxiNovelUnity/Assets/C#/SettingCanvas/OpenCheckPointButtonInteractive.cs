using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCheckPointButtonInteractive : MonoBehaviour
{
    [SerializeField] private string noAchieveAnyEnd;
    [SerializeField] private string achieveAnyEnd_JA;
    [SerializeField] private string achieveAnyEnd_EN;
    [SerializeField] private GameObject buttonTextObject;
    
    private void Start()
    {
        List<EndingData> endingDataList = EndingDataHolder.Instance.endingDataList;

        bool achieveAnyEnd = false;
        
        foreach (var endingData in endingDataList)
        {
            if (endingData.progress == 1)
            {
                achieveAnyEnd = true;
                break;
            }
        }

        if (achieveAnyEnd)
        {
            buttonTextObject.GetComponent<UILanguageChange>().ChangeText(achieveAnyEnd_JA, achieveAnyEnd_EN);
            this.gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            buttonTextObject.GetComponent<UILanguageChange>().ChangeText(noAchieveAnyEnd, noAchieveAnyEnd);
            this.gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
