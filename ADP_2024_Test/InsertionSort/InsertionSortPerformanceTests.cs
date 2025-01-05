using ADP_2024;
using ADP_2024.InsertionSort;
using System.Diagnostics;

namespace ADP_2024_Test.InsertionSort;

[TestClass]
public class InsertionSortPerformanceTests
{
    public required DatasetReader reader;

    [TestInitialize]
    public void SetUp()
    {
        reader = new DatasetReader();
    }

    public static int[] GenerateRandomArrayWithoutDuplicates(int length, int minValue, int maxValue)
    {
        if (maxValue - minValue + 1 < length)
        {
            throw new ArgumentException("The range is too small to generate unique numbers of the requested length.");
        }

        Random random = new();
        HashSet<int> numbersSet = [];

        while (numbersSet.Count < length)
        {
            numbersSet.Add(random.Next(minValue, maxValue + 1));
        }

        return [.. numbersSet];
    }

    /*
    Execution time:
    |--------------------------------|
    | N          | Time              |
    |--------------------------------|
    | 10         | 00:00:00.0000018  |
    | 100        | 00:00:00.0000115  |
    | 1000       | 00:00:00.0036414  |
    | 10_000     | 00:00:00.1052592  |
    |--------------------------------|
    1. Quadratic time complexity
    2. Average case scenario
    */
    [TestMethod]
    [DataRow(10, 10)]
    [DataRow(100, 100)]
    [DataRow(1000, 1000)]
    [DataRow(10_000, 10_000)]
    public void TestWillekeurig(int amount, int expectedAmount)
    {
        // Arrange
        var iterations = 100;

        Stopwatch stopwatch = new();

        // Act
        for (int i = 0; i < iterations; i++)
        {
            var array = GenerateRandomArrayWithoutDuplicates(amount, 1, amount);

            stopwatch.Start();

            InsertionSortAlgorithm.InsertionSort(array);

            stopwatch.Stop();
        }

        // Assert
        stopwatch.Stop();

        Console.WriteLine(TimeSpan.FromTicks(stopwatch.ElapsedTicks / iterations));
    }

    /*
    Execution time:
    |--------------------------------|
    | N          | Time              |
    |--------------------------------|
    | 10         | 00:00:00.00       |
    | 100        | 00:00:00.0000010  |
    | 1000       | 00:00:00.0000052  |
    | 10_000     | 00:00:00.0000500  |
    |--------------------------------|
    1. Linear time complexity
    2. Best case scenario 
    */
    [TestMethod]
    [DataRow(10, 10)]
    [DataRow(100, 100)]
    [DataRow(1000, 1000)]
    [DataRow(10_000, 10_000)]
    public void TestOplopend(int amount, int expectedAmount)
    {
        // Arrange
        var iterations = 100;

        Stopwatch stopwatch = new();

        // Act
        for (int i = 0; i < iterations; i++)
        {
            var array = GenerateRandomArrayWithoutDuplicates(amount, 1, amount);

            // Sort
            InsertionSortAlgorithm.InsertionSort(array);

            stopwatch.Start();

            InsertionSortAlgorithm.InsertionSort(array);

            stopwatch.Stop();
        }

        // Assert
        Console.WriteLine(TimeSpan.FromTicks(stopwatch.ElapsedTicks / iterations));
    }

    /*
    Execution time:
    |--------------------------------|
    | N          | Time              |
    |--------------------------------|
    | 10         | 00:00:00.0000013  |
    | 100        | 00:00:00.0000215  |
    | 1000       | 00:00:00.0022582  |
    | 10_000     | 00:00:00.2045180  |
    |--------------------------------|
    1. Quadratic time complexity
    2. Worst case scenario 
    */
    [TestMethod]
    [DataRow(10, 10)]
    [DataRow(100, 100)]
    [DataRow(1000, 1000)]
    [DataRow(10_000, 10_000)]
    public void TestAflopend(int amount, int expectedAmount)
    {
        // Arrange
        var iterations = 100;

        Stopwatch stopwatch = new();

        // Act
        for (int i = 0; i < iterations; i++)
        {
            var array = GenerateRandomArrayWithoutDuplicates(amount, 1, amount);

            int length = array.Length;

            // Reverse sort
            for (int x = 0; x < length - 1; x++)
            {
                int minIndex = x;

                for (int y = x + 1; y < length; y++)
                {
                    if (array[y].CompareTo(array[minIndex]) > 0)
                    {
                        minIndex = y;
                    }
                }

                var temp = array[minIndex];
                array[minIndex] = array[x];
                array[x] = temp;
            }

            stopwatch.Start();

            InsertionSortAlgorithm.InsertionSort(array);

            stopwatch.Stop();
        }

        // Assert
        Console.WriteLine(TimeSpan.FromTicks(stopwatch.ElapsedTicks / iterations));
    }
}
