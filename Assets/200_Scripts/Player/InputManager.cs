using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private UnityEngine.GameObject UIStats;
    [SerializeField] private bool UIStatsIsActive;

    [SerializeField] private Harpoon harpoon;
    [SerializeField] private StickAndOrbite stickAndOrbite;

    [SerializeField] private PlayerStates playerStates;

    public void Start()
    {
        UIStatsIsActive = false;
    }

    public void OpenUIStats(InputAction.CallbackContext context) // Permet d'ouvrir et fermer la fenêtre de stats du véhicule
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                if(UIStatsIsActive == false) 
                {
                    UIStats.SetActive(true);
                    UIStatsIsActive = true;
                }
                else
                {
                    UIStats.SetActive(false);
                    UIStatsIsActive = false;
                }
                break;

        }        

    }

    public void ThrowHarpoon(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                if (harpoon.harpoonIsReady == true)
                {
                    harpoon.shootHarpoon();
                }
            break;
        }


    }

    public void ForceHarpoonBack(InputAction.CallbackContext context)
    {
        switch (context.phase) 
        {
            case InputActionPhase.Performed:
                stickAndOrbite.isOrbited = false;
                harpoon.isShooted = false;
                harpoon.harpoonReadyToBack = true;
                break;
        }
    }

    public void ChangeMode(InputAction.CallbackContext context)
    {
        switch (context.phase) 
        {
            case InputActionPhase.Performed:
                if (playerStates.states == PlayerStates.States.Exploring)
                {
                    playerStates.ChangeStateForFighting();
                } else if (playerStates.states == PlayerStates.States.Fifhting)
                {
                    playerStates.ChangeStateForExploring();
                }
                break;
        }
    }

}
