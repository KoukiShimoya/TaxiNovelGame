using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionChange : MonoBehaviour
{
    [SerializeField] private ResolutionStateHolder.ResolutionState resolutionState;

    public void OnValueChanged(bool isOn)
    {
        if (!isOn)
        {
            return;
        }

        ResolutionStateHolder.ResolutionStateChange(resolutionState);
    }
}
