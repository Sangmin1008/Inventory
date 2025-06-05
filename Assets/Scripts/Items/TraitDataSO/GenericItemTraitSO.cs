using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericItemTraitSO<T> : ScriptableObject, IItemTrait
{
    [SerializeField] private T data;
    [SerializeField] private GenericEventChannelSO<T> eventChannelSO;
    public void Apply()
    {
        eventChannelSO.Raise(data);
    }

    protected void SetData(T value)
    {
        data = value;
    }
}
