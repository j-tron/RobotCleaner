using RobotCleaner;
using RobotCleaner.Interfaces;

while (true)
{
    var cleaned = ServiceProviderBuilder.GetServiceProvider<IDataBuilder>()?.Run();
    Console.WriteLine($"=> Cleaned: {cleaned}");
}