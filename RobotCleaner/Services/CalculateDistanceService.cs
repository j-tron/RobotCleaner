using RobotCleaner.Models;
using RobotCleaner.Services.Interfaces;

namespace RobotCleaner.Services
{
    public class CalculateDistanceService : ICalculateDistanceService
    {
        private readonly IPointsService _pointsService;

        public CalculateDistanceService(IPointsService pointsService)
        {
            _pointsService = pointsService;
        }
        public long CalculateDistances(Point startingPoint, IEnumerable<Vector> vectors)
        {
            HashSet<Point> visitedPoints = new()
            {
                { startingPoint } //starting position is considered to have already been visited
            };

            Point lastVisitedPoint = startingPoint;

            foreach (var vector in vectors)
            {
                foreach (var currentPoint in _pointsService.GetPointsList(lastVisitedPoint, vector))
                {
                    if (!visitedPoints.Contains(currentPoint))
                    {
                        visitedPoints.Add(currentPoint);
                    }

                    lastVisitedPoint = currentPoint;
                }
            }

            return visitedPoints.Count;
        }
    }
}
