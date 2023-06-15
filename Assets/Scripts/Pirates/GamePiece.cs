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
    private Vector3 desiredScale = new Vector3(0.75f,0.75f,0.75f);

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 10);
        transform.localScale = Vector3.Lerp(transform.localScale, desiredScale, Time.deltaTime * 10);
    }
    public virtual void SetPosition(Vector3 position, bool force = false)
    {
        desiredPosition = position;
        if (force)
        {
            transform.position = desiredPosition;
        }
    }
    public virtual void SetScale(Vector3 scale, bool force = false)
    {
        desiredScale = scale;
        if (force)
        {
            transform.localScale = desiredScale;
        }
    }
}
