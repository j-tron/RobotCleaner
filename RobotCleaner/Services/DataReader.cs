using RobotCleaner.Interfaces;
using RobotCleaner.Models;

namespace RobotCleaner.Services;

public class DataReader : IDataReader
{
    public readonly int nrOfCommands;
    public readonly Point startingPoint;
    private readonly IEnumerable<Vector> _vectors;

    public DataReader()
    {

        nrOfCommands = int.Parse(Console.ReadLine()!);
        startingPoint = GetStartingPoint(Console.ReadLine()!);
        _vectors = GetVectors(nrOfCommands);
    }

    public Point GetStartingPoint()
    {
        return startingPoint;
    }

    public IEnumerable<Vector> GetVectors()
    {
        return _vectors;
    }

    private static Point GetStartingPoint(string startingPoints)
    {
        var startingPoint = startingPoints.Split(' ');
        int x = int.Parse(startingPoint[0]);
        int y = int.Parse(startingPoint[1]);

        return new(x, y);
    }
    private static IEnumerable<Vector> GetVectors(int nrOfCommands)
    {
        for (int i = 0; i < nrOfCommands; i++)
        {
            var command = Console.ReadLine()?.Split(' ');
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            yield return Vector.GetVector(command[0], int.Parse(command[1]));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}