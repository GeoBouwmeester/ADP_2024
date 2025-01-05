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
    | 1_000         | 00:00:00.0000000  |
    | 10_000        | 00:00:00.0000001  |
    | 100_000       | 00:00:00.0000001  |
    | 1_000_000     | 00:00:00.0000001  |
    | 10_000_000    | 00:00:00.0000001  |
    | 100_000_000   | 00:00:00.0000001  |
    | 1_000_000_000 | 00:00:00.0000002  |
    |-----------------------------------|
    1. Difficult to measure efficient binary search implementation.
    2. Slight increase can be observed
    3. Time complexity: O(log N)
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

        var iterations = 100_000;

        // Warm-up
        BinarySearchAlgorithm.BinarySearch(array, target);

        Stopwatch stopwatch = new();

        // Act
        for (int i = 0; i < iterations; i++)
        {
            stopwatch.Start();

            _ = BinarySearchAlgorithm.BinarySearch(array, target);

            stopwatch.Stop();
        }

        // Assert
        Console.WriteLine(TimeSpan.FromTicks(stopwatch.ElapsedTicks / iterations));
    }

    /*
    Execution time:
    |-----------------------------------|
    | N             | Time              |
    |-----------------------------------|
    | 1_000         | 00:00:00.00       |
    | 10_000        | 00:00:00.00       |
    | 100_000       | 00:00:00.00       |
    | 1_000_000     | 00:00:00.00       |
    | 10_000_000    | 00:00:00.00       |
    | 100_000_000   | 00:00:00.00       |
    | 1_000_000_000 | 00:00:00.00       |
    |-----------------------------------|
    1. Difficult to measure efficient binary search implementation.
    2. No increase can be observed in this best case scenario where the target is found in constant time
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

        var iterations = 100_000;

        Stopwatch stopwatch = new();

        // Act
        for (int i = 0; i < iterations; i++)
        {
            stopwatch.Start();

            _ = BinarySearchAlgorithm.BinarySearch(array, target);

            stopwatch.Stop();
        }

        // Assert
        Console.WriteLine(TimeSpan.FromTicks(stopwatch.ElapsedTicks / iterations));
    }

    /*
    Execution time:
    |-----------------------------------|
    | N             | Time              |
    |-----------------------------------|
    | 1_000         | 00:00:00.00       |
    | 10_000        | 00:00:00.0000001  |
    | 100_000       | 00:00:00.0000001  |
    | 1_000_000     | 00:00:00.0000001  |
    | 10_000_000    | 00:00:00.0000001  |
    | 100_000_000   | 00:00:00.0000001  |
    | 1_000_000_000 | 00:00:00.0000002  |
    |-----------------------------------|
    1. Difficult to measure efficient binary search implementation.
    2. Slight increase can be observed
    3. Time complexity: O(log N)
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

        var iterations = 100_000;

        Stopwatch stopwatch = new();

        // Act
        for (int i = 0; i < iterations; i++)
        {
            stopwatch.Start();

            _ = BinarySearchAlgorithm.BinarySearch(array, target);

            stopwatch.Stop();
        }

        // Assert
        Console.WriteLine(TimeSpan.FromTicks(stopwatch.ElapsedTicks / iterations));
    }

    /*
    Execution time:
    |-----------------------------------|
    | N             | Time              |
    |-----------------------------------|
    | 1_000         | 00:00:00.00       |
    | 10_000        | 00:00:00.00       |
    | 100_000       | 00:00:00.0000001  |
    | 1_000_000     | 00:00:00.0000001  |
    | 10_000_000    | 00:00:00.0000001  |
    | 100_000_000   | 00:00:00.0000001  |
    | 1_000_000_000 | 00:00:00.0000003  |
    |-----------------------------------|
    1. Difficult to measure efficient binary search implementation.
    2. Slight increase can be observed
    3. Time complexity: O(log N)
    */
    [TestMethod]
    [DataRow(1_000, 726)]
    [DataRow(10_000, 4832)]
    [DataRow(100_000, 73456)]
    [DataRow(1_000_000, 528914)]
    [DataRow(10_000_000, 7_362_419)]
    [DataRow(100_000_000, 47_829_153)]
    [DataRow(1_000_000_000, 682_417_395)]
    public void TestRandomItem(int arraySize, int target)
    {
        // Arrange
        int[] array = new int[arraySize];

        for (int i = 0; i < arraySize; i++)
        {
            array[i] = i;
        }

        var iterations = 100_000;

        Stopwatch stopwatch = new();

        // Act
        for (int i = 0; i < iterations; i++)
        {
            stopwatch.Start();

            _ = BinarySearchAlgorithm.BinarySearch(array, target);

            stopwatch.Stop();
        }

        // Assert
        Console.WriteLine(TimeSpan.FromTicks(stopwatch.ElapsedTicks / iterations));
    }
}
