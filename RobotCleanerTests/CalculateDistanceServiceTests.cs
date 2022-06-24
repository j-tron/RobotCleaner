using RobotCleaner;

namespace RobotCleanerTests
{
    public class CalculateDistanceServiceTests
    {
        [Theory]
        [InlineData(0, 0, Direction.North, 0)]
        [InlineData(0, 0, Direction.South, 1)]
        [InlineData(0, 0, Direction.East, 32441)]
        [InlineData(0, 0, Direction.West, 9912111)]
        public void GetPointsList_One_Way_Direction_Should_Give_Expected_Values(int x, int y, Direction direction, int steps)
        {
            var expected = steps;
            var sut = new CalculateDistanceService();

            var result = sut.GetPointsList(new(x, y), new Vector(direction, steps));

            Assert.True(result.Count() == expected);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(78121)]
        public void GetPointsList_Four_Way_Distinct_Direction_Same_Steps_Should_Give_Expected_Values(int steps)
        {
            var expected = steps * 4;
            var sut = new CalculateDistanceService();

            Point north = new(0, 0);
            Point south = new(1, 1);
            Point east = new(2, 2);
            Point west = new(3, 3);

            var resultNorth = sut.GetPointsList(north, new Vector(Direction.North, steps));
            var resultSouth = sut.GetPointsList(south, new Vector(Direction.South, steps));
            var resultEast = sut.GetPointsList(east, new Vector(Direction.East, steps));
            var resultWest = sut.GetPointsList(west, new Vector(Direction.West, steps));

            Assert.True(resultNorth.Count() + resultSouth.Count() + resultEast.Count() + resultWest.Count() == expected);
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(5, 3, 2, 3)]
        [InlineData(78121, 0, 84, 212121)]
        public void GetPointsList_Four_Way_Distinct_Direction_Different_Steps_Should_Give_Expected_Values(int northSteps, int southSteps, int eastSteps, int westSteps)
        {
            var expected = northSteps + southSteps + eastSteps + westSteps;
            var sut = new CalculateDistanceService();

            Point north = new(0, 0);
            Point south = new(1, 1);
            Point east = new(2, 2);
            Point west = new(3, 3);

            var resultNorth = sut.GetPointsList(north, new Vector(Direction.North, northSteps));
            var resultSouth = sut.GetPointsList(south, new Vector(Direction.South, southSteps));
            var resultEast = sut.GetPointsList(east, new Vector(Direction.East, eastSteps));
            var resultWest = sut.GetPointsList(west, new Vector(Direction.West, westSteps));

            Assert.True(resultNorth.Count() + resultSouth.Count() + resultEast.Count() + resultWest.Count() == expected);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100000)]
        public void CalculateDistances_Distinct_Direction_Should_Give_Expected_Values(int steps)
        {
            var expected = steps + 1; //starting point
            var sut = new CalculateDistanceService();

            Point startingPoint = new(0, 0);

            var actual = sut.CalculateDistances(startingPoint, new Vector[] { new(Direction.North, steps) });

            Assert.True(actual == expected);
        }

        [Theory]
        [InlineData(1, 2, 2, 2)]
        [InlineData(10, 6532, 2354, 2)]
        [InlineData(100000, 100000, 100000, 100000)]
        public void CalculateDistances_Four_Way_Distinct_Direction_Different_Steps_Should_Give_Expected_Values(int northSteps, int southSteps, int eastSteps, int westSteps)
        {
            var expected = northSteps + southSteps + eastSteps + westSteps + 1; //starting point
            var sut = new CalculateDistanceService();

            Point startingPoint = new(0, 0);

            var actual = sut.CalculateDistances(startingPoint, new Vector[] { new(Direction.North, northSteps), new(Direction.East, eastSteps), new(Direction.South, southSteps), new(Direction.West, westSteps) });

            Assert.True(actual == expected);
        }

        [Fact]
        public void CalculateDistances_Four_Way_NoDistinct_Direction_Different_Steps_Should_Give_Expected_Values()
        {
            var expected = 4; //last step ends up in starting point
            var sut = new CalculateDistanceService();

            Point startingPoint = new(0, 0);

            var actual = sut.CalculateDistances(startingPoint, new Vector[] { new(Direction.North, 1), new(Direction.East, 1), new(Direction.South, 1), new(Direction.West, 1) });

            Assert.True(actual == expected);

            //sista steg ska testa hela vagen med en testfil
        }

        [Theory]
        [InlineData(100000, 100000, 100000, 100000)]
        public void CalculateDistances_Four_Way_NoDistinct_Direction_Max_Steps_Should_Give_Expected_Values(int northSteps, int southSteps, int eastSteps, int westSteps)
        {
            var expected = northSteps + southSteps + eastSteps + westSteps; //last step ends up in starting point
            var sut = new CalculateDistanceService();

            Point startingPoint = new(0, 0);

            var actual = sut.CalculateDistances(startingPoint, new Vector[] { new(Direction.North, northSteps), new(Direction.East, eastSteps), new(Direction.South, southSteps), new(Direction.West, westSteps) });

            Assert.True(actual == expected);

            //sista steg ska testa hela vagen med en testfil
        }
    }
}
