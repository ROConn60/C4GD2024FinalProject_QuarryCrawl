using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batteries : MonoBehaviour, IInteractable
{
    public GameObject flashlight;

    public void Interact()
    {
        flashlight.GetComponent<FlashlightScript>().power = 100;
        MiscSFX.instance.ChargeSound();
        Debug.Log("Power reset");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
