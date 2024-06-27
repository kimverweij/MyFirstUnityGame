using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC : MonoBehaviour
{

    public GameObject DialogHolder;
    public GameObject ActionHolder;


    // is set to true when player is in range of NPC
    private bool interActionNPC = false;
    public bool InterActionNPC
    {
        get { return interActionNPC; }
        set { interActionNPC = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && interActionNPC) 
        {
            Debug.Log("Start dialog");
            startDialog();
        }
    }

    void startDialog()
    {
        DialogHolder.SetActive(true);
        ActionHolder.SetActive(false);
    }
}
