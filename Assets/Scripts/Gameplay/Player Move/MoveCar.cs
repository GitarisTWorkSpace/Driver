using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveCar : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private PlayerInput _playerInput;

    private Vector2 _moveDirection;
    
    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void CarMove() // Это точно можно сделать по другому, но, я думаю, это решение менее грамосткое
    {
        _moveDirection = new Vector2(_playerInput.Main.Move.ReadValue<float>(), 0);

        if (_moveDirection.sqrMagnitude < 0.1f) return;

        float scaledMoveSpeed = _moveSpeed * Time.deltaTime;
        Vector3 offset = new Vector3(_moveDirection.x, 0f, 0f) * scaledMoveSpeed;
        transform.Translate(offset);
    }

    private void FixedUpdate()
    {
        CarMove();
    }

}
