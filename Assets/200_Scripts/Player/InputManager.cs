using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject UIStats;
    [SerializeField] private bool UIStatsIsActive;

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
}
