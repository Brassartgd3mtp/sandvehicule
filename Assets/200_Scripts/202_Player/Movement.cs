using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private PlayerStates playerStates;
    private Stats stats;

    //private Vector3 movement = Vector3.zero;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float minRotationSpeed, maxRotationSpeed;

    [SerializeField] private UnityEngine.GameObject turret;
    [SerializeField] private float turretRotationSpeed;
    [SerializeField] private float turretRotationSpeedMax;

    private Rigidbody rb;

    private Vector2 inputDirection;
    private Vector3 movement;
    private bool isMoving;

    void Start()
    {
        playerStates = GetComponent<PlayerStates>();
        stats = GetComponent<Stats>();
        rb = GetComponent<Rigidbody>();
        isMoving = false;
    }



    private void Update()
    {
        
    }

    void FixedUpdate()
    {
        MovePlayer();
        //if (playerStates.states == PlayerStates.States.Exploring)
        //{
        //    if (rb.velocity.magnitude > stats.maxSpeed)
        //    {
        //        rb.velocity = Vector3.ClampMagnitude(rb.velocity, stats.maxSpeed);
        //    }
        //}

        //Using turret if player is in "Fighting" State  
        //if (playerStates.states == PlayerStates.States.Fifhting)
        //{
        //    turret.transform.Rotate(Vector3.up * turretRotationSpeed * Time.deltaTime);
        //    rb.velocity = new Vector3(0,0,0);
        //}
    }
    #region Movement Inputs 

    public void OnMove(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                isMoving = true;
                break;
            case InputActionPhase.Canceled:
                isMoving = false;
                break;

        }


        inputDirection = context.ReadValue<Vector2>();
        
    }

    public void MovePlayer()
    {
        movement = new Vector3(inputDirection.x, 0f, inputDirection.y);

        if (isMoving == true)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.10f);
        }

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
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
