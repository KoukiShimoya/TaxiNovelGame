using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConstValues;

public class FungusMessageSend : MonoBehaviour
{
    [SerializeField] private Fungus.Flowchart flowchart;
    [SerializeField] private string enterMessage;
    [SerializeField] private string exitMessage;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(TagName.Player))
        {
            flowchart.SendFungusMessage(enterMessage);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(TagName.Player))
        {
            flowchart.SendFungusMessage(exitMessage);
        }
    }
}
