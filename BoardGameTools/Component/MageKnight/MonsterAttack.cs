using BoardGameTools.Component.MageKnight.Models;

namespace BoardGameTools.Component.MageKnight
{

    public class MonsterAttack
    {

        public static ParadeModel TryParade(List<Cards> cards, int monsterAttack)
        {
            var deletedCards = new List<int>();
            var parade = 0;

            foreach (var card in cards)
            {
                if(card.Characteristics.CharacteristicType == CharacteristicType.Parade)
                {
                    if (monsterAttack > parade)
                    {
                        parade += card.Characteristics.Value;
                        deletedCards.Add(card.Id);
                    }
                }
            }

            if(monsterAttack > parade)
            {
                foreach (var card in cards.Where(c => !deletedCards.Contains(c.Id)).ToList())
                {
                    if (monsterAttack > parade)
                    {
                        parade++;
                        deletedCards.Add(card.Id);
                    }
                }
            }
              
            if (monsterAttack <= parade)
            {
                var removeCards = RemoveCards(cards, deletedCards);
                return new ParadeModel { Cards = removeCards, Success = true };
            }

            return new ParadeModel();

        }

        private static List<Cards> RemoveCards(List<Cards> cards, List<int> deletedCards)
        {
            cards.ForEach(c =>
            {
                if (deletedCards.Contains(c.Id))
                    c.Delete = true;
            });

            cards.RemoveAll(x => x.Delete);
            return cards;
        }
    }
}
