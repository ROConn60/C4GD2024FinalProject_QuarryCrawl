using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerLook : MonoBehaviour
{
    public float lookSpeed;
    Vector3 look;

    void Update()
    {
        look += new Vector3(-Input.GetAxis("Mouse Y") * lookSpeed, Input.GetAxis("Mouse X") * lookSpeed, 0);
        look.x = Mathf.Clamp(look.x, -80, 80);
        transform.eulerAngles = look;
    }
}
