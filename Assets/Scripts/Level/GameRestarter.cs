using UnityEngine;
using UnityEngine.UI;

namespace Level
{
    public class GameRestarter : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void Start()
        {
            HideRestartButton();
        }

        public void ShowRestartButton()
        {
            _button.gameObject.SetActive(true);
        }

        public void HideRestartButton()
        {
            _button.gameObject.SetActive(false);
        }
    }
}