using RobotCleaner.Interfaces;

namespace RobotCleanerTests.IntegrationTests;

public class DataReaderTests
{
    [Fact]
    public void DataBuilder_Should_Return_Correct()
    {
        var cleaned = new IntegrationServiceBuilder(@"..\..\..\IntegrationTests\TestData.txt").GetServiceProvider<IDataBuilder>()?.Run();

        Assert.True(cleaned == 4);
    }

    [Fact]
    public void DataBuilder_With_Large_File_Should_Return_Correct()
    {
        var expected = 400000;
        var cleaned = new IntegrationServiceBuilder(@"..\..\..\IntegrationTests\TestDataBigger.txt").GetServiceProvider<IDataBuilder>()?.Run();

        Assert.True(cleaned == expected);
    }
}
