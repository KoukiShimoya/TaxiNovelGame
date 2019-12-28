using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElapsedTime
{
    private float elapsedTime;

    public float GetElapsedTIme
    {
        get { return elapsedTime; }
    }
    
    
    void Start()
    {
        elapsedTime = 0f;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
    }
}
