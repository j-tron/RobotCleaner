using RobotCleaner.Models;

namespace RobotCleaner.Interfaces;

public interface IDataReader
{
    Point GetStartingPoint();
    IEnumerable<Vector> GetVectors();
}