using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UI;

public class deathGrass : MonoBehaviour
{
    public UnityEngine.Sprite death;
    private int numbersWhite = 3;
    private int numbersRed = 3;
    private int numbersBlue = 3;
    private int numbersBlack = 3;

    [SerializeField] public GameObject prefab;
    [SerializeField] public TileBoard board;
    private bool isCreated = false;
    private GamePiece piece;

    void Update()
    {
        piece = TileBoard.gamePieces[(int)(gameObject.transform.localPosition.x - 42.5), (int)(gameObject.transform.localPosition.z - 47.5)];
        if (piece != null && piece.type == GamePieceType.Pirate)
        {
            KillPirate();
        }
    }

    void KillPirate()
    {
        int team = piece.team;
        string name = "";
        switch (team)
        {
            case 0: //white team
                {
                    name = "PirateWhite" + (4 - numbersWhite).ToString();
                    numbersWhite--;
                    break;
                }
            case 1: //red team
                {
                    name = "PirateRed" + (4 - numbersRed).ToString();
                    numbersRed--;
                    break;
                }
            case 2: //black team
                {
                    name = "PirateBlack" + (4 - numbersBlack).ToString();
                    numbersBlack--;
                    break;
                }
            case 3: //blue team
                {
                    name = "PirateBlue" + (4 - numbersBlue).ToString();
                    numbersBlue--;
                    break;
                }
        }
        var imageGameObject = GameObject.Find(name);
        if (imageGameObject != null)
        {
            var img = imageGameObject.GetComponentInParent<Image>();
            img.sprite = death;
        }
        piece.PieceDestroy();

        if (!isCreated)
        {
            board.SpawnBear((int)(gameObject.transform.localPosition.x - 42.5), (int)(gameObject.transform.localPosition.z - 47.5));
            isCreated = true;
        }
    }
}
