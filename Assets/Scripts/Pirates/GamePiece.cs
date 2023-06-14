using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GamePieceType
{
    None = 0,
    Pirate = 1,
    Bear = 2,
    Missionary = 3
}
public class GamePiece : MonoBehaviour
{
    public int team;
    public int currentX;
    public int currentY;
    public GamePieceType type;

    private Vector3 desiredPosition;
    private Vector3 desiredScale;
}
