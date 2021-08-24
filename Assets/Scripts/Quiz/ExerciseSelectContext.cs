using System.Collections.Generic;
using System.Linq;
using Card;
using UnityEngine;

namespace Quiz
{
    [RequireComponent(typeof(ExerciseView))]
    public class ExerciseSelectContext : MonoBehaviour
    {
        private readonly List<Exercise> _secondaryExercises = new List<Exercise>();

        [SerializeField] private CardPool _cardPool;

        private ExerciseView _exerciseView;

        public Exercise CurrentExercise { get; private set; }

        private void Awake()
        {
            _exerciseView = GetComponent<ExerciseView>();
        }

        public void SelectNewExercise()
        {
            Exercise exercise = GetNextExercise();
            AddExerciseToSecondaryPool(exercise);
            SetNextExercise(exercise);
        }

        private Exercise GetNextExercise()
        {
            for (int i = 0; i < _cardPool.Count; i++)
            {
                CardPresenter cardObject = _cardPool.GetRandomCard();
                CurrentExercise = new Exercise(cardObject.CardData.Name);
                if (IsSecondaryExercise(CurrentExercise) == false)
                {
                    CurrentExercise = new Exercise(cardObject);
                    return CurrentExercise;
                }
            }

            _secondaryExercises.Clear();
            return GetNextExercise();
        }

        private bool IsSecondaryExercise(Exercise exercise)
        {
            return _secondaryExercises.Any(secondaryExercise => secondaryExercise == exercise);
        }
        
        private void AddExerciseToSecondaryPool(Exercise exercise)
        {
            _secondaryExercises.Add(exercise);
        }

        private void SetNextExercise(Exercise exercise)
        {
            _exerciseView.SetTask(exercise);
        }
    }
}