namespace RobotCleaner
{
    public class CalculateDistanceService
    {
        public IEnumerable<Point> CalculateDistance(Point point, string direction, int steps)
        {
            PositionService positionService = new();
            //Dictionary<Point, bool> visitedPoints = new();

            for (int i = 0; i < steps; i++)
            {
                yield return positionService.GetPosition(point, direction);

                //if (!visitedPoints.ContainsKey(position))
                //{
                //    yield return position;
                //    //visitedPoints.Add(position, true);
                //}
            }

            //return visitedPoints;
        }
    }
}
