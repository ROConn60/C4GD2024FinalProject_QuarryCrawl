using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscSFX : MonoBehaviour
{
    public static MiscSFX instance;

    public AudioSource source;
    //play donk when mining
    //play dink when mining empty crystal vein
    //play bzzzrp when mining on full inventory
    //play click when flashlight on
    //play crzzrckhtz when charge flashlight
    //maybe play footsteps when walk

    void Start()
    {
        instane = this;
        source = GetComponent<AudioSource>();
    }
}
