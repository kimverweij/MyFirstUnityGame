using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogRosmerta : MonoBehaviour
{

    public List<string> ListObjective1 = new List<string>();
    public string HintObjective1;

    public TextMeshProUGUI textDialog;

    private int pageDialog       = 0;
    private int currentObjective = 1;

    public Button InteractebleDialogObject;
  

    // Start is called before the first frame update
    void Start()
    {
        InteractebleDialogObject.onClick.AddListener(startRosmertaDialog);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startRosmertaDialog()
    {
        if(ListObjective1.Count > pageDialog)
        {
            textDialog.text = ListObjective1[pageDialog];
            pageDialog++;
        }
        else
        {
            textDialog.text = HintObjective1;
        }
        
    }
}
