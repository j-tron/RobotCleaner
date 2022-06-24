namespace RobotCleaner
{
    public class PositionService
    {
        private static Exception GetArgumentOutOfRangeException()
        {
            return new ArgumentOutOfRangeException($"Unkown direction");
        }

        public Point GetPosition(Point point, Direction direction) => direction switch
        {
            Direction.North => new Point(point.X + 1, point.Y),
            Direction.South => new Point(point.X - 1, point.Y),
            Direction.East => new Point(point.X, point.Y + 1),
            Direction.West => new Point(point.X, point.Y - 1),
            _ => throw GetArgumentOutOfRangeException()
        };
    }
}
