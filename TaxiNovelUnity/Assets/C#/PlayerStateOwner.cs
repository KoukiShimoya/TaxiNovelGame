using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateOwner : SingletonMonoBehaviour<PlayerStateOwner>
{
    private PlayerState playerState;

    public PlayerState GetPlayerState
    {
        get { return playerState; }
    }

    private void Start()
    {
        playerState = PlayerState.Driving;
    }

    /// <summary>
    /// PlayerStateのSetter、Fungusから呼ぶために関数化
    /// </summary>
    /// <param name="ps"></param>
    public void ChangePlayerState(PlayerState ps)
    {
        playerState = ps;
    }
}

public enum PlayerState
{
    Driving,
    Stopping
}
