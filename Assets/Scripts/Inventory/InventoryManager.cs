using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] private int initialSlotCount = 20;
    [SerializeField] private VoidEventChannelSO OnInventoryChanged;
    public Inventory Inventory { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        Inventory = new Inventory(initialSlotCount);
    }
}
