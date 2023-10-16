using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private PlayerStates playerStates;
    private Stats stats;

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
    [SerializeField] private WheelCollider[] backWheels;
    [SerializeField] private WheelCollider[] wheels;

    [SerializeField] private int Torque;
    [SerializeField] private int counterTorque;

    private Rigidbody rb;

    [SerializeField] private Vector2 inputDirection;

    void Start()
    {
        playerStates = GetComponent<PlayerStates>();
        stats = GetComponent<Stats>();
        rb = GetComponent<Rigidbody>();
    }



    private void Update()
    {
        StartCoroutine(CalculateSpeed());
    }

    void FixedUpdate()
    {
        // Movement if the player is in "Exploring" State (ref in script "PlayerState")
        if (playerStates.states == PlayerStates.States.Exploring)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

            LerpToSteerAngle();

            if (rb.velocity.magnitude > stats.maxSpeed)
            {
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, stats.maxSpeed);
            }
        }

        // Using turret if player is in "Fighting" State  
        if (playerStates.states == PlayerStates.States.Fifhting)
        {
            turret.transform.Rotate(Vector3.up * turretRotationSpeed * Time.deltaTime);
            ApplyTorque(0);
            rb.velocity = new Vector3(0,0,0);
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
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                for (int i = 0; i < wheels.Length; i++)
                {
                    wheels[i].brakeTorque = 0;
                }
                ApplyTorque(Torque); 
                break;
            case InputActionPhase.Canceled:
                
                ApplyTorque(0); 
                for (int i = 0; i < wheels.Length; i++)
                {
                    wheels[i].brakeTorque = counterTorque;
                }
                break;
        }
    }
    #endregion

    void ApplyTorque(float _value)
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].motorTorque = _value;
        }
    }

    IEnumerator CalculateSpeed()
    {
        Vector3 _lastPosition = transform.position; 
        yield return new WaitForFixedUpdate();
        speed = Mathf.RoundToInt(Vector3.Distance(transform.position,_lastPosition) / Time.deltaTime);
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
