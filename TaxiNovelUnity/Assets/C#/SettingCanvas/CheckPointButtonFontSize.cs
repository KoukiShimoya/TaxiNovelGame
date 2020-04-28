using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPointButtonFontSize : MonoBehaviour
{
    private Text text;

    private void Start()
    {
        text = this.gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        switch (NowActiveLanguage.GetSetLanguageCode)
        {
            case NowActiveLanguage.LanguageCode.JA:
                text.fontSize = 23;
                break;
            case NowActiveLanguage.LanguageCode.EN:
                text.fontSize = 19;
                break;
            default:
                EditorDebug.LogWarning("その言語のLanguageCodeは存在しません");
                break;
        }
    }
}
