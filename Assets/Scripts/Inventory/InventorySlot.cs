using System;

[Serializable]
public struct InventorySlot
{
    public int ItemId;
    public int ItemQuantity;
    
    public InventorySlot(int itemId, int itemQuantity)
    {
        ItemId = itemId;
        ItemQuantity = itemQuantity;
    }

    public static InventorySlot Empty => new InventorySlot(0, 0);
    
    public static bool operator ==(InventorySlot slot1, InventorySlot slot2)
        => (slot1.ItemId == slot2.ItemId) && (slot1.ItemQuantity == slot2.ItemQuantity);

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
        return HashCode.Combine(ItemId, ItemQuantity);
    }
    
    public static InventorySlot operator +(InventorySlot slot, (int itemId, int itemQuantity) pair)
    {
        if (slot == Empty)
        {
            return new InventorySlot(pair.itemId, pair.itemQuantity);
        }
        else
        {
            if (slot.ItemId != pair.itemId)
                throw new Exception("다른 아이템 종류를 더하려고 시도함");

            return new InventorySlot(slot.ItemId, slot.ItemQuantity + pair.itemQuantity);
        }
    }
    
    public static InventorySlot operator -(InventorySlot slot, (int itemId, int itemQuantity) pair)
    {
        if (slot.ItemId != pair.itemId)
            throw new Exception("다른 아이템 종류를 빼려고 시도함");

        if (slot.ItemId <= 0)
            throw new Exception("아이템이 없는데 개수를 뺄 수는 없음");

        if (slot.ItemQuantity - pair.itemQuantity < 0)
            throw new Exception("슬롯 데이터는 개수를 음수로 가질 수 없음");

        if (slot.ItemQuantity - pair.itemQuantity == 0)
            return InventorySlot.Empty;

        return new InventorySlot(slot.ItemId, slot.ItemQuantity - pair.itemQuantity);
    }
}