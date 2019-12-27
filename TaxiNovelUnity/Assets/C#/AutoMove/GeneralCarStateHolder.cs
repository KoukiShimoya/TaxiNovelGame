using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralCarStateHolder : MonoBehaviour
{
    public GeneralCarState generalCarState;
}

public enum GeneralCarState
{
    Driving,
    Stopping,
}