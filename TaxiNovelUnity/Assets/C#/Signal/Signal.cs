using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour
{
    /// <summary>
    /// Listにすることで、4Type対面式信号と、3TypeT字信号を可能にする
    /// </summary>
    [SerializeField] private List<GameObject> horizontalSignalObject = new List<GameObject>();
    [SerializeField] private List<GameObject> verticalSignalObject = new List<GameObject>();
    private List<ChangeSignalColor> verticalSignal = new List<ChangeSignalColor>();
    private List<ChangeSignalColor> horizontalSignal = new List<ChangeSignalColor>();

    /// <summary>
    /// greenTime + yellowTime == redTime
    /// </summary>
    [SerializeField] private int greenTime;
    [SerializeField] private int yellowTime;

    private float elapsedTime;

    private bool verticalGreenToYellow;
    private bool verticalYellowToRed;
    private bool horizontalGreenToYellow;

    private WorldStateHolder worldStateHolder;

    private void Start()
    {
        for (int i = 0; i < horizontalSignalObject.Count; i++)
        {
            horizontalSignal.Add(horizontalSignalObject[i].GetComponent<ChangeSignalColor>());
        }

        for (int i = 0; i < verticalSignalObject.Count; i++)
        {
            verticalSignal.Add(verticalSignalObject[i].GetComponent<ChangeSignalColor>());
        }

        foreach (var horizontal in horizontalSignal)
        {
            horizontal.AllSignalInactive();
            horizontal.YellowToRed();
        }

        foreach (var vertical in verticalSignal)
        {
            vertical.AllSignalInactive();
            vertical.RedToGreen();
        }

        elapsedTime = 0f;
        verticalGreenToYellow = false;
        verticalYellowToRed = false;

        worldStateHolder = WorldStateHolder.Instance;
    }

    private void Update()
    {
        if (worldStateHolder.GetSetWorldState == WorldStateHolder.WorldState.ObjectStopping || worldStateHolder.GetSetWorldState == WorldStateHolder.WorldState.Settings)
        {
            return;
        }
        
        elapsedTime += Time.deltaTime;

        if (elapsedTime > greenTime && !verticalGreenToYellow)
        {
            foreach (var vertical in verticalSignal)
            {
                vertical.GreenToYellow();
            }

            verticalGreenToYellow = true;
        }

        if (elapsedTime > greenTime + yellowTime && !verticalYellowToRed)
        {
            foreach (var vertical in verticalSignal)
            {
                vertical.YellowToRed();
            }

            foreach (var horizontal in horizontalSignal)
            {
                horizontal.RedToGreen();
            }

            verticalYellowToRed = true;
        }

        if (elapsedTime > greenTime + yellowTime + greenTime && !horizontalGreenToYellow)
        {
            foreach (var horizontal in horizontalSignal)
            {
                horizontal.GreenToYellow();
            }

            horizontalGreenToYellow = true;
        }

        if (elapsedTime > greenTime + yellowTime + greenTime + yellowTime)
        {
            foreach (var horizontal in horizontalSignal)
            {
                horizontal.YellowToRed();
            }

            foreach (var vertical in verticalSignal)
            {
                vertical.RedToGreen();
            }

            verticalGreenToYellow = false;
            verticalYellowToRed = false;
            horizontalGreenToYellow = false;
            
            elapsedTime = 0f;
        }
    }
}
