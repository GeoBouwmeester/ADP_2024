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
			foreach (var value in reader.LijstOplopend10000)
			{
				doublyLinkedList.Add(value);
			}

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
		public void TestGetLijstFloat8001()
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<float>();

			// Act
			foreach (var value in reader.LijstFloat8001)
			{
				doublyLinkedList.Add(value);
			}

			var newValue = 121.34F;

			doublyLinkedList.Add(newValue);

			// Assert
			Assert.AreEqual(8002, doublyLinkedList.Length);
			Assert.AreEqual(-0.0, doublyLinkedList.Get(0));
			Assert.ThrowsException<IndexOutOfRangeException>(() => doublyLinkedList.Get(-1));
			Assert.ThrowsException<IndexOutOfRangeException>(() => doublyLinkedList.Get(doublyLinkedList.Length));
		}

		[TestMethod]
		public void TestSet()
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();
			foreach (var value in reader.LijstHerhaald1000)
			{
				doublyLinkedList.Add(value);
			}

			// Act
			doublyLinkedList.Set(500, 42); 

			// Assert
			Assert.AreEqual(42, doublyLinkedList.Get(500)); 
			Assert.AreEqual(1, doublyLinkedList.Get(499)); 
			Assert.AreEqual(1, doublyLinkedList.Get(501)); 


			Assert.ThrowsException<IndexOutOfRangeException>(() => doublyLinkedList.Set(-1, 10));
		}

		[TestMethod]
		public void TestRemove()
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();


			foreach (var value in reader.LijstWillekeurig3) 
			{
				doublyLinkedList.Add(value);
			}

			// Act: 
			var removed = doublyLinkedList.Remove(1);

			// Assert: 
			Assert.IsTrue(removed);
			Assert.AreEqual(2, doublyLinkedList.Length);

			var exists = doublyLinkedList.Contains(3);
			Assert.IsTrue(exists);

			exists = doublyLinkedList.Contains(2);
			Assert.IsTrue(exists);
		}

		[TestMethod]
		public void TestContains()
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();
			foreach (var value in reader.LijstWillekeurig10000)
			{
				doublyLinkedList.Add(value);
			}

			// Act
			Assert.IsTrue(doublyLinkedList.Contains(4138));
		}

		[TestMethod]
		public void TestFind()
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();
			foreach (var value in reader.LijstGesorteerdOplopend3)
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

			// Act
			foreach (var value in reader.LijstPizza6)
			{
				doublyLinkedList.Add(value);
			}

			var newPizza = new Pizza("Mushroom", 8);

			doublyLinkedList.Add(newPizza);

			var contains = doublyLinkedList.Contains(newPizza);
			var index = doublyLinkedList.IndexOf(newPizza);
			var first = doublyLinkedList.Get(index);

			// Assert
			Assert.AreEqual(7, doublyLinkedList.Length);
			Assert.IsTrue(contains);
			Assert.AreEqual(6, index);
			Assert.AreEqual(newPizza, first);
		}

		[TestMethod]
		public void TestIndexOf()
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();
			foreach (var value in reader.LijstGesorteerdAflopend3)
			{
				doublyLinkedList.Add(value);
			}

			// Act
			int index3 = doublyLinkedList.IndexOf(3);
			int index1 = doublyLinkedList.IndexOf(1);

			// Assert
			Assert.AreEqual(0, index3);
			Assert.AreEqual(2, index1);
		}

		[TestMethod]
		public void TestLijstLeeg0()
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();

			// Act
			foreach (var value in reader.LijstLeeg0)
			{
				doublyLinkedList.Add((int)value);
			}

			var newValue = 10;

			doublyLinkedList.Add(newValue);


			// Assert
			Assert.AreEqual(1, doublyLinkedList.Length);
		}

		[TestMethod]
		public void TestLijstNull1()
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();

			// Act
			foreach (var value in reader.LijstNull1)
			{
				if (value != null) doublyLinkedList.Add((int)value);
			}

			var newValue = 10123;

			doublyLinkedList.Add(newValue);


			// Assert
			Assert.AreEqual(1, doublyLinkedList.Length);
		}

		[TestMethod]
		public void TestLijstNull3()
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();

			// Act
			foreach (var value in reader.LijstNull3)
			{
				if (value != null) doublyLinkedList.Add((int)value);
			}

			var newValue = 11233;

			doublyLinkedList.Add(newValue);


			// Assert
			Assert.AreEqual(3, doublyLinkedList.Length);
			Assert.AreEqual(1, doublyLinkedList.Get(0));
		}

		[TestMethod]
		public void TestLijstOnsorteerbaar3()
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();

			// Act
			foreach (var value in reader.LijstOnsorteerbaar3)
			{
				if (value.GetType() != typeof(Int64)) continue;

				doublyLinkedList.Add((int)(long)value);
			}

			var extravalue = 10;
			doublyLinkedList.Add(extravalue);

			// Assert
			Assert.AreEqual(2, doublyLinkedList.Length);
		}

	}
}
