using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

public class FungusMessageSend : MonoBehaviour
{
    [SerializeField] private Fungus.Flowchart flowchart;
    [SerializeField] private string message;
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(Tag.Player))
        {
            flowchart.SendFungusMessage(message);
        }
    }
}
