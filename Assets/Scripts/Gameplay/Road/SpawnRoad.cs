using UnityEngine;

namespace Gameplay.Road
{
    public class SpawnRoad : MonoBehaviour
    {
        public float MoveSpeed { get; set; }
        [SerializeField] private GameObject[] _roadPrefab;
        [SerializeField] private Vector3 _position;        

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "RoadEnd")
            {
                int rnd = Random.Range(0, _roadPrefab.Length - 1);
                GameObject newRoad = _roadPrefab[rnd];
                newRoad.GetComponent<MoveRoad>().MoveSpeed = MoveSpeed;
                Instantiate(newRoad, _position, Quaternion.identity);
            }
        }
    }
}

