using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;


    public GameObject HUD;
    public GameObject StartScreen;
    public GameObject ControlsScreen;
    public GameObject PauseMenu;
    public GameObject GameoverScreen;
    public GameObject shop;
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
        instance = this;
        startbutton.onClick.AddListener(LoadGame);
        controlsbutton1.onClick.AddListener(ShowControls);
        controlsbutton2.onClick.AddListener(ShowControls);
        backbutton.onClick.AddListener(goback);
        resumebutton.onClick.AddListener(continuegame);
        restartbutton.onClick.AddListener(restartgame);
        Time.timeScale = 0f;
    }
    public void LoadGame()
    {
        Time.timeScale = 1f;
        HUD.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartScreen.SetActive(false);
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
    public void Die()
    {
        HUD.SetActive(false);
        GameoverScreen.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameoverScreen.SetActive(false);
        StartScreen.SetActive(true);
    }
    public void continuegame()
    {
        isPaused = !isPaused;
        HUD.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Escape) && !StartScreen.activeInHierarchy)
        {
            isPaused = !isPaused;
            PauseMenu.SetActive(isPaused);
            if (isPaused)
            {
                HUD.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0f;
            }
            else
            {
                HUD.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1f;
            }
               
        }
    }
    
    public void OpenShop()
    {
        shop.SetActive(true);
        Time.timeScale = 0f;
        HUD.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

}
