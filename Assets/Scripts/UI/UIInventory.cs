using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private UISlot slotUIPrefab;
    [SerializeField] private GameObject inventoryUIContent;

    private List<UISlot> _slots;

    public void Render()
    {
        
    }
}
