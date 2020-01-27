using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class WorldStateHolder : SingletonMonoBehaviour<WorldStateHolder>
{
    [SerializeField] private WorldState worldState;
    [SerializeField] private DialogInput dialogInput;

    public WorldState GetSetWorldState
    {
        get { return worldState; }
        set
        {
            ChangeWorldState(value, worldState);
            worldState = value;
        }
    }

    /// <summary>
    /// WorldStateが変わったタイミングで呼ばれる
    /// </summary>
    /// <param name="nextWorldState"></param>
    /// <param name="preWorldState"></keparam>
    private void ChangeWorldState(WorldState nextWorldState, WorldState preWorldState)
    {
        if (nextWorldState == WorldState.Settings)
        {
            dialogInput.clickMode = ClickMode.Disabled;
        }

        if (preWorldState == WorldState.Settings)
        {
            dialogInput.clickMode = ClickMode.ClickAnywhere;
        }
    }
    
    /// <summary>
    /// 世界全体のState
    /// </summary>
    public enum WorldState
    {
        Standard,
        /// <summary>
        /// Settingsは全物体の時間が止まり、Fungusの会話も止まる
        /// </summary>
        Settings,
        /// <summary>
        /// ObjectStoppingでは全物体の時間が止まる
        /// </summary>
        ObjectStopping,
        //OnlyPlayerMove
    }
}
