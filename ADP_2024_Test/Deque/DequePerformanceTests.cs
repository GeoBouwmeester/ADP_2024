using ADP_2024;
using ADP_2024.Deque;
using System.Diagnostics;

namespace ADP_2024_Test.Deque
{
	[TestClass]
	public sealed class DequePerformanceTests
	{
        public required DatasetReader reader;

        [TestInitialize]
        public void SetUp()
        {
            reader = new DatasetReader();
        }


        /*
        Execution time:
        |-------------------------------|
        | N         | Time              |
        |-------------------------------|
        | 10        | 00:00:00.0006728  |
        | 100       | 00:00:00.0003050  |
        | 1000      | 00:00:00.0003378  |
        | 10_000    | 00:00:00.0003149  |
        | 100_000   | 00:00:00.0143527  |
        | 1_000_000 | 00:00:00.1417488  |
        |-------------------------------|
        */

        [TestMethod]
        [DataRow(10, 10)]
        [DataRow(100, 100)]
        [DataRow(1000, 1000)]
        [DataRow(10_000, 10_000)]
        [DataRow(100_000, 100_000)]
        [DataRow(1_000_000, 1_000_000)]
        public void TestInsertLeftTimeComplexityForDeque(int amount, int expectedAmount)
        {
            // Arrange
            var deque = new Deque<int>();

            var watch = Stopwatch.StartNew();

            // Act
            for (var i = 0; i < amount; i++)
            {
                deque.InsertLeft(i);
            }

            // Assert
            watch.Stop();
            var elapsed = watch.Elapsed;
            Console.WriteLine($"Time taken to insert {amount} elements at the left: {elapsed}");

            Assert.AreEqual(expectedAmount, deque.Size());
        }



        /*
        Execution time:
        |-------------------------------|
        | N         | Time              |
        |-------------------------------|
        | 10        | 00:00:00.0000012  |
        | 100       | 00:00:00.0000092  |
        | 1000      | 00:00:00.0000564  |   
        | 10_000    | 00:00:00.0004308  |
        | 100_000   | 00:00:00.0123541  |
        | 1_000_000 | 00:00:00.1250873  |
        |-------------------------------|
        */

        [TestMethod]
        [DataRow(10, 10)]
        [DataRow(100, 100)]
        [DataRow(1000, 1000)]
        [DataRow(10_000, 10_000)]
        [DataRow(100_000, 100_000)]
        [DataRow(1_000_000, 1_000_000)]
        public void TestInsertRightTimeComplexityForDeque(int amount, int expectedAmount)
        {
            // Arrange
            var deque = new Deque<int>();

            var watch = Stopwatch.StartNew();

            // Act
            for (var i = 0; i < amount; i++)
            {
                deque.InsertRight(i);
            }

            // Assert
            watch.Stop();
            var elapsed = watch.Elapsed;
            Console.WriteLine($"Time taken to insert {amount} elements at the right: {elapsed}");

            Assert.AreEqual(expectedAmount, deque.Size());
        }


        /*
        Execution time:
        |-------------------------------|
        | N         | Time              |
        |-------------------------------|
        | 10        | 00:00:00.0000006  |
        | 100       | 00:00:00.0000012  |
        | 1000      | 00:00:00.0003102  |   
        | 10_000    | 00:00:00.0000849  |
        | 100_000   | 00:00:00.0010662  |
        | 1_000_000 | 00:00:00.0136602  |
        |-------------------------------|
        */

        [TestMethod]
        [DataRow(10, 10)]
        [DataRow(100, 100)]
        [DataRow(1000, 1000)]
        [DataRow(10_000, 10_000)]
        [DataRow(100_000, 100_000)]
        [DataRow(1_000_000, 1_000_000)]
        public void TestDeleteLeftTimeComplexityForDeque(int amount, int expectedAmount)
        {
            // Arrange
            var deque = new Deque<int>();

            for (var i = 0; i < amount; i++)
            {
                deque.InsertRight(i);
            }

            var watch = Stopwatch.StartNew();

            // Act
            for (var i = 0; i < amount; i++)
            {
                deque.DeleteLeft();
            }

            // Assert
            watch.Stop();
            var elapsed = watch.Elapsed;
            Console.WriteLine($"Time taken to delete {amount} elements from the left: {elapsed}");

            Assert.AreEqual(0, deque.Size());
        }


        /*
        Execution time:
        |-------------------------------|
        | N         | Time              |
        |-------------------------------|
        | 10        | 00:00:00.0000007  |
        | 100       | 00:00:00.0000017  |
        | 1000      | 00:00:00.0003071  |   
        | 10_000    | 00:00:00.0003812  |
        | 100_000   | 00:00:00.0012874  |
        | 1_000_000 | 00:00:00.0151024  |
        |-------------------------------|
        */

        [TestMethod]
        [DataRow(10, 10)]
        [DataRow(100, 100)]
        [DataRow(1000, 1000)]
        [DataRow(10_000, 10_000)]
        [DataRow(100_000, 100_000)]
        [DataRow(1_000_000, 1_000_000)]
        public void TestDeleteRightTimeComplexityForDeque(int amount, int expectedAmount)
        {
            // Arrange
            var deque = new Deque<int>();

            for (var i = 0; i < amount; i++)
            {
                deque.InsertLeft(i);
            }

            var watch = Stopwatch.StartNew();

            // Act
            for (var i = 0; i < amount; i++)
            {
                deque.DeleteRight();
            }

            // Assert
            watch.Stop();
            var elapsed = watch.Elapsed;
            Console.WriteLine($"Time taken to delete {amount} elements from the right: {elapsed}");

            Assert.AreEqual(0, deque.Size());
        }
    }
}
