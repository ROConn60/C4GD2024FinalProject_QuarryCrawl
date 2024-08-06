using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour, IInteractable
{
    [SerializeField] private int crystalType;
    //0 = blue
    //1 = purple
    //2 = orange

    public float maxVeinSize;
    public float crystalsLeft;

    public GameObject inventory;

    private float replenishCountdown;

    void Start()
    {
        inventory = GameObject.FindObjectOfType<InventoryScript>().gameObject;
    }

    void Update()
    {
        if(crystalsLeft == 0f)
        {
            replenishCountdown -= Time.deltaTime;
            if(replenishCountdown < 0f)
            {
                Replenish();
            }
        }else
        {
            replenishCountdown = 30f;
        }
    }

    public void Interact()
    {
        if(!inventory.GetComponent<InventoryScript>().inventoryFull)
        {
            if (crystalsLeft > 0f)
            {
                int crystalsMined = Random.Range(1, 6);
                if(inventory.GetComponent<InventoryScript>().crystalStorage + crystalsMined > inventory.GetComponent<InventoryScript>().maxCrystalStorage)
                {
                    crystalsMined = inventory.GetComponent<InventoryScript>().maxCrystalStorage - inventory.GetComponent<InventoryScript>().crystalStorage;
                }
                inventory.GetComponent<InventoryScript>().addToInventory(crystalType, crystalsMined);
                crystalsLeft -= 1f;
            }
            else
            {
                //display "vein empty" or something
            }
        }
        else
        {
            //display "inventory full" or something
        }
        
    }

    private void Replenish()
    {
        crystalsLeft = maxVeinSize;
    }
}
