using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour, IInteractable
{
    [SerializeField] private int upgradeType;
    //0 is mining upgrade
    //1 is inventory upgrade
    //2 is speed upgrade
    [SerializeField] private float price;

    public void Interact()
    {
        if(InventoryScript.instance.money >= price)
        {
            if (upgradeType == 0) //mining speed increase
            {
                Interaction.instance.toolCooldown -= 0.2f;
                //tell interaction script to decrease toolCooldown float
                Debug.Log("Mining Speed Increased");
            }
            if (upgradeType == 1)
            {
                InventoryScript.instance.maxCrystalStorage += 50;
                //tell maxCrystalStorage to increase
                Debug.Log("Inventory Space Increased");
            }
            if (upgradeType == 2)
            {
                PlayerControl.instance.speed += 2f;
                //increase speed float
                Debug.Log("Speed Increased");
            }
            InventoryScript.instance.money -= price;
        }else
        {
            Debug.Log("go make some money");
        }
        
    }


}
