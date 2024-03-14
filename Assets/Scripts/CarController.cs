using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private  float horizontalInput;
    private float verticalInput;
    private float steerAngle;
    private float currentbreakForce;
    private float currentSteerAngle;
    private bool isBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private Text SpeedText;
    [SerializeField] private Rigidbody Truck_Body;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider midLeftWheelCollider;
    [SerializeField] private WheelCollider midRightWheelCollider;
    [SerializeField] private WheelCollider backLeftWheelCollider;
    [SerializeField] private WheelCollider backRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform midLeftWheelTransform;
    [SerializeField] private Transform midRightWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;

    private void FixedUpdate(){
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        SpeedText.text = (Truck_Body.velocity.magnitude * 2.23693629f).ToString("0") + (" km/h");
    }

    private void GetInput(){
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }
    private void HandleMotor(){
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking(){
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        backRightWheelCollider.brakeTorque = currentbreakForce;
        backLeftWheelCollider.brakeTorque = currentbreakForce;
        midRightWheelCollider.brakeTorque = currentbreakForce;
        midLeftWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering(){
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels(){
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(midLeftWheelCollider, midLeftWheelTransform);
        UpdateSingleWheel(midRightWheelCollider, midRightWheelTransform);
        UpdateSingleWheel(backLeftWheelCollider, backLeftWheelTransform);
        UpdateSingleWheel(backRightWheelCollider, backRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform){
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}