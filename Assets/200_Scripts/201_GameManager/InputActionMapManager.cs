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

    [SerializeField] private InputManagerFighting inputManagerFighting;
    [SerializeField] private InputManagerExploration inputManagerExploration;

    [SerializeField] private CameraScript cameraScript;

    public void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        inputMap = new InputMap();
        inputManagerExploration.enabled = true;
        inputManagerFighting.enabled = false;

        inputManagerExploration.GetComponent<InputManagerExploration>();
        inputManagerFighting.GetComponent<InputManagerFighting>();
    }

    public void ChangeActionMapForExploring(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                cameraScript.CameraForExploring();
                inputManagerExploration.enabled = true;
                inputManagerFighting.enabled = false;
                playerInput.actions.FindActionMap("Exploring").Enable();
                playerInput.actions.FindActionMap("Fighting").Disable();
                break;
        }

    }// Permet de passer sur les contrôles d'exploration

    public void ChangeActionMapForFighting(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                cameraScript.CameraForFighting();
                inputManagerFighting.enabled = true;
                inputManagerExploration.enabled = false;
                playerInput.actions.FindActionMap("Fighting").Enable();
                playerInput.actions.FindActionMap("Exploring").Disable();
                break;
        }
    }// permet de passer sur les contrôles de combat
}
