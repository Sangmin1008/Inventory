using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIItemData : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    
    public void Render(string itemID)
    {
        itemNameText.text = GameManager.Instance.ItemRegistry.GetItem(itemID).ItemName;
        itemDescriptionText.text = GameManager.Instance.ItemRegistry.GetItem(itemID).Description;
    }
}
