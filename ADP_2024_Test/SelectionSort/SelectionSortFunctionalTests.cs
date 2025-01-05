using ADP_2024;
using ADP_2024.SelectionSort;

namespace ADP_2024_Test.SelectionSort;

[TestClass]
public class SelectionSortFunctionalTests
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
        var array = reader.LijstAflopend2;

        // Act
        SelectionSortAlgorithm.SelectionSort(array);

        // Assert
        Assert.AreEqual(2, array.Length);
        Assert.AreEqual(array[0], -10033224);
    }

    [TestMethod]
    public void TestLijstOplopend2()
    {
        // Arrange
        var array = reader.LijstOplopend2;

        // Act
        SelectionSortAlgorithm.SelectionSort(array);

        // Assert
        Assert.AreEqual(2, array.Length);
        Assert.AreEqual(array[0], -100324);
    }

    [TestMethod]
    public void TestLijstFloat8001()
    {
        // Arrange
        var array = reader.LijstFloat8001;

        // Act
        SelectionSortAlgorithm.SelectionSort(array);

        // Assert
        Assert.AreEqual(8001, array.Length);
        Assert.AreEqual(array[0], 0);
        Assert.AreEqual(array[array.Length - 1], 11312312312312.324f);
    }

    [TestMethod]
    public void TestLijstGesorteerdAflopend3()
    {
        // Arrange
        var array = reader.LijstGesorteerdAflopend3;

        // Act
        SelectionSortAlgorithm.SelectionSort(array);

        // Assert
        Assert.AreEqual(3, array.Length);
        Assert.AreEqual(array[0], 1);
        Assert.AreEqual(array[array.Length - 1], 3);
    }

    [TestMethod]
    public void TestLijstGesorteerdOplopend3()
    {
        // Arrange
        var array = reader.LijstGesorteerdOplopend3;

        // Act
        SelectionSortAlgorithm.SelectionSort(array);

        // Assert
        Assert.AreEqual(3, array.Length);
        Assert.AreEqual(array[0], 1);
        Assert.AreEqual(array[array.Length - 1], 3);
    }

    [TestMethod]
    public void TestLijstHerhaald1000()
    {
        // Arrange
        var array = reader.LijstHerhaald1000;

        // Act
        SelectionSortAlgorithm.SelectionSort(array);

        // Assert
        Assert.AreEqual(10000, array.Length);
        Assert.AreEqual(array[0], -1);
        Assert.AreEqual(array[array.Length - 3], 1);
        Assert.AreEqual(array[array.Length - 2], 11);
        Assert.AreEqual(array[array.Length - 1], 111);
    }

    [TestMethod]
    public void TestLijstLeeg0()
    {
        // Arrange
        var array = reader.LijstLeeg0;

        int[] newArray = new int[array.Length];

        for (var i = 0; i < array.Length; i++) 
        {
            var item = array[i];

            if (item != null)
            {
                newArray[i] = (int)item;
            }
        }

        // Act
        SelectionSortAlgorithm.SelectionSort(newArray);

        // Assert
        Assert.AreEqual(0, newArray.Length);
    }

    [TestMethod]
    public void TestLijstLeeg1()
    {
        // Arrange
        var array = reader.LijstNull1;

        int count = 0;

        foreach (var item in array)
        {
            if (item != null)
            {
                count++;
            }
        }

        int[] result = new int[count];

        int index = 0;

        foreach (var item in array)
        {
            if (item != null)
            {
                result[index++] = (int)item;
            }
        }

        // Act
        SelectionSortAlgorithm.SelectionSort(result);

        // Assert
        Assert.AreEqual(0, result.Count());
    }

    [TestMethod]
    public void TestLijstNull3()
    {
        // Arrange
        var array = reader.LijstNull3;

        int count = 0;

        foreach (var item in array)
        {
            if (item != null)
            {
                count++;
            }
        }

        int[] result = new int[count];

        int index = 0;

        foreach (var item in array)
        {
            if (item != null)
            {
                result[index++] = (int)item;
            }
        }

        // Act
        SelectionSortAlgorithm.SelectionSort(result);

        // Assert
        Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void TestLijstOnsorteerbaar3()
    {
        // Arrange
        var array = reader.LijstOnsorteerbaar3;

        int count = 0;

        foreach (var item in array)
        {
            if (item.GetType() != typeof(Int64)) continue;
            
            count++;
        }

        int[] result = new int[count];

        int index = 0;

        foreach (var item in array)
        {
            if (item.GetType() != typeof(Int64)) continue;

            result[index++] = (int)(long)item;
        }

        // Act
        SelectionSortAlgorithm.SelectionSort(result);

        // Assert
        Assert.AreEqual(1, result.Length);
        Assert.AreEqual(result[0], 1);
    }

    [TestMethod]
    public void TestLijstOplopend10000()
    {
        // Arrange
        var array = reader.LijstOplopend10000;

        // Act
        SelectionSortAlgorithm.SelectionSort(array);

        // Assert
        Assert.AreEqual(9999, array.Length);
        Assert.AreEqual(array[0], 1);
        Assert.AreEqual(array[array.Length - 1], 9999);
    }

    [TestMethod]
    public void TestLijstWillekeurig10000()
    {
        // Arrange
        var array = reader.LijstWillekeurig10000;

        // Act
        SelectionSortAlgorithm.SelectionSort(array);

        // Assert
        Assert.AreEqual(9999, array.Length);
        Assert.AreEqual(array[0], 1);
        Assert.AreEqual(array[array.Length - 1], 9999);
    }

    [TestMethod]
    public void TestLijstWillekeurig3()
    {
        // Arrange
        var array = reader.LijstWillekeurig3;

        // Act
        SelectionSortAlgorithm.SelectionSort(array);

        // Assert
        Assert.AreEqual(3, array.Length);
        Assert.AreEqual(array[0], 1);
        Assert.AreEqual(array[array.Length - 1], 3);
    }

    [TestMethod]
    public void TestString()
    {
        // Arrange
        string[] array = { "f", "d", "c", "b", "a" };

        // Act
        SelectionSortAlgorithm.SelectionSort(array);

        // Assert
        Assert.AreEqual(5, array.Length);
        Assert.AreEqual(array[0], "a");
        Assert.AreEqual(array[array.Length - 1], "f");
    }
}