using ADP_2024;
using ADP_2024.BinarySearch;

namespace ADP_2024_Test.BinarySearch;

[TestClass]
public class BinarySearchFunctionalTests
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

        var search = -10033224;

        // Act
        var index = BinarySearchAlgorithm.BinarySearch(array, search);

        // Assert
        Assert.AreEqual(-1, index);
    }

    [TestMethod]
    public void TestLijstOplopend2()
    {
        // Arrange
        var array = reader.LijstOplopend2;

        var search = -100324;

        // Act
        var index = BinarySearchAlgorithm.BinarySearch(array, search);

        // Assert
        Assert.AreNotEqual(-1, index);
        Assert.AreEqual(array[index], search);
    }

    [TestMethod]
    public void TestLijstFloat8001()
    {
        // Arrange
        var array = reader.LijstFloat8001;

        var search = 11312312312312.324f;

        // Act
        var index = BinarySearchAlgorithm.BinarySearch(array, search);

        // Assert
        Assert.AreNotEqual(-1, index);
        Assert.AreEqual(array[index], search);
    }

    [TestMethod]
    public void TestLijstGesorteerdAflopend3()
    {
        // Arrange
        var array = reader.LijstGesorteerdAflopend3;

        var search = 3;

        // Act
        var index = BinarySearchAlgorithm.BinarySearch(array, search);

        // Assert
        Assert.AreEqual(-1, index);
    }

    [TestMethod]
    public void TestLijstGesorteerdOplopend3()
    {
        // Arrange
        var array = reader.LijstGesorteerdOplopend3;

        var search = 3;

        // Act
        var index = BinarySearchAlgorithm.BinarySearch(array, search);

        // Assert
        Assert.AreNotEqual(-1, index);
        Assert.AreEqual(array[index], search);
    }

    [TestMethod]
    public void TestLijstHerhaald1000()
    {
        // Arrange
        var array = reader.LijstHerhaald1000;

        var search = 111;

        // Act
        var index = BinarySearchAlgorithm.BinarySearch(array, search);

        // Assert
        Assert.AreEqual(-1, index);
    }

    //[TestMethod]
    //public void TestLijstLeeg0()
    //{
    //    // Arrange
    //    var array = reader.LijstLeeg0;

    //    int[] newArray = new int[array.Length];
    //    Array.Copy(array, newArray, array.Length);

    //    var search = 0;

    //    // Act
    //    var index = BinarySearchAlgorithm.BinarySearch(newArray, search);

    //    // Assert
    //    Assert.AreEqual(-1, index);
    //}

    //[TestMethod]
    //public void TestLijstNull1()
    //{
    //    // Arrange
    //    var array = reader.LijstNull1;

    //    int[] newArray = new int[array.Length].ToArray();
    //    Array.Copy(array, newArray, array.Length);

    //    var search = 0;

    //    // Act
    //    var index = BinarySearchAlgorithm.BinarySearch(newArray, search);

    //    // Assert
    //    Assert.AreEqual(-1, index);
    //}

    //[TestMethod]
    //public void TestLijstNull3()
    //{
    //    // Arrange
    //    var array = reader.LijstNull3;

    //    int[] newArray = new int[array.Length].ToArray();
    //    Array.Copy(array, newArray, array.Length);

    //    var search = 0;

    //    // Act
    //    var index = BinarySearchAlgorithm.BinarySearch(newArray, search);

    //    // Assert
    //    Assert.AreEqual(-1, index);
    //}

    //[TestMethod]
    //public void TestLijstOnsorteerbaar3()
    //{
    //    // Arrange
    //    var array = reader.LijstOnsorteerbaar3;

    //    int[] newArray = new int[array.Length].ToArray();
    //    Array.Copy(array, newArray, array.Length);

    //    var search = 0;

    //    // Act
    //    var index = BinarySearchAlgorithm.BinarySearch(newArray, search);

    //    // Assert
    //    Assert.AreEqual(-1, index);
    //}

    [TestMethod]
    public void TestLijstOplopend10000()
    {
        // Arrange
        var array = reader.LijstOplopend10000;

        var search = 9664;

        // Act
        var index = BinarySearchAlgorithm.BinarySearch(array, search);

        // Assert
        Assert.AreNotEqual(-1, index);
        Assert.AreEqual(array[index], search);
    }

    [TestMethod]
    public void TestLijstWillekeurig10000()
    {
        // Arrange
        var array = reader.LijstWillekeurig10000;

        var search = 0;

        // Act
        var index = BinarySearchAlgorithm.BinarySearch(array, search);

        // Assert
        Assert.AreEqual(-1, index);
    }

    [TestMethod]
    public void TestLijstWillekeurig3()
    {
        // Arrange
        var array = reader.LijstWillekeurig3;

        var search = 0;

        // Act
        var index = BinarySearchAlgorithm.BinarySearch(array, search);

        // Assert
        Assert.AreEqual(-1, index);
    }

    [TestMethod]
    public void TestStrings()
    {
        // Arrange
        string[] array = {"a", "b", "c", "d", "e"};

        var target = "b";

        // Act
        var index = BinarySearchAlgorithm.BinarySearch<string>(array, target);

        // Assert
        Assert.AreEqual(1, index);
    }
}