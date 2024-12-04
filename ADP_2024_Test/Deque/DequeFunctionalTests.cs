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
        public void TestLijstOnsorteerbaar3()
        {
            // Arrange
            var deque = new Deque<object>();

            // Act
            foreach (var value in reader.LijstOnsorteerbaar3) 
            {
                deque.InsertLeft(value);
            }

            deque.DeleteLeft();

            // Assert
            Assert.AreEqual(2, deque.Size());
            Assert.AreEqual(1.0, deque.DeleteLeft());
        }
    }
}