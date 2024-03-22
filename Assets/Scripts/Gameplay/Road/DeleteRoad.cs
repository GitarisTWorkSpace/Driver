using UnityEngine;

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
