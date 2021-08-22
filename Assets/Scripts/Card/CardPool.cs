using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Card
{
    public class CardPool : MonoBehaviour, IEnumerable
    {
        private readonly List<CardPresenter> _cards = new List<CardPresenter>();

        public void AddCard(CardPresenter card)
        {
            _cards.Add(card);
        }

        public CardPresenter GetRandomCard()
        {
            return _cards[Random.Range(0, _cards.Count)];
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _cards.Count; i++)
            {
                yield return _cards[i];
            }
        }

        public void ClearPool()
        {
            _cards.Clear();
        }
    }
}