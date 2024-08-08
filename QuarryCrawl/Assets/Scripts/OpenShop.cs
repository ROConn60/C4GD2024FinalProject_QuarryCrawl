using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        MenuManager.instance.OpenShop();
    }
}
