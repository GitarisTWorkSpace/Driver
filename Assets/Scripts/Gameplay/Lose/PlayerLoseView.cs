using TMPro;
using Gameplay.Score;
using UnityEngine;


public class PlayerLoseView : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private ScoreController _scoreController;

    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private TMP_Text _bestScore;
    [SerializeField] private TMP_Text _currentScore;
    [SerializeField] private TMP_Text _currentCoinCount;
    [SerializeField] private TMP_Text _coinCount;

    private void OnEnable()
    {
        PlayerLoseController.PlayerLost += ActivateLosePanel;
    }

    private void OnDisable()
    {
        PlayerLoseController.PlayerLost -= ActivateLosePanel;
    }

    public void ActivateLosePanel()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        _gamePanel.SetActive(false);
        _losePanel.SetActive(true);
        _bestScore.text = _playerData.BestScore.ToString();
        _currentScore.text = _scoreController.CurrentScore.ToString();
        _coinCount.text = _playerData.CoinCount.ToString();
        _currentCoinCount.text = _scoreController.CurrentCoinCount.ToString();
    }
}
