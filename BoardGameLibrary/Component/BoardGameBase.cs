using BoardGameLibrary.Component.MageKnight;
using Microsoft.AspNetCore.Components;

namespace BoardGameLibrary.Component
{
    public class BoardGameBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; } = 0;
        [Parameter]
        public string Title { get; set; } = string.Empty;

        protected string searchString = string.Empty;
        protected HashSet<Cards> selectedCards = new();


        protected List<Cards> Cards = new();
        protected bool Result = false;

        protected override void OnInitialized()
        {
            switch(Id)
            {
                case 1:
                    Cards = new List<Cards>() {
                        new("ENDURANCE", new(CharacteristicType.Movement, 2)),
                        new("ENDURANCE", new(CharacteristicType.Movement, 2)),
                        new("CELERITE", new(CharacteristicType.Movement, 2)),
                        new("CELERITE", new(CharacteristicType.Movement, 2)),
                        new("MARCHE", new(CharacteristicType.Movement, 2)),
                        new("MARCHE", new(CharacteristicType.Movement, 2)),
                        new("INSTINCT", new(CharacteristicType.Attack, 2)),
                        new("ENDURANCE GIVREE", new(CharacteristicType.Attack, 2)),
                        new("RAGE", new(CharacteristicType.Parade, 2)),
                        new("RAGE", new(CharacteristicType.Parade, 2))
                    };
                    break;
                default:
                    break;
            }
        }

        protected bool FilterCards1(Cards card) => FilterCards(card, searchString);

        protected bool FilterCards(Cards card, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (card.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if ($"{card.Characteristics.CharacteristicType}".Contains(searchString))
                return true;
            if ($"{card.Characteristics.Value}".Contains(searchString))
                return true;
            return false;
        }

        public StartingHandModel StartingHand()
        {
            var cards = selectedCards.ToList();

            if (cards.Count > 6)
                throw new Exception();

            var monster = new Monsters("Rodeurs", 4, 3);

            var attack = 0;
            var parade = 0;
            foreach (var card in selectedCards)
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
                Result = CalculatedCharacValue(monster.Attack, parade);
                if (Result)
                    DeleteCardUsing();
            }
            if (monster.Armor > attack)
            {
                Result = CalculatedCharacValue(monster.Armor, attack);
                if(Result)
                    DeleteCardUsing();
            }
            else if (monster.Armor <= attack)
                Result = true;

            return new StartingHandModel(cards, Result);

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
