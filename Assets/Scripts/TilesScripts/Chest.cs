using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Pirate pirate;
    public TileBoard board;
    public GameObject MoneyButton;
    public int numberOfMoney;
    public bool isSpawn = false;

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
                pirate = (Pirate)TileBoard.gamePeces[(int)(gameObject.transform.localPosition.x - 42.5), (int)(gameObject.transform.localPosition.z - 47.5)]
                pirate.isCoin = true;
                if (!isSpawn)
                {
                    MoneyButton.SetActive(true);
                    isSpawn = true;
                }
            }
        }
    }
    //public void BringCoin()
    //{
    //    if (numberOfMoney != 0)
    //    {
    //        if (TileBoard.gamePieces[(int)(gameObject.transform.localPosition.x - 42.5), (int)(gameObject.transform.localPosition.z - 47.5)] != null)
    //        {
    //            pirate = (Pirate)TileBoard.gamePieces[(int)(gameObject.transform.localPosition.x - 42.5), (int)(gameObject.transform.localPosition.z - 47.5)];
    //            MoneyButton.SetActive(false);
    //            pirate.isCoin = true;
    //            numberOfMoney--;
    //            if (numberOfMoney != 0)
    //            {
    //                string name = numberOfMoney.ToString() + gameObject.name.Substring(1);
    //                var newGameObject = GameObject.Find(name);
    //                Debug.Log(name);
    //                if (newGameObject != null) newGameObject.SetActive(true);
    //            }
    //            Destroy(gameObject);
    //        }
    //    }
    //    else
    //    {
    //        MoneyButton.SetActive(false);
    //    }
    //}
}
