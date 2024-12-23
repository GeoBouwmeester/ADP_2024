using ADP_2024;
using ADP_2024.SortingAlgorithms;
using System.Diagnostics;

namespace ADP_2024_Test.ParallelMergeSortAlgorithm
{
	[TestClass]
	public sealed class ParallelMergeSortPerformanceTests
	{
		public required DatasetReader reader;

		/*
		Execution time:
		|-------------------------------|
		| N         | Time              |
		|-------------------------------|
		| 10        | 00:00:00.0037552  |
		| 100       | 00:00:00.0037835  |
		| 1000      | 00:00:00.0040763  |
		| 10_000    | 00:00:00.0105577  |
		| 100_000   | 00:00:00.0855061  |
		| 1_000_000 | 00:00:00.3415670  |
		|-------------------------------|
		Comments on performance:
		1. Normal case represents a dataset with elements in random order.
		2. The time complexity for this scenario is O(n log n).
		3. 
		*/

		[TestMethod]
		[DataRow(10)]
		[DataRow(100)]
		[DataRow(1_000)]
		[DataRow(10_000)]
		[DataRow(100_000)]
		[DataRow(1_000_000)]
		public void TestParallelMergeSortNormalCase(int amount)
		{
			// Arrange
			var mergeSort = new ParallelMergeSort<int>();
			var random = new Random();
			var array = new int[amount];

			for (int i = 0; i < amount; i++)
			{
				array[i] = random.Next(int.MinValue, int.MaxValue);
			}

			var watch = Stopwatch.StartNew();

			// Act
			mergeSort.Sort(array);

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
		}

		/*
		Execution time:
		|-------------------------------|
		| N         | Time              |
		|-------------------------------|
		| 10        | 00:00:00.0053611  |
		| 100       | 00:00:00.0054592  |
		| 1000      | 00:00:00.0055974  |
		| 10_000    | 00:00:00.0083485  |
		| 100_000   | 00:00:00.0193043  |
		| 1_000_000 | 00:00:00.1058987  |
		|-------------------------------|
		Comments on performance:
        1. Worst case represents a dataset with elements in reverse order.
        2. Time complexity remains O(n log n).
		*/

		[TestMethod]
		[DataRow(10)]
		[DataRow(100)]
		[DataRow(1_000)]
		[DataRow(10_000)]
		[DataRow(100_000)]
		[DataRow(1_000_000)]
		public void TestParallelMergeSortWorstCase(int amount)
		{
			// Arrange
			var mergeSort = new ParallelMergeSort<int>();
			var array = new int[amount];
			for (int i = 0; i < amount; i++)
			{
				array[i] = amount - i;
			}

			var watch = Stopwatch.StartNew();

			// Act
			mergeSort.Sort(array);

			// Assert
			watch.Stop();

			var elapsedMs = watch.Elapsed;

			Console.WriteLine($"Sorted {amount} elements in {elapsedMs} ms");

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
		| 10        | 00:00:00.0080839  |
		| 100       | 00:00:00.0080936  |
		| 1000      | 00:00:00.0083279  |
		| 10_000    | 00:00:00.0104458  |
		| 100_000   | 00:00:00.0295285  |
		| 1_000_000 | 00:00:00.1117991  |
		|-------------------------------|
		Comments on performance:
		1. Best case represents a dataset that is already sorted.
		2. The time complexity for this scenario is O(n log n).
		*/

		[TestMethod]
		[DataRow(10)]
		[DataRow(100)]
		[DataRow(1_000)]
		[DataRow(10_000)]
		[DataRow(100_000)]
		[DataRow(1_000_000)]
		public void TestParalellMergeSortBestCase(int amount)
		{
			// Arrange
			var mergeSort = new ParallelMergeSort<int>();
			var array = new int[amount];
			for (int i = 0; i < amount; i++)
			{
				array[i] = i + 1; 
			}

			var watch = Stopwatch.StartNew();

			// Act
			mergeSort.Sort(array);

			// Assert
			watch.Stop();

			var elapsedMs = watch.Elapsed;

			Console.WriteLine($"Sorted {amount} elements in {elapsedMs} ms");

			for (int i = 0; i < array.Length - 1; i++)
			{
				Assert.IsTrue(array[i] <= array[i + 1],
					$"Array is not sorted at index {i}: {array[i]} > {array[i + 1]}");
			}
		}

		//Edge Case, Empty Array
		[TestMethod]
		public void TestEdgeCaseEmptyArray()
		{
			// Arrange
			var mergeSort = new ParallelMergeSort<int>();
			var array = new int[] { };

			// Act
			mergeSort.Sort(array);

			// Assert
			Assert.AreEqual(0, array.Length, "Array is not empty.");
		}
	}
}
