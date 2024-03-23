using Gameplay.PlayerMove;
using UnityEngine;

public class LoseBox : MonoBehaviour
{
    private PlayerLoseController _loseController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerLoseController>(out _loseController))
        {
            _loseController.PlayerLose();
        }
    }
}
