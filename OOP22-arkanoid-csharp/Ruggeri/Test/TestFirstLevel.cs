using Xunit;
using Ruggeri.Api;
using Ruggeri.Game;

namespace Ruggeri.Test
{
    /// <summary>
    /// RoundEasy test class.
    /// </summary>
    public class TestFirstLevel
    {
        private const int NORMAL_FIRST = 19;
        private const int SURPRISE_FIRST = 2;

        [Fact]
        public void Test()
        {
            ILevel level = new FirstLevel();
            level.FirstRound();
            Assert.Equal(NORMAL_FIRST + SURPRISE_FIRST, level.CurrentRound.GetBrick().Count);
            Assert.Equal(NORMAL_FIRST, level.CurrentRound.GetBrick().Count - SURPRISE_FIRST);
            Assert.Equal(SURPRISE_FIRST, level.CurrentRound.GetBrick().Count - NORMAL_FIRST);
        }
    }
}