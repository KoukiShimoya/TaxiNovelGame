using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionFromCarPosition : MonoBehaviour
{
    [SerializeField] private GameObject car;
    
    private void LateUpdate()
    {
        this.gameObject.transform.position = car.transform.position;
    }
}
