using RobotCleaner.Models;

namespace RobotCleaner.Services.Interfaces;

public interface IPointsService
{
    IEnumerable<Point> GetPointsList(Point point, Vector vector);
}