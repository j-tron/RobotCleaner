namespace RobotCleaner
{
    public partial class CalculateDistanceService
    {
        public IEnumerable<Point> GetPointsList(Point point, Vector vector)
        {
            PositionService positionService = new();
            Point currentPoint = point;
            for (int i = 0; i < vector.Steps; i++)
            {
                var res = positionService.GetPosition(currentPoint, vector.Direction);

                yield return res;

                currentPoint = res;
            }
        }
        public long CalculateDistances(Point startingPoint, IEnumerable<Vector> vectors)
        {
            Dictionary<Point, bool> visitedPoints = new()
            {
                { startingPoint, true } //starting position is considered to have been visited
            };
            Point currentPoint = startingPoint;
            foreach (var vector in vectors)
            {
                var points = GetPointsList(currentPoint, vector);

                foreach (var point in points)
                {
                    if (!visitedPoints.ContainsKey(point))
                    {
                        visitedPoints.Add(point, true);
                    }
                }
                currentPoint = points.Last();
            }

            return visitedPoints.Count;
        }
    }
}
