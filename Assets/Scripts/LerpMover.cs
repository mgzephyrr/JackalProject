using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMover : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float stepSize;
    private float Progress;
    void Start()
    {
        transform.position = startPosition;
    }

   
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(startPosition, endPosition, Progress);
        Progress += stepSize;
    }
}
