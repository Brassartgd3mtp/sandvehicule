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

    [SerializeField] private InputActionMapManager inputActionMapManager;
    private void Awake()
    {
        UIStatsIsActive = false;
    }

    public void ChangeActionMapForExploring(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                Debug.Log("Exploring");
                inputActionMapManager.playerInput.SwitchCurrentActionMap("Exploring");
                inputActionMapManager.inputMap.Fighting.Disable();
                inputActionMapManager.inputMap.Exploring.Enable();
                break;
        }

    }// Permet de passer sur les contrôles d'exploration
    public void ChangeActionMapForFighting(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                Debug.Log("Fighting");
                inputActionMapManager.playerInput.SwitchCurrentActionMap("Fighting");
                inputActionMapManager.inputMap.Exploring.Disable();
                inputActionMapManager.inputMap.Fighting.Enable();
                break;
        }
    }// permet de passer sur les contrôles de combat

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

    //public void ChangeMode(InputAction.CallbackContext context)
    //{
    //    switch (context.phase) 
    //    {
    //        case InputActionPhase.Performed:
    //            if (playerStates.states == PlayerStates.States.Exploring)
    //            {
    //                playerStates.ChangeStateForFighting();
    //            } else if (playerStates.states == PlayerStates.States.Fifhting)
    //            {
    //                playerStates.ChangeStateForExploring();
    //            }
    //            break;
    //    }
    //}

}
