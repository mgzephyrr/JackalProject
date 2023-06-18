using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.ProBuilder.Shapes;
using System;

public class CoinToShip : MonoBehaviour
{
    private Pirate pirate;
    public int team; 
    void Update()
    {
        if (TileBoard.gamePieces[(int)(gameObject.transform.localPosition.x - 42.5), (int)(gameObject.transform.localPosition.z - 47.5)] != null)
        {
            pirate = TileBoard.gamePieces[(int)(gameObject.transform.localPosition.x - 42.5), (int)(gameObject.transform.localPosition.z - 47.5)].GetComponent<Pirate>();
            if (pirate.isCoin == true)
            {
                ChangeCoin();
            }
        }
    }
    void ChangeCoin()
    {
        team = pirate.team;
        string name = "";
        switch (team)
        {
            case 0: //white team
                {
                    name = "NumberMoneyWhite";
                    break;
                }
            case 1: //red team
                {
                    name = "NumberMoneyRed";
                    break;
                }
            case 2: //black team
                {
                    name = "NumberMoneyBlack";
                    break;
                }
            case 3: //blue team
                {
                    name = "NumberMoneyBlue";
                    break;
                }
        }
        var textGameObject = GameObject.Find(name);
        if (textGameObject != null)
        {
            var text = textGameObject.GetComponentInParent<TMPro.TMP_Text>();
            text.text = (Int32.Parse(text.text) + 1).ToString();
            pirate.isCoin = false;
        }
    }
}
