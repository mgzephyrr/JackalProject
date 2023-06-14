using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class TileBoard : MonoBehaviour // ASSIGN TO TILEBLOCKS
{
    [Header("Art stuff")]
    [SerializeField] private Material tileMaterial;
    [SerializeField] private float tileSize = 1.0f;
    [SerializeField] private float yOffset = 0.05f;
    [SerializeField] private Vector3 boardCenter = Vector3.zero;

    [Header("Prefabs && Materials")]
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Material[] teamMaterials;

    // LOGIC
    public static GamePiece[,] gamePieces;
    private GamePiece currentlyDragging;
    private const int TILE_COUNT_X = 13;
    private const int TILE_COUNT_Y = 13;
    private GameObject[,] tiles;
    private Camera currentCamera;
    private Vector2Int currentHover;
    private Vector3 bounds;

    private void Awake()
    {
        GenerateAllTiles(tileSize, TILE_COUNT_X, TILE_COUNT_Y);
        SpawnAllPieces();
        PositionAllPieces();
    }
    private void Update()
    {
        if (!currentCamera)
        {
            currentCamera = Camera.main;
            return;
        }

        RaycastHit info;
        Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out info, 100, LayerMask.GetMask("Tile", "Hover")))
        {            
            // Get the indexes of the tile i've hit
            Vector2Int hitPosition = LookupTileIndex(info.transform.gameObject);

            //Debug.Log(currentHover.x + ", " + currentHover.y);
            //Debug.Log(hitPosition.x + ", " + hitPosition.y);

            // If we're hovering a tile after not hovering any tiles
            if (currentHover == -Vector2Int.one)
            {
                currentHover = hitPosition;
                tiles[currentHover.x, currentHover.y].layer = LayerMask.NameToLayer("Tile");
            }

            // If we were already hovering a tile, change the previous one
            if (currentHover != hitPosition)
            {
                if (tiles[currentHover.x, currentHover.y] is not null)
                    tiles[currentHover.x, currentHover.y].layer = LayerMask.NameToLayer("Tile");
                currentHover = hitPosition;
                tiles[hitPosition.x, hitPosition.y].layer = LayerMask.NameToLayer("Hover");               
            }
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Надав");
                if (gamePieces[hitPosition.x, hitPosition.y] != null)
                {
                    if (true)
                    {
                        currentlyDragging = gamePieces[hitPosition.x, hitPosition.y];
                    }
                }
            }

            if (Input.GetMouseButtonUp(0) && currentlyDragging != null)
            {
                Vector2Int previousPosition = new Vector2Int(currentlyDragging.currentX, currentlyDragging.currentY);

                bool validMove = MoveTo(currentlyDragging, hitPosition.x, hitPosition.y);
                if (!validMove)
                {
                    currentlyDragging.transform.position = GetTileCenter(previousPosition.x, previousPosition.y);
                    currentlyDragging = null;
                }
            }
            else
            {
                if (currentHover == -Vector2Int.one)
                {
                    tiles[currentHover.x, currentHover.y].layer = LayerMask.NameToLayer("Tile");
                    currentHover = -Vector2Int.one;
                }
            }
        }
    }

    


    // Generate the board
    private void GenerateAllTiles(float tileSize, int tileCountX, int tileCountY)
    {
        yOffset += transform.position.y;
        bounds = new Vector3(tileCountX / 2 * tileSize, 0, tileCountX / 2 * tileSize) + boardCenter;

        tiles = new GameObject[tileCountX, tileCountY];
        for (int x = 0; x < tileCountX; x++)
        {
            for (int y = 0; y < tileCountY; y++)
            {
                //if ((0 < x && x < 12 && 0 < y && y < 12) ||
                //    (x == 0 && 4 < y && y < 8) ||
                //    (y == 0 && 4 < x && x < 8) ||
                //    (x == 12 && 4 < y && y < 8) ||
                //    (y == 12 && 4 < x && x < 8))
                    tiles[x, y] = GenerateSingleTile(tileSize, x, y);
            }
        }
    }
    private GameObject GenerateSingleTile(float tileSize, int x, int y)
    {
        GameObject tileObject = new GameObject(string.Format("X:{0}, Y:{1}", x, y));
        tileObject.transform.parent = transform;

        Mesh mesh = new Mesh();
        tileObject.AddComponent<MeshFilter>().mesh = mesh;
        tileObject.AddComponent<MeshRenderer>().material = tileMaterial;

        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector3(x * tileSize, yOffset, y * tileSize) - bounds;
        vertices[1] = new Vector3(x * tileSize, yOffset, (y+1) * tileSize) - bounds;
        vertices[2] = new Vector3((x+1) * tileSize, yOffset, y * tileSize) - bounds;
        vertices[3] = new Vector3((x+1) * tileSize, yOffset, (y + 1) * tileSize) - bounds;

        int[] tris = new int[] { 0, 1, 2, 1, 3, 2 };

        mesh.vertices = vertices;
        mesh.triangles = tris;

        mesh.RecalculateNormals();

        tileObject.layer = LayerMask.NameToLayer("Tile");
        tileObject.AddComponent<BoxCollider>();

        return tileObject;
    }


    //Generate the pirates
    private void SpawnAllPieces()
    {
        gamePieces = new GamePiece[TILE_COUNT_X, TILE_COUNT_Y];

        int whiteTeam = 0, blackTeam = 2, redTeam = 1, blueTeam = 3;

        //WhiteTeam
        gamePieces[5, 0] = SpawnPiece(GamePieceType.Pirate, 0);
        gamePieces[6, 0] = SpawnPiece(GamePieceType.Pirate, 0);
        gamePieces[7, 0] = SpawnPiece(GamePieceType.Pirate, 0);

        //RedTeam
        gamePieces[0, 5] = SpawnPiece(GamePieceType.Pirate, 1);
        gamePieces[0, 6] = SpawnPiece(GamePieceType.Pirate, 1);
        gamePieces[0, 7] = SpawnPiece(GamePieceType.Pirate, 1);

        //BlackTeam
        gamePieces[5, 12] = SpawnPiece(GamePieceType.Pirate, 2);
        gamePieces[6, 12] = SpawnPiece(GamePieceType.Pirate, 2);
        gamePieces[7, 12] = SpawnPiece(GamePieceType.Pirate, 2);

        //BlueTeam
        gamePieces[12, 5] = SpawnPiece(GamePieceType.Pirate, 3);
        gamePieces[12, 6] = SpawnPiece(GamePieceType.Pirate, 3);
        gamePieces[12, 7] = SpawnPiece(GamePieceType.Pirate, 3);
    }

    private GamePiece SpawnPiece(GamePieceType type, int team)
    {
        GamePiece gp = Instantiate(prefabs[(int)type - 1], transform).GetComponent<GamePiece>();

        gp.type = type;
        gp.team = team;
        gp.GetComponent<MeshRenderer>().material = teamMaterials[team];

        return gp;
    }

    //Positioning
    private void PositionAllPieces()
    {
        for (int x = 0; x < TILE_COUNT_X; x++)
            for (int y = 0; y < TILE_COUNT_Y; y++)
                if (gamePieces[x, y] != null)
                    PositionSinglePiece(x, y, true);

    }

    private void PositionSinglePiece(int x, int y, bool force = false)
    {
        gamePieces[x, y].currentX = x;
        gamePieces[x, y].currentY = y;
        gamePieces[x, y].transform.position = GetTileCenter(x,y);
    }

    private Vector3 GetTileCenter(int x, int y)
    {
        return new Vector3(x * tileSize, yOffset, y * tileSize) - bounds + new Vector3(tileSize/2, 0 , tileSize/2);
    }
    // Operations
    private bool MoveTo(GamePiece gp, int x, int y)
    {
        Vector2Int previousPosition = new Vector2Int(gp.currentX, gp.currentY);

        gamePieces[x,y] = gp;
        gamePieces[previousPosition.x, previousPosition.y] = null;

        PositionSinglePiece(x, y);
        return true;
    }
    private Vector2Int LookupTileIndex(GameObject hitInfo)
    {
        for (int x = 0; x < TILE_COUNT_X; x++)
        {
            for (int y = 0; y < TILE_COUNT_Y; y++)
            {
                if (tiles[x, y] == hitInfo)
                    return new Vector2Int(x, y);
            }
        }

        return -Vector2Int.one; // Invalid
    }
}
