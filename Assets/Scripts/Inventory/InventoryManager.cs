using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] private int initialSlotCount = 1;
    [SerializeField] private VoidEventChannelSO OnInventoryChanged;
    [field:SerializeField] public Inventory Inventory { get; private set; }
    public int InitialSlotCount => initialSlotCount;

    protected override void Awake()
    {
        base.Awake();
        //Inventory = new Inventory(initialSlotCount);
        OnInventoryChanged.RegisterListener(UIManager.Instance.InventoryUI.Render);
    }
}
