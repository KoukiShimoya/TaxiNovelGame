using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConstValues;

public class FungusMessageSend : MonoBehaviour
{
    [SerializeField] private Fungus.Flowchart flowchart;
    [SerializeField] private string message;
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(TagName.Player))
        {
            flowchart.SendFungusMessage(message);
        }
    }
}
