using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType   { Resource, Consumable, Weapon, Armor }
[CreateAssetMenu(fileName = "NewGenericItemData", menuName = "Scriptable Objects/Item/Generic Item Data")]
public class GenericItemDataSO : ScriptableObject
{
    [Header("Identity")]
    [SerializeField] private string itemID;
    [SerializeField] private string itemName;
    [SerializeField] [TextArea] private string description;
    [SerializeField] private Sprite icon;

    [Header("Classification")]
    [SerializeField] private ItemType type;
    [SerializeField] private int maxStack = 1;

    [Header("Trait")]
    [SerializeField] private List<ScriptableObject> traits;

    public string ItemID => itemID;
    public string ItemName => itemName;
    public string Description => description;
    public Sprite Icon => icon;
    public ItemType ItemType => type;
    public int MaxStack => maxStack;

    public void UseItem()
    {
        foreach (var trait in traits)
        {
            if (trait is IItemTrait itemTrait)
            {
                itemTrait.Apply();
            }
        }
    }
}
