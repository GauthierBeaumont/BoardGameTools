using BoardGameTools.Component.MageKnight;
using BoardGameTools.Component.MageKnight.NewFolder.Models;
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
                new("TEST", new Characteristic(CharacteristicType.RangedAttack, 2))
            };

            var armor = 1;

            var result = RangedAttack.With(cards, armor).Try();
            result.Should().BeTrue();
        }

        [Fact]
        public void TryToRangedAttack_AttackIsOkWithMultipleCards_ReturnTrue()
        {

        }
    }
}