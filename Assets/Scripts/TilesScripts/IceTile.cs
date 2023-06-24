using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTile : MonoBehaviour
{
    private GamePiece piece;
    [SerializeField] public TileBoard board;

    // Update is called once per frame
    void Update()
    {
        piece = TileBoard.gamePieces[(int)(gameObject.transform.localPosition.x - 42.5), (int)(gameObject.transform.localPosition.z - 47.5)];
        if (piece != null)
        {
            piece.isIceTile = true;
        }
    }
}
