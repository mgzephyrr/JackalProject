using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Pirate pirate;
    public GameObject MoneyButton;

    void Start()
    {
        MoneyButton.SetActive(false);
    }
    void Update()
    {
        if (TileBoard.gamePieces[(int)(gameObject.transform.localPosition.x - 42.5), (int)(gameObject.transform.localPosition.z - 47.5)] != null)
        {
            pirate = TileBoard.gamePieces[(int)(gameObject.transform.localPosition.x - 42.5), (int)(gameObject.transform.localPosition.z - 47.5)].GetComponent<Pirate>();
            MoneyButton.SetActive(true);
        }
        else
        {
            MoneyButton.SetActive(false);
        }
    }
}
