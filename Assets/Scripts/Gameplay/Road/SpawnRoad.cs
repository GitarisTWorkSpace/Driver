using UnityEngine;

namespace Gameplay.Road
{
    public class SpawnRoad : MonoBehaviour
    {
        [SerializeField] private GameObject _roadPrefab;
        [SerializeField] private Vector3 _position;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "RoadEnd")
            {
                Instantiate(_roadPrefab, _position, Quaternion.identity);
            }
        }
    }
}

