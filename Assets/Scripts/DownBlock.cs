using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownBlock : MonoBehaviour
{
    Vector3 pos;
    private float speed = 5;
    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.position = transform.position + Vector3.down * speed * Time.deltaTime;
        }
    }
}
