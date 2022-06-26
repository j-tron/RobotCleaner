using RobotCleaner.Models;

namespace RobotCleaner.Services.Interfaces;

public interface ICalculateDistanceService
{
    long CalculateDistances(Point startingPoint, IEnumerable<Vector> vectors);
}