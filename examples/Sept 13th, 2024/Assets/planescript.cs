using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planescript : MonoBehaviour
{

    float forwardSpeed = 0.01f;
    float xRotationSpeed = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vAxis = Input.GetAxis("Vertical");
        float hAxis = Input.GetAxis("Horizontal");


        transform.Rotate(vAxis, hAxis, 0, Space.Self);
        
        transform.posistion +=  transform.forward * forwardSpeed;
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.CompareTage("collectable"))
        {
            Destroy(other.gameObject);
        }
    }
}
