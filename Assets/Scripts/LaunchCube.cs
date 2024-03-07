using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchCube : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float jumpForce = 5f;
    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = gameObject.GetComponent<Rigidbody>();
        //m_Rigidbody.AddForce(0, 0, m_Thrust, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Als spatiebalk wordt ingedrukt
        {
            Jump(); // Roep de Jump-functie aan
        }
    }

    void Jump()
    {
        m_Rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
