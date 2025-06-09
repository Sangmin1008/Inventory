using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemQuantity;
    private ItemRegistrySO _itemRegistry;

    private void Start()
    {
        _itemRegistry = GameManager.Instance.ItemRegistry;
    }

    public void Render(string itemID, int quantity)
    {
        var itemData = _itemRegistry.GetItem(itemID);

        if (itemData != null)
        {
            itemIcon.sprite = itemData.Icon;
            itemIcon.enabled = true;
            itemQuantity.text = quantity > 0 ? quantity.ToString() : "";
        }
    }
}