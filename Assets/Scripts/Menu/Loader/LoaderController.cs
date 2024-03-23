using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu.Loader
{
    public class LoaderController : MonoBehaviour
    {
        [SerializeField] private GameObject _loadPanel;
        [SerializeField] private Animator _loadPanelAnimator;

        [SerializeField] private bool _needOffLoadPanel;

        private IEnumerator LoadNewScene(string sceneName) // Возможно это неправильно, но в данном случае я вижу только такое решение
        {
            _loadPanelAnimator.SetBool("NeedOnLoadPanel", true);
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(sceneName);
        }
        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadNewScene(sceneName));
        }

        private void Start()
        {
            if (_needOffLoadPanel)
            {
                _loadPanelAnimator.SetBool("NeedOffLoadPanel", true);
                Cursor.lockState = CursorLockMode.Locked;                
            }
            Time.timeScale = 1f;
        }
    }
}