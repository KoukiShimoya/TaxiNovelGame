using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleChangeByNowActiveLanguage : MonoBehaviour
{
    private bool preActiveSelf;
    [SerializeField] private GameObject languageBackPanel;
    [SerializeField] private List<Toggle> toggleList;

    private void Start()
    {
        preActiveSelf = languageBackPanel.activeSelf;
    }

    private void Update()
    {
        if (languageBackPanel.activeSelf && !preActiveSelf)
        {
            ToggleChange();
        }

        preActiveSelf = languageBackPanel.activeSelf;
    }

    private void ToggleChange()
    {
        switch (NowActiveLanguage.GetSetLanguageCode)
        {
            case NowActiveLanguage.LanguageCode.JP:
                toggleList[0].isOn = true;
                break;
            case NowActiveLanguage.LanguageCode.EN:
                toggleList[1].isOn = true;
                break;
            default:
                EditorDebug.LogWarning("その言語のLanguageCodeは存在しません");
                break;
        }
    }
}
