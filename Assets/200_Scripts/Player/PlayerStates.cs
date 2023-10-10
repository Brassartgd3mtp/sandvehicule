using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStates : MonoBehaviour
{

    public CameraScript CameraScript;
    public AttackManager AttackManager;
    public enum States { Exploring, Fifhting }

    public States states;
    public ParticleSystem projectileProjection;

    void Awake()
    {
        states = States.Exploring;
        AttackManager = GetComponent<AttackManager>();
        
    }

    // permet de changer de states pour les tests avec les touches "& et é"
    public void ChangeStateForFighting(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                states = PlayerStates.States.Fifhting;
                CameraScript.CameraForFighting();
                projectileProjection.Play();
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
                projectileProjection.Stop();
                projectileProjection.Clear();
                
                break;
        }
    }

}
