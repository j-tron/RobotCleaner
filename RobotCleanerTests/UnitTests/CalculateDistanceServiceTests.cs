using RobotCleaner.Models;
using RobotCleaner.Services;
using RobotCleaner.Services.Interfaces;

namespace RobotCleanerTests.UnitTests;

public class CalculateDistanceServiceTests
{
    [Fact]
    public void CalculateDistances_With_Empty_List_Should_Return_One()
    {
        const int expected = 1; //First step is starting point

        var sut = GetSut(new Point[] { });

        Point startingPoint = new(0, 0);

        var actual = sut.CalculateDistances(startingPoint, new Vector[] { new(Direction.North, 1) });

        Assert.True(actual == expected);
    }

    private static CalculateDistanceService GetSut(IEnumerable<Point> points)
    {
        var pointsService = new Mock<IPointsService>();
        pointsService.Setup(x => x.GetPointsList(It.IsAny<Point>(), It.IsAny<Vector>())).Returns(points);

        return new CalculateDistanceService(pointsService.Object);
    }
}
