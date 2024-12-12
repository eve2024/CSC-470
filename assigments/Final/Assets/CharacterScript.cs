using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    private CharacterController characterController;

    // move
    public float Speed = 5f;
    public float rotationSpeed = 10f;

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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (direction.magnitude >= 0.1f)
        {
        
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

           
            Vector3 moveDirection = direction * Speed;
            characterController.Move(moveDirection * Time.deltaTime);
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

      
        characterController.Move(velocity * Time.deltaTime);
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




