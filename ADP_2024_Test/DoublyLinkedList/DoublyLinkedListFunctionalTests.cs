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
		public void TestLijstAflopend2()
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

			// Check if a specific value exists in the list
			var contains = doublyLinkedList.Contains(5247);

			// Assert  Ensure the list is empty and Confirm the value is not present
			Assert.AreEqual(0, doublyLinkedList.Length); 
			Assert.IsFalse(contains);                   
		}

		[TestMethod]
		public void TestDoublyLinkedListWithLijstOnsorteerbaar3()
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<object>();

			// Act
			// Add elements from LijstOnsorteerbaar3 to the doubly linked list
			foreach (var value in reader.LijstOnsorteerbaar3)
			{
				doublyLinkedList.Add(value);
			}

			// Remove the string "string" from the list
			doublyLinkedList.Remove("string");

			// Check if the string "string" is still in the list
			var contains = doublyLinkedList.Contains("string");

			// Assert
			Assert.AreEqual(2, doublyLinkedList.Length); // Ensure the list has 2 items remaining
			Assert.IsFalse(contains);                   // Confirm the string is no longer present
		}
	}
}
