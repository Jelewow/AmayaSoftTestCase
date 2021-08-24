using UnityEngine;
using DG.Tweening;

namespace Quiz.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class FadeCanvasGroup : MonoBehaviour
    {
        private const int EndValue = 1;

        [SerializeField] private float _duration;
    
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            FadeIn();
        }

        public void FadeIn()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.DOFade(EndValue, _duration);
        }
    }
}