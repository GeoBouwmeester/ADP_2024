using ADP_2024;
using ADP_2024.Models;
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
            priorityQueue.Add(value);
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
            priorityQueue.Add(value);
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
            priorityQueue.Add(value);
        }

        // Assert
        Assert.IsFalse(priorityQueue.IsEmpty);
        Assert.AreEqual(8001, priorityQueue.Count);
        Assert.AreEqual(11312312312312, priorityQueue.Peek());
    }

    [TestMethod]
    public void TestLijstGesorteerdAflopend3()
    {
        // Arrange
        var priorityQueue = new PriorityQueue<int>();

        // Act
        foreach (var value in reader.LijstGesorteerdAflopend3)
        {
            priorityQueue.Add(value);
        }

        // Assert
        Assert.AreEqual(3, priorityQueue.Count);
        Assert.AreEqual(3, priorityQueue.Peek());
    }

    [TestMethod]
    public void TestLijstGesorteerdOplopend3()
    {
        // Arrange
        var priorityQueue = new PriorityQueue<int>();

        // Act
        foreach (var value in reader.LijstGesorteerdOplopend3)
        {
            priorityQueue.Add(value);
        }

        // Assert
        Assert.AreEqual(3, priorityQueue.Count);
        Assert.AreEqual(3, priorityQueue.Peek());
    }

    [TestMethod]
    public void TestLijstHerhaald1000()
    {
        // Arrange
        var priorityQueue = new PriorityQueue<int>();

        // Act
        foreach (var value in reader.LijstHerhaald1000)
        {
            priorityQueue.Add(value);
        }

        // Assert
        Assert.AreEqual(10000, priorityQueue.Count);
        Assert.AreEqual(111, priorityQueue.Peek());
    }

    [TestMethod]
    public void TestLijstLeeg0()
    {
        // Arrange
        var priorityQueue = new PriorityQueue<int>();

        // Act
        foreach (var value in reader.LijstLeeg0)
        {
            if (value != null) priorityQueue.Add((int)value);
        }

        // Assert
        Assert.AreEqual(0, priorityQueue.Count);
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Peek());
    }

    [TestMethod]
    public void TestLijstNull1()
    {
        // Arrange
        var priorityQueue = new PriorityQueue<int>();

        // Act
        foreach (var value in reader.LijstNull1)
        {
            if (value != null) priorityQueue.Add((int)value);
        }

        // Assert
        Assert.AreEqual(0, priorityQueue.Count);
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Peek());
    }

    [TestMethod]
    public void TestLijstNull3()
    {
        // Arrange
        var priorityQueue = new PriorityQueue<int>();

        // Act
        foreach (var value in reader.LijstNull3)
        {
            if (value != null) priorityQueue.Add((int)value);
        }

        // Assert
        Assert.AreEqual(2, priorityQueue.Count);
        Assert.AreEqual(3, priorityQueue.Peek());
    }

    [TestMethod]
    public void TestLijstOnsorteerbaar3()
    {
        // Arrange
        var priorityQueue = new PriorityQueue<Int64>();

        // Act
        foreach (var value in reader.LijstOnsorteerbaar3)
        {
            if (value.GetType() == typeof(Int64)) priorityQueue.Add((Int64)value);
        }

        // Assert
        Assert.AreEqual(1, priorityQueue.Count);
        Assert.AreEqual(1, priorityQueue.Peek());
    }

    [TestMethod]
    public void TestLijstOplopend10000()
    {
        // Arrange
        var priorityQueue = new PriorityQueue<int>();

        // Act
        foreach (var value in reader.LijstOplopend10000)
        {
            priorityQueue.Add(value);
        }

        // Assert
        Assert.AreEqual(9999, priorityQueue.Count);
        Assert.AreEqual(9999, priorityQueue.Peek());
    }

    [TestMethod]
    public void TestLijstWillekeurig10000()
    {
        // Arrange
        var priorityQueue = new PriorityQueue<int>();

        // Act
        foreach (var value in reader.LijstWillekeurig10000)
        {
            priorityQueue.Add(value);
        }

        // Assert
        Assert.AreEqual(9999, priorityQueue.Count);
        Assert.AreEqual(9999, priorityQueue.Peek());
    }

    [TestMethod]
    public void TestLijstWillekeurig3()
    {
        // Arrange
        var priorityQueue = new PriorityQueue<int>();

        // Act
        foreach (var value in reader.LijstWillekeurig3)
        {
            priorityQueue.Add(value);
        }

        // Assert
        Assert.AreEqual(3, priorityQueue.Count);
        Assert.AreEqual(3, priorityQueue.Peek());
    }

    [TestMethod]
    public void TestLijstPizza6()
    {
        // Arrange
        var priorityQueue = new PriorityQueue<Pizza>();

        // Act
        foreach (var value in reader.LijstPizza6)
        {
            priorityQueue.Add(value);
        }

        var newPizza = new Pizza("G", 8);

        priorityQueue.Add(newPizza);

        // Assert
        Assert.AreEqual(7, priorityQueue.Count);
        Assert.AreEqual(newPizza.PizzaName, priorityQueue.Peek().PizzaName);
    }
}
