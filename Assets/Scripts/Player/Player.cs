using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody _playerRb;

    private Vector3 _moveDirection = Vector3.zero;
    private float _moveSpeedX;
    private float _moveSpeedZ;

    private bool _toRight;

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _playerRb.velocity = new Vector3(
            _moveSpeedX * Time.fixedDeltaTime,
            _playerRb.velocity.y,
            _moveSpeedZ * Time.fixedDeltaTime);
    }

    private void Update()
    {
        InputHandler();
    }

    private void InputHandler()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        _toRight = !_toRight;

        _moveDirection = _toRight ? Vector3.right : Vector3.forward;

        _moveSpeedX = _moveDirection.x * moveSpeed;
        _moveSpeedZ = _moveDirection.z * moveSpeed;
    }

    // Update is called once per frame
}