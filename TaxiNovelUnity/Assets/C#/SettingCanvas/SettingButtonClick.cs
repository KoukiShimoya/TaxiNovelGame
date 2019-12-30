using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConstValues;
using UnityEngine.SceneManagement;

public class SettingButtonClick : SingletonMonoBehaviour<SettingButtonClick>
{
    [SerializeField] private GameObject settingCanvas;
    private WorldStateHolder worldStateHolder;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == SceneName.GameScene)
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
            if (SceneManager.GetActiveScene().name == SceneName.GameScene)
            {
                worldStateHolder.GetSetWorldState = WorldStateHolder.WorldState.Settings;
            }
        }
    }
}
