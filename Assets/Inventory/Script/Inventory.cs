using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory/Inventory", order = 1)]
public class Inventory : ScriptableObject
{
    // These ID should be the same.
    public int inventoryID;
    public int ConnectedToPlayerID;

    [SerializeField] private List<InventorySlot> Slots = new List<InventorySlot>();
    

    // Add Items (done through the InventoryManager Script).
    public void AddItem(Item item)
    {
        for (int i = 0; i < Slots.Count; i++)
        {
            InventorySlot slot = Slots[i];
            if(slot.item == null)
            {
                continue;
            }
            else
            {
                if(slot.slotType.ToString() != item.itemType.ToString())
                {
                    continue;
                }
                else
                {
                    slot.item = item;
                }
            }
        }
        Debug.Log("Inventory is full!");
    }
}
