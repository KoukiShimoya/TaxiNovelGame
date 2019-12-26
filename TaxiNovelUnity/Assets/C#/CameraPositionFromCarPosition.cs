using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionFromCarPosition : MonoBehaviour
{
    [SerializeField] private GameObject car;
    private const int cameraZ = -10;
    private const int carAboveY = -1;
    
    private void LateUpdate()
    {
        Vector3 carPosition = car.transform.position;
        carPosition.y += carAboveY;
        carPosition.z = cameraZ;
        this.gameObject.transform.position = carPosition;
    }
}
