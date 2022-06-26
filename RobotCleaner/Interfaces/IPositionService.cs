using RobotCleaner.Models;

namespace RobotCleaner.Services.Interfaces;

public interface IPositionService
{
    Point GetPosition(Point point, Direction direction);
}