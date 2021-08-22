using UnityEngine;
using Card;

namespace Cell
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private CardPresenter _template;

        private Vector2 _cellSize;

        public Vector2 Size => _template.transform.localScale;
    }
}