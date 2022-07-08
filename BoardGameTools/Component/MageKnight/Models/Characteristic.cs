namespace BoardGameTools.Component.MageKnight.Models
{
    public class Characteristic
    {
        public CharacteristicType CharacteristicType { get; }
        public int Value { get; }

        public Characteristic(CharacteristicType characteristicType, int value)
        {
            CharacteristicType = characteristicType;
            Value = value;
        }
    }
}
