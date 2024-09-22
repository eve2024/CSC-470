using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneScript : MonoBehaviour
{
    public Terrain terrain;

    public GameObject cameraObject;

     public TMP_Text scoreText;

    int score = 0;
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

        float terrainHeight = terrain.SampleHeight(transform.position);
            if (transform.position.y < terrainHeight) 
            {
            forwardSpeed = 0;
            }

        //Camera position
        Vector3 cameraPosition = transform.position;
        cameraPosition += -transform.forward * 10f;
        cameraPosition += Vector3.up * 8f;
        cameraObject.transform.position = cameraPosition;

        cameraObject.transform.LookAt(transform.position);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            forwardSpeed += 10;
        }

        forwardSpeed -= transform.forward.y * 5 * Time.deltaTime;
        forwardSpeed = Mathf.Max(0, forwardSpeed);

        
    }

    // Detect collision with collectables
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("collectable"))
        {
              score++;

            scoreText.text = "Score: " + score;

            Destroy(other.gameObject);
        }

         else if (other.CompareTag("wall")) 
        {
            // Check to see if we hit a big invisible wall, and if so turn around!
            transform.Rotate(0, 180, 0, Space.World);
        }
    }
}
