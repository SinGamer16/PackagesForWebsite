using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    [SerializeField] private GameSettings gameSettings;
    public bool canInteract = false;
    private GameObject[] interactableObjects;
    private float closestObjDist = 10000000;
    private GameObject closestObject = null;

    [SerializeField] private float interactableDistance = 5f;

    void Start()
    {

        interactableObjects = GameObject.FindGameObjectsWithTag("Interactable");
    }
     
    private void GetClosestObj(GameObject Player)
    {
        closestObjDist = Vector3.Distance(Player.transform.GetChild(0).transform.position, closestObject.transform.position);
        float closestObjectDist = closestObjDist;
        foreach (GameObject obj in interactableObjects)
        {
            if (closestObjectDist > Vector3.Distance(Player.transform.GetChild(0).transform.position, obj.transform.position))
            {
                closestObjDist = Vector3.Distance(Player.transform.GetChild(0).transform.position, obj.transform.position);
                closestObjectDist = closestObjDist;
                closestObject = obj.gameObject;
                obj.GetComponent<ClosestInteractableObject>().closest = true;
                continue;
            }
            if (obj != closestObject)
            {
                obj.GetComponent<ClosestInteractableObject>().closest = false;
            }

        }
    }
             
    void Update()
    {
        
        GameObject Player = gameSettings.GetActivePlayer();
        Debug.Log(Player);
        GetClosestObj(Player);

        //Debug.Log(GetClosestObj(Player));
        //Debug.Log(closestObjDist);

        if (closestObjDist <= interactableDistance)
        {
            canInteract = true;
        }
        else
        {
            canInteract = false;
        }
    }
}
