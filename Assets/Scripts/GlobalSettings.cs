using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{

    public static GlobalSettings instance;

    // static vars
    public readonly float hideCoinDuration = 15f;

    public int CoinsCollected = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

}
