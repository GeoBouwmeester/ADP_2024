using ADP_2024.AVL_Tree;
using System.Diagnostics;

namespace ADP_2024_Test.AVLTree
{
	[TestClass]
	public sealed class AvlTreePerformanceTests
	{
		/*
        Execution time:
        |-----------------------------------|
        | N             | Time              |
        |-----------------------------------|
        | 10            | 00:00:00.0019179  |
        | 100           | 00:00:00.0032339  |
        | 1_000         | 00:00:00.0030523  |
        | 10_000        | 00:00:00.0182760  |
        | 100_000       | 00:00:00.1575143  |
        | 1_000_000     | 00:00:01.7699808  |
        |-----------------------------------|
        1. Best case: Input elements inserted in a perfectly balanced order, minimizing rebalancing.
        2. Time complexity O(log n), with minimal rotations required.
        */

		[TestMethod]
		[DataRow(10, 10)]
		[DataRow(100, 100)]
		[DataRow(1_000, 1_000)]
		[DataRow(10_000, 10_000)]
		[DataRow(100_000, 100_000)]
		[DataRow(1_000_000, 1_000_000)]
		public void TestAVLTreePerformanceBestCase(int amount, int expectedAmount)
		{
			// Arrange
			var tree = new AvlTree<int>();
			var numbers = new List<int>(amount);

			GenerateBalancedInsertionOrder(0, amount - 1, numbers);

			var watch = Stopwatch.StartNew();

			// Act
			foreach (var num in numbers)
			{
				tree.Insert(num);
			}

			// Assert
			watch.Stop();
			var elapsedMs = watch.Elapsed;
			Console.WriteLine(elapsedMs);
			Assert.IsTrue(tree.IsBalanced());
			Assert.AreEqual(expectedAmount, tree.GetTreeSize(tree.GetRoot()));
		}

		/*
        Execution time:
        |-----------------------------------|
        | N             | Time              |
        |-----------------------------------|
        | 10            | 00:00:00.0030393  |
        | 100           | 00:00:00.0000502  |
        | 1_000         | 00:00:00.0012132  |
        | 10_000        | 00:00:00.0178929  |
        | 100_000       | 00:00:00.1463299  |
        | 1_000_000     | 00:00:02.9230764  |
        |-----------------------------------|
        1. Normal case: Input elements are inserted in random order, simulating typical usage patterns.
        2. Time complexity O(log n).
        */

		[TestMethod]
		[DataRow(10, 10)]
		[DataRow(100, 100)]
		[DataRow(1_000, 1_000)]
		[DataRow(10_000, 10_000)]
		[DataRow(100_000, 100_000)]
		[DataRow(1_000_000, 1_000_000)]
		public void TestAVLTreePerformanceNormalCase(int amount, int expectedAmount)
		{
			// Arrange
			var tree = new AvlTree<int>();
			var random = new Random(42);
			var uniqueNumbers = new HashSet<int>();

			while (uniqueNumbers.Count < amount)
			{
				uniqueNumbers.Add(random.Next());
			}

			var numbers = uniqueNumbers.ToList();

			var watch = Stopwatch.StartNew();

			// Act 
			foreach (var num in numbers)
			{
				tree.Insert(num);
			}

			// Assert
			watch.Stop();
			var elapsedMs = watch.Elapsed;
			Console.WriteLine(elapsedMs);
			Assert.IsTrue(tree.IsBalanced());
			Assert.AreEqual(expectedAmount, tree.GetTreeSize(tree.GetRoot()));
		}

		/*
        Execution time:
        |-----------------------------------|
        | N             | Time              |
        |-----------------------------------|
        | 10            | 00:00:00.0211587  |
        | 100           | 00:00:00.0010331  |
        | 1_000         | 00:00:00.0255405  |
        | 10_000        | 00:00:00.0244550  |
        | 100_000       | 00:00:00.1398396  |
        | 1_000_000     | 00:00:01.7518563  |
        |-----------------------------------|
        1. Worst-case scenario with ascending order inserts causes maximum rotations.
        2. Time complexity O(log n).
        */

		[TestMethod]
		[DataRow(10, 10)]
		[DataRow(100, 100)]
		[DataRow(1_000, 1_000)]
		[DataRow(10_000, 10_000)]
		[DataRow(100_000, 100_000)]
		[DataRow(1_000_000, 1_000_000)]
		public void TestAVLTreePerformanceWorstCase(int amount, int expectedAmount)
		{
			// Arrange
			var tree = new AvlTree<int>();
			var watch = Stopwatch.StartNew();

			// Act 
			for (int i = 0; i < amount; i++)
			{
				tree.Insert(i);
			}

			// Assert
			watch.Stop();
			var elapsedMs = watch.Elapsed;
			Console.WriteLine(elapsedMs);
			Assert.IsTrue(tree.IsBalanced());
			Assert.AreEqual(expectedAmount, tree.GetTreeSize(tree.GetRoot()));
		}

		/*
        Execution time:
        |-----------------------------------|
        | N             | Time              |
        |-----------------------------------|
        | 10            | 00:00:00.0029820  |
        | 100           | 00:00:00.0027336  |
        | 1_000         | 00:00:00.0029175  |
        | 10_000        | 00:00:00.0242051  |
        | 100_000       | 00:00:00.1393566  |
        | 1_000_000     | 00:00:01.7613433  |
        |-----------------------------------|
        1. Observed performance aligns with O(log n) insertion complexity.
        */

		[TestMethod]
		[DataRow(10, 10)]
		[DataRow(100, 100)]
		[DataRow(1_000, 1_000)]
		[DataRow(10_000, 10_000)]
		[DataRow(100_000, 100_000)]
		[DataRow(1_000_000, 1_000_000)]
		public void TestInsertTimeComplexityForAVLTree(int amount, int expectedAmount)
		{
			// Arrange
			var avlTree = new AvlTree<int>();
			var watch = Stopwatch.StartNew();

			// Act 
			for (var i = 0; i < amount; i++)
			{
				avlTree.Insert(i);
			}

			// Assert
			watch.Stop();
			var elapsed = watch.Elapsed;
			Console.WriteLine($"Time taken to insert {amount} elements into AVL Tree: {elapsed}");

			Assert.AreEqual(expectedAmount, avlTree.GetTreeSize(avlTree.GetRoot()));
			Assert.IsTrue(avlTree.IsBalanced());
		}

		/*
        Execution time:
        |-----------------------------------|
        | N             | Time              |
        |-----------------------------------|
        | 10            | 00:00:00.0004159  |
        | 100           | 00:00:00.0004875  |
        | 1_000         | 00:00:00.0008074  |
        | 10_000        | 00:00:00.0066966  |
        | 100_000       | 00:00:00.1010759  |
        | 1_000_000     | 00:00:01.0697478  |
        |-----------------------------------|
        1. The removal operation shows O(n log n) time complexity
        2. This is because we're performing n remove operations, each taking O(log n) time
        3. The significant increase in time with larger inputs reflects the combined complexity 
           of multiple remove operations and subsequent tree rebalancing.
        */

		[TestMethod]
		[DataRow(10)]
		[DataRow(100)]
		[DataRow(1_000)]
		[DataRow(10_000)]
		[DataRow(100_000)]
		[DataRow(1_000_000)]
		public void TestRemoveTimeComplexityForAVLTree(int amount)
		{
			// Arrange
			var avlTree = new AvlTree<int>();

			for (int i = 0; i < amount; i++)
			{
				avlTree.Insert(i);
			}

			var watch = Stopwatch.StartNew();

			// Act 
			for (int i = 0; i < amount; i++)
			{
				avlTree.Remove(i);
			}

			// Assert
			watch.Stop();
			var elapsed = watch.Elapsed;
			Console.WriteLine($"Time taken to remove {amount} elements from AVL Tree: {elapsed}");
			Assert.AreEqual(0, avlTree.GetTreeSize(avlTree.GetRoot()));
			Assert.IsTrue(avlTree.IsBalanced());
		}

		/*
        Execution time:
        |-----------------------------------|
        | N             | Time              |
        |-----------------------------------|
        | 10            | 00:00:00.0000003  |
        | 100           | 00:00:00.0000018  |
        | 1_000         | 00:00:00.0000007  |
        | 10_000        | 00:00:00.0000010  |
        | 100_000       | 00:00:00.0000030  |
        | 1_000_000     | 00:00:00.0000083  |
        |-----------------------------------|
        1. Find operation demonstrates fast performance O(1).
        2. AVL Tree's height-balanced structure optimizes lookup for all N values. 
        */

		[TestMethod]
		[DataRow(10, 7)]
		[DataRow(100, 56)]
		[DataRow(1_000, 636)]
		[DataRow(10_000, 7_945)]
		[DataRow(100_000, 66_666)]
		[DataRow(1_000_000, 123_456)]
		public void TestFindTimeComplexityForAVLTree(int amount, int findValue)
		{
			// Arrange
			var avlTree = new AvlTree<int>();

			// Act 
			for (int i = 0; i < amount; i++)
			{
				avlTree.Insert(i);
			}

			var watch = Stopwatch.StartNew();

			var result = avlTree.Find(findValue);

			// Assert
			watch.Stop();
			var elapsed = watch.Elapsed;
			Console.WriteLine($"Time taken to find {findValue} in AVL Tree with {amount} elements: {elapsed}");

			Assert.IsNotNull(result);
			Assert.AreEqual(findValue, result.Key);
			Assert.IsTrue(avlTree.IsBalanced());
		}

		/*
        Execution time:
        |-----------------------------------|
        | N             | Time              |
        |-----------------------------------|
        | 10            | 00:00:00.0000001  |
        | 100           | 00:00:00.0000003  |
        | 1_000         | 00:00:00.0000004  |
        | 10_000        | 00:00:00.0000004  |
        | 100_000       | 00:00:00.0000006  |
        | 1_000_000     | 00:00:00.0000011  |
        |-----------------------------------|
        1. The time complexity is O(log n).
        2. The minimal increase in time even with large input sizes confirms the logarithmic complexity
        */

		[TestMethod]
		[DataRow(10, 10)]
		[DataRow(100, 100)]
		[DataRow(1_000, 1_000)]
		[DataRow(10_000, 10_000)]
		[DataRow(100_000, 100_000)]
		[DataRow(1_000_000, 1_000_000)]
		public void TestFindMaxTimeComplexityForAVLTree(int amount, int expectedAmount)
		{
			// Arrange
			var avlTree = new AvlTree<int>();

			for (int i = 0; i < amount; i++)
			{
				avlTree.Insert(i);
			}

			var watch = Stopwatch.StartNew();

			// Act 
			var max = avlTree.FindMax();

			// Assert
			watch.Stop();
			var elapsed = watch.Elapsed;
			Console.WriteLine($"Time taken to find max in AVL Tree with {amount} elements: {elapsed}");

			Assert.AreEqual(amount - 1, max);
			Assert.AreEqual(expectedAmount, avlTree.GetTreeSize(avlTree.GetRoot()));
			Assert.IsTrue(avlTree.IsBalanced());
		}

		/*
        Execution time:
        |-----------------------------------|
        | N             | Time              |
        |-----------------------------------|
        | 10            | 00:00:00.0000001  |
        | 100           | 00:00:00.0000002  |
        | 1_000         | 00:00:00.0000004  |
        | 10_000        | 00:00:00.0000017  |
        | 100_000       | 00:00:00.0000041  |
        | 1_000_000     | 00:00:00.0000051  |
        |-----------------------------------|
        1. The operation shows O(log n) time complexity.
        2. Similar to FindMax, the execution time grows very slowly with input size, demonstrating efficient tree traversal
        */

		[TestMethod]
		[DataRow(10, 10)]
		[DataRow(100, 100)]
		[DataRow(1_000, 1_000)]
		[DataRow(10_000, 10_000)]
		[DataRow(100_000, 100_000)]
		[DataRow(1_000_000, 1_000_000)]
		public void TestFindMinTimeComplexityForAVLTree(int amount, int expectedAmount)
		{
			// Arrange
			var avlTree = new AvlTree<int>();

			for (int i = 0; i < amount; i++)
			{
				avlTree.Insert(i);
			}

			var watch = Stopwatch.StartNew();

			// Act 
			var min = avlTree.FindMin();

			// Assert
			watch.Stop();
			var elapsed = watch.Elapsed;
			Console.WriteLine($"Time taken to find min in AVL Tree with {amount} elements: {elapsed}");

			Assert.AreEqual(0, min);
			Assert.AreEqual(expectedAmount, avlTree.GetTreeSize(avlTree.GetRoot()));
			Assert.IsTrue(avlTree.IsBalanced());
		}


		private void GenerateBalancedInsertionOrder(int start, int end, List<int> result)
		{
			if (start > end) return;

			int mid = (start + end) / 2;
			result.Add(mid);

			GenerateBalancedInsertionOrder(start, mid - 1, result);
			GenerateBalancedInsertionOrder(mid + 1, end, result);
		}
	}
}

