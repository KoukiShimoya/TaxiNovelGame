using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnInCamera : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool isVisible;
    private GameObject car;

    private void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        car = PlayerStateOwner.Instance.gameObject;
    }

    private void LateUpdate()
    {
        if (Vector2.Distance(car.transform.position, this.gameObject.transform.position) < 15)
        {
            if (!spriteRenderer.enabled)
            {
                spriteRenderer.enabled = true;
            }
        }
        else
        {
            if (spriteRenderer.enabled)
            {
                spriteRenderer.enabled = false;
            }
        }
    }
}
