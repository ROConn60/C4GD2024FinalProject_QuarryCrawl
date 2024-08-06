using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour, IInteractable
{
    [SerializeField] private int upgradeType;
    //0 is mining upgrade
    //1 is inventory upgrade
    //2 is speed upgrade

    public void Interact()
    {
        if(upgradeType == 0) //mining speed increase
        {
            Interaction.instance.toolCooldown -= 0.2f;
            //tell interaction script to decrease toolCooldown float
        }
        if(upgradeType == 1)
        {
            InventoryScript.instance.maxCrystalStorage += 50f;
            //tell maxCrystalStorage to increase
        }
        if(upgradeType == 2)
        {
            //access player control script
            //increase speed float
        }
    }


}
