using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class CarLightIntencityChange : MonoBehaviour
{
    private List<Light2D> light2DList;
    private const float lowIntensity = 0.6f;
    private const float highIntensity = 2f;
    
    private void Start()
    {
        GameObject[] carChildObject = PlayerStateOwner.Instance.gameObject.GetOnlyOwnChildren();
        light2DList = new List<Light2D>();
        
        foreach (var VARIABLE in carChildObject)
        {
            Light2D light2D = VARIABLE.GetComponent<Light2D>();
            light2DList.Add(light2D);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag(ConstValues.TagName.Player))
        {
            foreach (var VARIABLE in light2DList)
            {
                VARIABLE.intensity = highIntensity;
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag(ConstValues.TagName.Player))
        {
            foreach (var VARIABLE in light2DList)
            {
                VARIABLE.intensity = lowIntensity;
            }
        }
    }
}
