using Menu.Loader;
using UnityEngine;

namespace Menu
{
    [RequireComponent(typeof(LoaderController))]
    public class MenuButtonsController : MonoBehaviour
    {
        [SerializeField] private LoaderController _loderController;

        public void PlayButton()
        {
            _loderController.LoadScene("Game");
        }

        public void ExitButton()
        {
            Application.Quit();
        }
    }
}
