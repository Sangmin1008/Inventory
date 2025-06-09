using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private UISlot slotUIPrefab;
    [SerializeField] private Transform inventoryUIContent;

    private List<UISlot> _slots;

    private void Start()
    {
        _slots = new List<UISlot>(InventoryManager.Instance.InitialSlotCount);
        Render();
    }

    public void Render()
    {
        foreach (var slot in _slots)
        {
            Destroy(slot.gameObject);
        }
        _slots.Clear();

        var inventory = InventoryManager.Instance.Inventory;

        for (int i = 0; i < inventory.Slots.Count; i++)
        {
            var slotData = inventory.Slots[i];
            var slotUI = Instantiate(slotUIPrefab, inventoryUIContent);
            slotUI.Render(slotData.ItemId, slotData.Quantity);
            _slots.Add(slotUI);
        }
    }
}
