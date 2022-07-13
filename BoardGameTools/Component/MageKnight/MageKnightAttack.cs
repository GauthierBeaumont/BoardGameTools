using BoardGameTools.Component.MageKnight.Models;

namespace BoardGameTools.Component.MageKnight
{

    public class MageKnightAttack
    {
        public static MageKnightAttackModel Try(List<Cards> cards, int monsterArmor)
        {
            var deletedCards = new List<int>();
            var attack = 0;

            foreach(var card in cards)
            {
                if(card.Characteristics.CharacteristicType == CharacteristicType.Attack)
                {
                    if(monsterArmor > attack)
                    {
                        attack += card.Characteristics.Value;
                        deletedCards.Add(card.Id);
                    }
                }
            }

            if(monsterArmor > attack)
            {
                foreach(var card in cards.Where(c => !deletedCards.Contains(c.Id)).ToList())
                {
                    if(monsterArmor > attack)
                    {
                        attack++;
                        deletedCards.Add(card.Id);
                    }
                }
            }

            if(monsterArmor <= attack)
            {
                var removeCards = RemoveCards(cards, deletedCards);
                return new MageKnightAttackModel { Cards = removeCards, Success = true };
            }

            return new MageKnightAttackModel();
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
