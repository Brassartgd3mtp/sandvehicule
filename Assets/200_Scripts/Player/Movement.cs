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

    [SerializeField] private float targetSteerAngle = 45;
    [SerializeField] private float turnSpeed = 5f;

    [SerializeField] private GameObject turret;
    [SerializeField] private float turretRotationSpeed;
    [SerializeField] private float turretRotationSpeedMax;

    [SerializeField] private WheelCollider[] frontWheels;
    [SerializeField] private int Torque;
    [SerializeField] private int counterTorque;

    private Rigidbody rb;

    [SerializeField] private Vector2 inputDirection;

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

            LerpToSteerAngle();

            //for (int i = 0; i < frontWheels.Length; i++) // Permet d'augmenter la vitesse avec les 2 roues avant 
            //{
            //    frontWheels[i].steerAngle = targetSteerAngle * inputDirection.x;
            //}
        }

        // Using turret if player is in "Fighting" State  
        if (playerStates.states == PlayerStates.States.Fifhting)
        {
            turret.transform.Rotate(Vector3.up * turretRotationSpeed * Time.deltaTime);
        }
    }
    #region Movement Inputs 
    
    public void Move(InputAction.CallbackContext context)
    {
        inputDirection = context.ReadValue<Vector2>();
    }

    private void LerpToSteerAngle()
    {
        for (int i = 0; i < frontWheels.Length; i++)
        {
            frontWheels[i].steerAngle = Mathf.MoveTowards(frontWheels[i].steerAngle, targetSteerAngle * inputDirection.x, Time.deltaTime * turnSpeed);
        }
    }
    
    public void MoveForward(InputAction.CallbackContext context)
    {
        //switch (context.phase)
        //{
        //    case InputActionPhase.Performed:
        //        speed = 10f;
        //        break;
        //    case InputActionPhase.Canceled:
        //        speed = 0; break;
        //}
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                for (int i = 0; i < frontWheels.Length; i++)
                {
                    frontWheels[i].brakeTorque = 0;
                }
                ApplyTorque(Torque); 
                break;
            case InputActionPhase.Canceled:
                
                ApplyTorque(0); 
                for (int i = 0; i < frontWheels.Length; i++)
                {
                    frontWheels[i].brakeTorque = counterTorque;
                }
                break;
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

    void ApplyTorque(float _value)
    {
        for (int i = 0; i < frontWheels.Length; i++)
        {
            frontWheels[i].motorTorque = _value;
        }
    }

    #region Rotation Tourelle
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
    #endregion 


}
