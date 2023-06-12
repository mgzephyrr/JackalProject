using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDeleter : MonoBehaviour
{
    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
