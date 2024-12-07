using ADP_2024;
using ADP_2024.Stack;
using System.Diagnostics;

namespace ADP_2024_Test.Stack;

[TestClass]
public sealed class StackPerformanceTests
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
    | 10        | 00:00:00.0000022  |
    | 100       | 00:00:00.0000012  |
    | 1000      | 00:00:00.0000128  |
    | 10_000    | 00:00:00.0001610  |
    | 100_000   | 00:00:00.0007772  |
    | 1_000_000 | 00:00:00.0131365  |
    |-------------------------------|
    Comments on performance:
    1. Pushing adds a new item to the top. We keep track of the top index which allows us to add items 
       in constant time O(1).
    2. Growing takes linear time O(n) but happens proportional to the size of the array.
    3. Resizing happens infrequent but still takes time. This is unnecessary when using a linked list as underlying 
       datastructure. But in that case we are storing pointers to next and previous nodes and the nodes themselves
       are not stored contiguousely in memory making it less suitable for caching.
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
        var stack = new AStack<int>();

        var watch = Stopwatch.StartNew();

        // Act
        for (var i = 0; i < amount; i++)
        {
            stack.Push(i);
        }

        // Assert
        watch.Stop();

        var elapsedMs = watch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreEqual(expectedAmount, stack.Size);
    }

    /*
    Execution time:
    |-------------------------------|
    | N         | Time              |
    |-------------------------------|
    | 10        | 00:00:00.0002686  |
    | 100       | 00:00:00.0002314  |
    | 1000      | 00:00:00.0002279  |
    | 10_000    | 00:00:00.0001073  |
    | 100_000   | 00:00:00.0019147  |
    | 1_000_000 | 00:00:00.0189605  |
    |-------------------------------|
    Comments on performance:
    1. Popping removes an item from the top. We keep track of the top index which allows us to pop items 
       in constant time O(1).
    2. Shrinking takes linear time O(n) but happens proportional to the size of the array.
    */
    [TestMethod]
    [DataRow(10, 0)]
    [DataRow(100, 0)]
    [DataRow(1000, 0)]
    [DataRow(10_000, 0)]
    [DataRow(100_000, 0)]
    [DataRow(1_000_000, 0)]
    public void TestPopTimeComplexity(int amount, int expectedAmount)
    {
        // Arrange
        var stack = new AStack<int>();

        for (var i = 0; i < amount; i++)
        {
            stack.Push(i);
        }

        var watch = Stopwatch.StartNew();

        // Act
        while (!stack.IsEmpty)
        {
            stack.Pop();
        }

        // Assert
        watch.Stop();

        var elapsedMs = watch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreEqual(expectedAmount, stack.Size);
    }

    /*
    Execution time:
    |-------------------------------|
    | N         | Time              |
    |-------------------------------|
    | 10        | 00:00:00.0000005  |
    | 100       | 00:00:00.0000005  |
    | 1000      | 00:00:00.0000278  |
    | 10_000    | 00:00:00.0001770  |
    | 100_000   | 00:00:00.0059834  |
    | 1_000_000 | 00:00:00.0223771  |
    |-------------------------------|
    Comments on performance:
    1. TopValue receives an item from the top. We keep track of the top index which allows us to receive items 
       in constant time O(1).
    */
    [TestMethod]
    [DataRow(10, 10)]
    [DataRow(100, 100)]
    [DataRow(1000, 1000)]
    [DataRow(10_000, 10_000)]
    [DataRow(100_000, 100_000)]
    [DataRow(1_000_000, 1_000_000)]
    public void TestTopValueTimeComplexity(int amount, int expectedAmount)
    {
        // Arrange
        var stack = new AStack<int>();

        for (var i = 0; i < amount; i++)
        {
            stack.Push(i);
        }

        var watch = Stopwatch.StartNew();

        // Act
        for (var i = 0; i < amount; i++)
        {
            stack.TopValue();
        }

        // Assert
        watch.Stop();

        var elapsedMs = watch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreEqual(expectedAmount, stack.Size);
    }
}
