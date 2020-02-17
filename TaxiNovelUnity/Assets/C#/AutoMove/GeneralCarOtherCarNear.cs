using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConstValues;

public class GeneralCarOtherCarNear : MonoBehaviour
{
    private GameObject parent;
    private GeneralCarStateHolder generalCarStateHolder;
    private List<GameObject> enteringCars;

    private void Start()
    {
        parent = this.gameObject.transform.parent.gameObject;
        generalCarStateHolder = parent.GetComponent<GeneralCarStateHolder>();
        enteringCars = new List<GameObject>();
    }

    /// <summary>
    /// 他車が近づいたときに、動きを止める
    /// </summary>
    /// <param name="collider2D"></param>
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        bool tag = collider2D.gameObject.CompareTag(TagName.Police) || collider2D.gameObject.CompareTag(TagName.Player);

        if (!tag)
        {
            return;
        }
        

        if (collider2D.gameObject == parent)
        {
            return;
        }

        if (enteringCars.Contains(collider2D.gameObject))
        {
            return;
        }

        if (generalCarStateHolder.generalCarState != GeneralCarState.Stopping)
        {
            generalCarStateHolder.generalCarState = GeneralCarState.Stopping;
            enteringCars.Add(collider2D.gameObject);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collider2D)
    {
        bool tag = collider2D.gameObject.CompareTag(TagName.Police) || collider2D.gameObject.CompareTag(TagName.Player);

        if (!tag)
        {
            return;
        }

        if (collider2D.gameObject == parent)
        {
            return;
        }

        if (!enteringCars.Contains(collider2D.gameObject))
        {
            return;
        }

        enteringCars.Remove(collider2D.gameObject);
        if (enteringCars.Count == 0)
        {
            if (generalCarStateHolder.generalCarState == GeneralCarState.Stopping)
            {
                generalCarStateHolder.generalCarState = GeneralCarState.Driving;
            }
        }
    }
}