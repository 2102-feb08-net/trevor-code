using System;
using Xunit;

namespace rockpaperscissors.Test
{
    public class RoundResultTests
    {

        [Fact]
        public void TestConstructor()
        {
            var roundResult = new RoundResult(Move.Rock, Move.Paper);

            Assert.Equal(Move.Rock, roundResult.PlayerMove);
            Assert.Equal(Move.Paper, roundResult.ComputerMove);
        }


        [Theory]
        [InlineData(Move.Rock)]
        [InlineData(Move.Paper)]
        [InlineData(Move.Scissors)]
        public void TestDraw(Move value)
        {
            var roundResult = new RoundResult(value, value);
            
            Assert.Equal(Result.Draw, roundResult.Result);
        }


        [Theory]
        [InlineData(Move.Rock, Move.Scissors)]
        [InlineData(Move.Paper, Move.Rock)]
        [InlineData(Move.Scissors, Move.Paper)]
        public void TestPlayerWin(Move player, Move computer)
        {
            var roundResult = new RoundResult(player, computer);

            Assert.Equal(Result.Win, roundResult.Result);
        }

        [Theory]
        [InlineData(Move.Rock, Move.Paper)]
        [InlineData(Move.Paper, Move.Scissors)]
        [InlineData(Move.Scissors, Move.Rock)]
        public void TestPlayerLose(Move player, Move computer)
        {
            var roundResult = new RoundResult(player, computer);

            Assert.Equal(Result.Lose, roundResult.Result);
        }
    }
}
