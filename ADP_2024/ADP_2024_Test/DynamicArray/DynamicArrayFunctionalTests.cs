using ADP_2024;
using ADP_2024.DynamicArray;
using ADP_2024.Models;

namespace ADP_2024_Test.DynamicArray;

[TestClass]
public sealed class DynamicArrayFunctionalTests
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
        var dynamicArray = new DynamicArray<int>();

        // Act
        foreach (var value in reader.LijstAflopend2)
        {
            dynamicArray.Add(value);
        }

        var contains = dynamicArray.Contains(-10033224);

        // Assert
        Assert.AreEqual(2, dynamicArray.Count);
        Assert.IsTrue(contains);
    }

    [TestMethod]
    public void TestLijstWillekeurig10000()
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>();

        // Act
        foreach (var value in reader.LijstOplopend10000)
        {
            dynamicArray.Add(value);
        }

        for (int i = 0; i < reader.LijstOplopend10000.Length; i++)
        {
            dynamicArray.Remove(0);
        }

        var contains = dynamicArray.Contains(5247);

        // Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => dynamicArray.Get(0));
        Assert.AreEqual(0, dynamicArray.Count);
        Assert.IsFalse(contains);
    }

    [TestMethod]
    public void TestLijstOnsorteerbaar3()
    {
        // Arrange
        var dynamicArray = new DynamicArray<object>();

        // Act
        foreach (var value in reader.LijstOnsorteerbaar3)
        {
            dynamicArray.Add(value);
        }

        dynamicArray.Remove("string");

        var contains = dynamicArray.Contains("string");

        // Assert
        Assert.AreEqual(2, dynamicArray.Count);
        Assert.IsFalse(contains);
    }

    [TestMethod]
    public void TestLijstPizza6()
    {
        // Arrange
        var dynamicArray = new DynamicArray<Pizza>(comparer: new PizzaComparer());

        // Act
        foreach (var value in reader.LijstPizza6)
        {
            dynamicArray.Add(value);
        }

        var newPizza = new Pizza("Mushroom", 8);

        dynamicArray.Add(newPizza);

        var contains = dynamicArray.Contains(newPizza);

        var index = dynamicArray.IndexOf(newPizza);

        var first = dynamicArray.Get(index);

        // Assert
        Assert.AreEqual(7, dynamicArray.Count);
        Assert.IsTrue(contains);
        Assert.AreEqual(6, index);
        Assert.AreEqual(newPizza, first);
    }
}