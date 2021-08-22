using System.Collections.Generic;
using UnityEngine;
using Card;
using Level;

namespace Cell
{
    public class CellContainer : MonoBehaviour
    {
        [SerializeField] private LevelChanger _levelChanger;
        [SerializeField] private CardPool _cardPool;
        [SerializeField] private Cell _cellPrefab;
        [SerializeField] private float _elementVerticalOffset = 2f;
        [SerializeField] private float _elementHorizontalOffset = 2f;
        private int _maxHeight = 3;
        private int _maxWidth = 3;

        private List<Vector2> _cellsPosition = new List<Vector2>();

        public void GenerateCells()
        {
            int expectedCells = _levelChanger.GetCurrentLevel().Amount;
            AdjustCellCount(expectedCells);
            DrawCells();
            SetCardsToCells();
        }

        public void DeleteCells()
        {
            _cellsPosition.Clear();
        }

        private void DrawCells()
        {
            int rows = 0;
            int columns = 0;
            bool canceled = false;

            for (int y = 0, offset = 0; y < _maxHeight; y++, offset += _maxWidth)
            {
                for (int x = 0; x < _maxWidth; x++)
                {
                    if (_cellsPosition.Count <= offset + x)
                    {
                        canceled = true;
                        break;
                    }

                    if (columns < _maxWidth)
                    {
                        columns++;
                    }
                }

                if (canceled) break;
                rows++;
            }

            float expectedWidth = columns * _elementHorizontalOffset * _cellPrefab.Size.x;
            float expectedHeight = rows * _elementVerticalOffset * _cellPrefab.Size.y;
            for (int y = 0, offset = 0; y < _maxHeight; y++, offset += _maxWidth)
            {
                for (int x = 0; x < _maxWidth; x++)
                {
                    if (_cellsPosition.Count <= offset + x)
                        return;

                    _cellsPosition[offset + x] = new Vector2(
                        x * _elementHorizontalOffset - (expectedWidth / columns),
                        (y * _elementVerticalOffset + (expectedHeight / rows) - (rows * _cellPrefab.Size.y)));
                }
            }
        }

        private void SetCardsToCells()
        {
            Queue<Vector2> cells = new Queue<Vector2>(_cellsPosition);
            foreach (CardPresenter card in _cardPool)
            {
                card.transform.localPosition = cells.Dequeue();
            }
        }

        private void AdjustCellCount(int expectedCount)
        {
            if (_cellsPosition.Count == expectedCount)
                return;

            if (_cellsPosition.Count < expectedCount)
                for (int i = _cellsPosition.Count; i < expectedCount; i++)
                {
                    InstantiateCells();
                }

            if (_cellsPosition.Count > expectedCount)
                for (int i = _cellsPosition.Count; i >= expectedCount; i--)
                {
                    _cellsPosition.RemoveAt(i - 1);
                }
        }

        private void InstantiateCells()
        {
            Vector2 cellPosition = new Vector2();
            _cellsPosition.Add(cellPosition);
        }
    }
}