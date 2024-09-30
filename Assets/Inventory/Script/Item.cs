using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 3)]
public class Item : ScriptableObject
{
    public itemType itemType;
}

// Item types.
public enum itemType
{
    Item
}
