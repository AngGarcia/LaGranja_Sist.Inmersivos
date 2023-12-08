using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationSwitcher : MonoBehaviour
{
    [SerializeField]
    private InputActionReference toggleTeleportAction;
    
    [SerializeField]
    private XRRayInteractor teleportInteractor;
    
    [SerializeField]
    private XRDirectInteractor generalInteractor;

    [SerializeField]
    private UnityEvent onPerformAction;

    [SerializeField]
    private UnityEvent onCancelAction;

    void OnEnable()
    {
        toggleTeleportAction.action.started += onPerform;
        toggleTeleportAction.action.canceled += onCancel;
    }

    private void OnDisable()
    {
        toggleTeleportAction.action.started -= onPerform;
        toggleTeleportAction.action.canceled -= onCancel;
    }



    private void onPerform(InputAction.CallbackContext obj)
    {
        if(onPerformAction != null)
        {
            onPerformAction.Invoke();
        }
    }
    private void onCancel(InputAction.CallbackContext obj)
    {
        if (onCancelAction != null)
        {
            onCancelAction.Invoke();
        }
    }
}
