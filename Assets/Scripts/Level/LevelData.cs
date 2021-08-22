using UnityEngine;

namespace Level
{
    [CreateAssetMenu(fileName = "new Level", menuName = "Level", order = 48)]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private int _rows;
        [SerializeField] private int _cols;

        public int Amount => _rows * _cols;
    }
}