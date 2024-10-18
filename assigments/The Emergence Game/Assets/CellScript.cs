using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    public Renderer cubeRenderer;

    public bool alive = false;

    public int aliveCount = 0;

    public int xIndex = -1;
    public int yIndex = -1;

    public Color aliveColor;
    public Color deadColor;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        SetColor();

        GameObject gmObj = GameObject.Find("GameManagerObject");
        gameManager = gmObj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        alive = !alive;
        SetColor();

        int neighborCount = gameManager.CountNeighbors(xIndex, yIndex);
        Debug.Log("(" + xIndex + "," + yIndex + "): " + neighborCount);
    }
    public void SetColor() {
         if (alive) {
             cubeRenderer.material.color = aliveColor;
         } else {
             cubeRenderer.material.color = deadColor;
        }
        //cubeRenderer.material.color = Color.HSVToRGB(aliveCount / 75f, 0.6f, 1f);
    }
// if player steps on dead cell they return to starting position, if player steps on alive cell the pattern changes
// if the player steps on a alive cell the pattern changes  
    void OnTriggerEnter(Collider other)
    {
      Debug.Log("Trigger entered by: " + other.name); // Check if player is detected

        if (other.CompareTag("Player"))
        {
            if (!alive)
            {
                other.transform.position = gameManager.playerStartPosition;
                Debug.Log("Player stepped on a dead cell! Resetting position to start.");
            }
            else 
            {
                alive = !alive;
                SetColor();
                gameManager.ChangePattern();
                Debug.Log("Player stepped on an alive cell. Pattern changed.");
            }
            Debug.Log("Stepped on:" + xIndex + " " + yIndex);   
        }
        
    
    }
}
