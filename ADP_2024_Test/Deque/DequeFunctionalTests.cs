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
        public void TestInsertLeftLijstAflopend2()
        {
            // Arrange
            var deque = new Deque<int>();

            // Act
            foreach (var value in reader.LijstAflopend2)
            {
                deque.InsertLeft(value);
            }

            // Assert
            Assert.AreEqual(reader.LijstAflopend2.Length, deque.Size());
        }

        [TestMethod]
        public void TestInsertRightLijstOplopend10000()
        {
            // Arrange
            var deque = new Deque<int>();

            // Act
            foreach (var value in reader.LijstOplopend10000)
            {
                deque.InsertRight(value);
            }

            // Assert
            Assert.AreEqual(reader.LijstOplopend10000.Length, deque.Size());
            Assert.AreEqual(reader.LijstOplopend10000.Last(), deque.DeleteRight());
        }

        [TestMethod]
        public void TestDeleteLeftLijstWillekeurig10000()
        {
            // Arrange
            var deque = new Deque<int>();

            // Act
            foreach (var value in reader.LijstWillekeurig10000)
            {
                deque.InsertLeft(value);  
            }

            var deletedValue = deque.DeleteLeft();  

            // Assert
            Assert.AreEqual(reader.LijstWillekeurig10000.Last(), deletedValue);  
            Assert.AreEqual(reader.LijstWillekeurig10000.Length - 1, deque.Size()); 
        }

		[TestMethod]
		public void TestLijstOplopend3()
		{
			// Arrange
			var deque = new Deque<int>();

			// Act
			foreach (var value in reader.LijstGesorteerdOplopend3)
			{
				deque.InsertLeft(value);
			}

			var newValue = 556;
			var extraValue = 123;

			deque.InsertLeft(newValue);
			deque.InsertRight(extraValue);

			// Assert
			Assert.AreEqual(5, deque.Size());
		}

		[TestMethod]
        public void TestDeleteRightLijstWillekeurig3()
        {
            // Arrange
            var deque = new Deque<int>();

            // Act
            foreach (var value in reader.LijstWillekeurig3)
            {
                deque.InsertRight(value);
            }

            var deletedValue = deque.DeleteRight();

            // Assert
            Assert.AreEqual(reader.LijstWillekeurig3.Last(), deletedValue);
            Assert.AreEqual(reader.LijstWillekeurig3.Length - 1, deque.Size());
        }

        [TestMethod]
        public void TestSizeLijstAflopend2()
        {
            // Arrange
            var deque = new Deque<float>();

            // Act
            foreach (var value in reader.LijstFloat8001) 
            {
                deque.InsertLeft(value);
            }

            // Assert
            Assert.AreEqual(reader.LijstFloat8001.Length, deque.Size()); 
        }

        [TestMethod]
        public void TestLijstOnsorteerbaar3()
        {
            // Arrange
            var deque = new Deque<object>();

            // Act
            foreach (var value in reader.LijstOnsorteerbaar3) 
            {
                deque.InsertLeft(value);
            }

            deque.DeleteRight();

            // Assert
            Assert.AreEqual(2, deque.Size());
        }

		[TestMethod]
		public void TestLijstOplopend2()
		{
			// Arrange
			var deque = new Deque<object>();

			// Act
			foreach (var value in reader.LijstOplopend2)
			{
				deque.InsertLeft(value);
			}

			deque.DeleteRight();

			// Assert
			Assert.AreEqual(1, deque.Size());
		}

		[TestMethod]
		public void TestLijstNull1()
		{
			// Arrange
			var deque = new Deque<int>();

			// Act
			foreach (var value in reader.LijstNull1)
			{
				if (value != null) deque.InsertLeft((int)value);
			}

			var valueInserting = 1213;

			deque.InsertRight(valueInserting);

			// Assert
			Assert.AreEqual(1, deque.Size());
		}

		[TestMethod]
		public void TestLijstNull3()
		{
			// Arrange
			var deque = new Deque<int>();

			// Act
			foreach (var value in reader.LijstNull3)
			{
				if (value != null) deque.InsertLeft((int)value);
			}

			var valueInserting = 443;

			deque.InsertRight(valueInserting);
			deque.DeleteLeft();

			// Assert
			Assert.AreEqual(2, deque.Size());
		}

		[TestMethod]
		public void TestLijstAflopend3()
		{
			// Arrange
			var deque = new Deque<int>();

			// Act
			foreach (var value in reader.LijstGesorteerdAflopend3)
			{
				deque.InsertLeft(value);
			}

			var newValue = 12;

			deque.InsertRight(newValue);

			// Assert
			Assert.AreEqual(4, deque.Size());
		}

		[TestMethod]
		public void TestLijstHerhaald1000()
		{
			// Arrange
			var deque = new Deque<int>();

			// Act
			foreach (var value in reader.LijstHerhaald1000)
			{
				deque.InsertLeft(value);
			}

			var newValue = 556;
			var extraValue = 556;

			deque.InsertLeft(newValue);
			deque.InsertRight(extraValue);

			// Assert
			Assert.AreEqual(10002, deque.Size());
		}

		[TestMethod]
		public void TestLijstLeeg0()
		{
			// Arrange
			var deque = new Deque<int>();

			// Act
			foreach (var value in reader.LijstLeeg0)
			{
				deque.InsertLeft((int)value);
			}

			var newValue = 1;

			deque.InsertRight(newValue);

			// Assert
			Assert.AreEqual(1, deque.Size());
		}

		[TestMethod]
		public void TestLijstPizza()
		{
			// Arrange
			var deque = new Deque<Pizza>();

			// Act
			foreach (var value in reader.LijstPizza6)
			{
				deque.InsertLeft(value);
			}

			var newPizza = new Pizza("Pepperoni", 8);

			deque.InsertRight(newPizza);

			// Assert
			Assert.AreEqual(7, deque.Size());
		}
	}
}