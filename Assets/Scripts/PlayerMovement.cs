using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float controlSpeed = 10f;
    Vector2 movement;

    private void Update() {
        ProcessMove();
    }


    public void OnMove(InputValue value) {
        movement = value.Get<Vector2>();
    }

    private void ProcessMove() {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float xMax = 30f;
        float yMax = 20f;
        
        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x + xOffset,-xMax,xMax), Mathf.Clamp(transform.localPosition.y + yOffset,-yMax,yMax), 0);
        
    }
}