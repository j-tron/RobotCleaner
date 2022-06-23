namespace RobotCleaner
{
    public class PositionService
    {
        public Point GetPosition(Point point, string compassDirection)
        {
            return compassDirection switch
            {
                "N" => new Point(point.X + 1, point.Y),
                "S" => new Point(point.X - 1, point.Y),
                "E" => new Point(point.X, point.Y + 1),
                "W" => new Point(point.X, point.Y - 1),
                _ => throw new ArgumentOutOfRangeException($"Direction: {compassDirection} invalid"),
            };
        }
    }
}
