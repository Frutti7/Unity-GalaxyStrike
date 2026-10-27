using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float controlSpeed = 10f;
    [SerializeField] private float xClampRange = 30f;
    [SerializeField] private float yClampRange = 20f;
    
    [SerializeField] private float controllRollFactor = 20f;
    [SerializeField] private float rotationSpeed = 10f;
    
    [SerializeField] private float pitchFactor = 20f;
    [SerializeField] private float pitchSpeed = 20f;
    
    [SerializeField] private float xRotationSpeed = 0;
    [SerializeField] private float yRotationSpeed = 0;
    
    Vector2 movement;

    private void Update() {
        ProcessMove();
        ProcessRoll();
        ProcessPitch();
    }

    private void ProcessPitch() {
        Quaternion targetPitch = Quaternion.Euler(-pitchFactor * movement.y, 0f, 0f);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetPitch, Time.deltaTime * pitchSpeed);
    }

    private void ProcessRoll() {
        //transform.localRotation *= Quaternion.Euler(xRotationSpeed* Time.deltaTime, yRotationSpeed* Time.deltaTime, controllRollFactor * Time.deltaTime);
        //transform.localRotation *= Quaternion.Euler(0f, 0f, controllRollFactor * Time.deltaTime);
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, -controllRollFactor * movement.x);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
    }


    public void OnMove(InputValue value) {
        movement = value.Get<Vector2>();
    }

    private void ProcessMove() {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        
        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x + xOffset,-xClampRange,xClampRange), Mathf.Clamp(transform.localPosition.y + yOffset,-yClampRange,yClampRange), 0);
        
    }
}