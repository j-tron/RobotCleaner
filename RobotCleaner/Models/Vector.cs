namespace RobotCleaner.Models
{
    public class Vector
    {
        public Direction Direction { get; }
        public int Steps { get; }

        public Vector(Direction direction, int steps)
        {
            Direction = direction;
            Steps = steps;
        }

        public static Vector GetVector(string direction, int steps)
        {
            switch (direction)
            {
                case "N":
                    return new(Direction.North, steps);
                case "S":
                    return new(Direction.South, steps);
                case "W":
                    return new(Direction.West, steps);
                case "E":
                    return new(Direction.East, steps);
                default:
                    throw new ArgumentOutOfRangeException($"{direction} is not valid direction");
            }
        }
    }


}
