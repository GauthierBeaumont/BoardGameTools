using BoardGameTools.Component.MageKnight;
using BoardGameTools.Component.MageKnight.Models;
using FluentAssertions;

namespace BoardGameTools.Tests
{

    public class MonsterAttackTests
    {
        [Fact]
        public void Try_ParadeMonsterAttack_ReturnTrue()
        {
            var cards = new List<Cards>
            {
                new(1, "TEST", new Characteristic(CharacteristicType.Parade, 2))
            };

            var attack = 1;

            var result = MonsterAttack.TryParade(cards, attack);

            result.Should().BeEquivalentTo(new ParadeModel
            {
                Success = true
            });
        }

        [Fact]
        public void Try_ParadeMonsterAttackWithMultipleCard_ReturnTrue()
        {
            var cards = new List<Cards>
            {
                new(1, "TEST", new Characteristic(CharacteristicType.Parade, 2)),
                new(2, "TEST", new Characteristic(CharacteristicType.Parade, 1))
            };

            var attack = 3;

            var result = MonsterAttack.TryParade(cards, attack);

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
                new(1, "TEST", new Characteristic(CharacteristicType.Parade, 2)),
                new(2, "TEST", new Characteristic(CharacteristicType.Parade, 1)),
                new(3, "TEST", new Characteristic(CharacteristicType.Parade, 1))
            };

            var attack = 3;

            var result = MonsterAttack.TryParade(cards, attack);

            result.Should().BeEquivalentTo(new ParadeModel
            {
                Cards = new List<Cards> { new(3, "TEST", new Characteristic(CharacteristicType.Parade, 1)) },
                Success = true
            });
        }

        [Fact]
        public void Try_ParadeMonsterAttackWithNoCardParade_ReturnTrue()
        {
            var cards = new List<Cards>
            {
                new(1, "TEST", new Characteristic(CharacteristicType.Attack, 2)),
                new(2, "TEST", new Characteristic(CharacteristicType.Movement, 1)),
                new(3, "TEST", new Characteristic(CharacteristicType.Movement, 1))
            };

            var attack = 3;

            var result = MonsterAttack.TryParade(cards, attack);

            result.Should().BeEquivalentTo(new ParadeModel
            {
                Success = true
            });
        }

        [Fact]
        public void Try_ParadeMonsterAttack_ReturnFalse()
        {
            var cards = new List<Cards>
            {
                new(1, "TEST", new Characteristic(CharacteristicType.Parade, 2))
            };

            var attack = 3;

            var result = MonsterAttack.TryParade(cards, attack);

            result.Should().BeEquivalentTo(new ParadeModel
            {
                Success = false
            });
        }

        [Fact]
        public void Try_ParadeMonsterAttackWithMultipleCards_ReturnFalse()
        {
            var cards = new List<Cards>
            {
                new(1, "TEST", new Characteristic(CharacteristicType.Parade, 2)),
                new(2, "TEST", new Characteristic(CharacteristicType.Parade, 2))

            };

            var attack = 5;

            var result = MonsterAttack.TryParade(cards, attack);

            result.Should().BeEquivalentTo(new ParadeModel
            {
                Success = false
            });
        }

        [Fact]
        public void Try_ParadeMonsterAttackWithNoCardParade_ReturnFalse()
        {
            var cards = new List<Cards>
            {
                new(1, "TEST", new Characteristic(CharacteristicType.Attack, 2)),
                new(2, "TEST", new Characteristic(CharacteristicType.Movement, 2))

            };

            var attack = 3;

            var result = MonsterAttack.TryParade(cards, attack);

            result.Should().BeEquivalentTo(new ParadeModel
            {
                Success = false
            });
        }
    }
}