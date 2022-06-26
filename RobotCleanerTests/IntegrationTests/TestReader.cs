using RobotCleaner.Interfaces;
using RobotCleaner.Models;

namespace RobotCleanerTests.IntegrationTests
{
    internal class TestReader : IDataReader
    {
        private Point _startingPoint;
        private IEnumerable<Vector> _vectors;

        public Point GetStartingPoint()
        {
            return _startingPoint;
        }

        public IEnumerable<Vector> GetVectors()
        {
            return _vectors;
        }
        public TestReader(string file)
        {
            var lines = File.ReadAllLines(file);
            _startingPoint = GetStartingPoint(lines[1]);

            _vectors = GetVectors(lines);
        }

        private static Point GetStartingPoint(string startingPoints)
        {
            var startingPoint = startingPoints.Split(' ');
            int x = int.Parse(startingPoint[0]);
            int y = int.Parse(startingPoint[1]);

            return new(x, y);
        }
        private static IEnumerable<Vector> GetVectors(string[] lines)
        {
            for (int i = 2; i < lines.Length; i++)
            {
                var command = lines[i].Split(' ');
                yield return Vector.GetVector(command[0], int.Parse(command[1]));
            }
        }
    }
}
