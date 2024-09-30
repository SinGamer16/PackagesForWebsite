using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class DoorInteraction : MonoBehaviour
{
    private Interactable Interactable;
    private ClosestInteractableObject CIO;

    //Variables
    private bool doorActive = false;
    private Vector3 start;
    private Vector3 end;
    [SerializeField] private float offset;
    [SerializeField] private float speed;
    private Transform door;

    private void Start()
    {
        door = transform.GetChild(0).transform;
        Interactable = transform.parent.GetComponent<Interactable>();
        CIO = GetComponent<ClosestInteractableObject>();

        start = transform.position;
        end = transform.position + (Vector3.up * offset);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (Interactable.canInteract == true)
            {
                if (CIO.closest)
                {
                    if (doorActive) { doorActive=false; } else { doorActive=true; }
                }
            }
        }

        if (doorActive == true)
        {
            door.position = Vector3.Lerp(door.position, end, speed * Time.deltaTime);
        }
        else
        {
            door.position = Vector3.Lerp(door.position, start, speed * Time.deltaTime);
        }

    }

}
