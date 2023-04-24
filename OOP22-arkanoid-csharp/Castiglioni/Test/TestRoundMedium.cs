using Xunit;
using Castiglioni.Game;
using Castiglioni.Api;

namespace Castiglioni.Test
{
    /// <summary>
    /// RoundMedium and Round test class.
    /// </summary>
    public class TestRoundMedium
    {

        private const int BrickRow = 15;
        private const int Jump = 4;
        private const int Gray = 8;
        private const int Normal = 37;
        private const int Surprise = 3;
        private const int SizeList = Gray + Surprise + Normal;
        private const int BrickCol = 4;
        /// <summary>
        /// tests the size of the brick list, the Remove and the AddSurprise method.
        /// </summary>
        [Fact]
        public void TestRoundM()
        {
            IRound round = new RoundMedium(Jump, Normal, Surprise, Gray, new SizeCalculation(BrickCol, BrickRow));
            Assert.Equal(SizeList, round.GetBrick().Count);
            int gray = 0;
            int sur = 0;
            int indexG = 0;
            int indexS = 0;
            foreach (var b in round.GetBrick())
            {
                if (b.Type.Equals(BrickType.SURPRISE))
                {
                    indexS = round.GetBrick().IndexOf(b);
                    sur++;
                }
                else if (b.GetRes().Equals(2))
                {
                    indexG = round.GetBrick().IndexOf(b);
                    gray++;
                }
            }
            Assert.Equal(Gray, gray);
            Assert.Equal(Surprise, sur);
            round.Remove(indexG);
            Assert.Equal(SizeList, round.GetBrick().Count);
            round.Remove(indexS);
            Assert.Equal(SizeList - 1, round.GetBrick().Count);
            Assert.True(round.GetSurprise().Count.Equals(1));

        }
    }
}