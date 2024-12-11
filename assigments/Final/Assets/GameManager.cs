using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{

    public Transform player;
    public GameObject popUpWindow;
    public TMP_Text popUpText;
    public GameObject instructions;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
    }

  

    public void ClosePopUpWindow()
    {
        popUpWindow.SetActive(false);
    }
    public void ShowInstructions()
    {
        instructions.SetActive(true);
    }
    public void CloseInstructions()
    {
        instructions.SetActive(false);
    }
}
