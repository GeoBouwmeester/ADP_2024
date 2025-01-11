using ADP_2024;
using ADP_2024.AVL_Tree;
using ADP_2024.Models;

namespace ADP_2024_Test.AVLTree;

[TestClass]
public sealed class AvlTreeFunctionalTests
{
	public required DatasetReader reader;

	[TestInitialize]
	public void SetUp()
	{
		reader = new DatasetReader();
	}

	[TestMethod]
	public void TestAVLTreeWillekeurig10000()
	{
		// Arrange
		var avlTree = new AvlTree<int>();

		// Act
		foreach (var value in reader.LijstWillekeurig10000)
		{
			avlTree.Insert(value);
		}

		avlTree.PrintTreeStructure();

		// Assert
		Assert.AreEqual(reader.LijstWillekeurig10000.Length, avlTree.GetTreeSize(avlTree.GetRoot()));
		Assert.IsTrue(avlTree.IsBalanced());
	}

	[TestMethod]
	public void TestAVLTreeAflopend2()
	{
		// Arrange
		var avlTree = new AvlTree<int>();

		// Act
		foreach (var value in reader.LijstAflopend2)
		{
			avlTree.Insert(value);
		}

		var newValue = 5123;
		var extraValue = 1223;
		avlTree.Insert(newValue);
		avlTree.Insert(extraValue);

		avlTree.PrintTreeStructure();

		// Assert
		Assert.AreEqual(4, avlTree.GetTreeSize(avlTree.GetRoot()));
		Assert.IsTrue(avlTree.IsBalanced());
	}

	[TestMethod]
	public void TestAVLTreeFloat8001()
	{
		// Arrange
		var avlTree = new AvlTree<float>();

		var uniqueValues = reader.LijstFloat8001.Distinct();

		// Act
		foreach (var value in uniqueValues)
		{
			avlTree.Insert(value);
		}

		avlTree.PrintTreeStructure();

		// Assert
		Assert.AreEqual(uniqueValues.Count(), avlTree.GetTreeSize(avlTree.GetRoot()));
		Assert.IsTrue(avlTree.IsBalanced());
	}
	[TestMethod]
	public void TestAVLTreeOplopend10000()
	{
		// Arrange
		var avlTree = new AvlTree<int>();

		// Act
		foreach (var value in reader.LijstOplopend10000)
		{
			avlTree.Insert(value);
		}

		avlTree.PrintTreeStructure();

		// Assert
		Assert.AreEqual(reader.LijstOplopend10000.Length, avlTree.GetTreeSize(avlTree.GetRoot()));
		Assert.IsTrue(avlTree.IsBalanced());
	}

	[TestMethod]
	public void TestAVLTreeGesorteerdOplopend3()
	{
		// Arrange
		var avlTree = new AvlTree<int>();

		// Act
		foreach (var value in reader.LijstGesorteerdOplopend3)
		{
			avlTree.Insert(value);
		}

		avlTree.PrintTreeStructure();

		// Assert
		Assert.AreEqual(reader.LijstGesorteerdOplopend3.Length, avlTree.GetTreeSize(avlTree.GetRoot()));
		Assert.IsTrue(avlTree.IsBalanced());
	}

	[TestMethod]
	public void TestAVLTreeWillekeurig3()
	{
		// Arrange
		var avlTree = new AvlTree<int>();

		// Act
		foreach (var value in reader.LijstWillekeurig3)
		{
			avlTree.Insert(value);
		}

		avlTree.PrintTreeStructure();

		// Assert
		Assert.AreEqual(reader.LijstWillekeurig3.Length, avlTree.GetTreeSize(avlTree.GetRoot()));
		Assert.IsTrue(avlTree.IsBalanced());
	}

	[TestMethod]
	public void TestAVLTreeOplopend2()
	{
		// Arrange
		var avlTree = new AvlTree<int>();

		// Act
		foreach (var value in reader.LijstOplopend2)
		{
			avlTree.Insert(value);
		}

		avlTree.PrintTreeStructure();

		// Assert
		Assert.AreEqual(reader.LijstOplopend2.Length, avlTree.GetTreeSize(avlTree.GetRoot()));
		Assert.IsTrue(avlTree.IsBalanced());
	}

	[TestMethod]
	public void TestAVLTreeGesorteerdAflopend3()
	{
		// Arrange
		var avlTree = new AvlTree<int>();

		// Act
		foreach (var value in reader.LijstGesorteerdAflopend3)
		{
			avlTree.Insert(value);
		}
		avlTree.Remove(3);
		avlTree.PrintTreeStructure();

		// Assert
		Assert.AreEqual(2, avlTree.GetTreeSize(avlTree.GetRoot()));
		Assert.IsTrue(avlTree.IsBalanced());
	}

	[TestMethod]
	public void TestAVLTreeHerhaald1000()
	{
		// Arrange
		var avlTree = new AvlTree<int>();
		var firstValue = reader.LijstHerhaald1000[0];

		// Act & Assert
		try
		{
			foreach (var value in reader.LijstHerhaald1000)
			{
				avlTree.Insert(value);
			}
			Assert.Fail("Expected an InvalidOperationException, but no exception was thrown.");
		}
		catch (InvalidOperationException ex)
		{
			Assert.AreEqual("Duplicate Key!", ex.Message);

			var node = avlTree.Find(firstValue);
			Assert.IsNotNull(node);

			avlTree.PrintTreeStructure();

			Assert.AreEqual(1, avlTree.GetTreeSize(avlTree.GetRoot()));
			Assert.IsTrue(avlTree.IsBalanced());
		}
	}

	[TestMethod]
	public void TestLijstPizza()
	{
		// Arrange
		var avlTree = new AvlTree<Pizza>();

		// Act
		foreach (var value in reader.LijstPizza6)
		{
			avlTree.Insert(value);
		}

		var newPizza = new Pizza("Pepperoni", 8);

		avlTree.Insert(newPizza);
		avlTree.PrintTreeStructure();

		// Assert
		Assert.AreEqual(7, avlTree.GetTreeSize(avlTree.GetRoot()));
		Assert.IsTrue(avlTree.IsBalanced());
	}

	[TestMethod]
	public void TestAVLTreeOnsorteerbaar3()
	{
		// Arrange
		var avlTree = new AvlTree<int>();

		var array = reader.LijstOnsorteerbaar3
						  .Where(value => value.GetType() == typeof(Int64))
						  .Select(value => (int)(long)value)
						  .ToArray();

		// Act
		foreach (var value in array)
		{
			avlTree.Insert(value);
		}

		avlTree.PrintTreeStructure();

		// Assert
		Assert.AreEqual(1, avlTree.GetTreeSize(avlTree.GetRoot()));
		Assert.IsTrue(avlTree.IsBalanced());
	}

	[TestMethod]
	public void TestAVLTreeNull1()
	{
		// Arrange
		var avlTree = new AvlTree<int>();

		var array = reader.LijstNull1
						  .Where(value => value != null)
						  .Cast<int>()
						  .ToArray();

		// Act
		foreach (var value in array)
		{
			avlTree.Insert(value);
		}

		avlTree.PrintTreeStructure();

		// Assert
		Assert.AreEqual(0, avlTree.GetTreeSize(avlTree.GetRoot()));
		Assert.IsTrue(avlTree.IsBalanced());
	}

	[TestMethod]
	public void TestAVLTreeNull3()
	{
		// Arrange
		var avlTree = new AvlTree<int>();

		var array = reader.LijstNull3
						  .Where(value => value != null)
						  .Cast<int>()
						  .ToArray();

		// Act
		foreach (var value in array)
		{
			avlTree.Insert(value);
		}

		avlTree.PrintTreeStructure();

		// Assert
		Assert.AreEqual(2, avlTree.GetTreeSize(avlTree.GetRoot()));
		Assert.IsTrue(avlTree.IsBalanced());
	}

	[TestMethod]
	public void TestAVLTreeNull0()
	{
		// Arrange
		var avlTree = new AvlTree<int>();

		var array = reader.LijstLeeg0
						  .Where(value => value != null)
						  .Cast<int>()
						  .ToArray();

		// Act
		foreach (var value in array)
		{
			avlTree.Insert(value);
		}

		avlTree.PrintTreeStructure();

		// Assert
		Assert.AreEqual(reader.LijstLeeg0.Length, avlTree.GetTreeSize(avlTree.GetRoot()));
		Assert.IsTrue(avlTree.IsBalanced());
	}

	[TestMethod]
	public void TestPrintAVLTree()
	{
		// Arrange
		var avlTree = new AvlTree<int>();

		// Act
		var values = new int[] { 50, 30, 70, 20, 40, 60, 80 };
		foreach (var value in values)
		{
			avlTree.Insert(value);
		}

		// Assert
		Assert.IsTrue(avlTree.IsBalanced());
		Assert.AreEqual(7, avlTree.GetTreeSize(avlTree.GetRoot()));
		avlTree.PrintTreeStructure();
	}

}
