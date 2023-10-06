using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private PlayerStates playerStates;

    private Vector3 movement = Vector3.zero;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float minRotationSpeed, maxRotationSpeed;

    [SerializeField] private GameObject turret;
    [SerializeField] private float turretRotationSpeed;
    [SerializeField] private float turretRotationSpeedMax;

    private Rigidbody rb;

    void Start()
    {
        playerStates = GetComponent<PlayerStates>();
    }

    void FixedUpdate()
    {
        // Movement if the player is in "Exploring" State (ref in script "PlayerState")
        if (playerStates.states == PlayerStates.States.Exploring)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        if (playerStates.states == PlayerStates.States.Fifhting)
        {
            turret.transform.Rotate(Vector3.up * turretRotationSpeed * Time.deltaTime);
        }
    }
    #region Movement Inputs 
    public void MoveForward(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                speed = 10f;
                break;
            case InputActionPhase.Canceled:
                speed = 0; break;
        }
    }

    public void MoveBackward(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                speed = -0.1f;
                break;
            case InputActionPhase.Canceled:
                speed = 0; break;
        }
    }

    public void RotateLeft(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                rotationSpeed = minRotationSpeed;                
                break;
                       
            case InputActionPhase.Canceled:
                rotationSpeed = 0;
                break;  
        }
    }

    public void RotateRight(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                rotationSpeed = maxRotationSpeed;
                break;

            case InputActionPhase.Canceled:
                rotationSpeed = 0;
                break;
        }
    }
    #endregion


    public void RotateTurretLeft(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                turretRotationSpeed = -turretRotationSpeedMax;
                break;
            case InputActionPhase.Canceled:
                turretRotationSpeed = 0;
                break;
        }
    }

    public void RotateTurretRight(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                turretRotationSpeed = turretRotationSpeedMax;
                break;
            case InputActionPhase.Canceled:
                turretRotationSpeed = 0;
                break;
        }
    }

}
