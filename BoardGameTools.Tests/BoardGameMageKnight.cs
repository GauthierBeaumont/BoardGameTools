using BoardGameTools.Component.MageKnight;
using BoardGameTools.Component.MageKnight.Models;
using FluentAssertions;

namespace BoardGameTools.Tests
{

    //public class BoardGameMageKnight
    //{
    //    [Fact]
    //    public void StartingHand_AttackIsOk_CardsIsNotRandom()
    //    {
    //        var cards = new List<Cards>
    //        {
    //            new("ENDURANCE", new(CharacteristicType.Movement, 2)),
    //            new("ENDURANCE", new(CharacteristicType.Movement, 2)),
    //            new("INSTINCT", new(CharacteristicType.Attack, 2)),
    //            new("ENDURANCE GIVREE", new(CharacteristicType.Attack, 2)),
    //            new("RAGE", new(CharacteristicType.Parade, 2)),
    //            new("RAGE", new(CharacteristicType.Parade, 2))
    //        };

    //        var monster = new Monsters("Rodeurs", 4, 3);

    //        var board = new BoardGameBase();
    //        var result = board.Attacking();

    //        result.Should().BeEquivalentTo(
    //            new AttackingModel(
    //                new List<Cards>(){ 
    //                    new("ENDURANCE", new(CharacteristicType.Movement, 2)), 
    //                    new("ENDURANCE", new(CharacteristicType.Movement, 2)), 
    //                }, 
    //                true));
    //    }

    //    [Fact]
    //    public void StartingHand_AttackIsOk_WithNoAttackCard()
    //    {
    //        var cards = new List<Cards>
    //        {
    //            new("ENDURANCE", new(CharacteristicType.Movement, 2)),
    //            new("ENDURANCE", new(CharacteristicType.Movement, 2)),
    //            new("MARCHE", new(CharacteristicType.Movement, 2)),
    //            new("MARCHE", new(CharacteristicType.Movement, 2)),
    //            new("RAGE", new(CharacteristicType.Parade, 2)),
    //            new("RAGE", new(CharacteristicType.Parade, 2))
    //        };

    //        var monster = new Monsters("Rodeurs", 4, 3);

    //        var board = new BoardGameBase();
    //        var result = board.Attacking();

    //        result.Should().BeEquivalentTo(
    //            new AttackingModel(
    //                new List<Cards>()
    //                {
    //                    new("MARCHE", new(CharacteristicType.Movement, 2))
    //                }, 
    //                true));
    //    }

    //    [Fact]
    //    public void StartingHand_ParadeIsOk_WithNoParadeCard()
    //    {
    //        var cards = new List<Cards>
    //        {
    //            new("ENDURANCE", new(CharacteristicType.Movement, 2)),
    //            new("ENDURANCE", new(CharacteristicType.Movement, 2)),
    //            new("MARCHE", new(CharacteristicType.Movement, 2)),
    //            new("MARCHE", new(CharacteristicType.Movement, 2)),
    //            new("RAGE", new(CharacteristicType.Attack, 2)),
    //            new("RAGE", new(CharacteristicType.Attack, 2))
    //        };

    //        var monster = new Monsters("Rodeurs", 4, 3);

    //        var board = new BoardGameBase();
    //        var result = board.Attacking();

    //        result.Should().BeEquivalentTo(new AttackingModel(new List<Cards>(), true));
    //    }

    //    [Fact]
    //    public void StartingHand_ParadeAndAttackIsOk_WithNoEnoughtParadeAndAttackValue()
    //    {
    //        var cards = new List<Cards>
    //        {
    //            new("ENDURANCE", new(CharacteristicType.Movement, 2)),
    //            new("MARCHE", new(CharacteristicType.Movement, 2)),
    //            new("RAGE", new(CharacteristicType.Attack, 1)),
    //            new("RAGE", new(CharacteristicType.Attack, 1)),
    //            new("RAGE", new(CharacteristicType.Parade, 3))
    //        };

    //        var monster = new Monsters("Rodeurs", 4, 3);

    //        var board = new BoardGameBase();
    //        var result = board.Attacking();

    //        result.Should().BeEquivalentTo(new AttackingModel(new List<Cards>(), true));
    //    }

    //}
}