using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConstValues;

public class SettingToStartScene : SingletonMonoBehaviour<SettingToStartScene>
{
    [SerializeField] private GameObject returnStartPanel;

    public GameObject GetReturnStartPanel
    {
        get { return returnStartPanel; }
    }

    private void Start()
    {
        returnStartPanel.SetActive(false);
    }

    public void OnOpenReturnStartPanelButtonClick()
    {
        returnStartPanel.SetActive(true);
    }

    public void OnReturnSettingPanelButtonClick()
    {
        returnStartPanel.SetActive(false);
    }

    public void OnReturnStartSceneButtonClick()
    {
        SceneChange.Instance.SceneChangeFunction(SceneName.StartScene);
    }
}
