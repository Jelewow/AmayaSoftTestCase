using System.Collections;
using Card;
using Level;
using UnityEngine;
using UnityEngine.Events;

namespace Answer
{
    public class AnswerEffectHandler : MonoBehaviour
    {
        [SerializeField] private BounceEffect _bounceEffect;
        [SerializeField] private LevelShift _levelShift;
        [SerializeField] private CardParticleTask _particleTask;
        [SerializeField] private UnityEvent _levelCompleted;
        [SerializeField] private AnswerChecker _answerChecker;
        [SerializeField] private EffectParameter _correctEffectParameters;
        [SerializeField] private EffectParameter _wrongEffectParameters;

        private IAnswerEffectPlayable _effect;

        private void OnEnable()
        {
            _answerChecker.CardClicked += OnCardClick;
        }

        private void OnDisable()
        {
            _answerChecker.CardClicked -= OnCardClick;
        }

        private void OnCardClick(GameObject card, bool isCorrect)
        {
            if (isCorrect)
            {
                _effect = new CorrectAnswerHandler(_correctEffectParameters, _particleTask, _bounceEffect);
                StartCoroutine(EventDelay());
            }
            else
            {
                _effect = new WrongAnswerHandler(_wrongEffectParameters);
            }

            _effect.PlayEffect(card);
        }

        private IEnumerator EventDelay()
        {
            yield return new WaitForSeconds(_correctEffectParameters.Duration);
            if (_levelShift.IsLastLevel() == false)
                _levelCompleted?.Invoke();
        }
    }
}