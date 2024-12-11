using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    private CharacterController characterController;
    public float Speed = 5f;
    public float gravity = 10f;
    public float jumpSpeed = 3f;
    private float directionY;
    private bool canDoubleJump = false;
    public float doubleJumpMultiplier = 1.5f;
    public float rotationSpeed = 10f;
    private Vector3 moveDirection;
    

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
    
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

     
        if (characterController.isGrounded)
        {
           
            directionY = 0f;
            canDoubleJump = true;

            if (Input.GetButtonDown("Jump"))
            {
                directionY = jumpSpeed; 
            }
        }
        else
        {
           
            if (Input.GetButtonDown("Jump") && canDoubleJump)
            {
                directionY = jumpSpeed * doubleJumpMultiplier; 
                canDoubleJump = false; 
            }

            
            directionY -= gravity * Time.deltaTime;
        }
        if (direction.magnitude >= 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            characterController.Move(direction * Speed * Time.deltaTime);

            moveDirection = direction * Speed;
        }

     
        direction.y = directionY;

   
        characterController.Move(direction * Speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("collect"))
        {
            GameManager.Instance.CollectItem(other.name);
            Destroy(other.gameObject);
        }
    }
}



