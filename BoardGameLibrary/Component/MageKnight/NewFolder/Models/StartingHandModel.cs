namespace BoardGameLibrary.Component.MageKnight.NewFolder.Models
{
    public class AttackingModel
    {
        public List<Cards> Cards { get; }
        public bool Result { get; }

        public AttackingModel(List<Cards> cards, bool result)
        {
            Cards = cards;
            Result = result;
        }
    }
}
