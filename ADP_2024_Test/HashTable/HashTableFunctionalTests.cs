using ADP_2024;
using ADP_2024.HashTable;
using ADP_2024.Models;

namespace ADP_2024_Test.HashTable
{
	[TestClass]
	public sealed class HashTableFunctionalTests
	{
		public required DatasetReader reader;

		[TestInitialize]
		public void SetUp()
		{
			reader = new DatasetReader();
		}

		[TestMethod]
		public void TestHashTableInsert()
		{
			// Arrange
			var hashTable = new HashTable<string, List<int>>();

			// Act
			foreach (var entry in reader.HashingDatasets.hashtabelsleutelswaardes)
			{
				hashTable.Insert(entry.Key, entry.Value);
				Console.WriteLine($"Inserted - Key: {entry.Key}, Value: [{string.Join(", ", entry.Value)}]");
			}

			Console.WriteLine("\nHash Table Contents:");
			Console.WriteLine("-------------------");

			// Assert
			foreach (var entry in reader.HashingDatasets.hashtabelsleutelswaardes)
			{
				var result = hashTable.Get(entry.Key);
				Console.WriteLine($"Key: {entry.Key}, Value: [{string.Join(", ", result)}]");
				CollectionAssert.AreEqual(entry.Value, result, $"The value for key '{entry.Key}' should match the dataset.");
			}
			Console.WriteLine($"\nTotal size: {hashTable.Size()}");
			Assert.AreEqual(reader.HashingDatasets.hashtabelsleutelswaardes.Count, hashTable.Size());
		}

		[TestMethod]
		public void TestHashTableGet()
		{
			var hashTable = new HashTable<string, List<int>>();

			foreach (var entry in reader.HashingDatasets.hashtabelsleutelswaardes)
			{
				hashTable.Insert(entry.Key, entry.Value);
			}

			var keyToTest = reader.HashingDatasets.hashtabelsleutelswaardes.First().Key;
			var expectedValue = reader.HashingDatasets.hashtabelsleutelswaardes[keyToTest];
			var result = hashTable.Get(keyToTest);


			CollectionAssert.AreEqual(expectedValue, result, $"The value for key '{keyToTest}' should match the dataset.");
			Assert.ThrowsException<KeyNotFoundException>(() => hashTable.Get("nonExistingKey"));
		}

		[TestMethod]
		public void TestHashTableDelete()
		{
			var hashTable = new HashTable<string, List<int>>();

			foreach (var entry in reader.HashingDatasets.hashtabelsleutelswaardes)
			{
				hashTable.Insert(entry.Key, entry.Value);
			}

			var keyToDelete = reader.HashingDatasets.hashtabelsleutelswaardes.First().Key;
			hashTable.Delete(keyToDelete);

			Assert.ThrowsException<KeyNotFoundException>(() => hashTable.Get(keyToDelete), $"The key '{keyToDelete}' should not exist after deletion.");

			foreach (var entry in reader.HashingDatasets.hashtabelsleutelswaardes.Where(e => e.Key != keyToDelete))
			{
				var result = hashTable.Get(entry.Key);
				CollectionAssert.AreEqual(entry.Value, result, $"The value for key '{entry.Key}' should remain unchanged.");
			}
		}

		[TestMethod]
		public void TestHashTableUpdate()
		{
			var hashTable = new HashTable<string, List<int>>();

			foreach (var entry in reader.HashingDatasets.hashtabelsleutelswaardes)
			{
				hashTable.Insert(entry.Key, entry.Value);
			}

			var newValue = new List<int> { 42 };
			hashTable.Update("a", newValue);

			var result = hashTable.Get("a");
			CollectionAssert.AreEqual(newValue, result);
		}
	}
}
