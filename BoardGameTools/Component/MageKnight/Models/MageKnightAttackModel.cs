namespace BoardGameTools.Component.MageKnight.Models
{
    public class MageKnightAttackModel
    {
        public List<Cards> Cards { get; set; } = new();
        public bool Success { get; set; }
    }
}
