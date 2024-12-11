using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int snowflakeCollected = 0;
    public int candycaneCollcted = 0;
    public int bellCollected = 0;
    //UI Elemnts 
    public GameObject instructionWindow;
    public TMP_Text snowflakeText;
    public TMP_Text candyCaneText;
    public TMP_Text bellText;


    public Transform player;
    public GameObject popUpWindow;
    public TMP_Text popUpText;
    public GameObject instructions;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    public void CollectItem(string itemName)
    {
        switch (itemName)
        {
            case "Snowflake":
                snowflakeCollected ++;
                snowflakeText.text = "x Snowflake";
                Debug.Log("snowflake");
                break;

                case "candyCane":
                candycaneCollcted ++;
                candyCaneText.text = "x Candy Cane";
                Debug.Log("candyCane");
                break;

                case "Bell":
                bellCollected ++;
                bellText.text = "x Bell";
                Debug.Log("bells");
                break;
        }
        
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
