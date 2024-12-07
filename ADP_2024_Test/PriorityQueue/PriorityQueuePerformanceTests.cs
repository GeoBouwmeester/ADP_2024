using ADP_2024;
using ADP_2024.PriorityQueue;
using System.Diagnostics;

namespace ADP_2024_Test.PriorityQueue;

[TestClass]
public sealed class PriorityQueuePerformanceTests
{
    public required DatasetReader reader;

    [TestInitialize]
    public void SetUp()
    {
        reader = new DatasetReader();
    }

    /*
    Execution time:
    |-------------------------------|
    | N         | Time              |
    |-------------------------------|
    | 10        | 00:00:00.0004835  |
    | 100       | 00:00:00.0001037  |
    | 1000      | 00:00:00.0097914  |
    | 10_000    | 00:00:01.2690286  |
    | 100_000   | 00:02:19.1081207  |
    | 1_000_000 | 02:26:57.0500567  |
    |-------------------------------|
    Comments on performance:
    1. Inserting an item takes constant time O(1) since it is appended to the back.
    2. If the array is full resizing takes O(n) due to copying all items over to the new array.
    3. Reordering takes in the worst case scenario O(n) because it then has to compare each item in the array.
    */
    [TestMethod]
    [DataRow(10, 10)]
    [DataRow(100, 100)]
    [DataRow(1000, 1000)]
    [DataRow(10_000, 10_000)]
    [DataRow(100_000, 100_000)]
    [DataRow(1_000_000, 1_000_000)]
    public void TestPushTimeComplexity(int amount, int expectedAmount)
    {
        // Arrange
        var priorityQueue = new PriorityQueue<int>();

        var watch = Stopwatch.StartNew();

        // Act
        for (var i = 0; i < amount; i++)
        {
            priorityQueue.Add(i);
        }

        // Assert
        watch.Stop();

        var elapsedMs = watch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreEqual(expectedAmount, priorityQueue.Count);
    }

    /*
    Execution time:
    |-------------------------------|
    | N         | Time              |
    |-------------------------------|
    | 10        | 00:00:00.0001118  |
    | 100       | 00:00:00.0001412  |
    | 1000      | 00:00:00.0000077  |
    | 10_000    | 00:00:00.0000725  |
    | 100_000   | 00:00:00.0011823  |
    | 1_000_000 | 00:00:00.0048671  |
    |-------------------------------|
    Comments on performance:
    1. Peek() accesses the first element which is tracked by the front property
       which makes this operation constant time O(1).
    */
    [TestMethod]
    [DataRow(10, 10)]
    [DataRow(100, 100)]
    [DataRow(1000, 1000)]
    [DataRow(10_000, 10_000)]
    [DataRow(100_000, 100_000)]
    [DataRow(1_000_000, 1_000_000)]
    public void TestPeekTimeComplexity(int amount, int expectedAmount)
    {
        // Arrange
        var priorityQueue = new PriorityQueue<int>();

        for (var i = 0; i < amount; i++)
        {
            priorityQueue.Add(i);
        }

        var watch = Stopwatch.StartNew();

        // Act
        for (var i = 0; i < amount; i++)
        {
            var peekValue = priorityQueue.Peek();
        }

        // Assert
        watch.Stop();

        var elapsedMs = watch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreEqual(expectedAmount, priorityQueue.Count);
    }

    /*
    Execution time:
    |-------------------------------|
    | N         | Time              |
    |-------------------------------|
    | 10        | 00:00:00.0000004  |
    | 100       | 00:00:00.0000018  |
    | 1000      | 00:00:00.0000071  |
    | 10_000    | 00:00:00.0001959  |
    | 100_000   | 00:00:00.0060346  |
    | 1_000_000 | 00:00:00.0170213  |
    |-------------------------------|
    Comments on performance:
    1. Having a circular array removes the need for shifting items after a deletion in the front.
    2. Sorting in the add function meens we have a sorted array while polling the priority queue, 
       taking constant time O(1) to access the front item.
    3. Shrinking takes linear time O(n) but happens proportional to the size of the array.
    */
    [TestMethod]
    [DataRow(10, 10)]
    [DataRow(100, 100)]
    [DataRow(1000, 1000)]
    [DataRow(10_000, 10_000)]
    [DataRow(100_000, 100_000)]
    [DataRow(1_000_000, 1_000_000)]
    public void TestPollTimeComplexity(int amount, int expectedAmount)
    {
        // Arrange
        var priorityQueue = new PriorityQueue<int>();

        for (var i = 0; i < amount; i++)
        {
            priorityQueue.Add(i);
        }

        var watch = Stopwatch.StartNew();

        // Act
        for (var i = 0; i < amount; i++)
        {
            var polledValue = priorityQueue.Poll();
        }

        // Assert
        watch.Stop();

        var elapsedMs = watch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreEqual(expectedAmount, priorityQueue.Count);
    }
}
