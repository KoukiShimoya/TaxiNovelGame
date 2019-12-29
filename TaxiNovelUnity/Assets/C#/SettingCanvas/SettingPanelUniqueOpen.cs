using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanelUniqueOpen : MonoBehaviour
{
    [SerializeField] private GameObject languagePanel;
    [SerializeField] private GameObject howToUsePanel;
    [SerializeField] private GameObject settingCanvas;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="languageOrHowToUse">languagePanelならtrue, HowToUsePanelならfalse</param>
    public void ChangeActivePanel(bool languageOrHowToUse)
    {
        if (languageOrHowToUse)
        {
            languagePanel.SetActive(true);
            howToUsePanel.SetActive(false);
        }
        else
        {
            languagePanel.SetActive(false);
            howToUsePanel.SetActive(true);
        }
    }

    private void Start()
    {
        settingCanvas.SetActive(false);
        languagePanel.SetActive(false);
        howToUsePanel.SetActive(false);
    }
}
