using System;
using Card;
using Quiz;
using UnityEngine;

namespace Answer
{
    public class AnswerChecker : MonoBehaviour
    {
        [SerializeField] private CardPool _cardPool;
        [SerializeField] private ExerciseSelectContext _exerciseSelectContext;

        public Action<GameObject, bool> CardClicked;

        public void SubscribeOnCards()
        {
            foreach (CardPresenter card in _cardPool)
                card.Clicked += OnCardClick;
        }

        private void UnsubscribeFromCards()
        {
            foreach (CardPresenter card in _cardPool)
                card.Clicked -= OnCardClick;
        }

        private void OnCardClick(CardPresenter cardPresenter)
        {
            bool isCorrect = _exerciseSelectContext.CurrentExercise.CheckAnswer(cardPresenter);
            if (isCorrect)
                UnsubscribeFromCards();

            CardClicked?.Invoke(cardPresenter.SpriteRenderer.gameObject, isCorrect);
        }
    }
}