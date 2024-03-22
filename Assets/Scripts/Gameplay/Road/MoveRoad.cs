using UnityEngine;

namespace Gameplay.Road
{ 
    public class MoveRoad : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _moveDirection;

        private void RoadMove()
        {
            float scaledMoveSpeed = _moveSpeed * Time.deltaTime;
            Vector3 offset = new Vector3(0f, 0f, _moveDirection) * scaledMoveSpeed;
            transform.Translate(offset);
        }

        private void FixedUpdate()
        {
            RoadMove();
        }


    }
}

