using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour
{
    private Button start;
    // Start is called before the first frame update
    void Start()
    {
        start = GetComponent<Button>();
        start.onClick.AddListener(LoadGame);
    }
   
    // Update is called once per frame
    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    void Update()
    {
       
    }
}
