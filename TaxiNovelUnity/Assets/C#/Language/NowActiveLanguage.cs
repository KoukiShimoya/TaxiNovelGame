using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NowActiveLanguage
{
    private static LanguageCode languageCode = LanguageCode.JP;

    public static LanguageCode GetSetLanguageCode
    {
        get
        {
            return languageCode;
        }
        set
        {
            EditorDebug.Log("LanguageCodeが" + value.ToString() + "に変更されました");
            languageCode = value;
        }
    }

    public enum LanguageCode
    {
        JP,
        EN
    }
}
