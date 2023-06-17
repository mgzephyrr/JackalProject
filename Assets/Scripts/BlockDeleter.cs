using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDeleter : MonoBehaviour
{
    void Update()
    {
        if (TileBoard.gamePieces[(int)(gameObject.transform.localPosition.x - 42.5), (int)(gameObject.transform.localPosition.z - 47.5)] != null)
            Destroy(gameObject);
    }
}