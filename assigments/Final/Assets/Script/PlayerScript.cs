using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpHeight = 5f;
    public float moveSpeed = 5f;
    public float sprintSpeed = 8f;
    public float rotationSpeed = 10f;

    private Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    private void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

      
        movement = new Vector3(horizontal, 0f, vertical).normalized;

       
        if (movement.magnitude > 0.1f)
        {
        
            Vector3 adjustedMovement = new Vector3(-movement.x, movement.y, -movement.z); // Reverse direction

       
            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;

        
            transform.Translate(adjustedMovement * currentSpeed * Time.deltaTime, Space.World);

         
            Quaternion targetRotation = Quaternion.LookRotation(adjustedMovement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }

}
