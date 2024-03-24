using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameStartController : MonoBehaviour
{
    public static Action<float> RoadSpeedChaged;

    public bool IsPlaying { get; private set; }

    [SerializeField] private float _roadSpeed;  
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();

        _playerInput.Main.StartGame.performed += StartGame;
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    public void StartGame(InputAction.CallbackContext context)
    {
        RoadSpeedChaged?.Invoke(_roadSpeed);
        IsPlaying = true;
    }
}
