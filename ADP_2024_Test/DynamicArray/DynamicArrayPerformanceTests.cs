using ADP_2024;
using ADP_2024.DynamicArray;
using System.Diagnostics;

namespace ADP_2024_Test.DynamicArray;

[TestClass]
public sealed class DynamicArrayPerformanceTests
{
    public required DatasetReader reader;

    [TestInitialize]
    public void SetUp()
    {
        reader = new DatasetReader();
    }

    /*
    Exectuion time:
    |-------------------------------|
    | N         | Time              |
    |-------------------------------|
    | 10        | 00:00:00.0000004  |
    | 100       | 00:00:00.0000033  |
    | 1000      | 00:00:00.0000132  |
    | 10_000    | 00:00:00.0000791  |
    | 100_000   | 00:00:00.0013540  |
    | 1_000_000 | 00:00:00.0119180  |
    |-------------------------------|
    */
    [TestMethod]
    [DataRow(10, 10)]
    [DataRow(100, 100)]
    [DataRow(1000, 1000)]
    [DataRow(10_000, 10_000)]
    [DataRow(100_000, 100_000)]
    [DataRow(1_000_000, 1_000_000)]
    public void TestAddTimeComplexity(int amount, int expectedAmount)
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>();

        var watch = Stopwatch.StartNew();

        // Act
        for (var i = 0; i < amount; i++)
        {
            dynamicArray.Add(i);
        }

        // Assert
        watch.Stop();

        var elapsedMs = watch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreEqual(expectedAmount, dynamicArray.Count);
    }

    /*
    Execution time:
    |-------------------------------|
    | N         | Time              |
    |-------------------------------|
    | 10        | 00:00:00.0001541  |
    | 100       | 00:00:00.0001724  |
    | 1000      | 00:00:00.0010575  |
    | 10_000    | 00:00:00.1609186  |
    | 100_000   | 00:00:11.5904742  |
    | 1_000_000 | 00:27:03.2711971  |
    |-------------------------------|

    Comments on performance:
    1. Items are always removed from index 0 which means all elements after have to get shifted. 
       This test tests the worst case scenario.
    2. Space complexity is taken into account in the implementation by shrinking the array 
       to half its size when it reaches 25% or less of its maximum size. This could have been omitted 
       to improve performance.
    */
    [TestMethod]
    [DataRow(10, 0)]
    [DataRow(100, 0)]
    [DataRow(1000, 0)]
    [DataRow(10_000, 0)]
    [DataRow(100_000, 0)]
    [DataRow(1_000_000, 0)]
    public void TestRemoveTimeComplexity(int amount, int expectedAmount)
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>();

        for (var i = 0; i < amount; i++)
        {
            dynamicArray.Add(i);
        }

        var watch = Stopwatch.StartNew();

        // Act
        for (int i = 0; i < amount; i++)
        {
            dynamicArray.Remove(0);
        }

        // Assert
        watch.Stop();

        var elapsedMs = watch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreEqual(expectedAmount, dynamicArray.Count);
    }
}
