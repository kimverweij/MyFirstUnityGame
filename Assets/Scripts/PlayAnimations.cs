using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimations : MonoBehaviour
{

    Animator m_Animator;
    // Start is called before the first frame update
    bool isMoving = false;
    string howToMove = "Walk";
    string HowNotToMove = "Run";

    string currentState;

    void Start()
    {
        Debug.Log("Start");
        m_Animator = gameObject.GetComponent<Animator>();
        m_Animator.SetTrigger("Idle");

        currentState = "Idle";
    }



    public void ChangeAnimationState(string newState)
    {
        if(currentState != newState)
        {
            // play new animation 
            StartAnimation(newState, currentState);
            currentState = newState;
        }
    }


    void StartAnimation(string playAnimation, string resetAnimation)
    {
        m_Animator.ResetTrigger(resetAnimation);
        m_Animator.SetTrigger(playAnimation);
    }

        // Update is called once per frame
        void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.M))
        {
            HandleAnimation(true, "Dancing", null);
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            HandleAnimation(false, "Dancing", null);
        }
        */
        /*

      if (Input.GetKeyDown(KeyCode.Space))
      {
          HandleAnimation(true, "Jump", howToMove);

      }


      if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
      {
          howToMove    = "Run";
          HowNotToMove = "Walk";
          HandleAnimation(true, howToMove, HowNotToMove);
      }
      else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
      {
          howToMove    = "Walk";
          HowNotToMove = "Run";
          HandleAnimation(true, howToMove, HowNotToMove);
      }

      if ((Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") > 0) && !isMoving)
      {
          HandleAnimation(true, howToMove, HowNotToMove);
          isMoving = true;
      }
      else if ((Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") < 0) && !isMoving)
      {
          HandleAnimation(true, howToMove, HowNotToMove);
          isMoving = true;
      }
      else if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0 && isMoving)
      {
          HandleAnimation(false,howToMove, HowNotToMove);
          isMoving = false;
      }
      */
    }

    public void StartAnimation(string nameStartAnimation, List<string> resetAnimations)
    {
        Debug.Log("Start animationsss");
        m_Animator.ResetTrigger("Jump");
        m_Animator.SetTrigger("Jump");
    }

    public void ResetAnimation(string nameResetAnimation)
    {
        m_Animator.ResetTrigger("Jump");
    }

    /*
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
    }*/
}


