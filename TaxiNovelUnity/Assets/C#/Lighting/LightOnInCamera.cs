using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class LightOnInCamera : MonoBehaviour
{
    private Light2D light2D;
    private bool isVisible;
    private GameObject car;

    private void Start()
    {
        light2D = this.gameObject.GetComponent<Light2D>();
        light2D.enabled = false;
        car = PlayerStateOwner.Instance.gameObject;
    }

    private void LateUpdate()
    {
        if (Vector2.Distance(car.transform.position, this.gameObject.transform.position) < 15)
        {
            if (!light2D.isActiveAndEnabled)
            {
                light2D.enabled = true;
            }
        }
        else
        {
            if (light2D.isActiveAndEnabled)
            {
                light2D.enabled = false;
            }
        }
    }
}
