using BoardGameTools.Component.MageKnight.Models;
using Microsoft.AspNetCore.Components;

namespace BoardGameTools.Component.MageKnight
{

    public class BoardGameBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        protected HashSet<Cards> SelectedCards = new();

        protected Monsters? SelectedMonster = null;

        protected List<Cards> Cards = new();
        protected List<Monsters> Monsters = new();

        protected AttackingModel Result = new();
        protected string Visible = "none";

        protected override void OnInitialized()
        {
            switch (Id)
            {
                case 1:
                    Cards = new List<Cards>() {
                        new(1, "ENDURANCE", new Characteristic(CharacteristicType.Movement, 2)),
                        new(2, "ENDURANCE", new Characteristic(CharacteristicType.Movement, 2)),
                        new(3, "CELERITE", new Characteristic(CharacteristicType.Movement, 2)),
                        new(4, "CELERITE", new Characteristic(CharacteristicType.Movement, 2)),
                        new(5, "MARCHE", new Characteristic(CharacteristicType.Movement, 2)),
                        new(6, "MARCHE", new Characteristic(CharacteristicType.Movement, 2)),
                        new(7, "INSTINCT", new Characteristic(CharacteristicType.Attack, 2)),
                        new(8, "ENDURANCE GIVREE", new Characteristic(CharacteristicType.Attack, 2)),
                        new(9, "RAGE", new Characteristic(CharacteristicType.Parade, 2)),
                        new(10, "RAGE", new Characteristic(CharacteristicType.Parade, 2)),
                        new(11, "RANGED ATTACK", new Characteristic(CharacteristicType.RangedAttack, 3)),
                    };
                    Monsters = new List<Monsters>
                    {
                        new("Rodeurs", 4, 3),
                        new("Rodeurs", 6, 2)
                    };
                    break;
            }
        }
        
        public void Attacking()
        {
            var cards = SelectedCards.ToList();

            if (cards.Count > 6 || SelectedMonster is null)
                throw new Exception();

            var rangedAttack = RangedAttack.Try(cards, SelectedMonster.Armor);

            var resultCards = rangedAttack.Cards;
            var resultSuccess = rangedAttack.Success;

            if (rangedAttack.Success is false)
            {
                var mageKnightParade = MonsterAttack.TryParade(cards, SelectedMonster.Attack);
                if(mageKnightParade.Success)
                {
                    var mageKnightAttack = MageKnightAttack.Try(mageKnightParade.Cards, SelectedMonster.Attack);
                    if (mageKnightAttack.Success)
                    {
                        resultCards = mageKnightAttack.Cards;
                        resultSuccess = mageKnightAttack.Success;
                    }
                }
            }

            Visible = "Block";
            Result = new AttackingModel { Cards = resultCards, Success = resultSuccess };
        }
    }
}
