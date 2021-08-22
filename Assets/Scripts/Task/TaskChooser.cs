using System.Collections.Generic;
using Card;
using UnityEngine;

namespace Task
{
    [RequireComponent(typeof(TaskPresenter))]
    public class TaskChooser : MonoBehaviour
    {
        [SerializeField] private CardPool _cardPool;
        
        private TaskPresenter _taskPresenter;
        private readonly List<Task> _secondaryTasks = new List<Task>();
    
        public Task CurrentTask { get; private set; }
        
        private void Awake()
        {
            _taskPresenter = GetComponent<TaskPresenter>();
        }
    
        public void ClearSecondaryTasksPool()
        {
            _secondaryTasks.Clear();
        }
        
        public void ChooseTask()
        {
            Task task = GetNextTask();
            SetTask(task);
        }
    
        private Task GetNextTask()
        {
            CardPresenter card;
            do
            {
                card = _cardPool.GetRandomCard();
                CardData cardData = card.CardData;
                CurrentTask = new Task(cardData.Name);
            } while (IsSecondaryTask(CurrentTask));
    
            CurrentTask = new Task(card);
            _secondaryTasks.Add(CurrentTask);
            return CurrentTask;
        }
    
        private void SetTask(Task task)
        {
            _taskPresenter.SetTask(task);
        }
    
        private bool IsSecondaryTask(Task task)
        {
            foreach (Task secondaryTask in _secondaryTasks)
            {
                if (secondaryTask == task)
                {
                    return true;
                }
            }
    
            return false;
        }
    }
}