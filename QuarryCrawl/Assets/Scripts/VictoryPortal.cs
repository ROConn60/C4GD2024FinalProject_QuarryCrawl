using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPortal : MonoBehaviour, IInteractable
{
    public GameObject inventory;
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindObjectOfType<InventoryScript>().gameObject;
        menu = GameObject.FindObjectOfType<MenuManager>().gameObject;
    }

    public void Interact()
    {
        if (inventory.GetComponent<InventoryScript>().money >= 250)
        {
            menu.GetComponent<MenuManager>().WinGame();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
