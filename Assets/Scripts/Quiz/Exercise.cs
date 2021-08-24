using Card;

#pragma warning disable CS0660
#pragma warning disable CS0661

namespace Quiz
{
    public class Exercise
    {
        private readonly CardData _cardData;
        
        public Exercise(string name)
        {
            Name = name;
        }

        public Exercise(CardPresenter cardPresenter) : this(cardPresenter.CardData.Name)
        {
            _cardData = cardPresenter.CardData;
        }

        public string Name { get; }
        
        public bool CheckAnswer(CardPresenter cardPresenter)
        {
            return _cardData == cardPresenter.CardData;
        }

        public static bool operator ==(Exercise lvalue, Exercise rvalue)
        {
            return lvalue?.Name == rvalue?.Name;
        }

        public static bool operator !=(Exercise lvalue, Exercise rvalue)
        {
            return lvalue?.Name != rvalue?.Name;
        }
    }
}