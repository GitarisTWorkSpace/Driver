using Gameplay.Score;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System;

public class PlayerLoseController : MonoBehaviour
{
    public static Action PlayerLost;

    [SerializeField] private PlayerData _playerData;
    [SerializeField] private ScoreController _scoreController;

    [SerializeField] private AudioSource _engineAuidoSource;
    [SerializeField] private AudioSource _crashAudioSource;

    private PlayerInput _playerInput;

    public void PlayerLose()
    {
        CheckBestScore();
        PlayerLost?.Invoke();
        _engineAuidoSource.Stop();
        _crashAudioSource.Play();
    }

    private void Awake()
    {
        _playerInput = new PlayerInput();

        _playerInput.Main.Restart.performed += Restart;
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable(); 
    }

    private void CheckBestScore()
    {
        if (_scoreController.CurrentScore > _playerData.BestScore)
            _playerData.BestScore = _scoreController.CurrentScore;
    }

    private void Restart(InputAction.CallbackContext context)
    {
        PlayerLose();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }
}
