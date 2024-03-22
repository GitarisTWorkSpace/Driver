using Gameplay.Score;
using UnityEngine;

namespace Gameplay.Money
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int _coinCount;
        private ScoreController _score; 

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<ScoreController>(out _score))
            {
                _score.AddCoin(_coinCount);
                Destroy(gameObject);
            }
        }
    }
}
