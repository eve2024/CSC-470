using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    // These variables will control how the plane moves
    float forwardSpeed = 0.1f;
    float xRotationSpeed = 0.2f; 
    float yRotationSpeed = 0.2f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vAxis = Input.GetAxis("Vertical"); 
        float hAxis = Input.GetAxis("Horizontal"); 

        
        transform.Rotate(vAxis * xRotationSpeed, hAxis * yRotationSpeed, 0, Space.Self);

        
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
