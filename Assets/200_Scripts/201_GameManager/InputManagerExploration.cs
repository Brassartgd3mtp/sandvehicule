using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerExploration : MonoBehaviour
{
    public ControllerExploration controllerExploration;
    public InputMap inputMap;
    public Vector2 moveExploration;
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
        moveExploration = inputMap.Exploring.Movement.ReadValue<Vector2>();
        inputX = moveExploration.x; inputY = moveExploration.y;
    }

    public void Accelerate(InputAction.CallbackContext context) // input pour accélérer 
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

    public void Breaking(InputAction.CallbackContext context) // input pour freiner 
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
}
