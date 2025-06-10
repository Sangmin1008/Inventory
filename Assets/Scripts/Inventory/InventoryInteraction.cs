using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryInteraction : MonoBehaviour
{
    [SerializeField] private GraphicRaycaster graphicRaycaster;
    [SerializeField] private InventoryController inventoryController;
    
    [Header("Event Channels")]
    [SerializeField] private VoidEventChannelSO OnInteract;
    [SerializeField] private Vector2EventChannelSO OnLook;
    [SerializeField] private VoidEventChannelSO OnStatusChanged;

    
    private PointerEventData _pointerEventData;
    private List<RaycastResult> _results = new List<RaycastResult>();
    private Vector2 _mouse;
    
    private void Awake()
    {
        _pointerEventData = new PointerEventData(EventSystem.current);
    }

    private void OnEnable()
    {
        OnInteract.RegisterListener(HandleClick);
        //OnLook.RegisterListener(GetMousePosition);
    }

    private void OnDisable()
    {
        OnInteract.UnregisterListener(HandleClick);
        OnLook.UnregisterListener(GetMousePosition);
    }


    private void GetMousePosition(Vector2 pos)
    {
        _mouse = pos;
    }
    
    private void HandleClick()
    {
        if (!TryRaycastSlotUI(out UISlot slotUI))
        {
            Debug.LogWarning("아이템 슬롯 검출 실패");
            return;
        }
            

        var slotData = inventoryController.GetSlot(slotUI.Index);
        if (slotData == InventorySlot.Empty)
        {
            Debug.LogWarning("아이템 데이터 Empty");
            return;
        }
            
        Debug.Log($"아이템 검출 {slotData.ItemId}");
        //inventoryController.RemoveItem(slotData.ItemId, 1);
        // TODO 해당 아이템을 들고와서 ItemUse를 사용하기

        UseItem(slotData.ItemId);
    }

    private bool TryRaycastSlotUI(out UISlot slotUI)
    {
        _results.Clear();
        var pointerEventData = new PointerEventData(EventSystem.current)
        {
            position = Mouse.current.position.ReadValue()
        };
        graphicRaycaster.Raycast(pointerEventData, _results);

        foreach (var result in _results)
        {
            Debug.Log($"Raycast hit: {result.gameObject.name}");
            if (result.gameObject.TryGetComponent(out slotUI))
                return true;
        }

        slotUI = null;
        return false;
    }

    private void UseItem(string itemID)
    {
        inventoryController.UseItem(itemID);
        OnStatusChanged.Raise();
    }
}
