using ADP_2024;
using ADP_2024.PriorityQueue;

namespace ADP_2024_Test.PriorityQueue;

[TestClass]
public class PriorityQueueFunctionalTests
{
    public required DatasetReader reader;

    [TestInitialize]
    public void SetUp()
    {
        reader = new DatasetReader();
    }

    [TestMethod]
    public void TestLijstAflopend2()
    {
        // Arrange
        var priorityQueue = new PriorityQueue<int>();

        // Act
        foreach (var value in reader.LijstAflopend2)
        {
            priorityQueue.Add(value, value);
        }

        // Assert
        Assert.IsFalse(priorityQueue.IsEmpty);
        Assert.AreEqual(2, priorityQueue.Count);
        Assert.AreEqual(1, priorityQueue.Peek());
    }

    [TestMethod]
    public void TestLijstOplopend2()
    {
        // Arrange
        var priorityQueue = new PriorityQueue<int>();

        // Act
        foreach (var value in reader.LijstOplopend2)
        {
            priorityQueue.Add(value, value);
        }

        // Assert
        Assert.IsFalse(priorityQueue.IsEmpty);
        Assert.AreEqual(2, priorityQueue.Count);
        Assert.AreEqual(1023, priorityQueue.Peek());
    }

    [TestMethod]
    public void TestLijstFloat8001()
    {
        // Arrange
        var priorityQueue = new PriorityQueue<float>();

        // Act
        foreach (var value in reader.LijstFloat8001)
        {

            var priority = 0;

            if (value == 11312312312312.324f) priority = 2;
            if (value == 1.0f) priority = 1;

            priorityQueue.Add(value, priority);
        }

        // Assert
        Assert.IsFalse(priorityQueue.IsEmpty);
        Assert.AreEqual(8001, priorityQueue.Count);
        Assert.AreEqual(11312312312312, priorityQueue.Peek());
    }
}
