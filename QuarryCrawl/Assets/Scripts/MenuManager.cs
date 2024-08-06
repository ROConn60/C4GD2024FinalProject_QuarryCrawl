using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject StartScreen;
    public GameObject ControlsScreen;
    public GameObject PauseMenu;
    public GameObject GameoverScreen;
    public Button startbutton;
    public Button controlsbutton1;
    public Button controlsbutton2;
    public Button backbutton;
    public Button resumebutton;
    public Button restartbutton;
    public bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        startbutton.onClick.AddListener(LoadGame);
        controlsbutton1.onClick.AddListener(ShowControls);
        controlsbutton2.onClick.AddListener(ShowControls);
        backbutton.onClick.AddListener(goback);
        resumebutton.onClick.AddListener(continuegame);
        restartbutton.onClick.AddListener(restartgame);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ShowControls()
    {
        PauseMenu.SetActive(false);
        StartScreen.SetActive(false);
        ControlsScreen.SetActive(true);
    }
    public void goback()
    {
        ControlsScreen.SetActive(false);
        if (isPaused)
        {
            PauseMenu.SetActive(true);
        }
        else
        {
            StartScreen.SetActive(true);
        }
    }
    public void restartgame()
    {
        GameoverScreen.SetActive(false);
        StartScreen.SetActive(true);
    }
    public void continuegame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            PauseMenu.SetActive(isPaused);
            if (isPaused)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
               
        }
    }
    
}
