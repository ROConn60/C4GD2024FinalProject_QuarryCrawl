using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryScript : MonoBehaviour
{
    public static InventoryScript instance; // SINGLETON
    public int blueCrystals = 0;
    public int purpCrystals = 0;
    public int orangeCrystals = 0;
    public int crystalStorage = 0;
    public int maxCrystalStorage = 100;
    public bool inventoryFull = false;

    public float money;
    public float blueValue;
    public float purpValue;
    public float orangeValue;

    public TMP_Text inventoryText;
    public TMP_Text walletText;

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
        else
        {
            inventoryFull = false;
        }
        crystalStorage = blueCrystals + purpCrystals + orangeCrystals;
        inventoryText.text = blueCrystals.ToString() + " Blue | " + purpCrystals.ToString() + " Purple | " + orangeCrystals.ToString() + " Orange | " + crystalStorage.ToString() + " Total";
        walletText.text = "$" + money.ToString();
    }

    public void RemoveCrystals()
    {
        for (int i = blueCrystals; i > 0; i--)
        {
            blueCrystals -= 1;
            money += blueValue;
        }
        for (int i = purpCrystals; i > 0; i--)
        {
            purpCrystals -= 1;
            money += purpValue;
        }
        for (int i = orangeCrystals; i > 0; i--)
        {
            orangeCrystals -= 1;
            money += orangeValue;
        }

    }
}
