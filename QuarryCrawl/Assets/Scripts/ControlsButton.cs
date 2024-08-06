using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsButton : MonoBehaviour 
{
    public GameObject StartScreen;
    public GameObject ControlsScreen;

    private Button controls;
    void Start()
    {
        controls = GetComponent<Button>();
        controls.onClick.AddListener(ShowControls);
    }

    public void ShowControls()
    {
        
        StartScreen.SetActive(false);
        ControlsScreen.SetActive(true);
    }
}


