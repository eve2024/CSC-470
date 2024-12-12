using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScipt : MonoBehaviour
{
    public GameObject doorCollider;

    // Start is called before the first frame update
    void Start()
    {
        doorCollider.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            doorCollider.SetActive(false);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
