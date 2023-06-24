using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Pirate pirate;
    public TileBoard board;
    public GameObject MoneyButton;
    public int numberOfMoney;
    public bool isSpawn = false;
    public GameObject money;

    void Start()
    {
        MoneyButton.SetActive(false);
    }
    void Update()
    {
        if (numberOfMoney != 0)
        {
            if (TileBoard.gamePieces[(int)(gameObject.transform.localPosition.x - 42.5), (int)(gameObject.transform.localPosition.z - 47.5)] != null)
            {
                pirate = (Pirate)TileBoard.gamePieces[(int)(gameObject.transform.localPosition.x - 42.5), (int)(gameObject.transform.localPosition.z - 47.5)];
                pirate.isCoin = true;
                if (!isSpawn)
                { 
                    money.SetActive(true);
                    isSpawn = true;
                }
            }
        }
    }

    private void Button()
    {
        if (numberOfMoney != 0)
        {
            if (TileBoard.gamePieces[(int)(gameObject.transform.localPosition.x - 42.5), (int)(gameObject.transform.localPosition.z - 47.5)] != null)
            {
                pirate = TileBoard.gamePieces[(int)(gameObject.transform.localPosition.x - 42.5), (int)(gameObject.transform.localPosition.z - 47.5)].GetComponent<Pirate>();
                if (pirate.team == board.turn % 4 && pirate.isCoin == false)
                {
                    Debug.Log(pirate.currentX.ToString() + " " + pirate.currentY.ToString());
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
    public void BringCoin()
    {
        if (numberOfMoney != 0)
        {
            if (TileBoard.gamePieces[(int)(gameObject.transform.localPosition.x - 42.5), (int)(gameObject.transform.localPosition.z - 47.5)] != null)
            {
                pirate = TileBoard.gamePieces[(int)(gameObject.transform.localPosition.x - 42.5), (int)(gameObject.transform.localPosition.z - 47.5)].GetComponent<Pirate>();
                MoneyButton.SetActive(false);
                pirate.isCoin = true;
                numberOfMoney--;
                if (numberOfMoney != 0)
                {
                    string name = numberOfMoney.ToString() + gameObject.name.Substring(1);
                    var newGameObject = GameObject.Find(name);
                    Debug.Log(name);
                    if (newGameObject != null) newGameObject.SetActive(true);
                }
                Destroy(gameObject);
            }
        }
        else
        {
            MoneyButton.SetActive(false);
        }
    }


}
