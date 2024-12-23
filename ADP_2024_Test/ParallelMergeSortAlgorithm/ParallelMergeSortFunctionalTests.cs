using ADP_2024;
using ADP_2024.Models;
using ADP_2024.SortingAlgorithms;

namespace ADP_2024_Test.ParallelMergeSortAlgorithm
{
	[TestClass]
	public sealed class ParallelMergeSortFunctionalTests
	{
		public required DatasetReader reader;

		[TestInitialize]
		public void SetUp()
		{
			reader = new DatasetReader();
		}

		[TestMethod]
		public void TestLijstWillekeurig10000()
		{
			// Arrange
			var mergeSort = new ParallelMergeSort<int>(); 
			var array = reader.LijstWillekeurig10000;

			// Act
			mergeSort.Sort(array);

			// Assert
			for (int i = 0; i < array.Length - 1; i++)
			{
				Assert.IsTrue(array[i].CompareTo(array[i + 1]) <= 0,
					$"Array is not sorted at index {i}: {array[i]} > {array[i + 1]}");
			}
		}

		[TestMethod]
		public void TestLijstAflopend2()
		{
			// Arrange
			var mergeSort = new ParallelMergeSort<int>();
			var array = reader.LijstAflopend2;

			// Act
			mergeSort.Sort(array);

			// Assert
			for (int i = 0; i < array.Length - 1; i++)
			{
				Assert.IsTrue(array[i].CompareTo(array[i + 1]) <= 0,
					$"Array is not sorted at index {i}: {array[i]} > {array[i + 1]}");
			}
		}

		[TestMethod]
		public void TestLijstFloat8001()
		{
			// Arrange
			var mergeSort = new ParallelMergeSort<float>();
			var array = reader.LijstFloat8001;

			// Act
			mergeSort.Sort(array);

			// Assert
			for (int i = 0; i < array.Length - 1; i++)
			{
				Assert.IsTrue(array[i].CompareTo(array[i + 1]) <= 0,
					$"Array is not sorted at index {i}: {array[i]} > {array[i + 1]}");
			}
		}


		[TestMethod]
		public void TestLijstOplopend10000()
		{
			// Arrange
			var mergeSort = new ParallelMergeSort<int>();
			var array = reader.LijstOplopend10000;

			// Act
			mergeSort.Sort(array);

			// Assert
			for (int i = 0; i < array.Length - 1; i++)
			{
				Assert.IsTrue(array[i].CompareTo(array[i + 1]) <= 0,
					$"Array is not sorted at index {i}: {array[i]} > {array[i + 1]}");
			}
		}

		[TestMethod]
		public void TestLijstGesorteerdOplopend3()
		{
			// Arrange
			var mergeSort = new ParallelMergeSort<int>();
			var array = reader.LijstGesorteerdOplopend3;

			// Act
			mergeSort.Sort(array);

			// Assert
			for (int i = 0; i < array.Length - 1; i++)
			{
				Assert.IsTrue(array[i].CompareTo(array[i + 1]) <= 0,
					$"Array is not sorted at index {i}: {array[i]} > {array[i + 1]}");
			}
		}

		[TestMethod]
		public void TestLijstWillekeurig3()
		{
			// Arrange
			var mergeSort = new ParallelMergeSort<int>();
			var array = reader.LijstWillekeurig3;

			// Act
			mergeSort.Sort(array);

			// Assert
			for (int i = 0; i < array.Length - 1; i++)
			{
				Assert.IsTrue(array[i].CompareTo(array[i + 1]) <= 0,
					$"Array is not sorted at index {i}: {array[i]} > {array[i + 1]}");
			}
		}

		[TestMethod]
		public void TestLijstOplopend2()
		{
			// Arrange
			var mergeSort = new ParallelMergeSort<int>();
			var array = reader.LijstOplopend2;

			// Act
			mergeSort.Sort(array);

			// Assert
			for (int i = 0; i < array.Length - 1; i++)
			{
				Assert.IsTrue(array[i].CompareTo(array[i + 1]) <= 0,
					$"Array is not sorted at index {i}: {array[i]} > {array[i + 1]}");
			}
		}

		[TestMethod]
		public void TestLijstGesorteerdAflopend3()
		{
			// Arrange
			var mergeSort = new ParallelMergeSort<int>();
			var array = reader.LijstGesorteerdAflopend3;

			// Act
			mergeSort.Sort(array);

			// Assert
			for (int i = 0; i < array.Length - 1; i++)
			{
				Assert.IsTrue(array[i].CompareTo(array[i + 1]) <= 0,
					$"Array is not sorted at index {i}: {array[i]} > {array[i + 1]}");
			}
		}

		[TestMethod]
		public void TestLijstHerhaald1000()
		{
			// Arrange
			var mergeSort = new ParallelMergeSort<int>();
			var array = reader.LijstHerhaald1000;

			// Act
			mergeSort.Sort(array);

			// Assert
			for (int i = 0; i < array.Length - 1; i++)
			{
				Assert.IsTrue(array[i].CompareTo(array[i + 1]) <= 0,
					$"Array is not sorted at index {i}: {array[i]} > {array[i + 1]}");
			}
		}

		[TestMethod]
		public void TestLijstPizza()
		{
			// Arrange
			var mergeSort = new ParallelMergeSort<Pizza>();
			var array = reader.LijstPizza6;

			// Act
			mergeSort.Sort(array);

			// Assert
			for (int i = 0; i < array.Length - 1; i++)
			{
				Assert.IsTrue(array[i].CompareTo(array[i + 1]) <= 0,
					$"Array is not sorted at index {i}: {array[i]} > {array[i + 1]}");
			}
		}


		[TestMethod]
		public void TestLijstOnsorteerbaar3()
		{
			// Arrange
			var mergeSort = new ParallelMergeSort<int>();
			var array = reader.LijstOnsorteerbaar3
							  .Where(value => value.GetType() == typeof(Int64))
							  .Select(value => (int)(long)value)
							  .ToArray();
			// Act
			mergeSort.Sort(array);

			// Assert
			for (int i = 0; i < array.Length - 1; i++)
			{
				Assert.IsTrue(array[i].CompareTo(array[i + 1]) <= 0,
					$"Array is not sorted at index {i}: {array[i]} > {array[i + 1]}");
			}

			Assert.AreEqual(1, array.Length, "The filtered array does not have the expected length.");
		}

		[TestMethod]
		public void TestLijstNull1()
		{
			// Arrange
			var mergeSort = new ParallelMergeSort<int>();
			var array = reader.LijstNull1
							  .Where(value => value != null)
							  .Cast<int>()
							  .ToArray();

			// Act
			mergeSort.Sort(array);

			// Assert
			for (int i = 0; i < array.Length - 1; i++)
			{
				Assert.IsTrue(array[i].CompareTo(array[i + 1]) <= 0,
					$"Array is not sorted at index {i}: {array[i]} > {array[i + 1]}");
			}

			Assert.AreEqual(0, array.Length, "Array should contain no elements after filtering nulls.");
		}

		[TestMethod]
		public void TestLijstNull3()
		{
			// Arrange
			var mergeSort = new ParallelMergeSort<int>();
			var array = reader.LijstNull3
							  .Where(value => value != null)
							  .Cast<int>()
							  .ToArray();

			// Act
			mergeSort.Sort(array);

			// Assert
			for (int i = 0; i < array.Length - 1; i++)
			{
				Assert.IsTrue(array[i].CompareTo(array[i + 1]) <= 0,
					$"Array is not sorted at index {i}: {array[i]} > {array[i + 1]}");
			}

			Assert.AreEqual(2, array.Length, "Array should contain no elements after filtering nulls.");
		}

		[TestMethod]
		public void TestLijstNull0()
		{
			// Arrange
			var mergeSort = new ParallelMergeSort<int>();
			var array = reader.LijstLeeg0
							  .Where(value => value != null)
							  .Cast<int>()
							  .ToArray();

			// Act
			mergeSort.Sort(array);

			// Assert
			for (int i = 0; i < array.Length - 1; i++)
			{
				Assert.IsTrue(array[i].CompareTo(array[i + 1]) <= 0,
					$"Array is not sorted at index {i}: {array[i]} > {array[i + 1]}");
			}

			Assert.AreEqual(0, array.Length, "Array should contain no elements after filtering nulls.");
		}

	}
}
