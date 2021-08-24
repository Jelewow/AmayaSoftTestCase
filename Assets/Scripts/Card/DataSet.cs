using System.Collections;
using UnityEngine;

namespace Card
{
    [CreateAssetMenu(fileName = "new DataSet", menuName = "DataSet", order = 52)]
    public class DataSet : ScriptableObject, IEnumerable
    {
        [SerializeField] private CardData[] _cards;

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _cards.Length; i++)
                yield return _cards[i];
        }
    }
}