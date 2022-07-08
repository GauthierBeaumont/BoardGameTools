using BoardGameTools.Component.MageKnight;
using BoardGameTools.Component.MageKnight.Models;
using FluentAssertions;

namespace BoardGameTools.Tests
{
    public class RangedAttackTests
    {
        [Fact]
        public void TryToRangedAttack_AttackIsOkWithOneCard_ReturnTrue()
        {
            var cards = new List<Cards>
            {
                new(1, "TEST", new Characteristic(CharacteristicType.RangedAttack, 2))
            };

            var armor = 1;

            var result = RangedAttack.Try(cards, armor);

            result.Should().BeEquivalentTo(new RangedAttackModel
            {
                Success = true
            });
        }

        [Fact]
        public void TryToRangedAttack_AttackIsOkWithMultipleCards_ReturnTrue()
        {
            var cards = new List<Cards>
            {
                new(1, "TEST", new Characteristic(CharacteristicType.RangedAttack, 2)),
                new(2, "TEST", new Characteristic(CharacteristicType.RangedAttack, 1))
            };

            var armor = 3;

            var result = RangedAttack.Try(cards, armor);

            result.Should().BeEquivalentTo(new RangedAttackModel
            {
                Success = true
            });
        }

        [Fact]
        public void TryToRangedAttack_AttackIsOkWithMultipleCards_ReturnTrueAndUnusedCard()
        {
            var cards = new List<Cards>
            {
                new(1, "TEST", new Characteristic(CharacteristicType.RangedAttack, 2)),
                new(2, "TEST", new Characteristic(CharacteristicType.RangedAttack, 1)),
                new(3, "TEST", new Characteristic(CharacteristicType.RangedAttack, 2))
            };

            var armor = 3;

            var result = RangedAttack.Try(cards, armor);

            result.Should().BeEquivalentTo(new RangedAttackModel
            {
                Cards = new List<Cards>
                {
                    new(3, "TEST", new Characteristic(CharacteristicType.RangedAttack, 2))
                },
                Success = true
            });
        }

        [Fact]
        public void TryToRangedAttack_AttackIsOkWithDifferentCharacteristicCard_ReturnTrueAndUnusedCard()
        {
            var cards = new List<Cards>
            {
                new(1, "TEST", new Characteristic(CharacteristicType.RangedAttack, 2)),
                new(2, "TEST", new Characteristic(CharacteristicType.RangedAttack, 1)),
                new(3, "TEST", new Characteristic(CharacteristicType.RangedAttack, 2)),
                new(4, "TEST", new Characteristic(CharacteristicType.Attack, 2)),
                new(5, "TEST", new Characteristic(CharacteristicType.Movement, 3))
            };

            var armor = 4;

            var result = RangedAttack.Try(cards, armor);

            result.Should().BeEquivalentTo(new RangedAttackModel
            {
                Cards = new List<Cards>
                {
                    new(4, "TEST", new Characteristic(CharacteristicType.Attack, 2)),
                    new(5, "TEST", new Characteristic(CharacteristicType.Movement, 3))
                },
                Success = true
            });
        }

        [Fact]
        public void TryToRangedAttack_AttackIsNotOk_ReturnFalse()
        {
            var cards = new List<Cards>
            {
                new(1, "TEST", new Characteristic(CharacteristicType.RangedAttack, 2))
            };

            var armor = 3;

            var result = RangedAttack.Try(cards, armor);

            result.Should().BeEquivalentTo(new RangedAttackModel
            {
                Cards = new List<Cards>
                {
                    new(1, "TEST", new Characteristic(CharacteristicType.RangedAttack, 2))
                },
                Success = false
            });
        }
    }
}