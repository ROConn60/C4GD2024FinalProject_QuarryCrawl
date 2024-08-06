using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScript : MonoBehaviour
{
    public GameObject player;
    public float holdTime = 0f;
    public float miningSpeed = 1f;
    public float mineTime = 3f;
    public bool keyHeld = false;
    public bool inRange = false;
    public float miningRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (keyHeld && Vector3.Distance(transform.position, player.transform.position) < miningRange)
        {
            holdTime += Time.deltaTime;
        }
        else
        {
            holdTime = 0;
            keyHeld = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            keyHeld = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            keyHeld = false; ;
        }
        if (holdTime > mineTime)
        {
            Destroy(gameObject);
        }



    }
}
