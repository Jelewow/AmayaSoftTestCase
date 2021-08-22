using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class Fader : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onScreenLoaded;
        [SerializeField] private Image _image;
        [SerializeField] private float _endvalue;
        [SerializeField] private float _fadeInDuration;
        [SerializeField] private float _fadeOutDuration;

        private Tween _tween;

        public void FadeIn()
        {
            Fade(_endvalue, _fadeInDuration);
            StartCoroutine(WaitTweenComplete(_fadeInDuration));
        }

        public void FadeOut()
        {
            Fade(0, _fadeOutDuration);
        }

        private void Fade(float endValue, float duration)
        {
            _tween?.Kill();
            _tween = _image.DOFade(endValue, duration);
        }

        private IEnumerator WaitTweenComplete(float duration)
        {
            yield return new WaitForSeconds(duration);
            OnComplete();
        }

        private void OnComplete()
        {
            _onScreenLoaded?.Invoke();
        }
    }
}