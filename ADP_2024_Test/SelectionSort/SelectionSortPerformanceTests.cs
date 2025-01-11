using ADP_2024;
using ADP_2024.SelectionSort;
using System.Diagnostics;

namespace ADP_2024_Test.SelectionSort;

[TestClass]
public class SelectionSortPerformanceTests
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
    | 10         | 00:00:00.0000015  |
    | 100        | 00:00:00.0000235  |
    | 1000       | 00:00:00.0020015  |
    | 10_000     | 00:00:00.1809969  |
    |--------------------------------|
    1. Quadratic time complexity
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

            SelectionSortAlgorithm.SelectionSort(array);

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
    | 10         | 00:00:00.0000002  |
    | 100        | 00:00:00.0000209  |
    | 1000       | 00:00:00.0019453  |
    | 10_000     | 00:00:00.1857489  |
    |--------------------------------|
    1. Quadratic time complexity
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
            SelectionSortAlgorithm.SelectionSort(array);

            stopwatch.Start();

            SelectionSortAlgorithm.SelectionSort(array);

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
    | 10         | 00:00:00.0003246  |
    | 100        | 00:00:00.0003374  |
    | 1000       | 00:00:00.0035115  |
    | 10_000     | 00:00:00.3591049  |
    |--------------------------------|
    1. Quadratic time complexity
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

                for (int j = x + 1; j < length; j++)
                {
                    if (array[j].CompareTo(array[minIndex]) > 0)
                    {
                        minIndex = j;
                    }
                }

                var temp = array[minIndex];
                array[minIndex] = array[x];
                array[x] = temp;
            }

            stopwatch.Start();

            SelectionSortAlgorithm.SelectionSort(array);

            stopwatch.Stop();
        }

        // Assert
        Console.WriteLine(TimeSpan.FromTicks(stopwatch.ElapsedTicks / iterations));
    }
}
