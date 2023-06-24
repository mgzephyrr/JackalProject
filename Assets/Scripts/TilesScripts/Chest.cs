using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Pirate pirate;
    public TileBoard board;
    public int numberOfMoney;
    public bool isSpawn = false;
    public GameObject money;
    public GameObject MoneyButton;
    public GameObject[] coins;

    void Update()
    {
        if (numberOfMoney != 0)
        {
            if (TileBoard.gamePieces[(int)(gameObject.transform.localPosition.x - 42.5), (int)(gameObject.transform.localPosition.z - 47.5)] != null)
            {
                pirate = TileBoard.gamePieces[(int)(gameObject.transform.localPosition.x - 42.5), (int)(gameObject.transform.localPosition.z - 47.5)].GetComponent<Pirate>();
                if (!isSpawn)
                {
                    money.SetActive(true);
                    isSpawn = true;
                }
                if (pirate.team == (board.turn-board.dopTurn) % 4 && pirate.isCoin == false)
                {
                    MoneyButton.SetActive(true);
                }
                else MoneyButton.SetActive(false);
            }
            else
            {
                MoneyButton.SetActive(false);
            }
        }
    }

 
    public void TakeCoin()
    {
        MoneyButton.SetActive(false);
        pirate.isCoin = true;
        coins[numberOfMoney-1].SetActive(false);
        numberOfMoney--;
        Destroy(gameObject);
    }



}
