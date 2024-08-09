using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashlightScript : MonoBehaviour
{
    public static FlashlightScript instance;
    public Light myLight;
    public float intensity = 3f;
    public float power = 100f;
    public float decayRate = 1f;
    public float minIntensity = 0.75f;
    public bool flashlightOn = false;
    public TMP_Text powerText;
    void Start()
    {
        instance = this;
    }


    public void changeFlashlight()
    {
        if (flashlightOn)
        {
            flashlightOn = false;
        }
        else
        {
            flashlightOn = true;
        }
    }

    void Update()
    {
        powerText.text = Mathf.Floor(power).ToString() + "%";
        if (Input.GetKeyDown(KeyCode.F))
        {
            changeFlashlight();
            MiscSFX.instance.FlashlightSound();
        }
        if (flashlightOn)
        {
            if (power <= 0)
            {
                power = 0;
                myLight.GetComponent<Light>().intensity = intensity * 0.25f;
            }
            else
            {
                myLight.GetComponent<Light>().intensity = (intensity - minIntensity) * power / 100 + minIntensity;
                power -= (Time.deltaTime * decayRate);
            }
        }
        else
        {
            myLight.GetComponent<Light>().intensity = 0;
        }
        
        
    }
}
