using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Place this script into the GameSettings object.

public class InventoryManager : MonoBehaviour
{
    private GameSettings gameSettings;
    private int numOfPlayers;

    [SerializeField] private Inventory InventoryPrefab;

    [Space(10)]
    public List<Inventory> Inventorys;


    private void Awake()
    {
        gameSettings = GetComponent<GameSettings>();
        numOfPlayers = gameSettings.numOfPlayers;
    }

    private void Start()
    {
        // Makes a inventory for each player.
        for(int i = 0; i < numOfPlayers; i++)
        {
            Inventorys.Add(InventoryPrefab);
            Inventorys[i].inventoryID = i;
            Inventorys[i].ConnectedToPlayerID = i;
        }
    }

    // InventoryID is the same as the PlayerID it is connected to.
    public void AddItemToInventory(int InventoryID, Item item)
    {
        Inventorys[InventoryID].AddItem(item);
    }
}
