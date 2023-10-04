using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Vector3 movement = Vector3.zero;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float minRotationSpeed, maxRotationSpeed;

    private Rigidbody rb;

    void Start()
    {

    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
        transform.Rotate(Vector3.up, rotationSpeed *Time.deltaTime);

    }

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

}
