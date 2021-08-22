using UnityEngine;

namespace Card
{
    [CreateAssetMenu(fileName = "new Card", menuName = "Card", order = 51)]
    public class CardData : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _sprite;

        public string Name => _name;
        public Sprite Sprite => _sprite;
    }
}