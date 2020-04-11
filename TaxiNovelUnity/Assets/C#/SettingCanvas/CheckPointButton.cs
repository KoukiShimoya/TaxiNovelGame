using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ConstValues;

public class CheckPointButton : MonoBehaviour
{
    [SerializeField] private GameObject button_JK;
    [SerializeField] private GameObject button_Element;
    [SerializeField] private GameObject button_OL;
    [SerializeField] private GameObject button_Thugs;
    [SerializeField] private GameObject button_Clerk;
    [SerializeField] private GameObject button_Worker;

    [SerializeField] private Sprite sprite_JK;
    [SerializeField] private Sprite sprite_JK_hidden;
    [SerializeField] private Sprite sprite_Element;
    [SerializeField] private Sprite sprite_Element_hidden;
    [SerializeField] private Sprite sprite_OL;
    [SerializeField] private Sprite sprite_OL_hidden;
    [SerializeField] private Sprite sprite_Thugs;
    [SerializeField] private Sprite sprite_Thugs_hidden;
    [SerializeField] private Sprite sprite_Clerk;
    [SerializeField] private Sprite sprite_Clerk_hidden;
    [SerializeField] private Sprite sprite_Worker;
    [SerializeField] private Sprite sprite_Worker_hidden;

    [SerializeField] private Image checkPointCharaImage;
    
    private void Start()
    {
        if (IsCheckPointAchieved(QuestKey.JK))
        {
            button_JK.transform.GetChild(0).GetComponent<UILanguageChange>().SetHiddenElement(false);
            button_JK.GetComponent<Button>().interactable = true;
        }
        else
        {
            button_JK.transform.GetChild(0).GetComponent<UILanguageChange>().SetHiddenElement(true);
            button_JK.GetComponent<Button>().interactable = false;
        }
        
        if (IsCheckPointAchieved(QuestKey.Element))
        {
            button_Element.transform.GetChild(0).GetComponent<UILanguageChange>().SetHiddenElement(false);
            button_Element.GetComponent<Button>().interactable = true;
        }
        else
        {
            button_Element.transform.GetChild(0).GetComponent<UILanguageChange>().SetHiddenElement(true);
            button_Element.GetComponent<Button>().interactable = false;
        }
        
        if (IsCheckPointAchieved(QuestKey.OL))
        {
            button_OL.transform.GetChild(0).GetComponent<UILanguageChange>().SetHiddenElement(false);
            button_OL.GetComponent<Button>().interactable = true;
        }
        else
        {
            button_OL.transform.GetChild(0).GetComponent<UILanguageChange>().SetHiddenElement(true);
            button_OL.GetComponent<Button>().interactable = false;
        }
        
        if (IsCheckPointAchieved(QuestKey.Thugs))
        {
            button_Thugs.transform.GetChild(0).GetComponent<UILanguageChange>().SetHiddenElement(false);
            button_Thugs.GetComponent<Button>().interactable = true;
        }
        else
        {
            button_Thugs.transform.GetChild(0).GetComponent<UILanguageChange>().SetHiddenElement(true);
            button_Thugs.GetComponent<Button>().interactable = false;
        }
        
        if (IsCheckPointAchieved(QuestKey.Clerk))
        {
            button_Clerk.transform.GetChild(0).GetComponent<UILanguageChange>().SetHiddenElement(false);
            button_Clerk.GetComponent<Button>().interactable = true;
        }
        else
        {
            button_Clerk.transform.GetChild(0).GetComponent<UILanguageChange>().SetHiddenElement(true);
            button_Clerk.GetComponent<Button>().interactable = false;
        }
        
        if (IsCheckPointAchieved(QuestKey.Worker))
        {
            button_Worker.transform.GetChild(0).GetComponent<UILanguageChange>().SetHiddenElement(false);
            button_Worker.GetComponent<Button>().interactable = true;
        }
        else
        {
            button_Worker.transform.GetChild(0).GetComponent<UILanguageChange>().SetHiddenElement(true);
            button_Worker.GetComponent<Button>().interactable = false;
        }
        
    }

    private bool IsCheckPointAchieved(QuestKey questKey)
    {
        List<QuestData> questDataList = QuestDataHolder.Instance.questDataList;

        foreach (var questData in questDataList)
        {
            if (questData.key == questKey)
            {
                if (questData.progress == -1)
                {
                    return false;
                }
                else if (questData.progress == 0 || questData.progress == 1)
                {
                    return true;
                }
            }
        }
        
        EditorDebug.LogError("QuestDataのprogress値が異常です");
        return false;
    }
    
    public void OnClick(GameObject clickedButton)
    {
        if (clickedButton == button_JK)
        {
            SceneChange.Instance.SceneChangeFunction(SceneName.JK_North_Scene);
        }
        else if (clickedButton == button_Element)
        {
            SceneChange.Instance.SceneChangeFunction(SceneName.Element_BeforeThugs_Scene);
        }
        else if (clickedButton == button_OL)
        {
            SceneChange.Instance.SceneChangeFunction(SceneName.OL_Central_Scene);
        }
        else if (clickedButton == button_Thugs)
        {
            SceneChange.Instance.SceneChangeFunction(SceneName.Thugs_Central_Scene);
        }
        else if (clickedButton == button_Clerk)
        {
            SceneChange.Instance.SceneChangeFunction(SceneName.Clerk_Central_Scene);
        }
        else if (clickedButton == button_Worker)
        {
            SceneChange.Instance.SceneChangeFunction(SceneName.Worker_South_Scene);
        }
        else
        {
            EditorDebug.LogError("設定されたチェックポイントボタンが異なります");
        }
    }

    public void OnHoverEnter(GameObject hoveredButton)
    {
        if (hoveredButton == button_JK)
        {
            checkPointCharaImage.enabled = true;
            if (IsCheckPointAchieved(QuestKey.JK))
            {
                checkPointCharaImage.sprite = sprite_JK;
            }
            else
            {
                checkPointCharaImage.sprite = sprite_JK_hidden;
            }
        }
        else if (hoveredButton == button_Element)
        {
            checkPointCharaImage.enabled = true;
            if (IsCheckPointAchieved(QuestKey.Element))
            {
                checkPointCharaImage.sprite = sprite_Element;
            }
            else
            {
                checkPointCharaImage.sprite = sprite_Element_hidden;
            }
        }
        else if (hoveredButton == button_OL)
        {
            checkPointCharaImage.enabled = true;
            if (IsCheckPointAchieved(QuestKey.OL))
            {
                checkPointCharaImage.sprite = sprite_OL;
            }
            else
            {
                checkPointCharaImage.sprite = sprite_OL_hidden;
            }
        }
        else if (hoveredButton == button_Thugs)
        {
            checkPointCharaImage.enabled = true;
            if (IsCheckPointAchieved(QuestKey.Thugs))
            {
                checkPointCharaImage.sprite = sprite_Thugs;
            }
            else
            {
                checkPointCharaImage.sprite = sprite_Thugs_hidden;
            }
        }
        else if (hoveredButton == button_Clerk)
        {
            checkPointCharaImage.enabled = true;
            if (IsCheckPointAchieved(QuestKey.Clerk))
            {
                checkPointCharaImage.sprite = sprite_Clerk;
            }
            else
            {
                checkPointCharaImage.sprite = sprite_Clerk_hidden;
            }
        }
        else if (hoveredButton == button_Worker)
        {
            checkPointCharaImage.enabled = true;
            if (IsCheckPointAchieved(QuestKey.Worker))
            {
                checkPointCharaImage.sprite = sprite_Worker;
            }
            else
            {
                checkPointCharaImage.sprite = sprite_Worker_hidden;
            }
        }
        else
        {
            EditorDebug.LogError("設定されたチェックポイントボタンが異なります");
        }
    }

    public void OnHoverExit()
    {
        checkPointCharaImage.enabled = false;
    }
}
