using TMPro;
using UnityEngine;

namespace Task
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TaskPresenter : MonoBehaviour
    {
        private TextMeshProUGUI _taskText;

        private void Awake()
        {
            _taskText = GetComponent<TextMeshProUGUI>();
        }

        public void SetTask(Task task)
        {
            _taskText.text = task.Name;
        }
    }
}