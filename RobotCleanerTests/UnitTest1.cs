using RobotCleaner;

namespace RobotCleanerTests
{
    public class UnitTest1
    {
        PositionService _positionService;
        public UnitTest1()
        {
            _positionService = new PositionService();
        }

        [Theory]
        [InlineData(0, 1, "N")]
        public void Test1(int x, int y, string direction)
        {
            var expected = new Point(1,1);
            var actual = _positionService.GetPosition(new (x, y), direction);

            Assert.Equal(expected, actual);
        }
    }
}