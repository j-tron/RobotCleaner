using Microsoft.Extensions.DependencyInjection;
using RobotCleaner.Interfaces;
using RobotCleaner.Services;
using RobotCleaner.Services.Interfaces;

namespace RobotCleanerTests.IntegrationTests
{
    internal class IntegrationServiceBuilder
    {
        private readonly ServiceProvider _services;

        public IntegrationServiceBuilder(string file)
        {
            _services = new ServiceCollection()
                        .AddSingleton<ICalculateDistanceService, CalculateDistanceService>()
                        .AddSingleton<IPointsService, PointsService>()
                        .AddSingleton<IPositionService, PositionService>()
                        .AddSingleton<IDataReader>(new TestReader(file))
                        .AddSingleton<IDataBuilder, DataBuilder>()
                        .BuildServiceProvider();
        }
        public T GetServiceProvider<T>() => _services.GetService<T>()!;
    }
}
