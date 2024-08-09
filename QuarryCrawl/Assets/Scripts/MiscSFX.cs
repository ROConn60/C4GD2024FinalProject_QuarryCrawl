using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscSFX : MonoBehaviour
{
    public static MiscSFX instance;

    public AudioSource source;
    //play donk when mining
    public AudioClip mineDonk;
    //play dink when mining empty crystal vein
    public AudioClip mineDink;
    //play bzzzrp when mining on full inventory
    //play click when flashlight on
    public AudioClip flashClick;
    //play crzzrckhtz when charge flashlight
    public AudioClip zapCharge;
    //maybe play footsteps when walk

    void Start()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    public void MineSound()
    {
        source.PlayOneShot(mineDonk);
    }
    public void MineDinkSound()
    {
        source.PlayOneShot(mineDink);
    }
    public void FlashlightSound()
    {
        source.PlayOneShot(flashClick);
    }
    public void ChargeSound()
    {
        source.PlayOneShot(zapCharge);
    }
}
