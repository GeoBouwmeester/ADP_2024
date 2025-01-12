using ADP_2024;
using ADP_2024.HashTable;

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
			}

			hashTable.Print();

			// Assert
			foreach (var entry in reader.HashingDatasets.hashtabelsleutelswaardes)
			{
				var result = hashTable.Get(entry.Key);
				CollectionAssert.AreEqual(entry.Value, result, $"The value for key '{entry.Key}' should match the dataset.");
			}
			Assert.AreEqual(reader.HashingDatasets.hashtabelsleutelswaardes.Count, hashTable.Size());
		}

		[TestMethod]
		public void TestHashTableGet()
		{
			// Arrange
			var hashTable = new HashTable<string, List<int>>();

			// Act
			foreach (var entry in reader.HashingDatasets.hashtabelsleutelswaardes)
			{
				hashTable.Insert(entry.Key, entry.Value);
			}

			var keyToTest = reader.HashingDatasets.hashtabelsleutelswaardes.First().Key;
			var expectedValue = reader.HashingDatasets.hashtabelsleutelswaardes[keyToTest];
			var result = hashTable.Get(keyToTest);

			// Assert
			CollectionAssert.AreEqual(expectedValue, result, $"The value for key '{keyToTest}' should match the dataset.");
			Assert.ThrowsException<KeyNotFoundException>(() => hashTable.Get("nonExistingKey"));
		}

		[TestMethod]
		public void TestHashTableDelete()
		{
			// Arrange
			var hashTable = new HashTable<string, List<int>>();

			// Act
			foreach (var entry in reader.HashingDatasets.hashtabelsleutelswaardes)
			{
				hashTable.Insert(entry.Key, entry.Value);
			}

			var initialCount = hashTable.Size(); 
			var keyToDelete = reader.HashingDatasets.hashtabelsleutelswaardes.First().Key;
			hashTable.Delete(keyToDelete);

			// Assert
			Assert.AreEqual(initialCount - 1, hashTable.Size(), "The count should decrease by 1 after deletion.");

			foreach (var entry in reader.HashingDatasets.hashtabelsleutelswaardes.Where(e => e.Key != keyToDelete))
			{
				var result = hashTable.Get(entry.Key);
				CollectionAssert.AreEqual(entry.Value, result, $"The value for key '{entry.Key}' should remain unchanged.");
			}
		}

		[TestMethod]
		public void TestHashTableUpdate()
		{
			// Arrange
			var hashTable = new HashTable<string, List<int>>();

			// Act
			foreach (var entry in reader.HashingDatasets.hashtabelsleutelswaardes)
			{
				hashTable.Insert(entry.Key, entry.Value);
			}
			
			var newValue = new List<int> { 42 };
			hashTable.Update("a", newValue);
			var result = hashTable.Get("a");

			// Assert
			CollectionAssert.AreEqual(newValue, result);
		}



		[TestMethod]
		public void TestLinearProbing0()
		{
			// Arrange
			var hashTable = new HashTable<int, string>(4);

			// Act
			hashTable.Insert(4,"Pietersen");
			hashTable.Insert(8, "Jakobsen");
			hashTable.Insert(12, "Marinus");

			hashTable.Print();
			Console.WriteLine();

			// Assert
			Assert.AreEqual("Pietersen", hashTable.Get(4));
			Assert.AreEqual("Jakobsen", hashTable.Get(8));
			Assert.AreEqual("Marinus", hashTable.Get(12));
			Assert.AreEqual(3, hashTable.Size());
			hashTable.Print();
		}

		[TestMethod]
		public void TestLinearProbingResizingandRehashing()
		{
			// Arrange
			var hashTable = new HashTable<int, string>(4);

			// Act
			hashTable.Insert(4, "Pietersen");
			hashTable.Insert(8, "Jakobsen");
			hashTable.Insert(12, "Marinus");
			hashTable.Insert(16, "Jordanson");

			hashTable.Print();
			Console.WriteLine();

			// Assert
			Assert.AreEqual("Pietersen", hashTable.Get(4));
			Assert.AreEqual("Jakobsen", hashTable.Get(8));
			Assert.AreEqual("Marinus", hashTable.Get(12));
			Assert.AreEqual("Jordanson", hashTable.Get(16));
			Assert.AreEqual(4, hashTable.Size());
			hashTable.Print();
		}

		[TestMethod]
		public void TestLinearProbingAdd1()
		{
			// Arrange
			var hashTable = new HashTable<int, string>(4);

			// Act
			hashTable.Insert(4, "Pietersen");
			hashTable.Insert(8, "Jakobsen");
			hashTable.Insert(12, "Marinus");
			hashTable.Insert(16, "Jordanson");

			hashTable.Print();
			Console.WriteLine();

			// Assert
			Assert.AreEqual("Pietersen", hashTable.Get(4));
			Assert.AreEqual("Jakobsen", hashTable.Get(8));
			Assert.AreEqual("Marinus", hashTable.Get(12));
			Assert.AreEqual("Jordanson", hashTable.Get(16));
			Assert.AreEqual(4, hashTable.Size());

			hashTable.Insert(20, "Barendsen");
			hashTable.Print();
		}

		[TestMethod]
		public void TestLinearProbingAdd2()
		{
			// Arrange
			var hashTable = new HashTable<int, string>(4);

			// Act 
			hashTable.Insert(4, "Pietersen");
			hashTable.Insert(8, "Jakobsen");
			hashTable.Insert(12, "Marinus");
			hashTable.Insert(16, "Jordanson");
			hashTable.Insert(20, "Barendsen");

			hashTable.Print();
			Console.WriteLine();

			// Assert
			Assert.AreEqual("Pietersen", hashTable.Get(4));
			Assert.AreEqual("Jakobsen", hashTable.Get(8));
			Assert.AreEqual("Marinus", hashTable.Get(12));
			Assert.AreEqual("Jordanson", hashTable.Get(16));
			Assert.AreEqual("Barendsen", hashTable.Get(20));
			Assert.AreEqual(5, hashTable.Size());

			hashTable.Insert(32, "Barello");
			hashTable.Print();
		}

		[TestMethod]
		public void TestLinearProbingZeroCapacity()
		{
			// Arrange
			var hashTable = new HashTable<int, int>(0);

			// Act 
			hashTable.Insert(4, 10);
			hashTable.Insert(8, 11);
			hashTable.Insert(12, 12);

			hashTable.Print();
			Console.WriteLine();

			// Assert
			Assert.AreEqual(10, hashTable.Get(4));
			Assert.AreEqual(11, hashTable.Get(8));
			Assert.AreEqual(12, hashTable.Get(12));
			Assert.AreEqual(3, hashTable.Size());

			hashTable.Insert(32, 44);
			Assert.AreEqual(44, hashTable.Get(32));
			Assert.AreEqual(4, hashTable.Size());
			hashTable.Print();
		}


	}
}
