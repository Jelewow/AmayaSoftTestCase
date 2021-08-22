
namespace Answer
{
    [System.Serializable]
    public class AnswerHandler
    {
        private EffectParameter _effectParameters;

        protected float Duration => _effectParameters.Duration;
        protected int Vibrato => _effectParameters.Vibrato;
        protected float Elasticity => _effectParameters.Elasticity;
        protected float Randomness => _effectParameters.Randomness;

        public AnswerHandler(EffectParameter parameters)
        {
            _effectParameters = parameters;
        }
    }
}