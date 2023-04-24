// importare le librerie necessarie
using Xunit;
using Moq;

public class MovingObjectTest
{
    [Fact]
    public void Ball_PositionIsSetCorrectly()
    {
        // creare una dimensione di prova
        var dimension = new Mock<IDimension>();
        dimension.SetupGet(d => d.Width).Returns(10);
        dimension.SetupGet(d => d.Height).Returns(10);

        // creare una palla di prova
        var ball = new Ball(dimension.Object);

        // verificare che la posizione sia stata impostata correttamente
        var expectedX = SizeCalculation.GetWorldSize().Item2 / 2 - dimension.Object.Width / 2;
        var expectedY = SizeCalculation.GetWorldSize().Item1 - 100 - 2 * dimension.Object.Height - 5;
        Assert.Equal(expectedX, ball.Pos.Item1);
        Assert.Equal(expectedY, ball.Pos.Item2);
    }

    [Fact]
    public void Pad_PositionIsSetCorrectly()
    {
        // creare una dimensione di prova
        var dimension = new Mock<IDimension>();
        dimension.SetupGet(d => d.Width).Returns(50);
        dimension.SetupGet(d => d.Height).Returns(10);

        // creare una pedana di prova
        var pad = new Pad(dimension.Object);

        // verificare che la posizione sia stata impostata correttamente
        var expectedX = SizeCalculation.GetWorldSize().Item2 / 2 - dimension.Object.Width / 2;
        var expectedY = SizeCalculation.GetWorldSize().Item1 - 100;
        Assert.Equal(expectedX, pad.Pos.Item1);
        Assert.Equal(expectedY, pad.Pos.Item2);
    }
}