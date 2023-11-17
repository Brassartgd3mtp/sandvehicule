using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerExploration : MonoBehaviour
{
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider backLeftWheelCollider;
    public WheelCollider backRightWheelCollider;

    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform backLeftWheelTransform;
    public Transform backRightWheelTransform;

    public InputManagerExploration InputManagerExploration;
    
    public float torque;

    public bool isAccelerating;
    public bool isBreaking;

    public float WheelsMaxAngle;

    public new Rigidbody rigidbody;

    public float actualSpeed;
    public Stats stats;

    public void Start()
    {
        isAccelerating = false;
        isBreaking = false;

        rigidbody.transform.parent = null;
    }

    public void Update()
    {
        UpdateWheels();
    }
    public void FixedUpdate()
    {
        actualSpeed = rigidbody.velocity.sqrMagnitude;

        if (actualSpeed < stats.maxSpeed)
        {
            if (isAccelerating)
            {
                ApplyTorque();
            } else
            {
                {
                    frontLeftWheelCollider.motorTorque = 0;
                    frontRightWheelCollider.motorTorque = 0;
                    backLeftWheelCollider.motorTorque = 0;
                    backRightWheelCollider.motorTorque = 0;
                }
            }
        }
        else
        {
            frontLeftWheelCollider.motorTorque = 0;
            frontRightWheelCollider.motorTorque = 0;
            backLeftWheelCollider.motorTorque = 0;
            backRightWheelCollider.motorTorque = 0;
        }

        if (actualSpeed <= 1 && !isAccelerating)
        {
            rigidbody.velocity = Vector3.zero;
        }
        Stearing();




        if (isBreaking)
        {
            Breaking();
        }
        else
        {
            frontRightWheelCollider.brakeTorque = 0;
            frontLeftWheelCollider.brakeTorque = 0;
            backLeftWheelCollider.brakeTorque = 0;
            backRightWheelCollider.brakeTorque = 0;
        }
    }
    

    public void ApplyTorque()
    {
        frontLeftWheelCollider.motorTorque = torque;
        frontRightWheelCollider.motorTorque = torque;
    }
    
    public void Breaking()
    {
            frontLeftWheelCollider.brakeTorque = Mathf.Infinity;
            frontRightWheelCollider.brakeTorque = Mathf.Infinity;
            backLeftWheelCollider.brakeTorque = Mathf.Infinity;
            backRightWheelCollider.brakeTorque = Mathf.Infinity;

    }

    public void Stearing()
    {
            float _steerAngle = InputManagerExploration.inputX * WheelsMaxAngle;
            frontLeftWheelCollider.steerAngle = Mathf.Lerp(frontLeftWheelCollider.steerAngle, _steerAngle, 0.05f);
            frontRightWheelCollider.steerAngle = Mathf.Lerp(frontRightWheelCollider.steerAngle, _steerAngle, 0.05f);
    }

    public void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(backLeftWheelCollider, backLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(backRightWheelCollider, backRightWheelTransform);
    }

    public void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
