using BoardGameTools.Component.MageKnight.Models;

namespace BoardGameTools.Component.MageKnight
{

    public class RangedAttack
    {
        public static RangedAttackModel Try(List<Cards> cards, int armor)
        {
            var rangedAttackCards = cards.FindAll(c => c.Characteristics.CharacteristicType == CharacteristicType.RangedAttack);
            if (!rangedAttackCards.Any())
                return new RangedAttackModel { Cards = cards };

            var deletedCards = new List<int>();
            var rangedAttack = 0;

            foreach(var card in rangedAttackCards)
            {
                if(armor > rangedAttack)
                {
                    rangedAttack += card.Characteristics.Value;
                    deletedCards.Add(card.Id);
                }
            }

            if (armor <= rangedAttack)
            {
                cards.ForEach(c =>
                {
                    if (deletedCards.Contains(c.Id))
                        c.Delete = true;
                });

                cards.RemoveAll(x => x.Delete);
                return new RangedAttackModel { Cards = cards, Success = true };
            }
                
            return new RangedAttackModel { Cards = cards };
        }
    }
}
