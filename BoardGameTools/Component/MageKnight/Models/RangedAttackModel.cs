namespace BoardGameTools.Component.MageKnight.Models
{
    public class RangedAttackModel
    {
        public List<Cards> Cards { get; set; } = new();
        public bool Success { get; set; }
    }
}
