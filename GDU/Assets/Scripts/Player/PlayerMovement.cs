using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private Vector2 moveInput;
    [SerializeField] private float playerSpeed;
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private int jumpAmount;

    private int _jumpLeft;

    // Start is called before the first frame update
    void Start()
    {
        _jumpLeft = jumpAmount;

        if (!_playerRigidbody)
            _playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var velocity = new Vector3(
            moveInput.x * playerSpeed,
            _playerRigidbody.velocity.y,
            moveInput.y * playerSpeed);
        _playerRigidbody.velocity = transform.TransformDirection(velocity);
    }

    void OnJump()
    {
        if (_jumpLeft <= 0)
            return;

        _jumpLeft--;

        _playerRigidbody.velocity = new Vector3(
            _playerRigidbody.velocity.x,
            jumpForce,
            _playerRigidbody.velocity.z);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))  _jumpLeft = jumpAmount;
        else if (collision.gameObject.CompareTag("Wall"))  _jumpLeft = jumpAmount;
    }
    
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))  _jumpLeft = jumpAmount - 1;
        else if (collision.gameObject.CompareTag("Wall"))  _jumpLeft = jumpAmount - 1;
    }


}
