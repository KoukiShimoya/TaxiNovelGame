using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSignalColor : MonoBehaviour
{
    /// <summary>
    /// 0=青、1=黄、2=赤
    /// </summary>
    private GameObject[] childSignals = new GameObject[3];

    public SignalState signalState;

    private void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            childSignals[i] = this.gameObject.transform.GetChild(i).gameObject;
        }
    }

    /// <summary>
    /// 全ての信号の灯火を切る
    /// </summary>
    public void AllSignalInactive()
    {
        foreach (var childSignal in childSignals)
        {
            childSignal.SetActive(false);
        }
    }

    /// <summary>
    /// 青から黄
    /// </summary>
    public void GreenToYellow()
    {
        childSignals[0].SetActive(false);
        childSignals[1].SetActive(true);
        signalState = SignalState.Yellow;
    }

    /// <summary>
    /// 黄から赤
    /// </summary>
    public void YellowToRed()
    {
        childSignals[1].SetActive(false);
        childSignals[2].SetActive(true);
        signalState = SignalState.Red;
    }

    /// <summary>
    /// 赤から青
    /// </summary>
    public void RedToGreen()
    {
        childSignals[2].SetActive(false);
        childSignals[0].SetActive(true);
        signalState = SignalState.Green;
    }

    public enum SignalState
    {
        Green,
        Yellow,
        Red
    }
}
