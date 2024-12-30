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

    [TestMethod]
    [DataRow(10, 10)]
    [DataRow(100, 100)]
    [DataRow(1000, 1000)]
    [DataRow(10_000, 10_000)]
    [DataRow(100_000, 100_000)]
    public void TestWillekeurig(int amount, int expectedAmount)
    {
        // Arrange
        var array = GenerateRandomArrayWithoutDuplicates(amount, 1, amount);

        var watch = Stopwatch.StartNew();

        // Act
        InsertionSortAlgorithm.InsertionSort(array);

        // Assert
        watch.Stop();

        var elapsedMs = watch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreEqual(expectedAmount, array.Length);
    }

    [TestMethod]
    [DataRow(10, 10)]
    [DataRow(100, 100)]
    [DataRow(1000, 1000)]
    [DataRow(10_000, 10_000)]
    [DataRow(100_000, 100_000)]
    public void TestOplopend(int amount, int expectedAmount)
    {
        // Arrange
        var array = GenerateRandomArrayWithoutDuplicates(amount, 1, amount);

        InsertionSortAlgorithm.InsertionSort(array);

        var watch = Stopwatch.StartNew();

        // Act
        InsertionSortAlgorithm.InsertionSort(array);

        // Assert
        watch.Stop();

        var elapsedMs = watch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreEqual(expectedAmount, array.Length);
    }

    [TestMethod]
    [DataRow(10, 10)]
    [DataRow(100, 100)]
    [DataRow(1000, 1000)]
    [DataRow(10_000, 10_000)]
    [DataRow(100_000, 100_000)]
    public void TestAflopend(int amount, int expectedAmount)
    {
        // Arrange
        var array = GenerateRandomArrayWithoutDuplicates(amount, 1, amount);

        int length = array.Length;

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
        InsertionSortAlgorithm.InsertionSort(array);

        // Assert
        watch.Stop();

        var elapsedMs = watch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreEqual(expectedAmount, array.Length);
    }
}
