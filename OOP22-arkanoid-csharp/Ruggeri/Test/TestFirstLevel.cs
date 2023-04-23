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
        private const int NormalFirst = 19;
        private const int SurpriseFirst = 2;

        [Fact]
        public void Test()
        {
            ILevel level = new FirstLevel();
            level.FirstRound();
            Assert.Equal(NormalFirst + SurpriseFirst, level.CurrentRound.GetBrick().Count);
            Assert.Equal(NormalFirst, level.CurrentRound.GetBrick().Count - SurpriseFirst);
            Assert.Equal(SurpriseFirst, level.CurrentRound.GetBrick().Count - NormalFirst);
        }
    }
}