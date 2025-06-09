using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TextMeshProUGUI _itemQuantity;

    public void Render(int itemId, int itemQuantity)
    {
        //_itemIcon.sprite = ;
        _itemQuantity.text = (itemQuantity > 0) ? "A" : string.Empty;
    }
}
