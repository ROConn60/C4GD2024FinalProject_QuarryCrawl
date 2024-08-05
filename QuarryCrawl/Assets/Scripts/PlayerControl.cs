using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    Rigidbody rb;
    public float speed;

    public float lookSpeed;
    Vector3 cameraLook;
    Vector3 playerLook;

    public Transform groundChecker;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {
        cameraLook += new Vector3(-Input.GetAxis("Mouse Y") * lookSpeed, Input.GetAxis("Mouse X") * lookSpeed, 0);
        playerLook += new Vector3(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        cameraLook.x = Mathf.Clamp(cameraLook.x, -80, 80);
        Camera.main.transform.eulerAngles = cameraLook;
        transform.eulerAngles = playerLook;

        //forward
        float nextVelocityZ = Input.GetAxisRaw("Vertical") * speed;
        //up down
        float nextVelocityY;
        if(CheckGrounded()) //constant earthquakes
        {
            //nextVelocityY -= 1f;
            Debug.Log("grounded");
        }
        else
        {
            nextVelocityY = rb.velocity.y;
            Debug.Log("no");
        }
        //left right
        float nextVelocityX = Input.GetAxisRaw("Horizontal") * speed;
        //rb.velocity = transform.TransformDirection(nextVelocityX, nextVelocityY, nextVelocityZ);
        

    }

    public bool CheckGrounded()
    {
        return Physics.CheckSphere(groundChecker.position, groundCheckRadius, groundLayer);
    }

}
