using UnityEngine;

namespace Card
{
    public class CardParticleTask : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particle;

        public void Play(GameObject cardPresenter)
        {
            CorrectPosition(cardPresenter);
            _particle.Play();
        }

        private void CorrectPosition(GameObject cardPresenter)
        {
            _particle.gameObject.transform.position = cardPresenter.gameObject.transform.position;
        }
    }
}