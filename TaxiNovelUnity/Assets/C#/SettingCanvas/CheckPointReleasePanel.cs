using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPointReleasePanel : MonoBehaviour
{
    [SerializeField] private Color32 defaultColor;
    [SerializeField] private Color32 pointerEnterColor;
    private Image image;
    private void Start()
    {
        image = this.gameObject.GetComponent<Image>();
        
        List<EndingData> endingDataList = EndingDataHolder.Instance.endingDataList;
        int achievedEndingType = 0;

        foreach (var endingData in endingDataList)
        {
            if (endingData.progress == 1)
            {
                achievedEndingType++;
            }
        }

        List<QuestData> questDataList = QuestDataHolder.Instance.questDataList;
        int achievedQuestDataType = 0;

        foreach (var questData in questDataList)
        {
            if (questData.progress == 0 || questData.progress == 1)
            {
                achievedQuestDataType++;
            }
        }

        if (achievedEndingType == 1 && achievedQuestDataType == 0)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public void OnClick()
    {
        this.gameObject.SetActive(false);
    }

    public void OnPointerEnter()
    {
        image.color = pointerEnterColor;
    }

    public void OnPointerExit()
    {
        image.color = defaultColor;
    }
}
