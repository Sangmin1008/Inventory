using System;
using UnityEngine.Serialization;

[Serializable]
public struct InventorySlot
{
    public string ItemId;
    public int quantity;
    
    public InventorySlot(string itemId, int quantity)
    {
        ItemId = itemId;
        this.quantity = quantity;
    }

    public static InventorySlot Empty => new InventorySlot(string.Empty, 0);
    
    public static bool operator ==(InventorySlot slot1, InventorySlot slot2)
        => (slot1.ItemId == slot2.ItemId) && (slot1.quantity == slot2.quantity);

    public static bool operator !=(InventorySlot slot1, InventorySlot slot2)
        => !(slot1 == slot2);

    public override bool Equals(object obj)
    {
        if (obj is InventorySlot other)
        {
            return this == other;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ItemId, quantity);
    }
    
    public static InventorySlot operator +(InventorySlot slot, (string itemId, int quantity) pair)
    {
        if (slot == Empty)
        {
            return new InventorySlot(pair.itemId, pair.quantity);
        }
        else
        {
            if (slot.ItemId != pair.itemId)
                throw new Exception("다른 아이템 종류를 더하려고 시도함");

            return new InventorySlot(slot.ItemId, slot.quantity + pair.quantity);
        }
    }
    
    public static InventorySlot operator -(InventorySlot slot, (string itemId, int quantity) pair)
    {
        if (slot.ItemId != pair.itemId)
            throw new Exception("다른 아이템 종류를 빼려고 시도함");

        if (slot.quantity - pair.quantity < 0)
            throw new Exception("슬롯 데이터는 개수를 음수로 가질 수 없음");

        if (slot.quantity - pair.quantity == 0)
            return InventorySlot.Empty;

        return new InventorySlot(slot.ItemId, slot.quantity - pair.quantity);
    }
}