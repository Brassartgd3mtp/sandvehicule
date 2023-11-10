using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionMapManager : MonoBehaviour
{
    public PlayerInput playerInput;
    public InputMap inputMap;
    public InputActionMap currentActionMap;


    public void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        inputMap = new InputMap();
        inputMap.Fighting.Enable();
    }
}
