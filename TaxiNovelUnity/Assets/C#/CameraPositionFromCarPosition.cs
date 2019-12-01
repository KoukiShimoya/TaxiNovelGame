using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionFromCarPosition : MonoBehaviour
{
    [SerializeField] private GameObject car;
    private const int cameraZ = -10;
    
    private void LateUpdate()
    {
        Vector3 carPosition = car.transform.position;
        carPosition.z = cameraZ;
        this.gameObject.transform.position = carPosition;
    }
}
