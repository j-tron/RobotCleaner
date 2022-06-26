using RobotCleaner.Models;
using RobotCleaner.Services;
using RobotCleaner.Services.Interfaces;

namespace RobotCleanerTests.UnitTests;

public class PointsServiceTests
{
    private readonly Mock<IPositionService> _positionService;
    public PointsServiceTests()
    {
        _positionService = new();
    }

    [Theory]
    [InlineData(0, 0, Direction.North, 0)]
    [InlineData(0, 0, Direction.South, 1)]
    [InlineData(0, 0, Direction.East, 325)]
    public void GetPointsList_One_Way_Direction_Should_Give_Expected_Values(int x, int y, Direction direction, int steps)
    {
        var expected = steps;
        var sut = GetSut();

        var result = sut.GetPointsList(new(x, y), new Vector(direction, steps));

        Assert.True(result.Count() == expected);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(325)]
    public void GetPointsList_Four_Way_Distinct_Direction_Same_Steps_Should_Give_Expected_Values(int steps)
    {
        var expected = steps * 4;
        var sut = GetSut();

        var resultNorth = sut.GetPointsList(new Point(0, 0), new Vector(Direction.North, steps));
        var resultSouth = sut.GetPointsList(new Point(1, 1), new Vector(Direction.South, steps));
        var resultEast = sut.GetPointsList(new Point(2, 2), new Vector(Direction.East, steps));
        var resultWest = sut.GetPointsList(new Point(3, 3), new Vector(Direction.West, steps));

        Assert.True(resultNorth.Count() + resultSouth.Count() + resultEast.Count() + resultWest.Count() == expected);
    }

    [Theory]
    [InlineData(0, 0, 0, 0)]
    [InlineData(5, 3, 2, 3)]
    public void GetPointsList_Four_Way_Distinct_Direction_Different_Steps_Should_Give_Expected_Values(int northSteps, int southSteps, int eastSteps, int westSteps)
    {
        var expected = northSteps + southSteps + eastSteps + westSteps;
        var sut = GetSut();

        var resultNorth = sut.GetPointsList(new Point(0, 0), new Vector(Direction.North, northSteps));
        var resultSouth = sut.GetPointsList(new Point(1, 1), new Vector(Direction.South, southSteps));
        var resultEast = sut.GetPointsList(new Point(2, 2), new Vector(Direction.East, eastSteps));
        var resultWest = sut.GetPointsList(new Point(3, 3), new Vector(Direction.West, westSteps));

        Assert.True(resultNorth.Count() + resultSouth.Count() + resultEast.Count() + resultWest.Count() == expected);
    }

    private PointsService GetSut()
    {
        _positionService.Setup(x => x.GetPosition(It.IsAny<Point>(), It.IsAny<Direction>())).Returns(new Point(0, 0));
        return new PointsService(_positionService.Object);
    }
}
