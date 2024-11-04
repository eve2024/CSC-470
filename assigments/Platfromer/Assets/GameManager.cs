using UnityEngine;
using TMPro; // For TextMeshPro support

public class GameManager : MonoBehaviour
{
    public int presentCount = 0; 
    public bool hasKey = false; 
    public GameObject door; 
    public TMP_Text presentCountText;
    public TMP_Text timerText; 

    public float countdownTime = 60f; 
    private float timeRemaining;
    private bool timerIsRunning = false;

    void Start()
    {
       
        timeRemaining = countdownTime;
        timerIsRunning = true;
        UpdatePresentCountText();
        UpdateTimerText(); 
    }

    void Update()
    {
       
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; 
                UpdateTimerText(); 
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                GameOver(); 
            }
        }
    }

   
    void UpdateTimerText()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
        }
    }

    
    void GameOver()
    {
        Debug.Log("Game Over! Time ran out.");
       
    }

   
    public void UpdatePresentCountText()
    {
        if (presentCountText != null)
        {
            presentCountText.text = "Presents: " + presentCount.ToString();
        }
    }

    public void CollectPresent()
    {
        presentCount++;
        Debug.Log("Presents collected: " + presentCount);
        UpdatePresentCountText();

        if (presentCount >= 5)
        {
            Debug.Log("All presents collected!");
            
        }
    }

    public void CollectKey()
    {
        hasKey = true;
        Debug.Log("Key collected!");
    }

    public void TryOpenDoor()
    {
        if (hasKey)
        {
            Debug.Log("Door opened!");
            
        }
        else
        {
            Debug.Log("You need a key to open this door.");
        }
    }
}



