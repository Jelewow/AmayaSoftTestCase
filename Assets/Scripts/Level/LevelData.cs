using UnityEngine;

namespace Level
{
    [CreateAssetMenu(fileName = "new Level", menuName = "Level", order = 48)]
    public class LevelData : ScriptableObject
    {
        [SerializeField, Min(1)] private int _rows;
        [SerializeField, Min(1)] private int _cols;

        public int Count => _rows * _cols;
        public int Rows => _rows;
        public int Cols => _cols;
    }
}