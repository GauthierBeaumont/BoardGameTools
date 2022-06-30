using Microsoft.AspNetCore.Components;

namespace BoardGameLibrary.Component
{
    public enum CharacteristicType
    {
        Movement,
        Attack,
        Parade
    }

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

    public class Cards
    {
        public string Name { get; }
        public Characteristic Characteristics { get; }
        public bool Delete { get; set; }

        public Cards(string name, Characteristic characteristics)
        {
            Name = name;
            Characteristics = characteristics;
        }
    }

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

    public class BoardGameBase : ComponentBase
    {
        public StartingHandModel StartingHand(List<Cards> cards, Monsters monster)
        {
            bool result = false;

            var attack = 0;
            var parade = 0;
            foreach (var card in cards)
            {
                if (card.Characteristics.CharacteristicType is CharacteristicType.Attack)
                {
                    card.Delete = true;
                    attack += card.Characteristics.Value;
                }
                else if (card.Characteristics.CharacteristicType is CharacteristicType.Parade)
                {
                    card.Delete = true;
                    parade += card.Characteristics.Value;
                }
            }

            DeleteCardUsing();

            if (monster.Attack > parade)
            {
                result = CalculatedCharacValue(monster.Attack, parade);
                if (result)
                    DeleteCardUsing();
            }
            if (monster.Armor > attack)
            {
                result = CalculatedCharacValue(monster.Armor, attack);
                if(result)
                    DeleteCardUsing();
            }
            else if (monster.Armor <= attack)
                result = true;

            return new StartingHandModel(cards, result);

            bool CalculatedCharacValue(int caracValueMonster, int caracValue)
            {
                foreach(var card in cards)
                {
                    if (caracValueMonster <= caracValue)
                        return true;
                    caracValue += 1;
                    card.Delete = true;
                }
                if (caracValueMonster <= caracValue)
                    return true;

                return false;
            }

            void DeleteCardUsing() => cards.RemoveAll(a => a.Delete);
        }
    }
}
