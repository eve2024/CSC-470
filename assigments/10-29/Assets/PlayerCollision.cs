using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("food"))
        {
            GameManager.instance.Addscore(2);
            Destroy(other.gameObject);
        } 
        else if (other.CompareTag("trash"))
        {
            GameManager.instance.Addscore(-1);
            Destroy(other.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
