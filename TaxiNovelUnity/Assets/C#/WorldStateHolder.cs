using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldStateHolder : SingletonMonoBehaviour<WorldStateHolder>
{
    public WorldState worldState;

    /// <summary>
    /// 世界全体のState
    /// </summary>
    public enum WorldState
    {
        Standard,
        AllStopping,
        //OnlyPlayerMove
    }
}
