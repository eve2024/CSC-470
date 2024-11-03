using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{
    public CharacterController cc;
    public Camera mainCamera; // Reference to the camera

    float rotateSpeed = 90;
    float moveSpeed = 12;
    float jumpVelocity = 8;

    float yVelocity = 0;
    float gravity = -9.8f;
    float fallingTime = 0;

    void Start()
    {
        // No need for initial camera offset; we'll set the camera position in Update.
    }

    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        // --- ROTATION ---
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
            yVelocity = -2; // Small downward force to keep the character grounded
            fallingTime = 0;

            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                yVelocity = jumpVelocity; // Jump when space is pressed
            }
        }

        // --- TRANSLATION ---
        Vector3 amountToMove = transform.forward * moveSpeed * vAxis;
        amountToMove.y += yVelocity; // Include vertical velocity (gravity/jump)
        amountToMove *= Time.deltaTime;
        cc.Move(amountToMove); // Move the character

        // --- CAMERA POSITIONING ---
        if (mainCamera != null)
        {
            // Position the camera behind and above the player
            Vector3 cameraPosition = transform.position;
            cameraPosition += -transform.forward * 10f; // Move back along the player's forward vector
            cameraPosition += Vector3.up * 8f; // Raise the camera up
            mainCamera.transform.position = cameraPosition; // Set the camera position

            // Make the camera look at the player
            mainCamera.transform.LookAt(transform.position);
        }
    }
}
