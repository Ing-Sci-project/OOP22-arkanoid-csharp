// importare le librerie necessarie
using Xunit;
using Moq;
using Castiglioni.Game;
using MovingShapesImpl;
using OOP22_arkanoid_csharp.Desiderio.Api;

// importare le librerie necessarie
using Xunit;
using Foschi.Game;

public class MovingObjectTest
{
    [Fact]
    public void Ball_PositionIsSetCorrectly()
    {
        // creare una palla di prova
        var ball = new Ball(new Dimension(10, 10));

        // verificare che la posizione sia stata impostata correttamente
        var expectedX = SizeCalculation.GetWorldSize().Item2 / 2 - 5;
        var expectedY = SizeCalculation.GetWorldSize().Item1 - 100 - 20 - 5;
        Assert.Equal(expectedX, ball.Pos.Item1);
        Assert.Equal(expectedY, ball.Pos.Item2);
    }

    [Fact]
    public void Pad_PositionIsSetCorrectly()
    {
        // creare una pedana di prova
        var pad = new Pad(new Dimension(50, 10));

        // verificare che la posizione sia stata impostata correttamente
        var expectedX = SizeCalculation.GetWorldSize().Item2 / 2 - 25;
        var expectedY = SizeCalculation.GetWorldSize().Item1 - 100;
        Assert.Equal(expectedX, pad.Pos.Item1);
        Assert.Equal(expectedY, pad.Pos.Item2);
    }
}