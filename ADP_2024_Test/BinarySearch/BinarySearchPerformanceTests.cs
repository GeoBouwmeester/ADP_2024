using ADP_2024;
using ADP_2024.BinarySearch;
using System.Diagnostics;

namespace ADP_2024_Test.BinarySearch;

[TestClass]
public class BinarySearchPerformanceTests
{
    public required DatasetReader reader;

    [TestInitialize]
    public void SetUp()
    {
        reader = new DatasetReader();
    }

    /*
    Execution time:
    |-----------------------------------|
    | N             | Time              |
    |-----------------------------------|
    | 1_000         | 00:00:00.0000029  |
    | 10_000        | 00:00:00.0000017  |
    | 100_000       | 00:00:00.0000002  |
    | 1_000_000     | 00:00:00.0000003  |
    | 10_000_000    | 00:00:00.0000005  |
    | 100_000_000   | 00:00:00.0000004  |
    | 1_000_000_000 | 00:00:00.0000010  |
    |-----------------------------------|
    */
    [TestMethod]
    [DataRow(1_000, 999)]
    [DataRow(10_000, 9_999)]
    [DataRow(100_000, 99_999)]
    [DataRow(1_000_000, 999_999)]
    [DataRow(10_000_000, 9_999_999)]
    [DataRow(100_000_000, 99_999_999)]
    [DataRow(1_000_000_000, 999_999_999)]
    public void TestLastItem(int arraySize, int target)
    {
        // Arrange
        int[] array = new int[arraySize];

        for (int i = 0; i < arraySize; i++)
        {
            array[i] = i;
        }

        // Warm-up
        BinarySearchAlgorithm.BinarySearch(array, target);

        Stopwatch stopwatch = new();

        stopwatch.Start();

        // Act
        var index = BinarySearchAlgorithm.BinarySearch(array, target);

        // Assert
        stopwatch.Stop();

        var elapsedMs = stopwatch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreNotEqual(-1, index);
        Assert.AreEqual(array[index], target);
    }

    /*
    Execution time:
    |-----------------------------------|
    | N             | Time              |
    |-----------------------------------|
    | 1_000         | 00:00:00.0000024  |
    | 10_000        | 00:00:00.0000001  |
    | 100_000       | 00:00:00.0000000  |
    | 1_000_000     | 00:00:00.0000001  |
    | 10_000_000    | 00:00:00.0000004  |
    | 100_000_000   | 00:00:00.0000004  |
    | 1_000_000_000 | 00:00:00.0000006  |
    |-----------------------------------|
    */
    [TestMethod]
    [DataRow(1_000, 499)]
    [DataRow(10_000, 4_999)]
    [DataRow(100_000, 49_999)]
    [DataRow(1_000_000, 499_999)]
    [DataRow(10_000_000, 4_999_999)]
    [DataRow(100_000_000, 49_999_999)]
    [DataRow(1_000_000_000, 499_999_999)]
    public void TestMiddleItem(int arraySize, int target)
    {
        // Arrange
        int[] array = new int[arraySize];

        for (int i = 0; i < arraySize; i++)
        {
            array[i] = i;
        }

        // Warm-up
        BinarySearchAlgorithm.BinarySearch(array, target);

        Stopwatch stopwatch = new();

        stopwatch.Start();

        // Act
        var index = BinarySearchAlgorithm.BinarySearch(array, target);

        // Assert
        stopwatch.Stop();

        var elapsedMs = stopwatch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreNotEqual(-1, index);
        Assert.AreEqual(array[index], target);
    }

    /*
    Execution time:
    |-----------------------------------|
    | N             | Time              |
    |-----------------------------------|
    | 1_000         | 00:00:00.0001093  |
    | 10_000        | 00:00:00.0000692  |
    | 100_000       | 00:00:00.0000011  |
    | 1_000_000     | 00:00:00.0000015  |
    | 10_000_000    | 00:00:00.0000022  |
    | 100_000_000   | 00:00:00.0000113  |
    | 1_000_000_000 | 00:00:00.0000180  |
    |-----------------------------------|
    */
    [TestMethod]
    [DataRow(1_000, 1)]
    [DataRow(10_000, 1)]
    [DataRow(100_000, 1)]
    [DataRow(1_000_000, 1)]
    [DataRow(10_000_000, 1)]
    [DataRow(100_000_000, 1)]
    [DataRow(1_000_000_000, 1)]
    public void TestFirstItem(int arraySize, int target)
    {
        // Arrange
        int[] array = new int[arraySize];

        for (int i = 0; i < arraySize; i++)
        {
            array[i] = i;
        }

        // Warm-up
        BinarySearchAlgorithm.BinarySearch(array, target);

        Stopwatch stopwatch = new();

        stopwatch.Start();

        // Act
        var index = BinarySearchAlgorithm.BinarySearch(array, target);

        // Assert
        stopwatch.Stop();

        var elapsedMs = stopwatch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreNotEqual(-1, index);
        Assert.AreEqual(array[index], target);
    }
}
