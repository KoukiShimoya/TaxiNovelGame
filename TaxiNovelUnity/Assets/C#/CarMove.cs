using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    
    [SerializeField] private float acceleration;
    
    /// <summary>
    /// 回転速度
    /// </summary>
    [SerializeField] private float steering;
 
    [SerializeField] private Rigidbody2D rigidbody2d;

    /// <summary>
    /// 何度ズレていたら真正面や真横に自動的に修正するか
    /// </summary>
    [SerializeField] private float autoFixInclinationThresould;
    
    private float currentSpeed; //現在速度メータなどが必要となった時に使う

    private KeyInput keyInput;
 
    private void Start()
    {
        if (rigidbody2d == null)
        {
            this.rigidbody2d = GetComponent<Rigidbody2D>();
        }

        keyInput = KeyInput.Instance;
    }
 
    private void FixedUpdate()
    {

        if (PlayerStateOwner.Instance.GetPlayerState == PlayerState.Stopping)
        {
            return;
        }

        float horizontal = HorizontalButtonPushLevel();
        float vertical = VerticalButtonPushLevel();
                 
        // Calculate speed from input and acceleration (transform.up is forward)
        Vector2 speed = transform.up * (vertical * acceleration);
        rigidbody2d.AddForce(speed);
        
        transform.Rotate(0, 0, horizontal * steering);
 
        // Force max speed limit
        if (rigidbody2d.velocity.magnitude > maxSpeed)
        {
            rigidbody2d.velocity = rigidbody2d.velocity.normalized * maxSpeed;
        }
        
        AutoFixInclination(horizontal, vertical);
        
        currentSpeed = rigidbody2d.velocity.magnitude;
    }

    private float HorizontalButtonPushLevel()
    {
        if (keyInput.GetKeyList.Contains(KeyInput.KEYTYPE.A) && keyInput.GetKeyList.Contains((KeyInput.KEYTYPE.D)))
        {
            return 0;
        }
        else if (keyInput.GetKeyList.Contains(KeyInput.KEYTYPE.A))
        {
            return 1;
        }
        else if (keyInput.GetKeyList.Contains(KeyInput.KEYTYPE.D))
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    private float VerticalButtonPushLevel()
    {
        if (keyInput.GetKeyList.Contains(KeyInput.KEYTYPE.W) && keyInput.GetKeyList.Contains((KeyInput.KEYTYPE.S)))
        {
            return 0;
        }
        else if (keyInput.GetKeyList.Contains(KeyInput.KEYTYPE.W))
        {
            return -1;
        }
        else if (keyInput.GetKeyList.Contains(KeyInput.KEYTYPE.S))
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    /// <summary>
    /// 車体の微妙な回転を、自動的に修正
    /// </summary>
    /// <param name="h">Input Horizontal</param>
    /// <param name="v">Input Vertical</param>
    private void AutoFixInclination(float h, float v)
    {
        if (Mathf.Abs(h) > 0.1f)
        {
            return;
        }

        rigidbody2d.angularVelocity = 0;

        float absRotationZ = this.gameObject.transform.eulerAngles.z;
        
        while (absRotationZ < 0f)
        {
            absRotationZ += 360;
        }
        
        if (absRotationZ <= autoFixInclinationThresould || absRotationZ >= 360 - autoFixInclinationThresould)
        {
            AutoRotate(0);
        }
        else if (Mathf.Abs(absRotationZ - 90) <= autoFixInclinationThresould)
        {
            AutoRotate(90);
        }
        else if (Mathf.Abs(absRotationZ - 180) <= autoFixInclinationThresould)
        {
            AutoRotate(180);
        }
        else if (Mathf.Abs(absRotationZ - 270) <= autoFixInclinationThresould)
        {
            AutoRotate(270);
        }
        
        void AutoRotate(int z)
        {
            rigidbody2d.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,0,z) ,0.05f));
        }
    }
}
