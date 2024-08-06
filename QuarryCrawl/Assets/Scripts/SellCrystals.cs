using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellCrystals : MonoBehaviour, IInteractable
{

    public void Interact()
    {
        InventoryScript.instance.RemoveCrystals();
    }
}
