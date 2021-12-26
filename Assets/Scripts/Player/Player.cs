using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Player : MonoBehaviour, IRestartable
{
    [SerializeField] private float moveSpeed;

    private Rigidbody _playerRb;

    private Vector3 _moveDirection;
    private Vector3 _startPosition;
    
    private float _moveSpeedX;
    private float _moveSpeedZ;
    private bool _toRight;

    public UnityAction PickUpGemAction { get; set; }
    public UnityAction PlayerDead { get; set; }

    
    private void Start()
    {
        _startPosition = transform.position;

        Reset();
    }

    private void Reset()
    {
        _playerRb = GetComponent<Rigidbody>();
        _moveDirection = Vector3.right;
        _moveSpeedX = 0;
        _moveSpeedZ = 0;
        transform.position = _startPosition;
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
        PlayerCheck();
    }

    private void InputHandler()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            ChangeDirection();
        }
    }

    void PlayerCheck()
    {
        if (transform.position.y < -10)
        {
            gameObject.SetActive(false);
            PlayerDead?.Invoke();
        }
    }

    private void ChangeDirection()
    {
        _toRight = !_toRight;

        _moveDirection = _toRight ? Vector3.right : Vector3.forward;

        _moveSpeedX = _moveDirection.x * moveSpeed;
        _moveSpeedZ = _moveDirection.z * moveSpeed;
    }

    public void PickUpGem()
    {
        PickUpGemAction?.Invoke();
    }
    
    public void RestartThisObject()
    {
        Reset();
        gameObject.SetActive(true);
    }
}