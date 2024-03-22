using System;
using System.Collections;
using UnityEngine;

namespace Gameplay.Score
{
    public class ScoreController : MonoBehaviour
    {
        public static Action CoinAdd;
        public static Action ScoreAdd;
        public int CurrentCoinCount { get; private set; } 
        public int CurrentScore { get; private set; }
        public int AddScoreCount { get; private set; } // Сколько очков будет добавляться 
        public bool ActivateDoublPoint { get; set; }

        [SerializeField] private float _timeToAddScore; // Через какое время добовлять очки
        [SerializeField] private PlayerData _playerData;

        public void AddCoin(int count) // Здесь еще проверки, на отрицательное число, на ноль и т.п
        {
            CurrentCoinCount += count;
            _playerData.CoinCount += count;
            CoinAdd?.Invoke();
        }

        private void Start ()
        {
            StartCoroutine(StartAddScore());
        }

        private IEnumerator StartAddScore()
        {
            while (true)
            {
                HowManyPointsToAddOverTime();
                yield return new WaitForSeconds(_timeToAddScore);
                if (ActivateDoublPoint)
                    CurrentScore += AddScoreCount * 2;
                else
                    CurrentScore += AddScoreCount;
                HowManyPointsToAddOverTime();
                ScoreAdd?.Invoke();
            }
        }        

        private void HowManyPointsToAddOverTime()
        {
            if (CurrentScore >= 10000000)
                AddScoreCount = 10000;
            else if (CurrentScore >= 1000000)
                AddScoreCount = 1000;
            else if (CurrentScore >= 100000)
                AddScoreCount = 100;
            else if (CurrentScore >= 1000)
                AddScoreCount = 10;
            else AddScoreCount = 1;
        }
    }
}

