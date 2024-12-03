using ADP_2024;
using ADP_2024.DoublyLinkedList;
using System.Diagnostics;

namespace ADP_2024_Test.DoublyLinkedList
{
	[TestClass]
	public sealed class DoublyLinkedListPerformanceTests
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
		*/

		[TestMethod]
		[DataRow(10, 10)]
		[DataRow(100, 100)]
		[DataRow(1000, 1000)]
		[DataRow(10_000, 10_000)]
		[DataRow(100_000, 100_000)]
		[DataRow(1_000_000, 1_000_000)]
		public void TestAddTimeComplexityForDoublyLinkedList(int amount, int expectedAmount)
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();
			var watch = Stopwatch.StartNew();

			// Act
			for (var i = 0; i < amount; i++)
			{
				doublyLinkedList.Add(i);
			}

			// Assert
			watch.Stop();

			// Use TimeSpan for consistent precision in time output
			var elapsed = watch.Elapsed;
			Console.WriteLine($"Time taken to add {amount} elements: {elapsed}");

			Assert.AreEqual(expectedAmount, doublyLinkedList.Length);
		}

		/*
		Execution time:
		|-------------------------------|
		| N         | Time              |
		|-------------------------------|
		| 10        | 00:00:00.0007575  |
		| 100       | 00:00:00.0000082  |
		| 1000      | 00:00:00.0000919  |
		| 10_000    | 00:00:00.0010243  |
		| 100_000   | 00:00:00.0101879  |
		| 1_000_000 | 00:00:00.0727935  |
		|-------------------------------|
		*/

		[TestMethod]
		[DataRow(10, 0)]
		[DataRow(100, 0)]
		[DataRow(1000, 0)]
		[DataRow(10_000, 0)]
		[DataRow(100_000, 0)]
		[DataRow(1_000_000, 0)]
		public void TestRemoveTimeComplexityForDoublyLinkedList(int amount, int expectedAmount)
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();

			// Populate the doubly linked list with the specified number of elements
			for (var i = 0; i < amount; i++)
			{
				doublyLinkedList.Add(i);
			}

			var watch = Stopwatch.StartNew();

			// Act
			// Remove elements from the list one by one
			for (var i = 0; i < amount; i++)
			{
				doublyLinkedList.Remove(i);
			}

			// Assert
			watch.Stop();

			var elapsedMs = watch.Elapsed;

			Console.WriteLine($"Time taken to remove {amount} elements: {elapsedMs}");

			Assert.AreEqual(expectedAmount, doublyLinkedList.Length);
		}


	}
}
