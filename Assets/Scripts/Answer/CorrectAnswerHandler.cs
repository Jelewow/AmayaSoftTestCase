using Card;
using DG.Tweening;
using UnityEngine;

namespace Answer
{
    public class CorrectAnswerHandler : AnswerHandler, IAnswerEffectPlayable
    {
        private readonly CardParticleTask _particle;
        private readonly BounceEffect _bounceEffect;
        
        public CorrectAnswerHandler(EffectParameter parameters, CardParticleTask particle, BounceEffect bounce) : base(parameters)
        {
            _particle = particle;
            _bounceEffect = bounce;
        }

        public void PlayEffect(GameObject card)
        {
            Bounce(card);
            PlayParticles(card);
        }

        private void Bounce(GameObject card)
        {
            _bounceEffect.Bounce(card, Duration, Vibrato, Elasticity);
        }

        private void PlayParticles(GameObject card)
        {
            _particle.Play(card);
        }
    }
}