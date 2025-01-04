using ADP_2024;

namespace ADP_2024_Test.Graph;

[TestClass]
public class GraphPerformanceTests
{
    public required DatasetReader reader;

    [TestInitialize]
    public void SetUp()
    {
        reader = new DatasetReader();
    }
}