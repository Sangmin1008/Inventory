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

    public void Render(string itemID, int quantity)
    {
        Debug.Log($"아이템 아이디 : {itemID}");
        var itemData = GameManager.Instance.ItemRegistry.GetItem(itemID);

        if (itemData != null)
        {
            itemIcon.sprite = itemData.Icon;
            itemIcon.enabled = true;
            itemQuantity.text = quantity > 0 ? quantity.ToString() : "";
        }
    }
}