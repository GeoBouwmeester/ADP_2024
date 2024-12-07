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
    public void TestLijstOplopend2()
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>();

        // Act
        foreach (var value in reader.LijstOplopend2)
        {
            dynamicArray.Add(value);
        }

        var contains = dynamicArray.Contains(-100324);

        // Assert
        Assert.AreEqual(2, dynamicArray.Count);
        Assert.IsTrue(contains);
    }

    [TestMethod]
    public void TestLijstFloat8001()
    {
        // Arrange
        var dynamicArray = new DynamicArray<float>();

        // Act
        foreach (var value in reader.LijstFloat8001)
        {
            dynamicArray.Add(value);
        }

        var newValue = 12.34F;

        dynamicArray.Add(newValue);

        var contains = dynamicArray.Contains(11312312312312.324f);

        var index = dynamicArray.IndexOf(newValue);

        var x = dynamicArray.Get(index);

        // Assert
        Assert.AreEqual(8002, dynamicArray.Count);
        Assert.IsTrue(contains);
        Assert.AreEqual(8001, index);
        Assert.AreEqual(newValue, x);
    }

    [TestMethod]
    public void TestLijstGesorteerdAflopend3()
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>();

        // Act
        foreach (var value in reader.LijstGesorteerdAflopend3)
        {
            dynamicArray.Add(value);
        }

        var newValue = 12;

        dynamicArray.Add(newValue);

        var contains = dynamicArray.Contains(newValue);

        var index = dynamicArray.IndexOf(newValue);

        var first = dynamicArray.Get(index);

        // Assert
        Assert.AreEqual(4, dynamicArray.Count);
        Assert.IsTrue(contains);
        Assert.AreEqual(3, index);
        Assert.AreEqual(newValue, first);
    }

    [TestMethod]
    public void TestLijstGesorteerdOplopend3()
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>();

        // Act
        foreach (var value in reader.LijstGesorteerdOplopend3)
        {
            dynamicArray.Add(value);
        }

        var newValue = 12;

        dynamicArray.Add(newValue);

        var contains = dynamicArray.Contains(newValue);

        var index = dynamicArray.IndexOf(newValue);

        var first = dynamicArray.Get(index);

        // Assert
        Assert.AreEqual(4, dynamicArray.Count);
        Assert.IsTrue(contains);
        Assert.AreEqual(3, index);
        Assert.AreEqual(newValue, first);
    }

    [TestMethod]
    public void TestLijstHerhaald1000()
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>();

        // Act
        foreach (var value in reader.LijstHerhaald1000)
        {
            dynamicArray.Add(value);
        }

        var newValue = 12;

        dynamicArray.Add(newValue);

        var contains = dynamicArray.Contains(newValue);

        var index = dynamicArray.IndexOf(newValue);

        var first = dynamicArray.Get(index);

        // Assert
        Assert.AreEqual(10001, dynamicArray.Count);
        Assert.IsTrue(contains);
        Assert.AreEqual(10000, index);
        Assert.AreEqual(newValue, first);
    }

    [TestMethod]
    public void TestLijstLeeg0()
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>();

        // Act
        foreach (var value in reader.LijstLeeg0)
        {
            dynamicArray.Add((int)value);
        }

        var newValue = 12;

        dynamicArray.Add(newValue);

        var contains = dynamicArray.Contains(newValue);

        var index = dynamicArray.IndexOf(newValue);

        var first = dynamicArray.Get(index);

        // Assert
        Assert.AreEqual(1, dynamicArray.Count);
        Assert.IsTrue(contains);
        Assert.AreEqual(0, index);
        Assert.AreEqual(newValue, first);
    }

    [TestMethod]
    public void TestLijstNull1()
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>();

        // Act
        foreach (var value in reader.LijstNull1)
        {
            if (value != null) dynamicArray.Add((int)value);
        }

        var newValue = 123456;

        dynamicArray.Add(newValue);

        var contains = dynamicArray.Contains(newValue);

        var index = dynamicArray.IndexOf(newValue);

        var first = dynamicArray.Get(index);

        // Assert
        Assert.AreEqual(1, dynamicArray.Count);
        Assert.IsTrue(contains);
        Assert.AreEqual(0, index);
        Assert.AreEqual(newValue, first);
    }

    [TestMethod]
    public void TestLijstNull3()
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>();

        // Act
        foreach (var value in reader.LijstNull3)
        {
            if (value != null) dynamicArray.Add((int)value);
        }

        var newValue = 123456;

        dynamicArray.Add(newValue);

        var contains = dynamicArray.Contains(newValue);

        var index = dynamicArray.IndexOf(newValue);

        var first = dynamicArray.Get(index);

        // Assert
        Assert.AreEqual(3, dynamicArray.Count);
        Assert.IsTrue(contains);
        Assert.AreEqual(2, index);
        Assert.AreEqual(newValue, first);
    }

    [TestMethod]
    public void TestLijstOnsorteerbaar3()
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>();

        // Act
        foreach (var value in reader.LijstOnsorteerbaar3)
        {
            if (value.GetType() != typeof(Int64)) continue;
                
            dynamicArray.Add((int)(long)value);
        }

        // Assert
        Assert.AreEqual(1, dynamicArray.Count);
    }

    [TestMethod]
    public void TestLijstOplopend10000()
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
    public void TestLijstWillekeurig10000()
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>();

        // Act
        foreach (var value in reader.LijstWillekeurig10000)
        {
            dynamicArray.Add(value);
        }

        for (int i = 0; i < reader.LijstWillekeurig10000.Length; i++)
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
    public void TestLijstWillekeurig3()
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>();

        // Act
        foreach (var value in reader.LijstWillekeurig3)
        {
            dynamicArray.Add(value);
        }

        var newValue = 123456789;

        dynamicArray.Add(newValue);

        var contains = dynamicArray.Contains(newValue);

        var index = dynamicArray.IndexOf(newValue);

        var first = dynamicArray.Get(index);

        // Assert
        Assert.AreEqual(4, dynamicArray.Count);
        Assert.IsTrue(contains);
        Assert.AreEqual(3, index);
        Assert.AreEqual(newValue, first);
    }

    [TestMethod]
    public void TestLijstPizza6()
    {
        // Arrange
        var dynamicArray = new DynamicArray<Pizza>();

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