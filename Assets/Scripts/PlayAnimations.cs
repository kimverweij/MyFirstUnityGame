using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimations : MonoBehaviour
{

    Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        m_Animator.SetTrigger("Idle");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.M))
        {
            HandleAnimation(true, "Dancing", null);
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            HandleAnimation(false, "Dancing", null);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            HandleAnimation(true, "Jump", null);

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            HandleAnimation(false, "Jump", null);
        }

        
        if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") > 0)
        {
            HandleAnimation(true, "Walk", "WalkR");
        }
        else if (Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") < 0)
        {
           // HandleAnimation(true, "WalkR", "Walk");
            HandleAnimation(true, "Walk", "WalkR");
        }
       
    }


    void HandleAnimation(bool startAnimation, string typeAnimation, string reset2ndTrigger)
    {
        if (startAnimation)
        {
            Debug.Log("Start " + typeAnimation);
            m_Animator.ResetTrigger("Idle");
            if (reset2ndTrigger != null) m_Animator.ResetTrigger(reset2ndTrigger);
            m_Animator.SetTrigger(typeAnimation);
        }
        else
        {
            Debug.Log("Stop "+ typeAnimation);
            m_Animator.SetTrigger("Idle");
            m_Animator.ResetTrigger(typeAnimation);
            if (reset2ndTrigger != null) m_Animator.ResetTrigger(reset2ndTrigger);
        }
    }
}


