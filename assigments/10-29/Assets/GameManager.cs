using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text bioText;
    public TMP_Text statsText;
    public Image portraitImage;
    public GameObject popUpWindow;

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
        
    }

    public void ClosePopUpWindow()
    {
        popUpWindow.SetActive(false);
    }
}
