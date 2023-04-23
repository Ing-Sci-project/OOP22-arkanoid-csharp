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

            level.CurrentRound.GetBrick().Clear();

            Assert.Empty(level.CurrentRound.GetBrick());
            isFinished = gameOver.IsRoundFinished();
            Assert.True(isFinished);
        }
    }
}