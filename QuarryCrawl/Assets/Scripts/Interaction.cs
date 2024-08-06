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
    public static Interaction instance;

    public Transform Interactor;
    public float interactRange;

    public TMP_Text interactText;

    private float toolRefresh;
    public float toolCooldown = 1f;

    void Start()
    {
        instance = this;
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
                    if (Input.GetKey(KeyCode.Mouse0) && toolRefresh <= 0f)
                    {
                        interactObj.Interact();
                        toolRefresh = toolCooldown;
                    }
                }

            }
            else
            {
                interactText.text = " ";
            }

        }
        else
        {
            interactText.text = " ";
        }
        if (toolRefresh > 0)
        {
            toolRefresh -= Time.deltaTime;
        }
    }
}
