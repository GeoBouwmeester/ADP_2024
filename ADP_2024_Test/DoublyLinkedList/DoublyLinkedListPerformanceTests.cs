using ADP_2024;
using ADP_2024.DoublyLinkedList;
using System.Diagnostics;

namespace ADP_2024_Test.DoublyLinkedList
{
	[TestClass]
	public sealed class DoublyLinkedListPerformanceTests
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
		| 10        | 00:00:00.0004567  |
		| 100       | 00:00:00.0004446  |
		| 1000      | 00:00:00.0000580  |
		| 10_000    | 00:00:00.0006445  |
		| 100_000   | 00:00:00.0398052  |
		| 1_000_000 | 00:00:00.2072315  |
		|-------------------------------|
		Comments on performance:
		1. Time Complexity: 
			- The `Add()` operation for a doubly linked list is O(1) in average and worst cases because the new node is appended to the end.
		2. Advantages:
			- There is no need for expensive resizing or shifting operations when adding elements to the end.
		*/
		[TestMethod]
		[DataRow(10, 10)]
		[DataRow(100, 100)]
		[DataRow(1000, 1000)]
		[DataRow(10_000, 10_000)]
		[DataRow(100_000, 100_000)]
		[DataRow(1_000_000, 1_000_000)]
		public void TestAddTimeComplexityForDoublyLinkedList(int amount, int expectedAmount)
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();
			var watch = Stopwatch.StartNew();

			// Act
			for (var i = 0; i < amount; i++)
			{
				doublyLinkedList.Add(i);
			}

			// Assert
			watch.Stop();

			var elapsed = watch.Elapsed;
			Console.WriteLine($"Time taken to add {amount} elements: {elapsed}");

			Assert.AreEqual(expectedAmount, doublyLinkedList.Length);
		}

		/*
		Execution time:
		|-------------------------------|
		| N         | Time              |
		|-------------------------------|
		| 10        | 00:00:00.0007575  |
		| 100       | 00:00:00.0000082  |
		| 1000      | 00:00:00.0000919  |
		| 10_000    | 00:00:00.0010243  |
		| 100_000   | 00:00:00.0101879  |
		| 1_000_000 | 00:00:00.0727935  |
		|-------------------------------|
		Comments on performance:
		1. Time Complexity:
			- The `Remove()` operation has a linear time complexity O(N) in the worst case. 
			  This is because locating the node to be removed requires a crossing of the list, which takes O(N) time.
			- Once the node is found, removal itself is O(1), as it involves adjusting a few pointers.
		2. Optimization Suggestions:
			- For sequential removals, caching the last accessed node can significantly improve crossing speed.
		*/
		[TestMethod]
		[DataRow(10, 0)]
		[DataRow(100, 0)]
		[DataRow(1000, 0)]
		[DataRow(10_000, 0)]
		[DataRow(100_000, 0)]
		[DataRow(1_000_000, 0)]
		public void TestRemoveTimeComplexityForDoublyLinkedList(int amount, int expectedAmount)
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();

			for (var i = 0; i < amount; i++)
			{
				doublyLinkedList.Add(i);
			}

			var watch = Stopwatch.StartNew();

			// Act
			for (var i = 0; i < amount; i++)
			{
				doublyLinkedList.Remove(i);
			}

			// Assert
			watch.Stop();

			var elapsedMs = watch.Elapsed;

			Console.WriteLine($"Time taken to remove {amount} elements: {elapsedMs}");

			Assert.AreEqual(expectedAmount, doublyLinkedList.Length);
		}

        /*
		Execution time:
		|-------------------------------|
		| N         | Time              |
		|-------------------------------|
		| 10        | 00:00:00.0003339  |
		| 100       | 00:00:00.0000056  |
		| 1000      | 00:00:00.0000592  |
		| 10_000    | 00:00:00.0040450  |
		| 100_000   | 00:00:00.0080216  |
		| 1_000_000 | 00:00:00.0320880  |
		|-------------------------------|
		Comments on performance:
		1. This specific scenario removes the first index which takes constant time O(1).
		2. Removing from the middle takes the longest time since this is furthest away from the head and tail. 
		   Removing from the middle takes O(n/2) = linear time O(n).
		*/
        [TestMethod]
        [DataRow(10, 0)]
        [DataRow(100, 0)]
        [DataRow(1000, 0)]
        [DataRow(10_000, 0)]
        [DataRow(100_000, 0)]
        [DataRow(1_000_000, 0)]
        public void TestRemoveByFirstIndexTimeComplexityForDoublyLinkedList(int amount, int expectedAmount)
        {
            // Arrange
            var doublyLinkedList = new DoublyLinkedList<int>();

            for (var i = 0; i < amount; i++)
            {
                doublyLinkedList.Add(i);
            }

            var watch = Stopwatch.StartNew();

            // Act
            for (var i = 0; i < amount; i++)
            {
                doublyLinkedList.RemoveAt(0);
            }

            // Assert
            watch.Stop();

            var elapsedMs = watch.Elapsed;

            Console.WriteLine($"Time taken to remove {amount} elements: {elapsedMs}");

            Assert.AreEqual(expectedAmount, doublyLinkedList.Length);
        }

        /*
		Execution time:
		|-------------------------------|
		| N         | Time              |
		|-------------------------------|
		| 10        | 00:00:00.0000007  |
		| 100       | 00:00:00.0000047  |
		| 1000      | 00:00:00.0000536  |
		| 10_000    | 00:00:00.0008106  |
		| 100_000   | 00:00:00.0077688  |
		| 1_000_000 | 00:00:00.0295492  |
		|-------------------------------|
		Comments on performance:
		1. If we wouldn't have the check for determining whether the index is closer to the head or tail,
	       removing the last index would take linear time O(n) since it would start at index 0 and search for
		   the index to remove.
		2. Since we do that check we can start searching for the last index from the tail and immediately find the last index
		   since that is the tail. Removing this element takes constant time O(1).
		*/
        [TestMethod]
		[DataRow(10, 0)]
		[DataRow(100, 0)]
		[DataRow(1000, 0)]
		[DataRow(10_000, 0)]
		[DataRow(100_000, 0)]
		[DataRow(1_000_000, 0)]
		public void TestRemoveByLastIndexTimeComplexityForDoublyLinkedList(int amount, int expectedAmount)
        {
            // Arrange
            var doublyLinkedList = new DoublyLinkedList<int>();

            for (var i = 0; i < amount; i++)
            {
                doublyLinkedList.Add(i);
            }

            var watch = Stopwatch.StartNew();

            // Act
            for (var i = amount - 1; i >= 0; i--)
            {
                doublyLinkedList.RemoveAt(i);
            }

            // Assert
            watch.Stop();

            var elapsedMs = watch.Elapsed;

            Console.WriteLine($"Time taken to remove {amount} elements: {elapsedMs}");

            Assert.AreEqual(expectedAmount, doublyLinkedList.Length);
        }

        /*
		Execution time:
		|-------------------------------|
		| N         | Time              |
		|-------------------------------|
		| 10        | 00:00:00.0001783  |
		| 100       | 00:00:00.0002328  |
		| 1000      | 00:00:00.0076908  |
		| 10_000    | 00:00:00.2432616  |
		| 100_000   | 00:01:02.7411362  |
		| 1_000_000 | 01:25:30.0412103  |
		|-------------------------------|
		Comments on performance:
		1. Time Complexity:
			- The `Get()` operation has a linear time complexity O(N) due to the need to cross the list from the beginning or from the tail,
			  if implemented to access a particular index.
			- Although indexing is straightforward in a doubly linked list (you just need to follow the links between nodes), 
			  it is still inherently slower compared to random access in arrays (which is O(1)).
		2. To improve performance we could start searching from the end if the given index is closer to the tail then to the head.
		*/
        [TestMethod]
		[DataRow(10, 10)]
		[DataRow(100, 100)]
		[DataRow(1000, 1000)]
		[DataRow(10_000, 10_000)]
		[DataRow(100_000, 100_000)]
		[DataRow(1_000_000, 1_000_000)]
		public void TestGetTimeComplexityForDoublyLinkedList(int amount, int expectedAmount)
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();
			for (int i = 0; i < amount; i++)
			{
				doublyLinkedList.Add(i);
			}

			var watch = Stopwatch.StartNew();

			// Act
			for (int i = 0; i < amount; i++)
			{
				var value = doublyLinkedList.Get(i);
			}

			// Assert
			watch.Stop();

			var elapsed = watch.Elapsed;
			Console.WriteLine($"Time taken to get {amount} elements: {elapsed}");

			Assert.AreEqual(amount, doublyLinkedList.Length);
		}

        /*
		Execution time:
		|-------------------------------|
		| N         | Time              |
		|-------------------------------|
		| 10        | 00:00:00.0001471  |
		| 100       | 00:00:00.0001818  |
		| 1000      | 00:00:00.0067066  |
		| 10_000    | 00:00:00.2283720  |
		| 100_000   | 00:01:08.5843781  |
		| 1_000_000 | 01:19:09.2746488  |
		|-------------------------------|
		Comments:
		1. Time Complexity:
			- The `Set()` operation updates the value of an element at a specified index in the doubly linked list. 
			  However, before updating, the list must travel through nodes to reach the target index.
			- This traversal step results in an O(N) time complexity, meaning the operation scales linearly with the size of the list. 
			  As N increases, the time to reach the desired node increases proportionally.
		2. Performance Observations:
			- The results demonstrate that time grows linearly with the size of the list. 
			  For example, for 100,000 elements, the operation takes 1 minute and 8 seconds, which highlights the linear relationship between time and list size.
		3. To improve performance we could start searching from the end if the given index is closer to the tail then to the head.
		*/
        [TestMethod]
		[DataRow(10, 10)]
		[DataRow(100, 100)]
		[DataRow(1000, 1000)]
		[DataRow(10_000, 10_000)]
		[DataRow(100_000, 100_000)]
		[DataRow(1_000_000, 1_000_000)]
		public void TestSetTimeComplexityForDoublyLinkedList(int amount, int expectedAmount)
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();
			for (int i = 0; i < amount; i++)
			{
				doublyLinkedList.Add(i);
			}

			var watch = Stopwatch.StartNew();

			// Act
			for (int i = 0; i < amount; i++)
			{
				doublyLinkedList.Set(i, i * 2);
			}

			// Assert
			watch.Stop();

			var elapsed = watch.Elapsed;
			Console.WriteLine($"Time taken to set {amount} elements: {elapsed}");

			Assert.AreEqual(amount, doublyLinkedList.Length);
		}

		/*
		Execution time:
		|-------------------------------|
		| N         | Time              |
		|-------------------------------|
		| 10        | 00:00:00.0004733  |
		| 100       | 00:00:00.0005046  |
		| 1000      | 00:00:00.0171177  |
		| 10_000    | 00:00:00.5838869  |
		| 100_000   | 00:01:56.0768304  |
		| 1_000_000 | 02:16:12.4603080  |
		|-------------------------------|
		Comments:	
		1. Time Complexity:
			- The `Contains()` method checks if a specific element exists in the doubly linked list. 
			  The method iterates through the list node by node until the target value is found.
			- Due to this travel, the **time complexity is O(N)** for this operation. As the list grows, 
			  the time taken increases linearly, which is evident from the execution times.
		2. Analysis of Results:
			- From the times recorded, we can see that for small lists, the method performs well. 
			  However, as the size increases, the time grows rapidly. For 100,000 elements, 
			  the operation takes nearly 1 minute and 56 seconds, which is a noticeable delay.
		*/
		[TestMethod]
		[DataRow(10, 10)]
		[DataRow(100, 100)]
		[DataRow(1000, 1000)]
		[DataRow(10_000, 10_000)]
		[DataRow(100_000, 100_000)]
		[DataRow(1_000_000, 1_000_000)]
		public void TestContainsTimeComplexityForDoublyLinkedList(int amount, int expectedAmount)
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();
			for (int i = 0; i < amount; i++)
			{
				doublyLinkedList.Add(i);
			}

			var watch = Stopwatch.StartNew();

			// Act
			for (int i = 0; i < amount; i++)
			{
				var contains = doublyLinkedList.Contains(i);
			}

			// Assert
			watch.Stop();

			var elapsed = watch.Elapsed;
			Console.WriteLine($"Time taken to check containment for {amount} elements: {elapsed}");

			Assert.AreEqual(amount, doublyLinkedList.Length);
		}

		/*
		Execution time:
		|-------------------------------|
		| N         | Time              |
		|-------------------------------|
		| 10        | 00:00:00.0004521  |
		| 100       | 00:00:00.0045865  |
		| 1000      | 00:00:00.0221734  |
		| 10_000    | 00:00:00.5307228  |
		| 100_000   | 00:01:59.3871020  |
		| 1_000_000 | 02:16:50.3450866  |
		|-------------------------------|
		Comments:
		1. Time Complexity:
			- The `Find()` operation searches the list for a node containing a specific value. 
			  Similar to `Contains()`, the method travels through the list from the head node, 
			  and the time complexity for this is O(N), as each node must be checked until the target is found.
			- As the number of elements grows, the traversal time increases linearly, making the `Find()` operation less efficient for large lists.
		2. Execution Time Insights:
			- For 100,000 elements, the search operation takes almost 2 minutes 16 seconds. 
			  This significant delay is indicative of the linear search pattern, where the list is scanned node-by-node until the target is located.
			- As expected, the time to find elements increases with the list size, which can be a problem when frequent searches are required.
		*/
		[TestMethod]
		[DataRow(10, 10)]
		[DataRow(100, 100)]
		[DataRow(1000, 1000)]
		[DataRow(10_000, 10_000)]
		[DataRow(100_000, 100_000)]
		[DataRow(1_000_000, 1_000_000)]
		public void TestFindTimeComplexityForDoublyLinkedList(int amount, int expectedAmount)
		{
			// Arrange
			var doublyLinkedList = new DoublyLinkedList<int>();
			for (int i = 0; i < amount; i++)
			{
				doublyLinkedList.Add(i);
			}

			var watch = Stopwatch.StartNew();

			// Act
			for (int i = 0; i < amount; i++)
			{
				var node = doublyLinkedList.Find(i);
				Assert.IsNotNull(node);
			}

			// Assert
			watch.Stop();

			var elapsed = watch.Elapsed;
			Console.WriteLine($"Time taken to find {amount} elements: {elapsed}");

			Assert.AreEqual(amount, doublyLinkedList.Length);
		}
	}
}
