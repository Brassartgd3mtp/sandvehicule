using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerExploration : MonoBehaviour
{
    public ControllerExploration controllerExploration;
    public InputMap inputMap;
    public Vector2 move;
    public float inputX, inputY;

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
        move = inputMap.Exploring.Movement.ReadValue<Vector2>();
        inputX = move.x; inputY = move.y;
    }

    public void Accelerate(InputAction.CallbackContext context)
    {
        switch (context.phase) 
        {
            case InputActionPhase.Performed:
                controllerExploration.isAccelerating = true;
                break;
            case InputActionPhase.Canceled:
                controllerExploration.isAccelerating = false;
                break;            
        }
    }

    public void Breaking(InputAction.CallbackContext context) 
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                controllerExploration.isBreaking = true;
                break;
            case InputActionPhase.Canceled:
                controllerExploration.isBreaking = false;
                break;
        }
    }

    public void Movement(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                controllerExploration.isMoving = true;
                break;
            case InputActionPhase.Canceled:
                controllerExploration.isMoving = false;
                break;
        }
    }
}
