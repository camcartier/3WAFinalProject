using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LedgeDetector : MonoBehaviour
{
    public event Action<Vector3, Vector3> OnLedgeDetect;

    private void OnTriggerEnter(Collider other)
    {
        //first parameter is closest point on the edge to the hand
        //transform.position is of the hand
        //second parameter is direction the ledge is facing in

        OnLedgeDetect?.Invoke(other.ClosestPoint(transform.position), other.transform.forward);
    }
}
