using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Card
{
    public class CardPresenter : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private CardData _cardData;
        private Coroutine _waiter;

        public event Action<CardPresenter> Clicked;

        public CardData CardData => _cardData;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public void Init(CardData cardData)
        {
            _cardData = cardData;
            _spriteRenderer.sprite = cardData.Sprite;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_waiter == null)
            {
                Clicked?.Invoke(this);
                _waiter = StartCoroutine(WaitEffect());
            }
        }

        private IEnumerator WaitEffect()
        {
            yield return new WaitForSeconds(2f);
            _waiter = null;
        }
    }
}