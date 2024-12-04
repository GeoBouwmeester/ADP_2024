using ADP_2024;
using ADP_2024.Models;
using ADP_2024.Stack;

namespace ADP_2024_Test.Stack;

[TestClass]
public sealed class StackFunctionalTests
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
        var stack = new AStack<int>();

        // Act
        foreach (var value in reader.LijstAflopend2)
        {
            stack.Push(value);
        }

        // Assert
        Assert.AreEqual(2, stack.Size());
    }

    [TestMethod]
    public void TestLijstOplopend2()
    {
        // Arrange
        var stack = new AStack<int>();

        // Act
        foreach (var value in reader.LijstOplopend2)
        {
            stack.Push(value);
        }

        stack.Pop();

        var newValue = 123;

        stack.Push(newValue);

        var first = stack.TopValue();

        var popped = stack.Pop();

        // Assert
        Assert.AreEqual(1, stack.Size());
        Assert.AreEqual(newValue, first);
        Assert.AreEqual(newValue, popped);
    }

    [TestMethod]
    public void TestLijstFloat8001()
    {
        // Arrange
        var stack = new AStack<float>();

        // Act
        foreach (var value in reader.LijstFloat8001)
        {
            stack.Push(value);
        }

        stack.Pop();

        var newValue = 123.456F;

        stack.Push(newValue);

        var first = stack.TopValue();

        var popped = stack.Pop();

        // Assert
        Assert.AreEqual(8000, stack.Size());
        Assert.AreEqual(newValue, first);
        Assert.AreEqual(newValue, popped);
    }

    [TestMethod]
    public void TestLijstGesorteerdAflopend3()
    {
        // Arrange
        var stack = new AStack<int>();

        // Act
        foreach (var value in reader.LijstGesorteerdAflopend3)
        {
            stack.Push(value);
        }

        stack.Pop();

        var newValue = 123456;

        stack.Push(newValue);

        var first = stack.TopValue();

        var popped = stack.Pop();

        // Assert
        Assert.AreEqual(2, stack.Size());
        Assert.AreEqual(newValue, first);
        Assert.AreEqual(newValue, popped);
    }

    [TestMethod]
    public void TestLijstGesorteerdOplopend3()
    {
        // Arrange
        var stack = new AStack<int>();

        // Act
        foreach (var value in reader.LijstGesorteerdOplopend3)
        {
            stack.Push(value);
        }

        stack.Pop();

        var newValue = 2;

        stack.Push(newValue);

        var first = stack.TopValue();

        var popped = stack.Pop();

        // Assert
        Assert.AreEqual(2, stack.Size());
        Assert.AreEqual(newValue, first);
        Assert.AreEqual(newValue, popped);
    }

    [TestMethod]
    public void TestLijstHerhaald1000()
    {
        // Arrange
        var stack = new AStack<int>();

        // Act
        foreach (var value in reader.LijstHerhaald1000)
        {
            stack.Push(value);
        }

        stack.Pop();

        var newValue = 9999;

        stack.Push(newValue);

        var first = stack.TopValue();

        var popped = stack.Pop();

        // Assert
        Assert.AreEqual(9999, stack.Size());
        Assert.AreEqual(newValue, first);
        Assert.AreEqual(newValue, popped);
    }

    [TestMethod]
    public void TestLijstLeeg0()
    {
        // Arrange
        var stack = new AStack<int>();

        // Act
        foreach (var value in reader.LijstLeeg0)
        {
            if (value != null) stack.Push((int)value);
        }

        var newValue = 999;

        stack.Push(newValue);

        var first = stack.TopValue();

        var popped = stack.Pop();

        // Assert
        Assert.AreEqual(0, stack.Size());
        Assert.AreEqual(newValue, first);
        Assert.AreEqual(newValue, popped);
    }

    [TestMethod]
    public void TestLijstNull1()
    {
        // Arrange
        var stack = new AStack<int>();

        // Act
        foreach (var value in reader.LijstNull1)
        {
            if (value != null) stack.Push((int)value);
        }

        var newValue = 12345;

        stack.Push(newValue);

        var first = stack.TopValue();

        var popped = stack.Pop();

        // Assert
        Assert.AreEqual(0, stack.Size());
        Assert.AreEqual(newValue, first);
        Assert.AreEqual(newValue, popped);
    }

    [TestMethod]
    public void TestLijstNull3()
    {
        // Arrange
        var stack = new AStack<int>();

        // Act
        foreach (var value in reader.LijstNull3)
        {
            if (value != null) stack.Push((int)value);
        }

        stack.Pop();

        var newValue = 12345;

        stack.Push(newValue);

        var first = stack.TopValue();

        var popped = stack.Pop();

        // Assert
        Assert.AreEqual(1, stack.Size());
        Assert.AreEqual(newValue, first);
        Assert.AreEqual(newValue, popped);
    }

    [TestMethod]
    public void TestLijstOnsorteerbaar3()
    {
        // Arrange
        var stack = new AStack<object>();

        // Act
        foreach (var value in reader.LijstOnsorteerbaar3)
        {
            stack.Push(value);
        }

        stack.Pop();
        stack.Pop();

        Int64 expected = 1;

        // Assert
        Assert.AreEqual(1, stack.Size());
        Assert.AreEqual(expected, stack.TopValue());
    }

    [TestMethod]
    public void TestLijstOplopend10000()
    {
        // Arrange
        var stack = new AStack<int>();

        // Act
        foreach (var value in reader.LijstOplopend10000)
        {
            stack.Push(value);
        }

        stack.Pop();

        var newValue = 12345;

        stack.Push(newValue);

        var first = stack.TopValue();

        var popped = stack.Pop();

        // Assert
        Assert.AreEqual(9998, stack.Size());
        Assert.AreEqual(newValue, first);
        Assert.AreEqual(newValue, popped);
    }

    [TestMethod]
    public void TestLijstWillekeurig10000()
    {
        // Arrange
        var stack = new AStack<int>();

        // Act
        foreach (var value in reader.LijstWillekeurig10000)
        {
            stack.Push(value);
        }

        for (int i = 0; i < reader.LijstWillekeurig10000.Length; i++)
        {
            stack.Pop();
        }

        // Assert
        Assert.ThrowsException<InvalidOperationException>(() => stack.TopValue());
        Assert.AreEqual(0, stack.Size());
    }

    [TestMethod]
    public void TestLijstWillekeurig3()
    {
        // Arrange
        var stack = new AStack<int>();

        // Act
        foreach (var value in reader.LijstWillekeurig3)
        {
            stack.Push(value);
        }

        stack.Pop();

        var newValue = 12345;

        stack.Push(newValue);

        var first = stack.TopValue();

        var popped = stack.Pop();

        // Assert
        Assert.AreEqual(2, stack.Size());
        Assert.AreEqual(newValue, first);
        Assert.AreEqual(newValue, popped);
    }

    [TestMethod]
    public void TestLijstPizza6()
    {
        // Arrange
        var stack = new AStack<Pizza>();

        // Act
        foreach (var value in reader.LijstPizza6)
        {
            stack.Push(value);
        }

        var newPizza = new Pizza("Mushroom", 8);

        stack.Push(newPizza);

        var first = stack.TopValue();

        // Assert
        Assert.AreEqual(7, stack.Size());
        Assert.AreEqual(newPizza, first);
    }
}
