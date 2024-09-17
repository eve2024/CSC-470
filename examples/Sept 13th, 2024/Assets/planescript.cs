using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    // These variables will control how the plane moves
    float forwardSpeed = 0.01f;
    float xRotationSpeed = 0.2f;  // Controls the vertical rotation
    float yRotationSpeed = 0.2f;  // Controls the horizontal rotation

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal"); 
        float vAxis = Input.GetAxis("Vertical"); 

        // Apply rotation using the assigned xRotationSpeed and yRotationSpeed
        transform.Rotate(vAxis * xRotationSpeed, hAxis * yRotationSpeed, 0, Space.Self);

        // Move the plane forward
        transform.position += transform.forward * forwardSpeed;
    }

    // Detect collision with collectables
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("collectable"))
        {
            Destroy(other.gameObject);
        }
    }
}


