using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO OnInventoryChanged;
    private Inventory _inventory;

    private void Start()
    {
        _inventory = InventoryManager.Instance.Inventory;
    }

    public bool AddItem(string itemID, int quantity = 1)
    {
        for (int i = 0; i < _inventory.Slots.Count; i++)
        {
            var slot = _inventory.Slots[i];
            if (slot.ItemId == itemID)
            {
                _inventory.Slots[i] = slot + (slot.ItemId, quantity);
                OnInventoryChanged?.Raise();
                return true;
            }
        }
        
        for (int i = 0; i < _inventory.Slots.Count; i++)
        {
            if (_inventory.Slots[i] == InventorySlot.Empty)
            {
                _inventory.Slots[i] = InventorySlot.Empty + (itemID, quantity);
                OnInventoryChanged?.Raise();
                return true;
            }
        }

        Debug.LogWarning("인벤토리 공간 부족");
        return false;
    }

    public bool RemoveItem(string itemID, int quantity = 1)
    {
        for (int i = 0; i < _inventory.Slots.Count; i++)
        {
            var slot = _inventory.Slots[i];
            if (slot.ItemId == itemID)
            {
                try
                {
                    _inventory.Slots[i] = slot - (slot.ItemId, quantity);
                    OnInventoryChanged?.Raise();
                    return true;
                }
                catch (Exception e)
                {
                    Debug.LogError(e.Message);
                    return false;
                }
            }
        }
        
        Debug.LogWarning("제거할 아이템이 없음");
        return false;
    }
    
    public InventorySlot GetSlot(int index)
    {
        if (index >= 0 && index < _inventory.Slots.Count)
            return _inventory.Slots[index];

        Debug.LogWarning("잘못된 인덱스 접근 " + index);
        return InventorySlot.Empty;
    }
}
