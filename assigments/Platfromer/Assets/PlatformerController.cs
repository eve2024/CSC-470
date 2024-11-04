using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{
    public CharacterController cc;
    public Camera mainCamera; 

    float rotateSpeed = 90;
    float moveSpeed = 12;
    float jumpVelocity = 8;

    float yVelocity = 0;
    float gravity = -9.8f;
    float fallingTime = 0;

    void Start()
    {
       
    }

    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        
        transform.Rotate(0, rotateSpeed * hAxis * Time.deltaTime, 0);

        if (!cc.isGrounded) 
        {
            fallingTime += Time.deltaTime;
            if (fallingTime < 0.5f && Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpVelocity;
            }

            if (yVelocity > 0 && Input.GetKeyUp(KeyCode.Space))
            {
                yVelocity = 0;
            }

            yVelocity += gravity * Time.deltaTime;
        }
        else
        {
            yVelocity = -2; 
            fallingTime = 0;

            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                yVelocity = jumpVelocity; 
            }
        }

    
        Vector3 amountToMove = transform.forward * moveSpeed * vAxis;
        amountToMove.y += yVelocity; 
        amountToMove *= Time.deltaTime;
        cc.Move(amountToMove); 

    
        if (mainCamera != null)
        {
      
            Vector3 cameraPosition = transform.position;
            cameraPosition += -transform.forward * 10f; 
            cameraPosition += Vector3.up * 8f;
            mainCamera.transform.position = cameraPosition; 

 
            mainCamera.transform.LookAt(transform.position);
        }
    }


    public GameManager gameManager; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable")) 
        {
            gameManager.CollectPresent(); 
            Destroy(other.gameObject); 
        }
        else if (other.CompareTag("Key")) 
        {
            gameManager.CollectKey(); 
            Destroy(other.gameObject); 
        }
        else if (other.CompareTag("Door"))
        {
            gameManager.TryOpenDoor(); 
        }
    }
}

