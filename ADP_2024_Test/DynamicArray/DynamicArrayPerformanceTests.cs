using ADP_2024;
using ADP_2024.DynamicArray;
using ADP_2024.Models;
using System.Diagnostics;

namespace ADP_2024_Test.DynamicArray;

[TestClass]
public sealed class DynamicArrayPerformanceTests
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
    | 10        | 00:00:00.0000004  |
    | 100       | 00:00:00.0000033  |
    | 1000      | 00:00:00.0000132  |
    | 10_000    | 00:00:00.0000791  |
    | 100_000   | 00:00:00.0013540  |
    | 1_000_000 | 00:00:00.0119180  |
    |-------------------------------|
    Comments on performance:
    1. Time complexity of the Add() operation is constant O(1) since an element is added to the back, so no shifting has to be done.
    2. In the worst case scenario time complexity would be linear O(n) due to resizing. It happens however infrequent. 
       This operation is expensive due to copying elements over to a new array.
    3. The implementation of Add() acts as an Append() method where the new item gets added to the end of the array. 
       Would the implementation change to an Insert() method where it would be possible to add an new item at any index of the array,
       then in the worst case scenario, when a new item gets added at the front of the array, 
       each insertion must shift all items to the left. This would take linear time O(n) due to the shifting of items.
    4. We could care less about space complexity and significantly increase the max size of the array each time we resize.
       This way, resizing - and with that copying elements over to a new array - happens a lot less frequent which would enhance the performance.
    */
    [TestMethod]
    [DataRow(10, 10)]
    [DataRow(100, 100)]
    [DataRow(1000, 1000)]
    [DataRow(10_000, 10_000)]
    [DataRow(100_000, 100_000)]
    [DataRow(1_000_000, 1_000_000)]
    public void TestAddTimeComplexity(int amount, int expectedAmount)
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>();

        var watch = Stopwatch.StartNew();

        // Act
        for (var i = 0; i < amount; i++)
        {
            dynamicArray.Add(i);
        }

        // Assert
        watch.Stop();

        var elapsedMs = watch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreEqual(expectedAmount, dynamicArray.Count);
    }

    /*
    Execution time:
    |-------------------------------|
    | N         | Time              |
    |-------------------------------|
    | 10        | 00:00:00.0000002  |
    | 100       | 00:00:00.0000009  |
    | 1000      | 00:00:00.0000079  |
    | 10_000    | 00:00:00.0001663  |
    | 100_000   | 00:00:00.0007844  |
    | 1_000_000 | 00:00:00.0032345  |
    |-------------------------------|
    Comments on performance:
    1. The Get() operation uses indexing which has a constant time complexity O(1).
    */
    [TestMethod]
    [DataRow(10, 10)]
    [DataRow(100, 100)]
    [DataRow(1000, 1000)]
    [DataRow(10_000, 10_000)]
    [DataRow(100_000, 100_000)]
    [DataRow(1_000_000, 1_000_000)]
    public void TestGetTimeComplexity(int amount, int expectedAmount)
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>();

        for (var i = 0; i < amount; i++)
        {
            dynamicArray.Add(i);
        }

        var watch = Stopwatch.StartNew();

        // Act
        for (var i = 0; i < amount; i++)
        {
            dynamicArray.Get(i);
        }

        // Assert
        watch.Stop();

        var elapsedMs = watch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreEqual(expectedAmount, dynamicArray.Count);
    }

    /*
    Execution time:
    |-------------------------------|
    | N         | Time              |
    |-------------------------------|
    | 10        | 00:00:00.0000001  |
    | 100       | 00:00:00.0000009  |
    | 1000      | 00:00:00.0000066  |
    | 10_000    | 00:00:00.0000654  |
    | 100_000   | 00:00:00.0006627  |
    | 1_000_000 | 00:00:00.0041343  |
    |-------------------------------|
    Comments on performance:
    1. The Set() operation uses indexing which has a constant time complexity O(1).
    */
    [TestMethod]
    [DataRow(10, 10)]
    [DataRow(100, 100)]
    [DataRow(1000, 1000)]
    [DataRow(10_000, 10_000)]
    [DataRow(100_000, 100_000)]
    [DataRow(1_000_000, 1_000_000)]
    public void TestSetTimeComplexity(int amount, int expectedAmount)
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>(amount);

        for (var i = 0; i < amount; i++)
        {
            dynamicArray.Add(i);
        }

        var watch = Stopwatch.StartNew();

        // Act
        for (var i = 0; i < amount; i++)
        {
            dynamicArray.Set(i, i);
        }

        // Assert
        watch.Stop();

        var elapsedMs = watch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreEqual(expectedAmount, dynamicArray.Count);
    }

    /*
    Execution time:
    |-------------------------------|
    | N         | Time              |
    |-------------------------------|
    | 10        | 00:00:00.0001541  |
    | 100       | 00:00:00.0001724  |
    | 1000      | 00:00:00.0010575  |
    | 10_000    | 00:00:00.1609186  |
    | 100_000   | 00:00:11.5904742  |
    | 1_000_000 | 00:27:03.2711971  |
    |-------------------------------|
    Comments on performance:
    1. Items are always removed from index 0 which means all elements after have to get shifted. 
       This test tests the worst case scenario. Which means it takes linear time O(n) to remove an item.
    2. Space complexity is taken into account in the implementation by shrinking the array 
       to half its size when it reaches 25% or less of its maximum size. This could have been omitted 
       to improve performance.
    */
    [TestMethod]
    [DataRow(10, 0)]
    [DataRow(100, 0)]
    [DataRow(1000, 0)]
    [DataRow(10_000, 0)]
    [DataRow(100_000, 0)]
    [DataRow(1_000_000, 0)]
    public void TestRemoveByFirstIndexTimeComplexity(int amount, int expectedAmount)
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>();

        for (var i = 0; i < amount; i++)
        {
            dynamicArray.Add(i);
        }

        var watch = Stopwatch.StartNew();

        // Act
        for (int i = 0; i < amount; i++)
        {
            dynamicArray.Remove(0);
        }

        // Assert
        watch.Stop();

        var elapsedMs = watch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreEqual(expectedAmount, dynamicArray.Count);
    }

    /*
    Execution time:
    |-------------------------------|
    | N         | Time              |
    |-------------------------------|
    | 10        | 00:00:00.0000006  |
    | 100       | 00:00:00.0001617  |
    | 1000      | 00:00:00.0000090  |
    | 10_000    | 00:00:00.0001414  |
    | 100_000   | 00:00:00.0009266  |
    | 1_000_000 | 00:00:00.0072280  |
    |-------------------------------|
    Comments on performance:
    1. Items are always removed from index n which means no elements have to get shifted because this is the last element. 
       This test tests the best case scenario. Which means it takes constant time O(1) to remove an item.
    2. Space complexity is taken into account in the implementation by shrinking the array 
       to half its size when it reaches 25% or less of its maximum size. This could have been omitted 
       to improve performance.
    */
    [TestMethod]
    [DataRow(10, 0)]
    [DataRow(100, 0)]
    [DataRow(1000, 0)]
    [DataRow(10_000, 0)]
    [DataRow(100_000, 0)]
    [DataRow(1_000_000, 0)]
    public void TestRemoveByLastIndexTimeComplexity(int amount, int expectedAmount)
    {
        // Arrange
        var dynamicArray = new DynamicArray<int>();

        for (var i = 0; i < amount; i++)
        {
            dynamicArray.Add(i);
        }

        var watch = Stopwatch.StartNew();

        // Act
        for (int i = amount - 1; i >= 0; i--)
        {
            dynamicArray.Remove(i);
        }

        // Assert
        watch.Stop();

        var elapsedMs = watch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreEqual(expectedAmount, dynamicArray.Count);
    }

    /*
    Execution time:
    |-------------------------------|
    | N         | Time              |
    |-------------------------------|
    | 10        | 00:00:00.0004591  |
    | 100       | 00:00:00.0002061  |
    | 1000      | 00:00:00.0089031  |
    | 10_000    | 00:00:00.2775046  |
    | 100_000   | 00:00:19.2821772  |
    | 1_000_000 | 00:41:38.2793591  |
    |-------------------------------|
    Comments on performance:
    1. Seaching and shifting requires, in the worst case scenario, looping through each element for each action. 
       They are however not nested which means the time complexity remains linear O(n).
    2. Space complexity is taken into account in the implementation by shrinking the array 
       to half its size when it reaches 25% or less of its maximum size. This could have been omitted 
       to improve performance.
    3. Shrinking happens proportional to the number of elements which means a constant time O(1).
    */
    [TestMethod]
    [DataRow(10, 0)]
    [DataRow(100, 0)]
    [DataRow(1000, 0)]
    [DataRow(10_000, 0)]
    [DataRow(100_000, 0)]
    [DataRow(1_000_000, 0)]
    public void TestRemoveByItemTimeComplexity(int amount, int expectedAmount)
    {
        // Arrange
        var dynamicArray = new DynamicArray<Pizza>();

        for (var i = 0; i < amount; i++)
        {
            dynamicArray.Add(new Pizza("Pepperoni", i));
        }

        var watch = Stopwatch.StartNew();

        // Act
        for (int i = 0; i < amount; i++)
        {
            dynamicArray.Remove(new Pizza("Pepperoni", i));
        }

        // Assert
        watch.Stop();

        var elapsedMs = watch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreEqual(expectedAmount, dynamicArray.Count);
    }

    /*
    Execution time:
    |-----------------------------------------------|
    | N             | Index     | Time              |
    |-----------------------------------------------|
    | 100           | first     | 00:00:00.0006349  |
    | 1000          | first     | 00:00:00.0000005  |
    | 10_000        | first     | 00:00:00.0000008  |
    | 100_000       | first     | 00:00:00.0000014  |
    | 1_000_000     | first     | 00:00:00.0000014  |
    | 10_000_000    | first     | 00:00:00.0000010  |
    | 100           | last      | 00:00:00.0000037  |
    | 1000          | last      | 00:00:00.0006594  |
    | 10_000        | last      | 00:00:00.0004734  |
    | 100_000       | last      | 00:00:00.0278958  |
    | 1_000_000     | last      | 00:00:00.1111015  |
    | 10_000_000    | last      | 00:00:00.3646652  |
    | 100           | n/a       | 00:00:00.0000054  |
    | 1000          | n/a       | 00:00:00.0007002  |
    | 10_000        | n/a       | 00:00:00.0003010  |
    | 100_000       | n/a       | 00:00:00.0252951  |
    | 1_000_000     | n/a       | 00:00:00.1463808  |
    | 10_000_000    | n/a       | 00:00:00.3568986  |
    |-----------------------------------------------|
    Comments on performance:
    1. Contains() searches through the entire array untill it finds the given item. This takes linear time O(n).
    2. Given the array is sorted (items are added sequentially with an increment of one) finding item 0, 
       which should be the first item in the given array, takes constant time O(1).
    3. Given the array is sorted (items are added sequentially with an increment of one) finding item n, 
       which should be the last item in the given array, takes linear time O(n).
    4. Finding an item which does not exist takes linear time O(n) since it traverses the entire array.
    */
    [TestMethod]
    [DataRow(100, 100, 0)]
    [DataRow(1_000, 1_000, 0)]
    [DataRow(10_000, 10_000, 0)]
    [DataRow(100_000, 100_000, 0)]
    [DataRow(1_000_000, 1_000_000, 0)]
    [DataRow(10_000_000, 10_000_000, 0)]
    [DataRow(100, 100, 99)]
    [DataRow(1_000, 1_000, 999)]
    [DataRow(10_000, 10_000, 9999)]
    [DataRow(100_000, 100_000, 99_999)]
    [DataRow(1_000_000, 1_000_000, 999_999)]
    [DataRow(10_000_000, 10_000_000, 9_999_999)]
    [DataRow(100, 100, 111)]
    [DataRow(1_000, 1_000, 1111)]
    [DataRow(10_000, 10_000, 11_111)]
    [DataRow(100_000, 100_000, 111_111)]
    [DataRow(1_000_000, 1_000_000, 1_111_111)]
    [DataRow(10_000_000, 10_000_000, 11_111_111)]
    public void TestContainsTimeComplexity(int amount, int expectedAmount, int item)
    {
        // Arrange
        var dynamicArray = new DynamicArray<Pizza>();

        for (var i = 0; i < amount; i++)
        {
            dynamicArray.Add(new Pizza("Pepperoni", i));
        }

        var watch = Stopwatch.StartNew();

        // Act
        dynamicArray.Contains(new Pizza("Pepperoni", item));

        // Assert
        watch.Stop();

        var elapsedMs = watch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreEqual(expectedAmount, dynamicArray.Count);
    }

    /*
    Execution time:
    |-----------------------------------------------|
    | N             | Index     | Time              |
    |-----------------------------------------------|
    | 100           | first     | 00:00:00.0022459  |
    | 1_000         | first     | 00:00:00.0021188  |
    | 10_000        | first     | 00:00:00.0000227  |
    | 100_000       | first     | 00:00:00.0000007  |
    | 1_000_000     | first     | 00:00:19.0000011  |
    | 10_000_000    | first     | 00:03:00.0000012  |
    | 100           | last      | 00:00:00.0021263  |
    | 1_000         | last      | 00:00:00.0021904  |
    | 10_000        | last      | 00:00:00.0048843  |
    | 100_000       | last      | 00:00:00.0153383  |
    | 1_000_000     | last      | 00:00:19.0784529  |
    | 10_000_000    | last      | 00:03:00.3098731  |
    |-----------------------------------------------|
    Comments on performance:
    1. IndexOf() searches through the entire array untill it finds the given item. This takes linear time O(n).
    2. Given the array is sorted (items are added sequentially with an increment of one) finding item 0, 
       which should be the first item in the given array, takes constant time O(1).
    3. Given the array is sorted (items are added sequentially with an increment of one) finding item n, 
       which should be the last item in the given array, takes linear time O(n).
    */
    [TestMethod]
    [DataRow(100, 100, 0)]
    [DataRow(1_000, 1_000, 0)]
    [DataRow(10_000, 10_000, 0)]
    [DataRow(100_000, 100_000, 0)]
    [DataRow(1_000_000, 1_000_000, 0)]
    [DataRow(10_000_000, 10_000_000, 0)]
    [DataRow(100, 100, 99)]
    [DataRow(1_000, 1_000, 999)]
    [DataRow(10_000, 10_000, 9999)]
    [DataRow(100_000, 100_000, 99_999)]
    [DataRow(1_000_000, 1_000_000, 999_999)]
    [DataRow(10_000_000, 10_000_000, 9_999_999)]
    public void TestIndexOfTimeComplexity(int amount, int expectedAmount, int item)
    {
        // Arrange
        var dynamicArray = new DynamicArray<Pizza>();

        for (var i = 0; i < amount; i++)
        {
            dynamicArray.Add(new Pizza("Pepperoni", i));
        }

        var watch = Stopwatch.StartNew();

        // Act
        var index = dynamicArray.IndexOf(new Pizza("Pepperoni", item));

        // Assert
        watch.Stop();

        var elapsedMs = watch.Elapsed;

        Console.WriteLine(elapsedMs);

        Assert.AreEqual(expectedAmount, dynamicArray.Count);
        Assert.AreEqual(item, index);
    }
}
