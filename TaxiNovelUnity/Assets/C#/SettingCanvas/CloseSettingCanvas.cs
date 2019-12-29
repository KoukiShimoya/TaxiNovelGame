using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSettingCanvas : MonoBehaviour
{
    [SerializeField] private GameObject settingCanvas;
    private WorldStateHolder worldStateHolder;

    private void Start()
    {
        worldStateHolder = WorldStateHolder.Instance;
    }

    public void OnClick()
    {
        if (settingCanvas.activeSelf)
        {
            settingCanvas.SetActive(false);
            if (worldStateHolder != null)
            {
                worldStateHolder.GetSetWorldState = WorldStateHolder.WorldState.Standard;
            }
        }
    }
}
