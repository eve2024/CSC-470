using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    //Collect items
    public int snowflakeCollected = 0;
    public int candycaneCollcted = 0;
    public int bellCollected = 0;

    public int totalItems = 3;
    public float timer = 60f;
    public bool isTimerRunning = true;
    
    //UI Elemnts 
    public TMP_Text timerText;
    public TMP_Text collectionText;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject instructionWindow;
    public TMP_Text snowflakeText;
    public TMP_Text candyCaneText;
    public TMP_Text bellText;
    public Transform player;
    public GameObject popUpWindow;
    public TMP_Text popUpText;
    public GameObject instructions;
    public GameObject snowMan;
    public TMP_Text SnowManText;
    // Start is called before the first frame update
    private bool gameWon = false;
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
    private void Update()
    {
        if (isTimerRunning && !gameWon)
        {
            UpdateTimer();
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
    private void UpdateTimer()
    {
        timer -= Time.deltaTime;

        timerText.text = $"Time: {Mathf.Ceil(timer)}";

        if (timer <= 0)
        {
            isTimerRunning = false;
            LoseGame();
        }
    }
    public void CheckWinCondition()
    {
        if (snowflakeCollected >= 1 && candycaneCollcted >=1 & bellCollected >=1)
        {
            Debug.Log("all items collected");
        }
    }
    public void WinGame()
    {
        gameWon = true;
        isTimerRunning = false;
        winScreen.SetActive(true);
    }
    public void LoseGame()
    {
        isTimerRunning = false;
        loseScreen.SetActive(true);
    }
   

    public void ClosePopUpWindow()
    {
        popUpWindow.SetActive(false);
    }
     public void CloseSnowManWindow()
    {
        snowMan.SetActive(false);
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
