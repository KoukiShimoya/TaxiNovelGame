using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPointButtonInteractive : MonoBehaviour
{
    [SerializeField] private GameObject Button_JK;
    [SerializeField] private GameObject Button_Element;
    [SerializeField] private GameObject Button_OL;
    [SerializeField] private GameObject Button_Thugs;
    [SerializeField] private GameObject Button_Clerk;
    [SerializeField] private GameObject Button_Worker;
    
    private void Start()
    {
        List<QuestData> questDataList = QuestDataHolder.Instance.questDataList;

        foreach (var questData in questDataList)
        {
            if (questData.key == QuestKey.JK)
            {
                if (questData.progress == -1)
                {
                    Button_JK.transform.GetChild(0).GetComponent<UILanguageChange>().SetHiddenElement(true);
                    Button_JK.GetComponent<Button>().interactable = false;
                }
                else if (questData.progress == 0 || questData.progress == 1)
                {
                    Button_JK.transform.GetChild(0).GetComponent<UILanguageChange>().SetHiddenElement(false);
                    Button_JK.GetComponent<Button>().interactable = true;
                }
            }
            else if (questData.key == QuestKey.Element)
            {
                if (questData.progress == -1)
                {
                    Button_Element.transform.GetChild(0).GetComponent<UILanguageChange>().SetHiddenElement(true);
                    Button_Element.GetComponent<Button>().interactable = false;
                }
                else if (questData.progress == 0 || questData.progress == 1)
                {
                    Button_Element.transform.GetChild(0).GetComponent<UILanguageChange>().SetHiddenElement(false);
                    Button_Element.GetComponent<Button>().interactable = true;
                }
            }
            else if (questData.key == QuestKey.OL)
            {
                if (questData.progress == -1)
                {
                    Button_OL.transform.GetChild(0).GetComponent<UILanguageChange>().SetHiddenElement(true);
                    Button_OL.GetComponent<Button>().interactable = false;
                }
                else if (questData.progress == 0 || questData.progress == 1)
                {
                    Button_OL.transform.GetChild(0).GetComponent<UILanguageChange>().SetHiddenElement(false);
                    Button_OL.GetComponent<Button>().interactable = true;
                }
            }
            else if (questData.key == QuestKey.Thugs)
            {
                if (questData.progress == -1)
                {
                    Button_Thugs.transform.GetChild(0).GetComponent<UILanguageChange>().SetHiddenElement(true);
                    Button_Thugs.GetComponent<Button>().interactable = false;
                }
                else if (questData.progress == 0 || questData.progress == 1)
                {
                    Button_Thugs.transform.GetChild(0).GetComponent<UILanguageChange>().SetHiddenElement(false);
                    Button_Thugs.GetComponent<Button>().interactable = true;
                }
            }
            else if (questData.key == QuestKey.Clerk)
            {
                if (questData.progress == -1)
                {
                    Button_Clerk.transform.GetChild(0).GetComponent<UILanguageChange>().SetHiddenElement(true);
                    Button_Clerk.GetComponent<Button>().interactable = false;
                }
                else if (questData.progress == 0 || questData.progress == 1)
                {
                    Button_Clerk.transform.GetChild(0).GetComponent<UILanguageChange>().SetHiddenElement(false);
                    Button_Clerk.GetComponent<Button>().interactable = true;
                }
            }
            else if (questData.key == QuestKey.Worker)
            {
                if (questData.progress == -1)
                {
                    Button_Worker.transform.GetChild(0).GetComponent<UILanguageChange>().SetHiddenElement(true);
                    Button_Worker.GetComponent<Button>().interactable = false;
                }
                else if (questData.progress == 0 || questData.progress == 1)
                {
                    Button_Worker.transform.GetChild(0).GetComponent<UILanguageChange>().SetHiddenElement(false);
                    Button_Worker.GetComponent<Button>().interactable = true;
                }
            }
        }
    }
}
