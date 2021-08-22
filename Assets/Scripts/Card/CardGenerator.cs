using System.Collections.Generic;
using Extensions;
using Level;
using Task;
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
        [SerializeField] private TaskChooser _taskChooser;
        [SerializeField] private LevelChanger _levelChanger;

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
            List<CardData> cardDatas = GetCardDataQueue(dataSet);
            CardData[] readyCardDatas = GetRandomCardData(_levelChanger.GetCurrentLevel().Amount, cardDatas);
            Queue<CardData> cardDatasQueue = new Queue<CardData>(readyCardDatas);
            InstantiateCards(cardDatasQueue);
            _taskChooser.ChooseTask();
            _spawned?.Invoke();
        }

        private void InstantiateCards(Queue<CardData> cardDatas)
        {
            int cardsAmount = cardDatas.Count;
            for (int i = 0; i < cardsAmount; i++)
            {
                CardPresenter card = Instantiate(_cardTemplate, transform.position, Quaternion.identity, transform);
                card.Init(cardDatas.Dequeue());
                _cardPool.AddCard(card);
            }
        }

        private CardData[] GetRandomCardData(int expectedCards, List<CardData> cardDatas)
        {
            CardData[] currentCards = new CardData[expectedCards];
            cardDatas.Shuffle();
            for (int i = 0; i < currentCards.Length; i++)
            {
                currentCards[i] = cardDatas[i];
            }

            return currentCards;
        }

        private List<CardData> GetCardDataQueue(DataSet dataSet)
        {
            List<CardData> cardDatas = new List<CardData>();
            foreach (CardData cardData in dataSet)
            {
                cardDatas.Add(cardData);
            }

            return cardDatas;
        }

        private DataSet GetRandomDataSet()
        {
            return _dataSets[Random.Range(0, _dataSets.Length)];
        }
    }
}