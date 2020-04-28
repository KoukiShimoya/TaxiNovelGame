using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class NowActiveLanguage
{
    private static LanguageCode languageCode = LanguageCode.JA;

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
            
            var gameObjects = Resources.FindObjectsOfTypeAll(typeof(GameObject))
                .Select(c => c as GameObject)
                .Where(c => c.hideFlags != HideFlags.NotEditable && c.hideFlags != HideFlags.HideAndDontSave);

            foreach(var item in gameObjects)
            {
                if (item.HasComponent<UILanguageChange>())
                {
                    UILanguageChange uChnage = item.GetComponent<UILanguageChange>();
                    uChnage.SetText();
                    uChnage.ChangeLanguage();
                }
            }
        }
    }

    public enum LanguageCode
    {
        JA,
        EN
    }
}
