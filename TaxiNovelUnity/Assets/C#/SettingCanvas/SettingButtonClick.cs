using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButtonClick : SingletonMonoBehaviour<SettingButtonClick>
{
    [SerializeField] private GameObject settingCanvas;
    private WorldStateHolder worldStateHolder;

    private void Start()
    {
        worldStateHolder = WorldStateHolder.Instance;
    }

    public void OnClick()
    {
        if (!settingCanvas.activeSelf)
        {
            settingCanvas.SetActive(true);
            if (worldStateHolder != null)
            {
                worldStateHolder.GetSetWorldState = WorldStateHolder.WorldState.Settings;
            }
        }
    }
}
