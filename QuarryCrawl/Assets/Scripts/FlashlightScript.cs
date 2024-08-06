using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    public static FlashlightScript instance;
    public Light myLight;
    public float intensity = 3f;
    public float power = 100f;
    public float decayRate = 1f;
    public float minIntensity = 0.75f;
    void Start()
    {
        instance = this;
    }

    void Update()
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
}
