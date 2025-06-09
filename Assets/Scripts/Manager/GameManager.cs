using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private VoidEventChannelSO OnInventoryChanged;
    public ItemRegistrySO ItemRegistry;

    protected override void Awake()
    {
        base.Awake();
        ItemRegistry.Init();

        OnInventoryChanged.RegisterListener(UIManager.Instance.InventoryUI.Render);
    }
}
