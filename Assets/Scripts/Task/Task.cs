using Card;

#pragma warning disable CS0660
#pragma warning disable CS0661

namespace Task
{
    public class Task
    {
        private CardData _cardData;
        public string Name { get; }

        public Task(string name)
        {
            Name = name;
            _cardData = null;
        }

        public Task(CardPresenter cardPresenter)
        {
            Name = cardPresenter.CardData.Name;
            _cardData = cardPresenter.CardData;
        }

        public bool CheckAnswer(CardPresenter cardPresenter)
        {
            return _cardData == cardPresenter.CardData;
        }

        public static bool operator ==(Task lvalue, Task rvalue)
        {
            return lvalue.Name == rvalue.Name;
        }

        public static bool operator !=(Task lvalue, Task rvalue)
        {
            return lvalue.Name != rvalue.Name;
        }
    }
}