using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Stats stats;

    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float minRotationSpeed, maxRotationSpeed;

    [SerializeField] private GameObject turret;
    [SerializeField] private float turretRotationSpeed;
    [SerializeField] private float turretRotationSpeedMax;

    private Vector2 inputDirection;



    void Start()
    {
        stats = GetComponent<Stats>();
    }


    
    #region Movement Inputs         
    


    #endregion


    //public void RotateTurretLeft(InputAction.CallbackContext context)
    //{
    //    switch (context.phase)
    //    {
    //        case InputActionPhase.Performed:
    //            turretRotationSpeed = -turretRotationSpeedMax;
    //            break;
    //        case InputActionPhase.Canceled:
    //            turretRotationSpeed = 0;
    //            break;
    //    }
    //}
    //
    //public void RotateTurretRight(InputAction.CallbackContext context)
    //{
    //    switch (context.phase)
    //    {
    //        case InputActionPhase.Performed:
    //            turretRotationSpeed = turretRotationSpeedMax;
    //            break;
    //        case InputActionPhase.Canceled:
    //            turretRotationSpeed = 0;
    //            break;
    //    }
    //}

}
