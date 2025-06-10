using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    public void OpenInventory() => UIManager.Instance.ShowUI(UIType.Inventory);
    public void OpenStatus() => UIManager.Instance.ShowUI(UIType.Status);
}
