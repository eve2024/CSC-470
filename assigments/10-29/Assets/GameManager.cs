using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public UnitScript selectedUnit;

    public Camera mainCamera;
    public TMP_Text scoreText;
    
    private int score = 0;
    public List<UnitScript> units = new List<UnitScript>();
    public TMP_Text nameText;
    public TMP_Text bioText;
    public TMP_Text statsText;
    public Image portraitImage;
    public GameObject popUpWindow;

    void OnEnable()
    {
        if (GameManager.instance == null){
            GameManager.instance = this;
        } else {
            Destroy(this);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = "Woof";
        bioText.text = "woof";
        statsText.text = "woof";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("ground"))
                {
                    MovePlayer(hit.point);
                }
            }
        }
    }

    void MovePlayer(Vector3 target)
    {
        GameObject player = GameObject.FindGameObjectWithTag("player");
        if (player != null)
        {
            player.GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(target);
        }
    }

    public void Addscore (int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    public void OpenCharacterSheet()
    {
        nameText.text = selectedUnit.unitName;
        bioText.text = selectedUnit.bio;
        statsText.text = selectedUnit.stats;

        popUpWindow.SetActive(true);
      
    }

    public void SelectUnit(UnitScript unit)
    {
         foreach(UnitScript u in units)
        {
            u.selected = false;
            u.bodyRenderer.material.color = u.normalColor;
         }

        selectedUnit = unit;
        unit.selected = true;
        unit.bodyRenderer.material.color = unit.selctedColor;
    }

    public void ClosePopUpWindow()
    {
        popUpWindow.SetActive(false);
    }
}
