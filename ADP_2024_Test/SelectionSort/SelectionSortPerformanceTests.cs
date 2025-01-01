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
    | 10         | 00:00:00.0000018  |
    | 100        | 00:00:00.0000185  |
    | 1000       | 00:00:00.0017769  |
    | 10_000     | 00:00:00.1757838  |
    |--------------------------------|
    */
    [TestMethod]
    [DataRow(10, 10)]
    [DataRow(100, 100)]
    [DataRow(1000, 1000)]
    [DataRow(10_000, 10_000)]
    public void TestWillekeurig(int amount, int expectedAmount)
    {
        // Arrange
        var array = GenerateRandomArrayWithoutDuplicates(amount, 1, amount);

        // Warm-up
        int[] newArray = new int[array.Length];
        Array.Copy(array, newArray, array.Length);
        SelectionSortAlgorithm.SelectionSort(newArray);

        var watch = Stopwatch.StartNew();

        // Act
        SelectionSortAlgorithm.SelectionSort(array);

        // Assert
        watch.Stop();

        var elapsedMs = watch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreEqual(expectedAmount, array.Length);
    }

    /*
    Execution time:
    |--------------------------------|
    | N          | Time              |
    |--------------------------------|
    | 10         | 00:00:00.0000023  |
    | 100        | 00:00:00.0000282  |
    | 1000       | 00:00:00.0025097  |
    | 10_000     | 00:00:00.1857489  |
    |--------------------------------|
    */
    [TestMethod]
    [DataRow(10, 10)]
    [DataRow(100, 100)]
    [DataRow(1000, 1000)]
    [DataRow(10_000, 10_000)]
    public void TestOplopend(int amount, int expectedAmount)
    {
        // Arrange
        var array = GenerateRandomArrayWithoutDuplicates(amount, 1, amount);

        // Sort
        SelectionSortAlgorithm.SelectionSort(array);

        // Warm-up
        SelectionSortAlgorithm.SelectionSort(array);

        var watch = Stopwatch.StartNew();

        // Act
        SelectionSortAlgorithm.SelectionSort(array);

        // Assert
        watch.Stop();

        var elapsedMs = watch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreEqual(expectedAmount, array.Length);
    }

    /*
    Execution time:
    |--------------------------------|
    | N          | Time              |
    |--------------------------------|
    | 10         | 00:00:00.0000025  |
    | 100        | 00:00:00.0000188  |
    | 1000       | 00:00:00.0019168  |
    | 10_000     | 00:00:00.1885616  |
    |--------------------------------|
    */
    [TestMethod]
    [DataRow(10, 10)]
    [DataRow(100, 100)]
    [DataRow(1000, 1000)]
    [DataRow(10_000, 10_000)]
    public void TestAflopend(int amount, int expectedAmount)
    {
        // Arrange
        var array = GenerateRandomArrayWithoutDuplicates(amount, 1, amount);

        int length = array.Length;

        // Warm-up
        SelectionSortAlgorithm.SelectionSort(array);

        // Reverse sort
        for (int i = 0; i < length - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < length; j++)
            {
                if (array[j].CompareTo(array[minIndex]) > 0)
                {
                    minIndex = j;
                }
            }

            var temp = array[minIndex];
            array[minIndex] = array[i];
            array[i] = temp;
        }

        var watch = Stopwatch.StartNew();

        // Act
        SelectionSortAlgorithm.SelectionSort(array);

        // Assert
        watch.Stop();

        var elapsedMs = watch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreEqual(expectedAmount, array.Length);
    }
}
