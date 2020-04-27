using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IsGameSceneCheck;
using ConstValues;

public class SettingPanelUniqueOpen : MonoBehaviour
{
    [SerializeField] private List<ButtonPanelSet> buttonPanelSetList;
    [SerializeField] private GameObject settingCanvas;
    private WorldStateHolder worldStateHolder;
    private SettingToStartScene settingToStartScene;
    private GameClose gameClose;

    /// <summary>
    /// 設定画面でボタンを押した際、開かれる画面を一意にする挙動
    /// </summary>
    /// <param name="languageOrHowToUse">languagePanelならtrue, HowToUsePanelならfalse</param>
    public void ChangeActivePanel(GameObject button)
    {
        foreach (var buttonPanelSet in buttonPanelSetList)
        {
            if (buttonPanelSet.Button == button)
            {
                buttonPanelSet.Panel.SetActive(true);
            }
            else
            {
                buttonPanelSet.Panel.SetActive(false);
            }
        }
    }

    /// <summary>
    /// 設定画面で閉じるボタンを押したときの挙動
    /// </summary>
    public void CloseSettingPanel()
    {
        settingCanvas.SetActive(false);
        
        foreach (var buttonPanelSet in buttonPanelSetList)
        {
            buttonPanelSet.Panel.SetActive(false);
        }
        
        if (GameSceneCheck.Check())
        {
            worldStateHolder.GetSetWorldState = WorldStateHolder.WorldState.Standard;
            settingToStartScene.GetReturnStartPanel.SetActive(false);
            gameClose.GetGameClosePanel.SetActive(false);
        }
        else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == SceneName.StartScene.ToString())
        {
            gameClose.GetGameClosePanel.SetActive(false);
        }
    }

    private void Start()
    {
        foreach (var buttonPanelSet in buttonPanelSetList)
        {
            buttonPanelSet.Panel.SetActive(false);
        }

        if (GameSceneCheck.Check())
        {
            worldStateHolder = WorldStateHolder.Instance;
            settingToStartScene = SettingToStartScene.Instance;
            gameClose = GameClose.Instance;
        }
        else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == SceneName.StartScene.ToString())
        {
            gameClose = GameClose.Instance;
        }
    }
}

[System.Serializable]
public class ButtonPanelSet
{
    public GameObject Button;
    public GameObject Panel;
}