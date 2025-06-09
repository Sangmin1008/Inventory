using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Inventory
{
    public List<InventorySlot> Slots;
    
    public Inventory(int slotNum)
    {
        Slots = new List<InventorySlot>(slotNum);

        for (int i = 0; i < slotNum; i++)
        {
            Slots.Add(InventorySlot.Empty);
        }
    }
}
