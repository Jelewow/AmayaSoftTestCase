using DG.Tweening;
using UnityEngine;

namespace Card
{
    public class BounceEffect : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private int _vibrato;
        [SerializeField] private float _elasticity;

        public void Bounce(GameObject card)
        {
            Vector3 reverse = -card.transform.localScale;
            card.transform.DOPunchScale(reverse, _duration, _vibrato, _elasticity);
        }

        public void Bounce(GameObject card, float duration, int vibrato, float elasticity)
        {
            _duration = duration;
            _vibrato = vibrato;
            _elasticity = elasticity;
            Bounce(card);
        }
    }
}