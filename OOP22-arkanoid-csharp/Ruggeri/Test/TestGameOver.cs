using Xunit;
using Ruggeri.Api;
using Ruggeri.Game;

namespace Ruggeri.Test
{
    /// <summary>
    /// GameOver test class.
    /// </summary>
    public class TestGameOver
    {
        [Fact]
        public void Test()
        {
            bool isFinished;
            ILevel level = new FirstLevel();
            level.FirstRound();
            GameOver gameOver = new GameOver(level.CurrentRound);

            while (!level.CurrentRound.GetBrick().Any())
            {
                level.CurrentRound.GetBrick().RemoveAt(0);
            }
            Assert.Equal(0, level.CurrentRound.GetBrick().Count);
            isFinished = gameOver.IsRoundFinished();
            Assert.True(isFinished);
        }
    }
}