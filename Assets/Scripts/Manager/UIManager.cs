using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UIManager : Singleton<UIManager>
{
    public UIMainMenu MainMenuUI;
    public UIStatus StatusUI;
    public UIInventory InventoryUI;
    
    private Dictionary<UIType, GameObject> _uiMap;

    protected override void Awake()
    {
        base.Awake();
        _uiMap = new Dictionary<UIType, GameObject>()
        {
            { UIType.MainMenu, MainMenuUI.gameObject },
            { UIType.Status, StatusUI.gameObject },
            { UIType.Inventory, InventoryUI.gameObject }
        };
    }

    public void ShowUI(UIType type)
    {
        foreach (var ui in _uiMap.Values)
        {
            ui.SetActive(false);
        }
        
        if (_uiMap.TryGetValue(type, out GameObject targetUI))
            targetUI.SetActive(true);
    }
}
