using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class InputManagerFighting : MonoBehaviour
{
    public InputMap inputMap;

    public Vector2 moveFighting;
    public float inputX, inputY;

    public ControllerFighting controllerFighting;
    public void Awake()
    {
        inputMap = new InputMap();
    }
    public void OnEnable()
    {
        inputMap.Enable();
    }
    public void OnDisable()
    {
        inputMap.Disable();
    }

    public void Update()
    {
        moveFighting = inputMap.Fighting.Move.ReadValue<Vector2>();
        inputX = moveFighting.x; inputY = moveFighting.y;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                controllerFighting.isMoving = true;
                break;
            case InputActionPhase.Canceled:
                controllerFighting.isMoving = false;
                break;
        }
    }
}
