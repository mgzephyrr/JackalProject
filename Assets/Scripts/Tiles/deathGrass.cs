using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deathGrass : MonoBehaviour
{
    public Sprite death;
    private int numbersWhite = 3;
    private int numbersRed = 3;
    private int numbersBlue = 3;
    private int numbersBlack = 3;
    Image imgObj;

    void Update()
    {
        if (TileBoard.gamePieces[(int)(gameObject.transform.localPosition.x - 42.5), (int)(gameObject.transform.localPosition.z - 47.5)] != null)
        {
            int team = TileBoard.gamePieces[(int)(gameObject.transform.localPosition.x - 42.5), (int)(gameObject.transform.localPosition.z - 47.5)].team;
            string name = "";
            switch (team)
            {
                case 0: //white team
                    {
                        name = "PirateWhite" + (4-numbersWhite).ToString();
                        numbersWhite--;                       
                        break;
                    }
                case 1: //red team
                    {
                        name = "PirateRed" + (4 - numbersRed).ToString();
                        numbersRed--;
                        break;
                    }
                case 2: //black team
                    {
                        name = "PirateBlack" + (4 - numbersBlack).ToString();
                        numbersBlack--;
                        break;
                    }
                case 3: //blue team
                    {
                        name = "PirateBlue" + (4 - numbersBlue).ToString();
                        numbersBlue--;
                        break;
                    }
            }
            var imageGameObject = GameObject.Find(name);
            if (imageGameObject != null)
            {
                var img = imageGameObject.GetComponentInParent<Image>();
                img.sprite = death;
            }
            Destroy(TileBoard.gamePieces[(int)(gameObject.transform.localPosition.x - 42.5), (int)(gameObject.transform.localPosition.z - 47.5)]);
        }
    }
}
