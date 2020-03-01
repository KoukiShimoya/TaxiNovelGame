using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionChangeInitialize : MonoBehaviour
{
    private void Awake()
    {
        ResolutionStateHolder.Initialize();
    }
}
