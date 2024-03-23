using TMPro;
using UnityEngine;

namespace Gameplay.Score
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private ScoreController _score;
        [SerializeField] private PlayerData _playerData;

        [SerializeField] private TMP_Text _bestScore;
        [SerializeField] private TMP_Text _currentScore;
        [SerializeField] private TMP_Text _currentCoinCount;

        private void OnEnable()
        {
            ScoreController.CoinAdd += CoinView;
            ScoreController.ScoreAdd += CurrentScoreView;
        }

        private void OnDisable()
        {
            ScoreController.CoinAdd -= CoinView;
            ScoreController.ScoreAdd -= CurrentScoreView;
        }

        private void CoinView()
        {
            _currentCoinCount.text = _score.CurrentCoinCount.ToString();
        }

        private void CurrentScoreView()
        {
            _currentScore.text = _score.CurrentScore.ToString();
        }

        private void Start()
        {
            _bestScore.text = _playerData.BestScore.ToString();
        }
    }
}
