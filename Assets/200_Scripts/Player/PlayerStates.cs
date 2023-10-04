using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStates : MonoBehaviour
{

    public CameraScript CameraScript;
    public enum States { Exploring, Fifhting }

    public States states;
    void Awake()
    {
        states = States.Exploring;

    }

    // permet de changer de states pour les tests avec les touches "& et é"
    public void ChangeStateForFighting(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                states = PlayerStates.States.Fifhting;
                CameraScript.CameraForFighting();
                break;
        };
    }

    public void ChangeStateForExploring(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                states = PlayerStates.States.Exploring;
                CameraScript.CameraForExploring();
                break;
        }
    }

}
