using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerExploration : MonoBehaviour
{
    public WheelCollider[] wheels = new WheelCollider[4];

    public InputManagerExploration InputManagerExploration;
    
    public float torque;

    public bool isAccelerating;
    public bool isBreaking;

    public bool isMoving;

    public float forwardAccel; 
    public float reverseAccel;
    public float maxSpeed;
    public float turnStrenght;
    private float speedInput;
    private float turnInput;

    public new Rigidbody rigidbody;

  

    public void Start()
    {
        isAccelerating = false;
        isBreaking = false;

        rigidbody.transform.parent = null;
    }

   
    public void FixedUpdate()
    {
        if (isMoving)
        {
            speedInput = InputManagerExploration.inputY * forwardAccel * 1000f;

            rigidbody.AddForce(transform.forward * speedInput);
        }



        //if (isAccelerating)
        //{
        //    Debug.Log("accelère");
        //    //ApplyTorque();
        //}
        //else
        //    for (int i = 0; i < wheels.Length; i++)
        //    {
        //        wheels[i].motorTorque = 0;
        //    }
        //
        //if (isBreaking)
        //{
        //    Debug.Log("Freine");
        //    //Breaking();
        //}
        //else
        //    for (int i = 0; i < wheels.Length; i++)
        //    {
        //        wheels[i].brakeTorque = 0;
        //    }

    }
    

    //public void ApplyTorque()
    //{
    //    for (int i = 0; i < wheels.Length; i++)
    //    {
    //        wheels[i].motorTorque = torque;
    //    }
    //}
    //
    //public void Breaking()
    //{
    //    for (int i = 0; i < wheels.Length; i++)
    //    {
    //        wheels[i].brakeTorque = Mathf.Infinity;
    //    }
    //}
    //
    //public void Stearing()
    //{
    //    
    //}
}
