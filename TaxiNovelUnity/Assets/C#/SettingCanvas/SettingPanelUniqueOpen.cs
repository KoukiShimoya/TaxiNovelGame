using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ConstValues;

public class SettingPanelUniqueOpen : MonoBehaviour
{
    [SerializeField] private List<ButtonPanelSet> buttonPanelSetList;
    [SerializeField] private GameObject settingCanvas;
    private WorldStateHolder worldStateHolder;
    private SettingToStartScene settingToStartScene;

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
        
        if (SceneManager.GetActiveScene().name == SceneName.GameScene)
        {
            worldStateHolder.GetSetWorldState = WorldStateHolder.WorldState.Standard;
        }

        if (SceneManager.GetActiveScene().name == SceneName.GameScene)
        if (SceneManager.GetActiveScene().name == SceneName.GameScene)
        {
            settingToStartScene.GetReturnStartPanel.SetActive(false);
        }
    }

    private void Start()
    {
        settingCanvas.SetActive(false);
        foreach (var buttonPanelSet in buttonPanelSetList)
        {
            buttonPanelSet.Panel.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == SceneName.GameScene)
        {
            worldStateHolder = WorldStateHolder.Instance;
            settingToStartScene = SettingToStartScene.Instance;
        }
    }
}

[System.Serializable]
public class ButtonPanelSet
{
    public GameObject Button;
    public GameObject Panel;
}