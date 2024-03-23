using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Settings.Pause
{
    public class PauseController : MonoBehaviour
    {
        [SerializeField] private GameObject _pausePanel;

        private PlayerInput _playerInput;

        private bool _isPlaying = true;

        public void UnPaused()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _pausePanel.SetActive(false);
            Time.timeScale = 1;
            _isPlaying = true;
        }

        public void InMenuButton()
        {
            SceneManager.LoadScene("Menu");
        }

        private void Awake()
        {
            _playerInput = new PlayerInput();

            _playerInput.Main.Paused.performed += Paused;
        }

        private void OnEnable()
        {
            _playerInput.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Disable();
        }

        private void Paused(InputAction.CallbackContext context)
        {
            if (_isPlaying)
            {
                Cursor.lockState = CursorLockMode.None;
                _pausePanel.SetActive(true);
                Time.timeScale = 0;
                _isPlaying = false;
            } 
            else
                UnPaused();

        }        
    }
}

