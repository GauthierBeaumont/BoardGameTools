using BoardGameTools.Component.MageKnight;
using BoardGameTools.Component.MageKnight.Models;
using FluentAssertions;

namespace BoardGameTools.Tests
{
    public class MageKnightAttackTests
    {
        [Fact]
        public void Try_MageKnighAttack_ReturnTrue()
        {
            var cards = new List<Cards>
            {
                new(1, "TEST", new Characteristic(CharacteristicType.Attack, 2))
            };

            var armor = 1;

            var result = MageKnightAttack.Try(cards, armor);

            result.Should().BeEquivalentTo(new ParadeModel
            {
                Success = true
            });
        }

        [Fact]
        public void Try_MageKnightAttackWithMultipleCard_ReturnTrue()
        {
            var cards = new List<Cards>
            {
                new(1, "TEST", new Characteristic(CharacteristicType.Attack, 2)),
                new(2, "TEST", new Characteristic(CharacteristicType.Attack, 1))
            };

            var armor = 3;

            var result = MageKnightAttack.Try(cards, armor);

            result.Should().BeEquivalentTo(new ParadeModel
            {
                Success = true
            });
        }

        [Fact]
        public void Try_ParadeMonsterAttackWithMultipleCard_ReturnTrueAndUnusedCard()
        {
            var cards = new List<Cards>
            {
                new(1, "TEST", new Characteristic(CharacteristicType.Attack, 2)),
                new(2, "TEST", new Characteristic(CharacteristicType.Attack, 1)),
                new(3, "TEST", new Characteristic(CharacteristicType.Attack, 1))
            };

            var armor = 3;

            var result = MageKnightAttack.Try(cards, armor);

            result.Should().BeEquivalentTo(new ParadeModel
            {
                Cards = new List<Cards> { new(3, "TEST", new Characteristic(CharacteristicType.Attack, 1)) },
                Success = true
            });
        }

        [Fact]
        public void Try_MageKnightAttackWithNoCardParade_ReturnTrue()
        {
            var cards = new List<Cards>
            {
                new(1, "TEST", new Characteristic(CharacteristicType.Parade, 2)),
                new(2, "TEST", new Characteristic(CharacteristicType.Movement, 1)),
                new(3, "TEST", new Characteristic(CharacteristicType.Movement, 1))
            };

            var armor = 3;

            var result = MageKnightAttack.Try(cards, armor);

            result.Should().BeEquivalentTo(new ParadeModel
            {
                Success = true
            });
        }

        [Fact]
        public void Try_MageKnightAttack_ReturnFalse()
        {
            var cards = new List<Cards>
            {
                new(1, "TEST", new Characteristic(CharacteristicType.Attack, 2))
            };

            var armor = 3;

            var result = MageKnightAttack.Try(cards, armor);

            result.Should().BeEquivalentTo(new ParadeModel
            {
                Success = false
            });
        }

        [Fact]
        public void Try_MageKnightAttackWithMultipleCards_ReturnFalse()
        {
            var cards = new List<Cards>
            {
                new(1, "TEST", new Characteristic(CharacteristicType.Attack, 2)),
                new(2, "TEST", new Characteristic(CharacteristicType.Attack, 2))

            };

            var armor = 5;

            var result = MageKnightAttack.Try(cards, armor);

            result.Should().BeEquivalentTo(new ParadeModel
            {
                Success = false
            });
        }

        [Fact]
        public void Try_MageKnightAttackWithNoCardAttack_ReturnFalse()
        {
            var cards = new List<Cards>
            {
                new(1, "TEST", new Characteristic(CharacteristicType.Parade, 2)),
                new(2, "TEST", new Characteristic(CharacteristicType.Movement, 2))

            };

            var armor = 3;

            var result = MageKnightAttack.Try(cards, armor);

            result.Should().BeEquivalentTo(new ParadeModel
            {
                Success = false
            });
        }
    }
}