using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript2 : MonoBehaviour
{
    public GameManager gm;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnMouseDown()
    {
      gm.snowMan.SetActive(true);
      
    
    }
}
