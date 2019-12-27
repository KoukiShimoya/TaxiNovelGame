using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Navigation4TilemapNameSpace;

public class DestinationToggleChanged : MonoBehaviour
{
    [SerializeField] private Toggle toggle;

    private Navigation4Tilemap navigation4Tilemap;

    private void Start()
    {
        toggle = this.gameObject.GetComponent<Toggle>();
        navigation4Tilemap = Navigation4Tilemap.Instance;
    }

    public void OnToggleChanged()
    {
        if (toggle.isOn)
        {
            navigation4Tilemap.StopAllCoroutines();
            navigation4Tilemap.FindingPath(
                new Vector2(navigation4Tilemap.player.transform.position.x,
                    navigation4Tilemap.player.transform.position.y), Destination.destination);
            navigation4Tilemap.StopFindAndStartCoroutine();
        }
        else
        {
            navigation4Tilemap.StopAllCoroutines();
            navigation4Tilemap.InActivePathMarks();
        }
    }
}
