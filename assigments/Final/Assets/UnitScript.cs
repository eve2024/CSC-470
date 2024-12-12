using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UnitScript : MonoBehaviour
{
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
      Debug.Log("hi");
      gm.popUpWindow.SetActive(true);
      gm.snowMan.SetActive(true);
    
    }
}
