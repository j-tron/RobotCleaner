using RobotCleaner.Interfaces;
using RobotCleaner.Services.Interfaces;

namespace RobotCleaner.Services;

public class DataBuilder : IDataBuilder
{
    private readonly ICalculateDistanceService _calculateDistanceService;
    private readonly IDataReader _dataReader;

    public DataBuilder(ICalculateDistanceService calculateDistanceService, IDataReader dataReader)
    {
        _calculateDistanceService = calculateDistanceService;
        _dataReader = dataReader;
    }

    public long Run()
    {
        return _calculateDistanceService.CalculateDistances(_dataReader.GetStartingPoint(), _dataReader.GetVectors());
    }
}
