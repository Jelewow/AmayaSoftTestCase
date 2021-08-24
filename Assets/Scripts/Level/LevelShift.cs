using UnityEngine;
using UnityEngine.Events;

namespace Level
{
    public class LevelShift : MonoBehaviour
    {
        [SerializeField] private UnityEvent _gameEnded;
        [SerializeField] private LevelData[] _levels;

        private int _currentLevel;

        public LevelData GetCurrentLevel()
        {
            return _levels[_currentLevel];
        }

        public void SetNextLevel()
        {
            if (_currentLevel + 1 >= _levels.Length)
            {
                _gameEnded?.Invoke();
                return;
            }

            _currentLevel++;
        }

        public void RestartGame()
        {
            _currentLevel = 0;
        }

        public bool IsLastLevel()
        {
            bool isLastLevel = _currentLevel + 1 >= _levels.Length;
            if (isLastLevel)
                _gameEnded?.Invoke();
            return isLastLevel;
        }
    }
}