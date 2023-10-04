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
        CameraScript.ChangeCameraForExploring();
    }

    // permet de changer de states pour les tests avec la touche "²"
    public void ChangeState(InputAction.CallbackContext context)
    {
        if (context.performed && states == PlayerStates.States.Fifhting)
        {
            states = PlayerStates.States.Exploring;
            CameraScript.ChangeCameraForExploring();
            return;
        }
        if (context.performed && states == PlayerStates.States.Exploring)
        {
            states = PlayerStates.States.Fifhting;
            CameraScript.ChangeCameraForFighting();
            return;
        }
    }

}
