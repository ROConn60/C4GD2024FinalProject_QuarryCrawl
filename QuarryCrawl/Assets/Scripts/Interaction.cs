using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}


public class Interaction : MonoBehaviour
{
    public Transform Interactor;
    public float interactRange;


    void Start()
    {
        
    }

    
    void Update()
    {
        Ray r = new Ray(Interactor.position, Interactor.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                Debug.Log("Interactable");
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    interactObj.Interact();
                }
                
            }
        }
        
    }
}
