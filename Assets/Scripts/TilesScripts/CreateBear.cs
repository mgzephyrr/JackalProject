using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBear : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private Vector3 localPosition;
    private bool isCreated = false;
    private void Start()
    {
        localPosition = gameObject.transform.position;
    }
    void Update()
    {
        //Debug.Log($"{(int)localPosition.x} {(int)localPosition.z}");
        SpawnBear();
    }
    public void SpawnBear()
    {
        if (TileBoard.gamePieces[(int)(localPosition.x - 0.5), (int)(localPosition.z - 0.5)] != null && !isCreated)
        {
            GamePiece bear = Instantiate(prefab, transform).GetComponent<GamePiece>();
            Debug.Log(bear);
            bear.type = GamePieceType.Bear;
            Destroy(TileBoard.gamePieces[(int)(localPosition.x - 0.5), (int)(localPosition.z - 0.5)]);//TileBoard.gamePieces[(int)(localPosition.x - 0.5), (int)(localPosition.z - 0.5)] = null;
            TileBoard.gamePieces[(int)(localPosition.x - 0.5), (int)(localPosition.z - 0.5)] = bear;
            isCreated = true;
        }       
    }
}
