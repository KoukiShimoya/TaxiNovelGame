using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GameClose : SingletonMonoBehaviour<GameClose>
{
    [SerializeField] private GameObject checkPanel;

    public GameObject GetGameClosePanel
    {
        get { return checkPanel; }
    }
    
    public void OnClick_NoCheck()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
            UnityEngine.Application.Quit();
        #endif
    }

    public void Onclick_Check()
    {
        if (checkPanel == null)
        {
            EditorDebug.LogWarning("ゲーム終了の確認パネルがありません");
        }
        
        checkPanel.SetActive(true);
    }

    public void Onclick_CloseCheckPanel()
    {
        if (checkPanel == null)
        {
            EditorDebug.LogWarning("ゲーム終了の確認パネルがありません");
        }
        
        checkPanel.SetActive(false);
    }
}