namespace BoardGameTools.Component.MageKnight.Models
{
    public class AttackingModel
    {
        public List<Cards> Cards { get; }
        public bool Success { get; }

        public AttackingModel(List<Cards> cards, bool success)
        {
            Cards = cards;
            Success = success;
        }
    }
}
