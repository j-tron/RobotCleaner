namespace RobotCleaner
{
    public record struct Vector(Direction Direction, int Steps);

    public enum Direction
    {
        North,
        South,
        West,
        East,
    }
}
