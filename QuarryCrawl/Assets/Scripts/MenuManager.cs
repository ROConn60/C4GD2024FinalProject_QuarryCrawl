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
    public GameObject WinScreen;
    public GameObject Settings;
    public GameObject shop;
    public Button startbutton;
    public Button controlsbutton1;
    public Button controlsbutton2;
    public Button backbutton;
    public Button backbutton2;
    public Button resumebutton;
    public Button restartbutton;
    public Button settingsbutton;
    public Button settingsbutton2;
    public bool isPaused = false;
    private bool shopOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        startbutton.onClick.AddListener(LoadGame);
        controlsbutton1.onClick.AddListener(ShowControls);
        controlsbutton2.onClick.AddListener(ShowControls);
        backbutton.onClick.AddListener(goback);
        backbutton2.onClick.AddListener(goback);
        resumebutton.onClick.AddListener(continuegame);
        restartbutton.onClick.AddListener(restartgame);
        settingsbutton.onClick.AddListener(settingsscreen);
        settingsbutton2.onClick.AddListener(settingsscreen);
        Time.timeScale = 0f;
    }

    public void WinGame()
    {
        Time.timeScale = 0f;
        HUD.SetActive(false);
        WinScreen.SetActive(true);
        
    }

    public void LoadGame()
    {
        Time.timeScale = 1f;
        HUD.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartScreen.SetActive(false);
    }
    public void settingsscreen()
    {
        StartScreen.SetActive(false);
        PauseMenu.SetActive(false);
        ControlsScreen.SetActive(false);
        Settings.SetActive(true);
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
        Settings.SetActive(false);
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
            if(shopOpen)
            {
                CloseShop();
            }
            else
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
    }
    
    public void OpenShop()
    {
        shop.SetActive(true);
        Time.timeScale = 0f;
        HUD.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        shopOpen = true;
    }

    public void CloseShop()
    {
        shop.SetActive(false);
        Time.timeScale = 1f;
        HUD.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        shopOpen = false;
    }

}
