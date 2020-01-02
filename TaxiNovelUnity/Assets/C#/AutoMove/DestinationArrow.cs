using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationArrow : MonoBehaviour
{
    private GameObject player;
    private GameObject destination;
    private RectTransform rectTransform;
    
    private void Start()
    {
        player = PlayerStateOwner.Instance.gameObject;
        destination = Destination.Instance.gameObject;
        rectTransform = this.gameObject.GetComponent<RectTransform>();
    }

    private void Update()
    {
        destination.transform.GetChild(0).transform.LookAt2D(player.transform.position);
        Quaternion quaternion = destination.transform.GetChild(0).transform.rotation;
        rectTransform.rotation = quaternion;
    }
}
