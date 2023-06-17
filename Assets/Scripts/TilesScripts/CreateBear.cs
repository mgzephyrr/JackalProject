using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBear : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private Vector3 localPosition;
    private bool isCreated = false;
    private GameObject temp;
    private void Start()
    {
        localPosition = gameObject.transform.position;
        Debug.Log($"{localPosition.x} {localPosition.z}");
        temp = GameObject.Find("Highlighter");
    }
    void Update()
    {
        //Debug.Log($"{(int)localPosition.x} {(int)localPosition.z}");
        SpawnBear();
    }
    public void SpawnBear()
    {
        GamePiece obj = TileBoard.gamePieces[(int)(localPosition.x - 0.5), (int)(localPosition.z - 0.5)];
        if (obj != null && !isCreated)
        {
            obj.PieceDestroy();
            Debug.Log($"{Instantiate(prefab, temp.transform).GetComponent<GamePiece>()}");
            Debug.Log($"{Instantiate(prefab, temp.transform)}");
            TileBoard.gamePieces[(int)(localPosition.x - 0.5), (int)(localPosition.z - 0.5)] = Instantiate(prefab, temp.transform).GetComponent<GamePiece>();
            isCreated = true;
        }       
    }
}
