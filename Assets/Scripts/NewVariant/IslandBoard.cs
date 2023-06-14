using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandBoard : MonoBehaviour
{
    //Логика
    private const int TILE_COUNT_X = 13;
    private const int TILE_COUNT_Y = 13;
    private GameObject[,] tiles;
    private void Awake()
    {
        GenerateAllTiles(1, TILE_COUNT_X, TILE_COUNT_Y);
    }
    private void GenerateAllTiles(float tileSize, int tileCountX, int tileCountY)
    {
        tiles = new GameObject[tileCountX, tileCountY];
        for (int x = 0; x < tileCountX; x++)
            for (int y = 0; y < tileCountY; y++)
                tiles[x, y] = GenerateSimpleTile(tileSize, x, y);
    }

    private GameObject GenerateSimpleTile(float tileSize, int x, int y)
    {
        GameObject tileObject = new GameObject(string.Format($"X:{x} Y:{y}"));
        tileObject.transform.parent = transform;

        return tileObject;
    }
}
