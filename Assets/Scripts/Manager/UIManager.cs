using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private UIMainMenu mainMenuPanel;
    [SerializeField] private UIStatus statusPanel;
    [SerializeField] private UIInventory inventoryPanel;
    
    private Dictionary<UIType, GameObject> _uiMap;

    protected override void Awake()
    {
        base.Awake();
        _uiMap = new Dictionary<UIType, GameObject>()
        {
            { UIType.MainMenu, mainMenuPanel.gameObject },
            { UIType.Status, statusPanel.gameObject },
            { UIType.Inventory, inventoryPanel.gameObject }
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
