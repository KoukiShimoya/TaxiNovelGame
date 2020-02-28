using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConstValues;

public class PoliceLight : MonoBehaviour
{
    [SerializeField] private Fungus.Flowchart flowchart;
    private const string message = "PoliceFind";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagName.Player))
        {
            flowchart.SendFungusMessage(message);
        }
    }
}
