using UnityEngine;

namespace Gameplay.Road
{
    public class DeleteRoad : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "RoadEnd")
            {
                Destroy(other.transform.parent.gameObject);
            }
        }
    }
}
