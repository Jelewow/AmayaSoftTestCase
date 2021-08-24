using System.Collections.Generic;
using UnityEngine;
using Card;
using Level;

namespace Cell
{
    public class CellGenerator : MonoBehaviour
    {
        [SerializeField] private LevelShift _levelShift;
        [SerializeField] private CardPool _cardPool;
        [SerializeField] private CardPresenter _cardPrefab;
        [SerializeField] private float _elementVerticalOffset;
        [SerializeField] private float _elementHorizontalOffset;

        private Vector2[] _cellsPosition;
        private int _currentGridHeight;
        private int _currentGridWidth;

        public void GenerateCells()
        {
            LevelData currentLevel = _levelShift.GetCurrentLevel();
            _currentGridHeight = currentLevel.Rows;
            _currentGridWidth = currentLevel.Cols;
            int expectedCells = currentLevel.Count;
            _cellsPosition = new Vector2[expectedCells];
            CalculateCellPositions();
            SetCardsToCells();
        }

        private void CalculateCellPositions()
        {
            float expectedWidth = _currentGridWidth * _elementHorizontalOffset * _cardPrefab.Size.x;
            float expectedHeight = _currentGridHeight * _elementVerticalOffset * _cardPrefab.Size.y;

            for (int y = 0, offset = 0; y < _currentGridHeight; y++, offset += _currentGridWidth)
            for (int x = 0; x < _currentGridWidth; x++)
                _cellsPosition[offset + x] = new Vector2(
                    x * _elementHorizontalOffset - expectedWidth / _currentGridWidth,
                    y * _elementVerticalOffset + expectedHeight / _currentGridHeight -
                    _currentGridHeight * _cardPrefab.Size.y);
        }

        private void SetCardsToCells()
        {
            Queue<Vector2> cells = new Queue<Vector2>(_cellsPosition);
            foreach (CardPresenter card in _cardPool)
                card.transform.localPosition = cells.Dequeue();
        }
    }
}