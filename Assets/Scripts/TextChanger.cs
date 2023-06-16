using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextChanger : MonoBehaviour
{
    public TileBoard board;
    private TMPro.TMP_Text textMesh;
    // Update is called once per frame
    void Awake()
    {
        textMesh = GetComponent<TMPro.TMP_Text>();
        Debug.Log(textMesh.text);
    }
    void Update()
    {
        if (board.turn%4 == 0)
        {
            textMesh.color = Color.white;
            textMesh.text = "Ход белых";
        }
        if (board.turn % 4 == 1)
        {
            textMesh.color = Color.red;
            textMesh.text = "Ход красных";
        }
        if (board.turn % 4 == 2)
        {
            textMesh.color = Color.gray;
            textMesh.text = "Ход черных";
        }
        if (board.turn % 4 == 3)
        {
            textMesh.color = Color.cyan;
            textMesh.text = "Ход синих";
        }
    }
}
