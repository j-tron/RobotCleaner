using RobotCleaner.Models;
using RobotCleaner.Services.Interfaces;

namespace RobotCleaner.Services;

public class PointsService : IPointsService
{
    private readonly IPositionService _positionService;

    public PointsService(IPositionService positionService)
    {
        _positionService = positionService;
    }
    public IEnumerable<Point> GetPointsList(Point point, Vector vector)
    {
        Point currentPoint = point;
        for (int i = 0; i < vector.Steps; i++)
        {
            var res = _positionService.GetPosition(currentPoint, vector.Direction);

            yield return res;

            currentPoint = res;
        }
    }
}
