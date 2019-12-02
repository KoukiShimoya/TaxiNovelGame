﻿using System.Collections;
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
 
    [SerializeField] private Rigidbody2D rb;

    /// <summary>
    /// 何度ズレていたら真正面や真横に自動的に修正するか
    /// </summary>
    [SerializeField] private float autoFixInclinationThresould;
    
    private float currentSpeed;
 
    private void Start()
    {
        if (rb == null)
        {
            this.rb = GetComponent<Rigidbody2D>();
        }
    }
 
    private void FixedUpdate()
    {

        if (PlayerStateOwner.Instance.GetPlayerState == PlayerState.Stopping)
        {
            return;
        }
        
        // Get input
        float h = Input.GetAxis("Horizontal");
        float v = -Input.GetAxis("Vertical");
                 
        // Calculate speed from input and acceleration (transform.up is forward)
        Vector2 speed = transform.up * (v * acceleration);
        rb.AddForce(speed);
        
        
        // Create car rotation
        float direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up));
        if (direction >= 0f)
        {
            rb.rotation += h * steering * (rb.velocity.magnitude / maxSpeed);
        }
        else
        {
            rb.rotation -= h * steering * (rb.velocity.magnitude / maxSpeed);
        }
        
 
        // Change velocity based on rotation
        float driftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.left)) * 2.0f;
        Vector2 relativeForce = Vector2.right * driftForce;
        EditorDebug.DrawLine(rb.position, rb.GetRelativePoint(relativeForce), Color.green);
        rb.AddForce(rb.GetRelativeVector(relativeForce));
 
        // Force max speed limit
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        
        AutoFixInclination(h, v);
        
        currentSpeed = rb.velocity.magnitude;
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
            rb.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,0,z) ,0.05f));
        }
    }
}
