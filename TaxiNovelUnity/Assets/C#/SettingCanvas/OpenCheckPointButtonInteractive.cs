using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCheckPointButtonInteractive : MonoBehaviour
{
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
            buttonTextObject.GetComponent<UILanguageChange>().SetHiddenElement(false);
            this.gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            buttonTextObject.GetComponent<UILanguageChange>().SetHiddenElement(true);
            this.gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
