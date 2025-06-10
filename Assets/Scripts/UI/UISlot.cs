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
    [SerializeField] private Outline outline;
    
    public int Index;

    public void Render(string itemID, int quantity)
    {
        var itemData = GameManager.Instance.ItemRegistry.GetItem(itemID);

        if (itemData != null)
        {
            itemIcon.sprite = itemData.Icon;
            itemIcon.enabled = true;
            itemQuantity.text = quantity > 0 ? quantity.ToString() : string.Empty;
        }
        else
        {
            itemIcon.enabled = false;
            itemQuantity.text = string.Empty;
        }
    }
    
    public void SetOutlineColor(Color color)
    {
        if (outline != null)
            outline.effectColor = color;
    }
}