using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewShop : MonoBehaviour
{
    [SerializeField] private int upgradeType;
    //0 is mining upgrade
    //1 is inventory upgrade
    //2 is speed upgrade
    [SerializeField] private float price;
    [SerializeField] private float degree;


    public GameObject baggedItem;

    void Start()
    {
        baggedItem.SetActive(false);
    }

    public void Buy()
    {
        if (InventoryScript.instance.money >= price)
        {
            if (upgradeType == 0) //mining speed increase
            {
                Interaction.instance.toolCooldown -= degree;

                //tell interaction script to decrease toolCooldown float
                Debug.Log("Mining Speed Increased");
            }
            if (upgradeType == 1)
            {
                InventoryScript.instance.maxCrystalStorage += (int)degree;

                //tell maxCrystalStorage to increase
                Debug.Log("Inventory Space Increased");
            }
            if (upgradeType == 2)
            {
                PlayerControl.instance.speed += degree;
                //increase speed float
                Debug.Log("Speed Increased");

            }
            InventoryScript.instance.money -= price;
            baggedItem.SetActive(true);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("go make some money");
        }

    }
}
