using ADP_2024;
using ADP_2024.SortingAlgorithms;
using System.Diagnostics;

namespace ADP_2024_Test.QuickSortAlgorithm
{
	[TestClass]
	public sealed class QuickSortPerformanceTests
	{
		public required DatasetReader reader;

		// Since we are using a median-of-three strategy for pivot selection,  
		// the outcomes in the worst case or average case can differ slightly.  
		// For instance, selecting a pivot that places all items on one side  
		// could significantly degrade performance.  

		/*
		Execution time:
		|-------------------------------|
		| N         | Time              |
		|-------------------------------|
		| 10        | 00:00:00.0318244  |
		| 100       | 00:00:00.0318979  |
		| 1000      | 00:00:00.0321429  |
		| 10_000    | 00:00:00.0046067  |
		| 100_000   | 00:00:00.0363200  |
		| 1_000_000 | 00:00:00.4410474  |
		|-------------------------------|
		Comments on performance:
		1. Normal case represents a dataset with elements in random order.
		2. The time complexity for this scenario is O(n log n).
		3. Execution time increases logarithmically relative to the dataset size.
		*/

		[TestMethod]
		[DataRow(10)]
		[DataRow(100)]
		[DataRow(1_000)]
		[DataRow(10_000)]
		[DataRow(100_000)]
		[DataRow(1_000_000)]
		public void TestQuickSortPerformanceNormal(int amount)
		{
			// Arrange
			var quickSort = new QuickSort();
			var random = new Random();
			var array = new int[amount];

			for (int i = 0; i < amount; i++)
			{
				array[i] = random.Next(int.MinValue, int.MaxValue);
			}

			var watch = Stopwatch.StartNew();

			// Act
			quickSort.QuicksortAlgorithm(array, 0, array.Length - 1);

			// Assert
			watch.Stop();

			var elapsedMs = watch.Elapsed;

			Console.WriteLine(elapsedMs);

			// Ensure the array is sorted
			for (int i = 0; i < array.Length - 1; i++)
			{
				Assert.IsTrue(array[i] <= array[i + 1],
					$"Array is not sorted at index {i}: {array[i]} > {array[i + 1]}");
			}
		}

		/*
		Execution time:
		|-------------------------------|
		| N         | Time              |
		|-------------------------------|
		| 10        | 00:00:00.0007946  |
		| 100       | 00:00:00.0025464  |
		| 1000      | 00:00:00.0024103  |
		| 10_000    | 00:00:00.0021982  |
		| 100_000   | 00:00:00.0164749  |
		| 1_000_000 | 00:00:00.1418703  |
		|-------------------------------|
		Comments on performance:
		1. Best case occurs when the array is already sorted in ascending order.
		2. With the median-of-three pivot selection, the time complexity remains O(n log n).
		3. Sorting time is faster because fewer swaps and partitioning steps are needed.
		*/

		[TestMethod]
		[DataRow(10)]
		[DataRow(100)]
		[DataRow(1_000)]
		[DataRow(10_000)]
		[DataRow(100_000)]
		[DataRow(1_000_000)]
		public void TestQuickSortPerformanceBestCase(int amount)
		{
			// Arrange
			var quickSort = new QuickSort();
			var array = new int[amount];

			for (int i = 0; i < amount; i++)
			{
				array[i] = i;
			}

			var watch = Stopwatch.StartNew();

			// Act
			quickSort.QuicksortAlgorithm(array, 0, array.Length - 1);

			// Assert
			watch.Stop();

			var elapsedMs = watch.Elapsed;

			Console.WriteLine(elapsedMs);

			// Ensure the array is sorted
			for (int i = 0; i < array.Length - 1; i++)
			{
				Assert.IsTrue(array[i] <= array[i + 1],
					$"Array is not sorted at index {i}: {array[i]} > {array[i + 1]}");
			}
		}

		/*
		Execution time:
		|-------------------------------|
		| N         | Time              |
		|-------------------------------|
		| 10        | 00:00:00.0007987  |
		| 100       | 00:00:00.0007989  |
		| 1000      | 00:00:00.0008543  |
		| 10_000    | 00:00:00.0025962  |
		| 100_000   | 00:00:00.0187790  |
		| 1_000_000 | 00:00:00.1463347  |
		|-------------------------------|
		Comments on performance:
		1. Worst case occurs when the array is sorted in descending order, and pivot selection does not balance partitions well.
		2. Time complexity is O(n2) due to the lack of balanced partitions.
		*/

		[TestMethod]
		[DataRow(10)]
		[DataRow(100)]
		[DataRow(1_000)]
		[DataRow(10_000)]
		[DataRow(100_000)]
		[DataRow(1_000_000)]
		public void TestQuickSortPerformanceWorstCase(int amount)
		{
			// Arrange
			var quickSort = new QuickSort();
			var array = new int[amount];

			for (int i = 0; i < amount; i++)
			{
				array[i] = amount - i;
			}

			var watch = Stopwatch.StartNew();

			// Act
			quickSort.QuicksortAlgorithm(array, 0, array.Length - 1);

			// Assert
			watch.Stop();

			var elapsedMs = watch.Elapsed;

			Console.WriteLine(elapsedMs);

			// Ensure the array is sorted
			for (int i = 0; i < array.Length - 1; i++)
			{
				Assert.IsTrue(array[i] <= array[i + 1],
					$"Array is not sorted at index {i}: {array[i]} > {array[i + 1]}");
			}
		}
	}
}