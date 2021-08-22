using UnityEngine;

namespace Answer
{
    [System.Serializable]
    public struct EffectParameter
    {
        [SerializeField] private float _duration;
        [SerializeField] private int _vibrato;
        [SerializeField] private float _elasticity;
        [SerializeField] private float _randomness;

        public float Duration => _duration;
        public int Vibrato => _vibrato;
        public float Elasticity => _elasticity;
        public float Randomness => _randomness;
    }
}