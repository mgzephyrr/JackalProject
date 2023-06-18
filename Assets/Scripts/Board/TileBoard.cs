using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class TileBoard : MonoBehaviour // ASSIGN TO TILEBLOCKS
{
    [Header("Art stuff")]
    [SerializeField] private Material tileMaterial;
    [SerializeField] private float tileSize = 1.0f;
    [SerializeField] private float yOffset = 0.05f;
    [SerializeField] private float dragOffset = 1.5f;
    [SerializeField] private Vector3 boardCenter = Vector3.zero;

    [Header("Prefabs && Materials")]
    [SerializeField] public GameObject[] prefabs;
    [SerializeField] private Material[] teamMaterials;

    // LOGIC
    private List<Vector2Int> availableMoves =new List<Vector2Int>();
    private int whiteTeam = 0, blackTeam = 2, redTeam = 1, blueTeam = 3, noneTeam = 4;
    public static GamePiece[,] gamePieces;
    private GamePiece currentlyDragging;
    private const int TILE_COUNT_X = 13;
    private const int TILE_COUNT_Y = 13;
    private GameObject[,] tiles;
    private Camera currentCamera;
    private Vector2Int currentHover;
    private Vector3 bounds;
    public int turn;
    

    private void Awake()
    {
        turn = 0;
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
        if (Physics.Raycast(ray, out info, 100, LayerMask.GetMask("Tile", "Hover", "Highlight")))
        {            
            // Get the indexes of the tile i've hit
            Vector2Int hitPosition = LookupTileIndex(info.transform.gameObject);

            //Debug.Log(currentHover.x + ", " + currentHover.y);
            //Debug.Log(hitPosition.x + ", " + hitPosition.y);

            // If we're hovering a tile after not hovering any tiles
            if (currentHover == -Vector2Int.one)
            {
                currentHover = hitPosition;
                tiles[currentHover.x, currentHover.y].layer = LayerMask.NameToLayer("Hover");
            }

            // If we were already hovering a tile, change the previous one
            if (currentHover != hitPosition)
            {
                if (tiles[currentHover.x, currentHover.y] is not null)
                    tiles[currentHover.x, currentHover.y].layer = (ContainsValidMove(ref availableMoves, currentHover)) ? LayerMask.NameToLayer("Highlight") : LayerMask.NameToLayer("Tile");
                currentHover = hitPosition;
                tiles[hitPosition.x, hitPosition.y].layer = LayerMask.NameToLayer("Hover");               
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (gamePieces[hitPosition.x, hitPosition.y] != null)
                {
                    //твой ход? 
                    if (gamePieces[hitPosition.x, hitPosition.y].team == turn % 4)
                    {
                        currentlyDragging = gamePieces[hitPosition.x, hitPosition.y];

                        //Допустимые для хода клетки
                        availableMoves = currentlyDragging.GetAvailableMoves(ref gamePieces, TILE_COUNT_X, TILE_COUNT_Y);
                        HighlightTiles();
                    }
                }
            }

            if (Input.GetMouseButtonUp(0) && currentlyDragging != null)
            {
                Vector2Int previousPosition = new Vector2Int(currentlyDragging.currentX, currentlyDragging.currentY);

                bool validMove = MoveTo(currentlyDragging, hitPosition.x, hitPosition.y);

                if (!validMove)
                    currentlyDragging.SetPosition(GetTileCenter(previousPosition.x, previousPosition.y));
                currentlyDragging = null;
                RemoveHighlightTiles();
            }
            else
            {
                if (currentHover == -Vector2Int.one)
                {
                    tiles[currentHover.x, currentHover.y].layer = (ContainsValidMove(ref availableMoves, currentHover)) ? LayerMask.NameToLayer("Highlight") : LayerMask.NameToLayer("Tile");
                    currentHover = -Vector2Int.one;
                }

                if (currentlyDragging && Input.GetMouseButtonUp(0))
                {
                    currentlyDragging.SetPosition(GetTileCenter(currentlyDragging.currentX, currentlyDragging.currentY));
                    currentlyDragging = null;
                    RemoveHighlightTiles();
                }
            }
        }
        if (currentlyDragging)
        {
            Plane horizontalPlane = new Plane(Vector3.up, Vector3.up * yOffset);
            float distance = 0.0f;
            if(horizontalPlane.Raycast(ray, out distance))
                currentlyDragging.SetPosition(ray.GetPoint(distance) + Vector3.up * dragOffset);
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

        

        //WhiteTeam
        gamePieces[5, 0] = SpawnPiece(GamePieceType.Pirate, whiteTeam);
        gamePieces[6, 0] = SpawnPiece(GamePieceType.Pirate, whiteTeam);
        gamePieces[7, 0] = SpawnPiece(GamePieceType.Pirate, whiteTeam);

        //RedTeam
        gamePieces[0, 5] = SpawnPiece(GamePieceType.Pirate, redTeam);
        gamePieces[0, 6] = SpawnPiece(GamePieceType.Pirate, redTeam);
        gamePieces[0, 7] = SpawnPiece(GamePieceType.Pirate, redTeam);

        //BlackTeam
        gamePieces[5, 12] = SpawnPiece(GamePieceType.Pirate, blackTeam);
        gamePieces[6, 12] = SpawnPiece(GamePieceType.Pirate, blackTeam);
        gamePieces[7, 12] = SpawnPiece(GamePieceType.Pirate, blackTeam);

        //BlueTeam
        gamePieces[12, 5] = SpawnPiece(GamePieceType.Pirate, blueTeam);
        gamePieces[12, 6] = SpawnPiece(GamePieceType.Pirate, blueTeam);
        gamePieces[12, 7] = SpawnPiece(GamePieceType.Pirate, blueTeam);
    }
    private GamePiece SpawnPiece(GamePieceType type, int team)
    {
        GamePiece gp = Instantiate(prefabs[(int)type - 1], transform).GetComponent<GamePiece>();

        gp.type = type;
        gp.team = team;
        MeshRenderer rend = gp.GetComponent<MeshRenderer>();
        if (rend != null)
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
        gamePieces[x, y].SetPosition(GetTileCenter(x,y), force);
    }
    private Vector3 GetTileCenter(int x, int y)
    {
        return new Vector3(x * tileSize, yOffset, y * tileSize) - bounds + new Vector3(tileSize/2, 0 , tileSize/2);
    }

    //Highlight Tiles
    private void HighlightTiles()
    {
        for (int i = 0;i < availableMoves.Count ; i++)
        {
            tiles[availableMoves[i].x, availableMoves[i].y].layer = LayerMask.NameToLayer("Highlight");
        }
    }
    private void RemoveHighlightTiles()
    {
        for (int i = 0; i < availableMoves.Count; i++)
        {
            tiles[availableMoves[i].x, availableMoves[i].y].layer = LayerMask.NameToLayer("Tile");
        }
        availableMoves.Clear();
    }
    
    // Operations
    private bool ContainsValidMove(ref List<Vector2Int> moves, Vector2 pos)
    {
        for (int i = 0; i<moves.Count; i++)
            if (moves[i].x == pos.x && moves[i].y == pos.y)
                return true;
        return false;
    }
    private bool MoveTo(GamePiece gp, int x, int y, bool isKilled = false)
    {
        Vector2Int previousPosition = new Vector2Int(gp.currentX, gp.currentY);
        if (isKilled)
        {
            if (gamePieces[x, y] != null)
            {
                GamePiece ogp = gamePieces[x, y];

                if (gp.team == ogp.team)
                    return false;
                else
                    RevivePiece(ogp);

            }
            gamePieces[x, y] = gp;
            gamePieces[previousPosition.x, previousPosition.y] = null;

            PositionSinglePiece(x, y);
            return true;
        }

        if (!ContainsValidMove(ref availableMoves, new Vector2(x, y)))
            return false;  
        
        if (gamePieces[x, y] != null)
        {
            GamePiece ogp = gamePieces[x, y];

            if (gp.team == ogp.team)
                return false;
            else
                RevivePiece(ogp);

        }

        gamePieces[x, y] = gp;
        gamePieces[previousPosition.x, previousPosition.y] = null;

        PositionSinglePiece(x, y);
        turn++;//to-do Если пират будет наступать на стрелку, то ход будет меняться дважды, если челоек захочет нажать пробел
        return true;
    }
    private void RevivePiece(GamePiece ogp)
    {
        if (ogp.team == 0)
        {
            if (gamePieces[6, 0] is null)
            {
                MoveTo(ogp, 6, 0,true);
                return;
            }
            if (gamePieces[5, 0] is null)
            {
                MoveTo(ogp, 5, 0, true);
                return;
            }
            if (gamePieces[7, 0] is null)
            {
                MoveTo(ogp, 7, 0, true);
                return;
            }
        }
        if (ogp.team == 1)
        {
            if (gamePieces[0, 6] is null)
            {
                MoveTo(ogp, 0, 6, true);
                return;
            }
            if (gamePieces[0, 5] is null)
            {
                MoveTo(ogp, 0, 5, true);
                return;
            }
            if (gamePieces[0, 7] is null)
            {
                MoveTo(ogp, 0, 7, true);
                return;
            }
        }
        if (ogp.team == 2)
        {
            if (gamePieces[6, 12] is null)
            {
                MoveTo(ogp, 6, 12, true);
                return;
            }
            if (gamePieces[5, 12] is null)
            {
                MoveTo(ogp, 5, 12, true);
                return;
            }
            if (gamePieces[7, 12] is null)
            {
                MoveTo(ogp, 7, 12, true);
                return;
            }
        }
        if (ogp.team == 3)
        {
            if (gamePieces[12, 6] is null)
            {
                MoveTo(ogp, 12, 6, true);
                return;
            }
            if (gamePieces[12, 5] is null)
            {
                MoveTo(ogp, 12, 5, true);
                return;
            }
            if (gamePieces[12, 7] is null)
            {
                MoveTo(ogp, 12, 7, true);
                return;
            }
        }
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

    public void SpawnBear(int x, int y)
    {
        gamePieces[x, y] = SpawnPiece(GamePieceType.Bear, noneTeam);
        PositionSinglePiece(x, y, true);
    }
}
