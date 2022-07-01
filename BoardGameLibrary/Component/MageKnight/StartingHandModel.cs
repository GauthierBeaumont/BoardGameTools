namespace BoardGameLibrary.Component.MageKnight
{
    public class StartingHandModel
    {
        public List<Cards> Cards { get; }
        public bool Result { get; }

        public StartingHandModel(List<Cards> cards, bool result)
        {
            Cards = cards;
            Result = result;
        }
    }
}
