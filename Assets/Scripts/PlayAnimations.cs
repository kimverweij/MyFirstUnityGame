using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimations : MonoBehaviour
{

    Animator m_Animator;
    bool isDancing;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        m_Animator.SetTrigger("Idle");
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.D) ){
            Debug.Log("D is pressed");
            m_Animator.ResetTrigger("Idle");
            m_Animator.SetTrigger("Dancing");

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Debug.Log("D is released");
            m_Animator.SetTrigger("Idle");
            m_Animator.ResetTrigger("Dancing");
        }
    }
}
