using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectObject : MonoBehaviour
{

    private string s_coin = "coin";
    private string s_rosmertaDialog = "rosmerta";

    public TextMeshProUGUI CoinText;
    public GameObject DialogObject;

    public DialogNPC DialogNPC;

    public DialogRosmerta DialogRosmerta;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if (other.CompareTag(s_coin))
        {
            other.gameObject.GetComponent<CoinBehavoir>().CollectCoin();
            CoinText.text = GlobalSettings.instance.CoinsCollected + "x";
            StartCoroutine(hideGameObjectTemporary(GlobalSettings.instance.hideCoinDuration, other.gameObject));
            
            // apply start coroutine here because it does not work properly when game object is disabled.

        }
        else if (other.CompareTag(s_rosmertaDialog))
        {
            DialogObject.SetActive(true);
            DialogNPC.InterActionNPC = true;
            DialogRosmerta.startRosmertaDialog();
        }
    }

    IEnumerator hideGameObjectTemporary(float timeToWait, GameObject gameObject)
    {
        gameObject.SetActive(false);
        Debug.Log("seconds to wait " + timeToWait);
        yield return new WaitForSeconds(timeToWait);
        gameObject.SetActive(true);
    }
}
