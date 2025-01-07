using ADP_2024;
using ADP_2024.ParallelMergeSort;
using System.Diagnostics;

namespace ADP_2024_Test.ParallelMergeSort;

[TestClass]
public sealed class ParallelMergeSortPerformanceTests
{
	/*
	Execution time:
	|-------------------------------|
	| N         | Time              |
	|-------------------------------|
	| 10        | 00:00:00.0005313  |
	| 100       | 00:00:00.0006317  |
	| 1000      | 00:00:00.0011044  |
	| 10_000    | 00:00:00.0852939  |
	| 100_000   | 00:00:01.5738480  |
	| 1_000_000 | 00:00:06.0864592  |
	|-------------------------------|
	Comments on performance:
	1. Normal case represents a dataset with elements in random order.
	2. The time complexity for this scenario is O(n log n).
	3. 
	*/

	[TestMethod]
	[DataRow(10, 10)]
	[DataRow(100, 100)]
	[DataRow(1_000, 1_000)]
	[DataRow(10_000, 10_000)]
	[DataRow(100_000, 100_000)]
	[DataRow(1_000_000, 1_000_000)]
	public void TestParallelMergeSortNormalCase(int amount, int expectedAmount)
	{
		// Arrange
		var random = new Random();
		var array = new int[amount];

		for (int i = 0; i < amount; i++)
		{
			array[i] = random.Next(int.MinValue, int.MaxValue);
		}

		var watch = Stopwatch.StartNew();

		// Act
		ParallelMergeSortAlgorithm<int>.Sort(array);

		// Assert
		watch.Stop();

		var elapsedMs = watch.Elapsed;

		Console.WriteLine($"Sorted {amount} elements in {elapsedMs} ms");

		// Ensure the array is sorted
		for (int i = 0; i < array.Length - 1; i++)
		{
			Assert.IsTrue(array[i] <= array[i + 1],
				$"Array is not sorted at index {i}: {array[i]} > {array[i + 1]}");
		}
		Assert.AreEqual(expectedAmount, array.Length);
	}

	/*
	Execution time:
	|-------------------------------|
	| N         | Time              |
	|-------------------------------|
	| 10        | 00:00:00.0116129  |
	| 100       | 00:00:00.0032193  |
	| 1000      | 00:00:00.0052119  |
	| 10_000    | 00:00:00.0711137  |
	| 100_000   | 00:00:01.3297160  |
	| 1_000_000 | 00:00:05.5626370  |
	|-------------------------------|
	Comments on performance:
	1. Worst case represents a dataset with elements in reverse order.
	2. Time complexity remains O(n log n).
	*/

	[TestMethod]
	[DataRow(10, 10)]
	[DataRow(100, 100)]
	[DataRow(1_000, 1_000)]
	[DataRow(10_000, 10_000)]
	[DataRow(100_000, 100_000)]
	[DataRow(1_000_000, 1_000_000)]
	public void TestParallelMergeSortWorstCase(int amount, int expectedAmount)
	{
		// Arrange
		var array = new int[amount];
		for (int i = 0; i < amount; i++)
		{
			array[i] = amount - i;
		}

		var watch = Stopwatch.StartNew();

		// Act
		ParallelMergeSortAlgorithm<int>.Sort(array);

		// Assert
		watch.Stop();

		var elapsedMs = watch.Elapsed;

		Console.WriteLine($"Sorted {amount} elements in {elapsedMs} ms");

		for (int i = 0; i < array.Length - 1; i++)
		{
			Assert.IsTrue(array[i] <= array[i + 1],
			$"Array is not sorted at index {i}: {array[i]} > {array[i + 1]}");
		}
		Assert.AreEqual(expectedAmount, array.Length);
	}
	/*
	Execution time:
	|-------------------------------|
	| N         | Time              |
	|-------------------------------|
	| 10        | 00:00:00.0116182  |
	| 100       | 00:00:00.0013707  |
	| 1000      | 00:00:00.0119753  |
	| 10_000    | 00:00:00.0962750  |
	| 100_000   | 00:00:01.2953734  |
	| 1_000_000 | 00:00:05.2973437  |
	|-------------------------------|
	Comments on performance:
	1. Best case represents a dataset that is already sorted.
	2. The time complexity for this scenario is O(n log n).
	*/

	[TestMethod]
	[DataRow(10, 10)]
	[DataRow(100, 100)]
	[DataRow(1_000, 1_000)]
	[DataRow(10_000, 10_000)]
	[DataRow(100_000, 100_000)]
	[DataRow(1_000_000, 1_000_000)]
	public void TestParalellMergeSortBestCase(int amount, int expectedAmount)
	{
		// Arrange
		var array = new int[amount];
		for (int i = 0; i < amount; i++)
		{
			array[i] = i + 1;
		}

		var watch = Stopwatch.StartNew();

		// Act
		ParallelMergeSortAlgorithm<int>.Sort(array);

		// Assert
		watch.Stop();

		var elapsedMs = watch.Elapsed;

		Console.WriteLine($"Sorted {amount} elements in {elapsedMs} ms");

		for (int i = 0; i < array.Length - 1; i++)
		{
			Assert.IsTrue(array[i] <= array[i + 1],
				$"Array is not sorted at index {i}: {array[i]} > {array[i + 1]}");
		}
		Assert.AreEqual(expectedAmount, array.Length);
	}

	//Edge Case, Empty Array
	[TestMethod]
	public void TestEdgeCaseEmptyArray()
	{
		// Arrange
		var array = new int[] { };

		// Act
		ParallelMergeSortAlgorithm<int>.Sort(array);

		// Assert
		Assert.AreEqual(0, array.Length, "Array is not empty.");
	}
}