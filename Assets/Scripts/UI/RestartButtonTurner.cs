using UnityEngine;
using UnityEngine.UI;

namespace Quiz.UI
{
    public class RestartButtonTurner : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;

        private void Start()
        {
            HideRestartButton();
        }

        public void HideRestartButton()
        {
            _restartButton.gameObject.SetActive(false);
        }
        
        public void ShowRestartButton()
        {
            _restartButton.gameObject.SetActive(true);
        }
    }
}