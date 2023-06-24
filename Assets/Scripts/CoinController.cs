using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public Pirate pirate;
    public GameObject coin;

    public void Update()
    {
        if (pirate.isCoin == true)
            coin.SetActive(true);

        else
            coin.SetActive(false);
    }
}
