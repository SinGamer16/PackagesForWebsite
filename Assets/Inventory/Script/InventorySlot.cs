using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Slot", menuName = "Inventory/Slot", order = 2)]
public class InventorySlot : ScriptableObject
{
    public slotType slotType;
    public Item item;

}

// Slot Types
public enum slotType
{
    Item
}
