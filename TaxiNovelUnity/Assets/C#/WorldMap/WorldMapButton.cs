using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapButton : MonoBehaviour
{
    private WorldStateHolder worldStateHolder;
    [SerializeField] private GameObject worldMapCanvas;
    
    private void Start()
    {
        worldStateHolder = WorldStateHolder.Instance;
    }

    public void OpenWorldMap()
    {
        if (worldStateHolder == null)
        {
            worldStateHolder = WorldStateHolder.Instance;
        }
        
        worldMapCanvas.SetActive(true);
        worldStateHolder.GetSetWorldState = WorldStateHolder.WorldState.Settings;
    }

    public void CloseWorldMap()
    {
        if (worldStateHolder == null)
        {
            worldStateHolder = WorldStateHolder.Instance;
        }
        
        worldMapCanvas.SetActive(false);
        worldStateHolder.GetSetWorldState = WorldStateHolder.WorldState.Standard;
    }
}
