﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILanguageChange : MonoBehaviour
{
    [SerializeField] private string JA;
    [SerializeField] private string EN;
    private Text text;

    private void Start()
    {
        text = this.gameObject.GetComponent<Text>();
        
        ChangeLanguage();
    }

    public void ChangeLanguage()
    {
        switch (NowActiveLanguage.GetSetLanguageCode)
        {
            case NowActiveLanguage.LanguageCode.JA:
                text.text = JA;
                break;
            case NowActiveLanguage.LanguageCode.EN:
                text.text = EN;
                break;
            default:
                EditorDebug.LogWarning("その言語のLanguageCodeは存在しません");
                break;
        }
    }

    public void ChangeText(string JA, string EN)
    {
        this.JA = JA;
        this.EN = EN;
        ChangeLanguage();
    }

    public void SetText()
    {
        if (text == null)
        {
            text = this.gameObject.GetComponent<Text>();
        }
    }
}
