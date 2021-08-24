using System.Collections.Generic;
using Extensions;
using Level;
using Quiz;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Card
{
    public class CardGenerator : MonoBehaviour
    {
        [SerializeField] private UnityEvent _spawned;
        [SerializeField] private UnityEvent _gameStarted;
        [SerializeField] private CardPresenter _cardTemplate;
        [SerializeField] private DataSet[] _dataSets;
        [SerializeField] private CardPool _cardPool;
        [SerializeField] private ExerciseSelectContext _exerciseSelectContext;
        [SerializeField] private LevelShift _levelShift;

        private void Start()
        {
            Init();
            _gameStarted?.Invoke();
        }

        public void ReInit()
        {
            DeleteCards();
            _cardPool.ClearPool();
            Init();
        }

        private void DeleteCards()
        {
            foreach (CardPresenter card in _cardPool)
            {
                Destroy(card.gameObject);
            }
        }

        private void Init()
        {
            DataSet dataSet = GetRandomDataSet();
            List<CardData> cardData = GetCardDataQueue(dataSet);
            CardData[] readyCardData = GetRandomCardData(_levelShift.GetCurrentLevel().Count, cardData);
            Queue<CardData> cardDataQueue = new Queue<CardData>(readyCardData);
            InstantiateCards(cardDataQueue);
            _exerciseSelectContext.SelectNewExercise();
            _spawned?.Invoke();
        }

        private void InstantiateCards(Queue<CardData> cardData)
        {
            int cardsAmount = cardData.Count;
            for (int i = 0; i < cardsAmount; i++)
            {
                CardPresenter card = Instantiate(_cardTemplate, transform.position, Quaternion.identity, transform);
                card.Init(cardData.Dequeue());
                _cardPool.AddCard(card);
            }
        }

        private CardData[] GetRandomCardData(int expectedCards, List<CardData> cardData)
        {
            CardData[] currentCards = new CardData[expectedCards];
            cardData.Shuffle();
            for (int i = 0; i < currentCards.Length; i++)
                currentCards[i] = cardData[i];

            return currentCards;
        }

        private List<CardData> GetCardDataQueue(DataSet dataSet)
        {
            List<CardData> cardDatas = new List<CardData>();
            foreach (CardData cardData in dataSet)
                cardDatas.Add(cardData);

            return cardDatas;
        }

        private DataSet GetRandomDataSet()
        {
            return _dataSets[Random.Range(0, _dataSets.Length)];
        }
    }
}