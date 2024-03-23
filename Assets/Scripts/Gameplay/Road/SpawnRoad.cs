using UnityEngine;

namespace Gameplay.Road
{
    public class SpawnRoad : MonoBehaviour
    {
        [SerializeField] private GameObject[] _roadPrefab;
        [SerializeField] private Vector3 _position;        

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "RoadEnd")
            {
                int rnd = Random.Range(0, _roadPrefab.Length - 1);
                GameObject newRoad = _roadPrefab[rnd];
                Instantiate(newRoad, _position, Quaternion.identity);
            }
        }
    }
}

