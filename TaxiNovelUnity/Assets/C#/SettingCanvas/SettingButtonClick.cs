using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConstValues;
using IsGameSceneCheck;

public class SettingButtonClick : SingletonMonoBehaviour<SettingButtonClick>
{
    [SerializeField] private GameObject settingCanvas;
    private WorldStateHolder worldStateHolder;

    private void Start()
    {
        if (GameSceneCheck.Check())
        {
            worldStateHolder = WorldStateHolder.Instance;
        }
        settingCanvas.SetActive(false);
    }

    public void OnClick()
    {
        if (!settingCanvas.activeSelf)
        {
            settingCanvas.SetActive(true);
            if (GameSceneCheck.Check())
            {
                worldStateHolder.GetSetWorldState = WorldStateHolder.WorldState.Settings;
            }
        }
    }
}
