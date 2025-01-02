using System.Data;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
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
		| 10        | 00:00:00.0015770  |
		| 100       | 00:00:00.0015823  |
	    | 1000      | 00:00:00.0017034  |
		| 10_000    | 00:00:00.0026005  |
		| 100_000   | 00:00:00.0258723  |
		| 1_000_000 | 00:00:00.1635523  |
		|-------------------------------|
		Comments on performance:
		1. 
		2. 
		*/

		[TestMethod]
		[DataRow(10, 10)]       
		[DataRow(100, 100)]      
		[DataRow(1_000, 1_000)]  
		[DataRow(10_000, 10_000)]  
		[DataRow(100_000, 100_000)] 
		[DataRow(1_000_000, 1_000_000)] 
		public void TestHashTableInsertBestCase(int datasetSize, int initialCapacity)
		{
			// Arrange
			var hashTable = new HashTable<int, int>(initialCapacity); 
			var watch = Stopwatch.StartNew();

			// Act
			for (int i = 0; i < datasetSize; i++)
			{
				hashTable.Insert(i, i); 
			}

			watch.Stop();
			Console.WriteLine($"Best Case Insertion Time for {datasetSize} elements (initial capacity {initialCapacity}): {watch.Elapsed}");
			
			// Assert
			Assert.AreEqual(datasetSize, hashTable.Size(), "The number of elements inserted does not match the dataset size.");
		}

		/*
		Execution time:
		|-------------------------------|
		| N         | Time              |
		|-------------------------------|
		| 10        | 00:00:00.0005948  |
		| 100       | 00:00:00.0006435  |
	    | 1000      | 00:00:00.0008192  |
		| 10_000    | 00:00:00.0028369  |
		| 100_000   | 00:00:00.0876553  |
		| 1_000_000 | 00:00:00.8319953  |
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
		public void TestHashTableInsertNormalCase(int datasetSize)
		{
			// Arrange
			var hashTable = new HashTable<int, int>(); 
			var random = new Random();
			var watch = Stopwatch.StartNew();

			// Act
			for (int i = 0; i < datasetSize; i++)
			{
				hashTable.Insert(random.Next(), i);
			}

			watch.Stop();

			Console.WriteLine($"Normal Case Insertion Time for {datasetSize} elements: {watch.Elapsed}");
			hashTable.Print();

			// Assert 
			Assert.AreEqual(datasetSize, hashTable.Size(), "The number of elements inserted does not match the dataset size.");
		}

		/*
		Execution time:
		|-------------------------------|
		| N         | Time              |
		|-------------------------------|
		| 10        | 00:00:00.0006578  |
		| 100       | 00:00:00.0006917  |
	    | 1000      | 00:00:00.0008080  |
		| 10_000    | 00:00:00.0015051  |
		| 100_000   | 00:00:00.0128756  |
		| 1_000_000 | 00:00:00.0647388  |
		|-------------------------------|
		Comments on performance:
		1. 
		2. 
		*/

		[TestMethod]
		[DataRow(10, 16)]      
		[DataRow(100, 32)]      
		[DataRow(1_000, 64)]    
		[DataRow(10_000, 128)]  
		[DataRow(100_000, 256)] 
		[DataRow(1_000_000, 512)] 
		public void TestHashTableInsertWorstCase(int datasetSize, int initialCapacity)
		{
			// Arrange
			var hashTable = new HashTable<int, int>(initialCapacity);
			var watch = Stopwatch.StartNew();

			// Act
			for (int i = 0; i < datasetSize; i++)
			{
				hashTable.Insert(i, i);  
			}

			watch.Stop();

			Console.WriteLine($"Worst Case Insertion Time for {datasetSize} elements (initial capacity {initialCapacity}): {watch.Elapsed}");

			hashTable.Print();
			// Assert
			Assert.AreEqual(datasetSize, hashTable.Size(), "The number of elements inserted does not match the dataset size.");
		}

	}
}
