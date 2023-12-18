using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DelockCam : MonoBehaviour
{
    public InputAction delockAction;
    public PlayerInput playerInput;

    public void Awake()
    {
        delockAction = playerInput.actions["Delock"];
    }
    public void OnEnable()
    {
        delockAction.performed += Delock;
    }

    public void OnDisable()
    {
        delockAction.performed -= Delock;
    }

    public void Delock(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
