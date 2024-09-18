using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{

    public GameObject cameraObject;
    // These variables will control how the plane moves
    float forwardSpeed = 12f;
    float xRotationSpeed = 90f; 
    float yRotationSpeed = 90f; 

    float boostTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vAxis = Input.GetAxis("Vertical"); 
        float hAxis = Input.GetAxis("Horizontal"); 

        Vector3 amountToRotate = new Vector3(0, 0, 0);
        amountToRotate.x = vAxis * xRotationSpeed;
        amountToRotate.y = hAxis * yRotationSpeed;
        amountToRotate *= Time.deltaTime;
        transform.Rotate(amountToRotate, Space.Self);

    
        transform.position += transform.forward * forwardSpeed * Time.deltaTime;

        //Camera position
        Vector3 cameraPosition = transform.position;
        cameraPosition += -transform.forward * 10f;
        cameraPosition += Vector3.up * 8f;
        cameraObject.transform.position = cameraPosition;

        cameraObject.transform.LookAt(transform.position);
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
