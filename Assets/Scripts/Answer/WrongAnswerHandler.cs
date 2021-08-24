using DG.Tweening;
using UnityEngine;

namespace Answer
{
    public class WrongAnswerHandler : AnswerHandler, IAnswerEffectPlayable
    {
        private readonly Vector3 _shakeVector = new Vector3(1, 0, 0);
        
        public WrongAnswerHandler(EffectParameter parameters) : base(parameters)
        {
        }

        public void PlayEffect(GameObject card)
        {
            Shake(card);
        }

        private void Shake(GameObject card)
        {
            card.transform.DOShakePosition(Duration, _shakeVector, Vibrato, Randomness);
        }
    }
}