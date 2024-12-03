using ADP_2024;
using ADP_2024.Deque;
using ADP_2024.Models;

namespace ADP_2024_Test.Deque
{
	[TestClass]
	public sealed class DequeFunctionalTests
	{
		public required DatasetReader reader;

		[TestInitialize]
		public void SetUp()
		{
			reader = new DatasetReader();
		}

		[TestMethod]
		public void TestInsertLeftWithLijstAflopend2()
		{
			// Arrange
			var deque = new Deque<int>();
			var expectedOrder = new Stack<int>();

			// Act
			foreach (var value in reader.LijstAflopend2)
			{
				deque.InsertLeft(value);
				expectedOrder.Push(value);
			}

			// Assert
			foreach (var expectedValue in expectedOrder)
			{
				Assert.AreEqual(expectedValue, deque.DeleteLeft());
			}
			Assert.AreEqual(0, deque.Size());
		}

		[TestMethod]
		public void TestInsertRightWithLijstOplopend10000()
		{
			// Arrange
			var deque = new Deque<int>();
			var expectedOrder = new Queue<int>();

			// Act
			foreach (var value in reader.LijstOplopend10000)
			{
				deque.InsertRight(value);
				expectedOrder.Enqueue(value);
			}

			// Assert
			foreach (var expectedValue in expectedOrder)
			{
				Assert.AreEqual(expectedValue, deque.DeleteLeft());
			}
			Assert.AreEqual(0, deque.Size());
		}

		[TestMethod]
		public void TestDeleteLeftWithLijstOnsorteerbaar3()
		{
			// Arrange
			var deque = new Deque<object>();

			foreach (var value in reader.LijstOnsorteerbaar3)
			{
				deque.InsertRight(value);
			}

			// Act & Assert
			foreach (var value in reader.LijstOnsorteerbaar3)
			{
				Assert.AreEqual(value, deque.DeleteLeft());
			}

			Assert.AreEqual(0, deque.Size());
		}

		[TestMethod]
		public void TestDeleteRightWithLijstAflopend2()
		{
			// Arrange
			var deque = new Deque<int>();
			var expectedOrder = new Stack<int>();

			foreach (var value in reader.LijstAflopend2)
			{
				deque.InsertLeft(value);
				expectedOrder.Push(value);
			}

			// Act & Assert
			foreach (var expectedValue in expectedOrder)
			{
				Assert.AreEqual(expectedValue, deque.DeleteRight());
			}

			Assert.AreEqual(0, deque.Size());
		}

		[TestMethod]
		public void TestLargeDatasetStressWithLijstOplopend10000()
		{
			// Arrange
			var deque = new Deque<int>();

			// Act
			foreach (var value in reader.LijstOplopend10000)
			{
				deque.InsertRight(value);
			}

			while (deque.Size() > 0)
			{
				deque.DeleteLeft();
			}

			// Assert
			Assert.AreEqual(0, deque.Size());
		}

		[TestMethod]
		public void TestMixedOperationsWithLijstOnsorteerbaar3()
		{
			// Arrange
			var deque = new Deque<object>();

			// Act
			foreach (var value in reader.LijstOnsorteerbaar3)
			{
				deque.InsertRight(value);
			}

			deque.InsertLeft("newStart");
			deque.InsertRight("newEnd");

			var removedFirst = deque.DeleteLeft();
			var removedLast = deque.DeleteRight();

			// Assert
			Assert.AreEqual("newStart", removedFirst);
			Assert.AreEqual("newEnd", removedLast);
			Assert.AreEqual(reader.LijstOnsorteerbaar3.Length, deque.Size());
		}

		[TestMethod]
		public void TestEdgeCaseWithLijstAflopend2()
		{
			// Arrange
			var deque = new Deque<int>();

			// Act
			foreach (var value in reader.LijstAflopend2)
			{
				deque.InsertRight(value);
			}

			// Clear the deque
			while (deque.Size() > 0)
			{
				deque.DeleteRight();
			}

			// Assert
			Assert.AreEqual(0, deque.Size());
			Assert.ThrowsException<InvalidOperationException>(() => deque.DeleteLeft());
		}
	}
}