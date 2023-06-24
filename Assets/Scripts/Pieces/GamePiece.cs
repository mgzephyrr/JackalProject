using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GamePieceType
{
    None = 0,
    Pirate = 1,
    Bear = 2,
    Horse = 2,
    Money = 27
}
public class GamePiece : MonoBehaviour
{
    public int team;
    public int currentX;
    public int currentY;
    public GamePieceType type;

    private Vector3 desiredPosition;
    private Vector3 desiredScale;

    public bool isHorseTile = false;
    public bool isArrowsTile = false;
    public bool isIceTile = false;

    private void Start()
    {
        if (type == GamePieceType.Pirate)
        {
            desiredScale = new Vector3(0.75f, 0.75f, 0.75f);
        }
        if (type == GamePieceType.Bear) 
        {
            desiredScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
        if (type == GamePieceType.Horse)
        {
            desiredScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
        if (type == GamePieceType.Money)
        {
            desiredScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 10);
        transform.localScale = Vector3.Lerp(transform.localScale, desiredScale, Time.deltaTime * 10);
    }

    public virtual List<Vector2Int> GetAvailableMoves(ref GamePiece[,] board, int tileCountX, int tileCountY)
    {
        List<Vector2Int> r = new List<Vector2Int>();
        return r;
    }
    public virtual List<Vector2Int> GetHorseMoves(ref GamePiece[,] board)
    {
        List<Vector2Int> r = new List<Vector2Int>();
        return r;
    }
    public virtual List<Vector2Int> GetArrowsMoves(ref GamePiece[,] board, string type)
    {
        List<Vector2Int> r = new List<Vector2Int>();
        return r;
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
    public void PieceDestroy()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
