using TMPro;
using Gameplay.Score;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerLose : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private ScoreController _scoreController;

    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private TMP_Text _bestScore;
    [SerializeField] private TMP_Text _currentScore;
    [SerializeField] private TMP_Text _currentCoinCount;
    [SerializeField] private TMP_Text _coinCount;

    private PlayerInput _playerInput;

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

    private void ActivateLosePanel()
    {
        CheckBestScore();
        _gamePanel.SetActive(false);
        _losePanel.SetActive(true);
        _bestScore.text = _playerData.BestScore.ToString();
        _currentScore.text = _scoreController.CurrentScore.ToString();
        _coinCount.text = _playerData.CoinCount.ToString();
        _currentCoinCount.text = _scoreController.CurrentCoinCount.ToString();
    }

    private void Restart(InputAction.CallbackContext context)
    {
        ActivateLosePanel();        
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
        _gamePanel.SetActive(true);
        _losePanel.SetActive(false);
    }
}
