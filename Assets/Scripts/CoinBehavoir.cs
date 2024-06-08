using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavoir : MonoBehaviour
{

    private GameObject coinObject;

    // Start is called before the first frame update
    void Start()
    {
        coinObject = GetComponent<GameObject>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectCoin()
    {
        Debug.Log("Coin collected!");
        GlobalSettings.instance.CoinsCollected++;
        
        // play sound
        // hide coin for x period
        // add + 1 coin to UI
        // show coin again
    }

    public void ResetCoin()
    {
        gameObject.SetActive(true);
    }
}
