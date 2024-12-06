using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject key;
    public GameObject door;
    public Transform player;
    public GameObject popUpWindow;
    public TMP_Text popUpText;
    public GameObject instructions;
    // Start is called before the first frame update
    private bool isKeyCollected = false;
    private bool isDoorLocked = true;
    void Start()
    {
        if (key==null || door==null||player==null)
        {
            Debug.Log("hi");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void CollecteKey()
    {
        isKeyCollected = true;
        Destroy(key);
        Debug.Log("collcted");
    }
  private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isKeyCollected)
            {
                // If the player has the key, destroy the door
                Debug.Log("You have the key! The door disappears.");
                Destroy(door); // Destroy the door
            }
            else
            {
                // If the door is locked, allow the player to walk through it
                Debug.Log("The door is locked, but you can walk through it.");
            }
        }
    }
    private void UnlockDoor()
    {
        isDoorLocked = false;
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
