using UnityEngine;

namespace Gameplay.Road
{ 
    public class MoveRoad : MonoBehaviour
    {
        public float MoveSpeed { get; set; }

        private void OnEnable()
        {
            ComplicationOverTime.RoadSpeedChaged += SpeedChaged;
        }

        private void OnDisable()
        {
            ComplicationOverTime.RoadSpeedChaged -= SpeedChaged;
        }

        private void SpeedChaged(int value)
        {
            MoveSpeed = value;
        }

        private void RoadMove()
        {
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

