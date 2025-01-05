using System.Data;
using System.Diagnostics;
using ADP_2024.HashTable;

namespace ADP_2024_Test.HashTable
{
	[TestClass]
	public sealed class HashTablePerformanceTests
	{
		/*
		Execution time:
		|-------------------------------|
		| N         | Time              |
		|-------------------------------|
		| 10        | 00:00:00.0008930  |
		| 100       | 00:00:00.0015748  |
	    | 1000      | 00:00:00.0015388  |
		| 10_000    | 00:00:00.0044010  |
		| 100_000   | 00:00:00.0371929  |
		| 1_000_000 | 00:00:00.2259849  |
		|-------------------------------|
		Comments on performance:
		1. 
		2. 
		*/

		[TestMethod]
		[DataRow(10)]
		[DataRow(100)]
		[DataRow(1_000)]
		[DataRow(10_000)]
		[DataRow(100_000)]
		[DataRow(1_000_000)]
		public void TestHashTableInsert(int datasetSize)
		{
			// Arrange
			var hashTable = new HashTable<int, int>();
			var watch = Stopwatch.StartNew();

			// Act
			for (int i = 0; i < datasetSize; i++)
			{
				hashTable.Insert(i, i);
			}

			watch.Stop();
			var elapsedMs = watch.Elapsed;

			Console.WriteLine(elapsedMs);

			// Assert
			Assert.AreEqual(datasetSize, hashTable.Size());
		}

		/*
		Execution time:
		|-------------------------------|
		| N         | Time              |
		|-------------------------------|
		| 10        | 00:00:00.0014497  |
		| 100       | 00:00:00.0015517  |
		| 1000      | 00:00:00.0011768  |
		| 10_000    | 00:00:00.0043497  |
		| 100_000   | 00:00:00.0334371  |
		| 1_000_000 | 00:00:00.4044959  |
		|-------------------------------|
		Comments on performance:
		1. 
		2. 
		*/

		[TestMethod]
		[DataRow(10)]
		[DataRow(100)]
		[DataRow(1_000)]
		[DataRow(10_000)]
		[DataRow(100_000)]
		[DataRow(1_000_000)]
		public void TestHashTableGet(int datasetSize)
		{
			// Arrange
			var hashTable = new HashTable<int, int>();
			for (int i = 0; i < datasetSize; i++)
			{
				hashTable.Insert(i, i);
			}

			var watch = Stopwatch.StartNew();

			// Act & Assert
			for (int i = 0; i < datasetSize; i++)
			{
				var value = hashTable.Get(i);
				Assert.AreEqual(i, value, $"Get operation failed for key {i}.");
			}

			watch.Stop();
			var elapsedMs = watch.Elapsed;

			Console.WriteLine(elapsedMs);

			// Assert
			Assert.AreEqual(datasetSize, hashTable.Size());
		}

		/*
		Execution time:
		|-------------------------------|
		| N         | Time              |
		|-------------------------------|
		| 10        | 00:00:00.0001955  |
		| 100       | 00:00:00.0000175  |
		| 1000      | 00:00:00.0001272  |
		| 10_000    | 00:00:00.0017484  |
		| 100_000   | 00:00:00.0088202  |
		| 1_000_000 | 00:00:00.0909273  |
		|-------------------------------|
		Comments on performance:
		1. 
		2. 
		*/

		[TestMethod]
		[DataRow(10)]
		[DataRow(100)]
		[DataRow(1_000)]
		[DataRow(10_000)]
		[DataRow(100_000)]
		[DataRow(1_000_000)]
		public void TestHashTableDelete(int datasetSize)
		{
			// Arrange
			var hashTable = new HashTable<int, int>();
			for (int i = 0; i < datasetSize; i++)
			{
				hashTable.Insert(i, i);
			}

			var watch = Stopwatch.StartNew();

			// Act
			for (int i = 0; i < datasetSize; i++)
			{
				hashTable.Delete(i);
			}

			watch.Stop();
			var elapsedMs = watch.Elapsed;

			Console.WriteLine(elapsedMs);

			// Assert
			Assert.AreEqual(0, hashTable.Size());
		}

		/*
		Execution time:
		|-------------------------------|
		| N         | Time              |
		|-------------------------------|
		| 10        | 00:00:00.0002310  |
		| 100       | 00:00:00.0000106  |
		| 1000      | 00:00:00.0001241  |
		| 10_000    | 00:00:00.0013644  |
		| 100_000   | 00:00:00.0088200  |
		| 1_000_000 | 00:00:00.0896521  |
		|-------------------------------|
		Comments on performance:
		1. 
		2. 
		*/

		[TestMethod]
		[DataRow(10)]
		[DataRow(100)]
		[DataRow(1_000)]
		[DataRow(10_000)]
		[DataRow(100_000)]
		[DataRow(1_000_000)]
		public void TestHashTableUpdate(int datasetSize)
		{
			// Arrange
			var hashTable = new HashTable<int, int>();
			for (int i = 0; i < datasetSize; i++)
			{
				hashTable.Insert(i, i);
			}

			var watch = Stopwatch.StartNew();

			// Act
			for (int i = 0; i < datasetSize; i++)
			{
				hashTable.Update(i, i + 1); 
			}

			watch.Stop();
			var elapsedMs = watch.Elapsed;

			Console.WriteLine(elapsedMs);

			// Assert
			for (int i = 0; i < datasetSize; i++)
			{
				var value = hashTable.Get(i);
				Assert.AreEqual(i + 1, value, $"Update operation failed for key {i}.");
			}
			Assert.AreEqual(datasetSize, hashTable.Size());
		}
	}
}