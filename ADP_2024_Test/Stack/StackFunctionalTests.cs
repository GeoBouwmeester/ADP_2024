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
    public void TestLijstWillekeurig10000()
    {
        // Arrange
        var stack = new AStack<int>();

        // Act
        foreach (var value in reader.LijstOplopend10000)
        {
            stack.Push(value);
        }

        for (int i = 0; i < reader.LijstOplopend10000.Length; i++)
        {
            stack.Pop();
        }


        // Assert
        Assert.ThrowsException<InvalidOperationException>(() => stack.TopValue());
        Assert.AreEqual(0, stack.Size());
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

        // Assert
        Assert.AreEqual(2, stack.Size());
        Assert.AreEqual(1.0, stack.TopValue());
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
