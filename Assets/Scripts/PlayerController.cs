using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed = 1f;
    [SerializeField] private float rotSpeed = 25f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Debug.Log(moveHorizontal);
        Debug.Log(moveVertical);

        

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized * speed;

        // Bereken de nieuwe positie van het object
        Vector3 newPosition = rb.position + movement * Time.fixedDeltaTime;

        // Gebruik Vector3.Lerp voor een vloeiende overgang naar de nieuwe positie
        rb.MovePosition(Vector3.Lerp(rb.position, newPosition, 0.5f));

        if (moveHorizontal != 0 || moveVertical != 0)
        {
            float targetAngle = Mathf.Atan2(moveHorizontal, moveVertical) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
            rb.MoveRotation(Quaternion.Lerp(rb.rotation, targetRotation, 0.5f));
        }
    }
}
