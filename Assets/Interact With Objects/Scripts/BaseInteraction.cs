using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class BaseInteraction : MonoBehaviour
{
    private Interactable Interactable;
    private ClosestInteractableObject CIO;

    //Variables
    

    private void Start()
    {
        Interactable = transform.parent.GetComponent<Interactable>();
        CIO = GetComponent<ClosestInteractableObject>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (Interactable.canInteract == true)
            {
                if (CIO.closest)
                {
                    
                }
            }
        }
    }

}
