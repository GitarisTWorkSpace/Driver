using Gameplay.Score;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gameplay.Money
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int _coinCount;
        [SerializeField] private AudioSource _audioSource;
        private ScoreController _score; 

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<ScoreController>(out _score))
            {
                _score.AddCoin(_coinCount);
                _audioSource.Play();
                Destroy(gameObject, 0.2f);
            }
        }
    }
}
