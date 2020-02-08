using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConstValues;
using IsGameSceneCheck;

public class SettingButtonClick : SingletonMonoBehaviour<SettingButtonClick>
{
    [SerializeField] private GameObject settingCanvas;

    public void OnClick()
    {
        if (!settingCanvas.activeSelf)
        {
            settingCanvas.SetActive(true);
            if (GameSceneCheck.Check())
            {
                WorldStateHolder.Instance.GetSetWorldState = WorldStateHolder.WorldState.Settings;
            }
        }
    }
}
