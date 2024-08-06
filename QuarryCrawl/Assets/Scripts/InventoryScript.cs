using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public static InventoryScript instance; // SINGLETON
    public int blueCrystals = 0;
    public int purpCrystals = 0;
    public int orangeCrystals = 0;
    public int crystalStorage = 0;
    public int maxCrystalStorage = 100;
    public bool inventoryFull = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this; // SETTING SINGLETON
    }

    public void addToInventory(int crystalType, int amount)
    {
        if (crystalType == 0)
        {
            blueCrystals += amount;
        }
        else if (crystalType == 1)
        {
            purpCrystals += amount;
        }
        else if (crystalType == 2)
        {
            orangeCrystals += amount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (crystalStorage == maxCrystalStorage)
        {
            inventoryFull = true;
        }
        crystalStorage = blueCrystals + purpCrystals + orangeCrystals;
    }
}
