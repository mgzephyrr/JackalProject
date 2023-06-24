using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class HorseTile : MonoBehaviour
{
    [SerializeField] public TileBoard board;
    private bool isCreated = false;
    private GamePiece piece;
    public GameObject horse;

    //Pirate pirate;

    void Update()
    {
        piece = TileBoard.gamePieces[(int)(gameObject.transform.localPosition.x - 42.5), (int)(gameObject.transform.localPosition.z - 47.5)];
        if (piece != null && piece.type == GamePieceType.Pirate)
        {
            piece.isHorseTile = true;
            if (!isCreated)
            {
                if (horse != null) horse.SetActive(true);
                isCreated = true;
            }
        }
    }
}
