using ADP_2024;
using ADP_2024.DoublyLinkedList;
using ADP_2024.Models;

namespace ADP_2024_Test.DoublyLinkedList
{
	[TestClass]
	public sealed class DoublyLinkedListFunctionalTests
	{
		public required DatasetReader reader;

		[TestInitialize]
		public void SetUp()
		{
			reader = new DatasetReader();
		}

		[TestMethod]
		public void TestAddLijstAflopend2()
		{
			//Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();

			//Act
			foreach (var value in reader.LijstAflopend2)
			{
				doublyLinkedList.Add(value);
			}
			var contains = doublyLinkedList.Contains(1);

			//Assert
			Assert.AreEqual(2, doublyLinkedList.Length);
			Assert.IsTrue(contains);
		}

		[TestMethod]
		public void TestDoublyLinkedListWithLijstOplopend10000()
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();

			// Act
			// Add elements from LijstOplopend10000 to the doubly linked list
			foreach (var value in reader.LijstOplopend10000)
			{
				doublyLinkedList.Add(value);
			}

			// Remove all elements from the doubly linked list
			for (int i = 0; i < reader.LijstOplopend10000.Length; i++)
			{
				doublyLinkedList.Remove(reader.LijstOplopend10000[i]);
			}
			var contains = doublyLinkedList.Contains(5247);

			// Assert 
			Assert.AreEqual(0, doublyLinkedList.Length); 
			Assert.IsFalse(contains);                   
		}

		[TestMethod]
		public void TestDoublyLinkedListWithLijstOnsorteerbaar3()
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<object>();

			// Act
			foreach (var value in reader.LijstOnsorteerbaar3)
			{
				doublyLinkedList.Add(value);
			}

			doublyLinkedList.Remove("string");

			var contains = doublyLinkedList.Contains("string");

			 Assert
			Assert.AreEqual(2, doublyLinkedList.Length); 
			Assert.IsFalse(contains);                   
		}

		// Test for Get method (by index)
		[TestMethod]
		public void TestGet()
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();
			foreach (var value in reader.LijstAflopend2)
			{
				doublyLinkedList.Add(value);
			}

			// Act & Assert
			Assert.AreEqual(-10033224, doublyLinkedList.Get(1));  // Get the second element
			Assert.ThrowsException<IndexOutOfRangeException>(() => doublyLinkedList.Get(-1)); // Invalid index
			Assert.ThrowsException<IndexOutOfRangeException>(() => doublyLinkedList.Get(doublyLinkedList.Length)); // Invalid index
		}

		// Test for Set method
		[TestMethod]
		public void TestSet()
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();
			foreach (var value in reader.LijstAflopend2)
			{
				doublyLinkedList.Add(value);
			}

			// Act
			doublyLinkedList.Set(1, 10);  // Set new value at index 1

			// Assert
			Assert.AreEqual(10, doublyLinkedList.Get(1));  // Check if value was set correctly
			Assert.ThrowsException<IndexOutOfRangeException>(() => doublyLinkedList.Set(-1, 10));  // Invalid index
			Assert.ThrowsException<IndexOutOfRangeException>(() => doublyLinkedList.Set(doublyLinkedList.Length, 10));  // Invalid index
		}

		[TestMethod]
		public void TestRemove()
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();

			// Add values from 1 to 10000 to the doubly linked list
			for (int i = 1; i <= 10000; i++)
			{
				doublyLinkedList.Add(i);
			}

			// Act: Remove the first element (value 1)
			var removed = doublyLinkedList.Remove(1);

			// Assert: Ensure that the value was removed
			Assert.IsTrue(removed);
			Assert.AreEqual(9999, doublyLinkedList.Length);  

			var exists = doublyLinkedList.Contains(99);
			Assert.IsTrue(exists);
		}
		
		// Test for Contains method
		[TestMethod]
		public void TestContains()
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();
			foreach (var value in reader.LijstAflopend2)
			{
				doublyLinkedList.Add(value);
			}

			// Act & Assert
			Assert.IsTrue(doublyLinkedList.Contains(1)); 
			Assert.IsFalse(doublyLinkedList.Contains(99)); 
		}

		// Test for Find method
		[TestMethod]
		public void TestFind()
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();
			foreach (var value in reader.LijstAflopend2)
			{
				doublyLinkedList.Add(value);
			}

			// Act
			var foundNode = doublyLinkedList.Find(1); 
			var notFoundNode = doublyLinkedList.Find(99);  

			// Assert
			Assert.IsNotNull(foundNode);
			Assert.AreEqual(1, foundNode.Data);
			Assert.IsNull(notFoundNode);
		}

		[TestMethod]
		public void TestLijstPizza()
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<Pizza>();

			foreach (var value in reader.LijstPizza6) 
			{
				doublyLinkedList.Add(value);
			}

			// Add a new pizza object to the list
			var newPizza = new Pizza("Pepperoni", 6);
			doublyLinkedList.Add(newPizza);

			// Act
			var contains = doublyLinkedList.Contains(newPizza);
			var indexOf = doublyLinkedList.IndexOf(newPizza); 
			var first = doublyLinkedList.Get(indexOf); 

			// Assert
			Assert.AreEqual(7, doublyLinkedList.Length); 
			Assert.IsTrue(contains);
			Assert.AreEqual(6, indexOf); 
			Assert.AreEqual(newPizza, first); 
		}

		[TestMethod]
		public void TestIndexOf()
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();
			foreach (var value in reader.LijstOplopend10000)
			{
				doublyLinkedList.Add(value);
			}

			// Act
			int index450 = doublyLinkedList.IndexOf(450); 
			int index99999 = doublyLinkedList.IndexOf(99999); 

			// Assert
			Assert.AreEqual(449, index450); 
			Assert.AreEqual(-1, index99999);
		}

	}
}
