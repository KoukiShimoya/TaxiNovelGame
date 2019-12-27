using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConstValues;

public class GeneralCarCheckSignal : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    private GeneralCarStateHolder generalCarStateHolder;

    private void Start()
    {
        generalCarStateHolder = parent.GetComponent<GeneralCarStateHolder>();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (!collider2D.CompareTag(TagName.Signal))
        {
            return;
        }

        StartCoroutine(WaitUntilSignalGreen(collider2D.gameObject));
    }

    private IEnumerator WaitUntilSignalGreen(GameObject signal)
    {
        ChangeSignalColor changeSignalColor = signal.GetComponent<ChangeSignalColor>();
        while (true)
        {
            if (changeSignalColor.signalState == ChangeSignalColor.SignalState.Green)
            {
                if (generalCarStateHolder.generalCarState == GeneralCarState.Stopping)
                {
                    generalCarStateHolder.generalCarState = GeneralCarState.Driving;
                }
                yield break;
            }
            else
            {
                if (generalCarStateHolder.generalCarState == GeneralCarState.Driving)
                {
                    generalCarStateHolder.generalCarState = GeneralCarState.Stopping;
                }
                yield return null;
            }
        }
    }
}
