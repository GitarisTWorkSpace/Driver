using UnityEngine;

namespace Gameplay.Road
{ 
    public class MoveRoad : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;

        private void RoadMove()
        {
            float scaledMoveSpeed = _moveSpeed * Time.deltaTime;
            Vector3 offset = new Vector3(0f, 0f, -1f) * scaledMoveSpeed;
            transform.Translate(offset);
        }

        private void FixedUpdate()
        {
            RoadMove();
        }


    }
}

