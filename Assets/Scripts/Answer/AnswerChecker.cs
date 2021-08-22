using System;
using Card;
using Task;
using UnityEngine;

namespace Answer
{
    public class AnswerChecker : MonoBehaviour
    {
        [SerializeField] private CardPool _cardPool;
        [SerializeField] private TaskChooser _taskChooser;

        public Action<GameObject, bool> CardClicked;

        public void SubscribeOnCards()
        {
            foreach (CardPresenter card in _cardPool)
            {
                card.Clicked += OnCardClick;
            }
        }

        private void UnsubscribeFromCards()
        {
            foreach (CardPresenter card in _cardPool)
            {
                card.Clicked -= OnCardClick;
            }
        }

        private void OnCardClick(CardPresenter cardPresenter)
        {
            bool isCorrect = _taskChooser.CurrentTask.CheckAnswer(cardPresenter);
            if (isCorrect == true)
            {
                UnsubscribeFromCards();
            }

            CardClicked?.Invoke(cardPresenter.SpriteRenderer.gameObject, isCorrect);
        }
    }
}