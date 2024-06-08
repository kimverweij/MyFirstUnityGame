using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public Transform girlTransform;

    public Vector3 offset = new Vector3(0, 2, -2); // Optionele offset van de camera
    public Vector3 rotationOffset = new Vector3(20, 0, 0); // Optionele rotatie offset van de camera
    public float smoothness = 5f;

    public float maxRotationAnglePerFrame = 2.0f;
    // Start is called before the first frame update
    public float rotationStep = 0.5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // Bereken de gewenste positie van de camera (spelerpositie + offset)
            Vector3 targetPosition = target.position + offset;

            // Interpoleer de huidige positie van de camera naar de gewenste positie met een zachte overgang
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5);
            // Pas de positie van de camera aan
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothness);

            Quaternion targetRotation = girlTransform.rotation; //Quaternion.Euler(rotationOffset);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * smoothness);
        }
    }
}
