using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Card
{
    public class CardPresenter : MonoBehaviour, IPointerClickHandler
    {
        private const float ClickDelay = 2f;
        
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private Coroutine _waiter;

        public event Action<CardPresenter> Clicked;

        public CardData CardData { get; private set; }
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public Vector2 Size => transform.localScale;

        public void Init(CardData cardData)
        {
            CardData = cardData;
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
            yield return new WaitForSeconds(ClickDelay);
            _waiter = null;
        }
    }
}