namespace BoardGameTools.Component.MageKnight.Models
{
    public class Cards
    {
        public int Id { get; }
        public string Name { get; }
        public Characteristic Characteristics { get; }
        public bool Delete { get; set; }

        public Cards(int id, string name, Characteristic characteristics)
        {
            Id = id;
            Name = name;
            Characteristics = characteristics;
        }
    }
}
