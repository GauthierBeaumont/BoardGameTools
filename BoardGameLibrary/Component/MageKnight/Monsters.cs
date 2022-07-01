namespace BoardGameLibrary.Component.MageKnight
{
    public class Monsters
    {
        public string Name { get; }
        public int Attack { get; }
        public int Armor { get; }

        public Monsters(string name, int attack, int armor)
        {
            Name = name;
            Attack = attack;
            Armor = armor;
        }
    }
}
