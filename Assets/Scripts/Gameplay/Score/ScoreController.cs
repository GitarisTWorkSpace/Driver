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
        public int AddScoreCount { get;  set; } // ������� ����� ����� ����������� 
        public bool ActivateDoublPoint { get; set; }

        [SerializeField] private float _timeToAddScore; // ����� ����� ����� ��������� ����
        [SerializeField] private PlayerData _playerData;

        public void AddCoin(int count) // ����� ��� ��������, �� ������������� �����, �� ���� � �.�
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
                yield return new WaitForSeconds(_timeToAddScore);
                if (ActivateDoublPoint)
                    CurrentScore += AddScoreCount * 2;
                else
                    CurrentScore += AddScoreCount;
                ScoreAdd?.Invoke();
            }
        }        

        
    }
}

