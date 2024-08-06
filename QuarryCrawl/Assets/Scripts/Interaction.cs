using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

interface IInteractable
{
    public void Interact();
}


public class Interaction : MonoBehaviour
{
    public Transform Interactor;
    public float interactRange;

    public TMP_Text interactText;

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
                if(hitInfo.collider.gameObject.CompareTag("Interaction"))
                {
                    interactText.text = "Press E";
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        interactObj.Interact();
                    }
                }else if (hitInfo.collider.gameObject.CompareTag("Use Tool"))
                {
                    interactText.text = "Mouse0";
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        interactObj.Interact();
                    }
                }

            }
            else
            {
                interactText.text = " ";
            }
        }
        
    }
}
