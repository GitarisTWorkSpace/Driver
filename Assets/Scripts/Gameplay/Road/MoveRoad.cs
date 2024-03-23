using UnityEngine;

namespace Gameplay.Road
{ 
    public class MoveRoad : MonoBehaviour
    {
        public float MoveSpeed { get; set; }

        private void RoadMove()
        {
            if (MoveSpeed == 0f) MoveSpeed = 15f;
            float scaledMoveSpeed = MoveSpeed * Time.deltaTime;
            Vector3 offset = new Vector3(0f, 0f, -1f) * scaledMoveSpeed;
            transform.Translate(offset);
        }

        private void FixedUpdate()
        {
            RoadMove();
        }


    }
}

