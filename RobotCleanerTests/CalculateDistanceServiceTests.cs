using RobotCleaner;

namespace RobotCleanerTests
{
    public class CalculateDistanceServiceTests
    {
        [Theory]
        [InlineData(0, 0, "N", 0)]
        [InlineData(0, 0, "S", 1)]
        [InlineData(0, 0, "E", 32441)]
        [InlineData(0, 0, "W", 9912111)]
        public void CalculateDistance_One_Way_Direction_Should_Give_Expected_Values(int x, int y, string direction, int steps)
        {
            var expected = steps;
            var sut = new CalculateDistanceService();

            var result = sut.CalculateDistance(new(x, y), direction, steps);

            Assert.True(result.Count() == expected);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(78121)]
        public void CalculateDistance_Four_Way_Distinct_Direction_Same_Steps_Should_Give_Expected_Values(int steps)
        {
            var expected = steps * 4;
            var sut = new CalculateDistanceService();

            Point north = new(0, 0);
            Point south = new(1, 1);
            Point east = new(2, 2);
            Point west = new(3, 3);

            var resultNorth = sut.CalculateDistance(north, "N", steps);
            var resultSouth = sut.CalculateDistance(south, "S", steps);
            var resultEast = sut.CalculateDistance(east, "E", steps);
            var resultWest = sut.CalculateDistance(west, "W", steps);

            Assert.True(resultNorth.Count() + resultSouth.Count() + resultEast.Count() + resultWest.Count() == expected);
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(5, 3, 2, 3)]
        [InlineData(78121, 0, 84, 212121)]
        public void CalculateDistance_Four_Way_Distinct_Direction_Different_Steps_Should_Give_Expected_Values(int northSteps, int southSteps, int eastSteps, int westSteps)
        {
            var expected = northSteps + southSteps + eastSteps + westSteps;
            var sut = new CalculateDistanceService();

            Point north = new(0, 0);
            Point south = new(1, 1);
            Point east = new(2, 2);
            Point west = new(3, 3);

            var resultNorth = sut.CalculateDistance(north, "N", northSteps);
            var resultSouth = sut.CalculateDistance(south, "S", southSteps);
            var resultEast = sut.CalculateDistance(east, "E", eastSteps);
            var resultWest = sut.CalculateDistance(west, "W", westSteps);

            Assert.True(resultNorth.Count() + resultSouth.Count() + resultEast.Count() + resultWest.Count() == expected);
        }
    }
}
