﻿using DG.Tweening;
using UnityEngine;

namespace Answer
{
    public class WrongAnswerHandler : AnswerHandler, IAnswerEffectPlayable
    {
        public WrongAnswerHandler(EffectParameter parameters) : base(parameters)
        {
        }

        public void PlayEffect(GameObject card)
        {
            Shake(card);
        }

        private void Shake(GameObject card)
        {
            Vector3 shakeVector = new Vector3(1, 0, 0);
            card.transform.DOShakePosition(Duration, shakeVector, Vibrato, Randomness);
        }
    }
}