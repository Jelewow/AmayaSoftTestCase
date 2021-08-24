using TMPro;
using UnityEngine;

namespace Quiz
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ExerciseView : MonoBehaviour
    {
        private TextMeshProUGUI _exerciseName;

        private void Awake()
        {
            _exerciseName = GetComponent<TextMeshProUGUI>();
        }

        public void SetTask(Exercise exercise)
        {
            _exerciseName.text = exercise.Name;
        }
    }
}