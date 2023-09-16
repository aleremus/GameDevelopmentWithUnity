using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementCharacterController : MonoBehaviour
{

    //for now all this things should be accessed only in Unity Editor
    [SerializeField] private float movementSpeed;
    [SerializeField] private float accelerationModifier;
    [SerializeField] private float gravityAcceleration;
    [SerializeField] private float jumpForce;

    private CharacterController _characterController;
    private Vector2 inputValue;
    private float _ySpeed;
    private bool _speedUp;
    private bool _jump;


    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame

    private void Update()
    {
        //call move function
        Move();
    }

    void Move()
    {
        //using input to create movement direction

        Vector3 movementDirection = new Vector3(inputValue.x, 0,inputValue.y) * movementSpeed;

        movementDirection = Vector3.ClampMagnitude(movementDirection, movementSpeed) * Time.deltaTime;

        movementDirection = transform.TransformDirection(movementDirection);


        //add speed if speed button pressed
        if (_speedUp)
            movementDirection *= accelerationModifier;

        //add gravity force 
        movementDirection.y = gravityAcceleration * Time.deltaTime;

        _characterController.Move(movementDirection);
    }


    //Input System reading values:
    void OnMove(InputValue input)
    {
        inputValue = input.Get<Vector2>();
    }

    void OnShift(InputValue input)
    {
        _speedUp = input.isPressed;
    }

    bool IsGrounded() => _characterController.isGrounded;
}
