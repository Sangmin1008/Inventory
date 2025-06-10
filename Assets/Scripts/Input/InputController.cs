using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class InputController : MonoBehaviour
{
    [SerializeField] private Vector2EventChannelSO OnLook;
    [SerializeField] private VoidEventChannelSO OnInteract;

    public void OnLookInput(InputAction.CallbackContext context)
    {
        Vector2 mouseDelta = context.ReadValue<Vector2>();
        //OnLook.Raise(mouseDelta);
    }
    
    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            OnInteract?.Raise();
        }
    }
}