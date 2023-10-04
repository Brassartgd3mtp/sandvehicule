using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Vector3 movement = Vector3.zero;
    [SerializeField] private float speed;


    void Start()
    {

    }

    void FixedUpdate()
    {

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            transform.position += new Vector3(0, 0, speed);
        }
    }

}
