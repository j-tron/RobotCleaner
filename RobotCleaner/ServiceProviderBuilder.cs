using Microsoft.Extensions.DependencyInjection;
using RobotCleaner.Interfaces;
using RobotCleaner.Services;
using RobotCleaner.Services.Interfaces;

namespace RobotCleaner
{
    public class ServiceProviderBuilder
    {
        private static readonly ServiceProvider _services;

        static ServiceProviderBuilder()
        {
            _services = new ServiceCollection()
                        .AddSingleton<ICalculateDistanceService, CalculateDistanceService>()
                        .AddSingleton<IPointsService, PointsService>()
                        .AddSingleton<IPositionService, PositionService>()
                        .AddSingleton<IDataReader, DataReader>()
                        .AddSingleton<IDataBuilder, DataBuilder>()
                        .BuildServiceProvider();
        }
        public static T GetServiceProvider<T>() => _services.GetService<T>()!;
    }
}
