using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScipt : MonoBehaviour
{
    public GameObject doorCollider;
    private DoorScript doorScript;
    // Start is called before the first frame update
    void Start()
    {
        //doorCollider.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            doorCollider.SetActive(true);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
