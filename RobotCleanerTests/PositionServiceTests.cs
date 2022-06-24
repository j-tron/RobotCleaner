using RobotCleaner;

namespace RobotCleanerTests
{
    public class PositionServiceTests
    {
        PositionService _positionService;
        public PositionServiceTests()
        {
            _positionService = new PositionService();
        }

        [Theory]
        [InlineData(0, 0, 1, 0)]
        [InlineData(-1, 0, 0, 0)]
        [InlineData(-4872, -9345, -4871, -9345)]
        [InlineData(9877, 743421, 9878, 743421)]
        public void PositionService_Direction_North_Should_Give_Expected_Values(int x, int y, int newX, int newY)
        {
            TestSut(x, y, newX, newY, Direction.North);
        }

        [Theory]
        [InlineData(0, 0, -1, 0)]
        [InlineData(1, 0, 0, 0)]
        [InlineData(-4254, -9345, -4255, -9345)]
        [InlineData(1, 743421, 0, 743421)]
        public void PositionService_Direction_South_Should_Give_Expected_Values(int x, int y, int newX, int newY)
        {
            TestSut(x, y, newX, newY, Direction.South);
        }

        [Theory]
        [InlineData(0, 0, 0, 1)]
        [InlineData(0, -1, 0, 0)]
        [InlineData(-4254, -9345, -4254, -9344)]
        [InlineData(743421, 6573, 743421, 6574)]
        public void PositionService_Direction_East_Should_Give_Expected_Values(int x, int y, int newX, int newY)
        {
            TestSut(x, y, newX, newY, Direction.East);
        }

        [Theory]
        [InlineData(0, 0, 0, -1)]
        [InlineData(0, 1, 0, 0)]
        [InlineData(-4254, -9345, -4254, -9346)]
        [InlineData(743421, 6573, 743421, 6572)]
        public void PositionService_Direction_West_Should_Give_Expected_Values(int x, int y, int newX, int newY)
        {
            TestSut(x, y, newX, newY, Direction.West);
        }

        private void TestSut(int x, int y, int newX, int newY, Direction direction)
        {
            var expected = new Point(newX, newY);
            var actual = _positionService.GetPosition(new(x, y), direction);

            Assert.Equal(expected, actual);
        }
    }
}