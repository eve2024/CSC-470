using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    private CharacterController characterController;

    // move
    public float Speed = 5f;
    public float rotationSpeed = 100f;

    // jump
    public float gravity = 10f;
    public float jumpSpeed = 3f;
    public float doubleJumpMultiplier = 1.5f;

    private Vector3 velocity;
    private bool canDoubleJump = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleMovement();
        HandleJumping();
    }

    private void HandleMovement()
    {
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * verticalInput;

        
        moveDirection = moveDirection.normalized * Speed;

        moveDirection.y = velocity.y;

        characterController.Move(moveDirection * Time.deltaTime);

        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0f)
        {
            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        }
    }

    private void HandleJumping()
    {
        if (characterController.isGrounded)
        {
            velocity.y = 0f;
            canDoubleJump = true;

            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = jumpSpeed;
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump") && canDoubleJump)
            {
                velocity.y = jumpSpeed * doubleJumpMultiplier;
                canDoubleJump = false;
            }

            velocity.y -= gravity * Time.deltaTime; 
        }


        characterController.Move(new Vector3(0, velocity.y, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("collect"))
        {
            GameManager.Instance.CollectItem(other.name);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("bed"))
        {
            if (GameManager.Instance.snowflakeCollected >= 1 && 
                GameManager.Instance.candycaneCollcted >= 1 && 
                GameManager.Instance.bellCollected >= 1)
            {
                GameManager.Instance.WinGame();
            }
        }
    }
}





