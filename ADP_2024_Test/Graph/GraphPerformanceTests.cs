using ADP_2024;
using ADP_2024.Graph;
using System.Diagnostics;

namespace ADP_2024_Test.Graph;

[TestClass]
public class GraphPerformanceTests
{
    public required DatasetReader reader;

    [TestInitialize]
    public void SetUp()
    {
        reader = new DatasetReader();
    }

    /*
    Execution time:
    |--------------------------------|
    | N          | Time              |
    |--------------------------------|
    | 10         | 00:00:00.0000290  |
    | 100        | 00:00:00.0000300  |
    | 1000       | 00:00:00.0000284  |
    | 10_000     | 00:00:00.0000318  |
    |--------------------------------|
    1. Constant time due to hash-based dictionary
    */
    [TestMethod]
    [DataRow(10)]
    [DataRow(100)]
    [DataRow(1000)]
    [DataRow(10_000)]
    public void TestAddVertex(int amount)
    {
        // Arrange
        var graph = new Graaf();

        var iterations = 10;

        Stopwatch stopwatch = new();

        // Act
        for (int i = 0; i < iterations; i++)
        {
            stopwatch.Start();

            graph.AddVertex(i);

            stopwatch.Stop();
        }

        // Assert
        stopwatch.Stop();

        Console.WriteLine(TimeSpan.FromTicks(stopwatch.ElapsedTicks / iterations));
    }

    /*
    Execution time:
    |--------------------------------|
    | N          | Time              |
    |--------------------------------|
    | 10         | 00:00:00.0000631  |
    | 100        | 00:00:00.0000617  |
    | 1000       | 00:00:00.0000624  |
    | 10_000     | 00:00:00.0000620  |
    |--------------------------------|
    1. Constant time due to hash-based dictionary
    */
    [TestMethod]
    [DataRow(10)]
    [DataRow(100)]
    [DataRow(1000)]
    [DataRow(10_000)]
    public void TestAddEdge(int amount)
    {
        // Arrange
        var graph = new Graaf();

        var iterations = 10;

        var random = new Random();

        Stopwatch stopwatch = new();

        // Act
        for (int i = 0; i < iterations; i++)
        {
            int vertex1 = random.Next(amount);
            int vertex2 = random.Next(amount);

            while (vertex1 == vertex2)
            {
                vertex2 = random.Next(amount);
            }

            int weight = random.Next(1, 101);

            stopwatch.Start();

            graph.AddEdge(vertex1, vertex2, weight);

            stopwatch.Stop();
        }

        // Assert
        Console.WriteLine(TimeSpan.FromTicks(stopwatch.ElapsedTicks / iterations));
    }

    /*
    Execution time:
    |--------------------------------|
    | N          | Time              |
    |--------------------------------|
    | 10         | 00:00:00.0004921  |
    | 100        | 00:00:00.0004796  |
    | 1000       | 00:00:00.0002862  |
    | 10_000     | 00:00:00.0005632  |
    | 100_000    | 00:00:00.0014946  |
    | 1_000_000  | 00:00:00.0294403  |
    | 10_000_000 | 00:00:00.0993423  |
    |--------------------------------|
    1. Time complexity: O(n + m)
    2. Foreach loop to find the vertex (linear) + linear time complexity for removing all edges (in this test case constant as it always removes one edge)
    */
    [TestMethod]
    [DataRow(10)]
    [DataRow(100)]
    [DataRow(1000)]
    [DataRow(10_000)]
    [DataRow(100_000)]
    [DataRow(1_000_000)]
    [DataRow(10_000_000)]
    public void TestRemoveVertex(int amount)
    {
        // Arrange
        var graph = new Graaf();

        var random = new Random();

        // Add vertices
        for (int i = 0; i < amount; i++)
        {
            graph.AddVertex(i);
        }

        // Add edges
        for (int i = 0; i < amount * 2; i++)
        {
            int vertex1 = random.Next(amount);
            int vertex2 = random.Next(amount);

            while (vertex1 == vertex2)
            {
                vertex2 = random.Next(amount);
            }

            int weight = random.Next(1, 101);

            graph.AddEdge(vertex1, vertex2, weight);
        }

        Stopwatch stopwatch = new();

        stopwatch.Start();

        // Act
        graph.RemoveVertex(random.Next(amount));

        // Assert
        stopwatch.Stop();

        Console.WriteLine(TimeSpan.FromTicks(stopwatch.ElapsedTicks));
    }

    /*
    Execution time:
    |--------------------------------|
    | N          | Time              |
    |--------------------------------|
    | 10         | 00:00:00.0000240  |
    | 100        | 00:00:00.0000197  |
    | 1000       | 00:00:00.0000002  |
    | 10_000     | 00:00:00.0000003  |
    | 100_000    | 00:00:00.0000006  |
    | 1_000_000  | 00:00:00.0000011  |
    | 10_000_000 | 00:00:00.0000023  |
    |--------------------------------|
    1. RemoveAll function within the tested function: 'RemoveEdge' uses linear time complexity.
    */
    [TestMethod]
    [DataRow(10)]
    [DataRow(100)]
    [DataRow(1000)]
    [DataRow(10_000)]
    [DataRow(100_000)]
    [DataRow(1_000_000)]
    [DataRow(10_000_000)]
    public void TestRemoveEdge(int amount)
    {
        // Arrange
        var graph = new Graaf();

        var random = new Random();

        var iterations = 10;

        // Add vertices
        for (int i = 0; i < amount; i++)
        {
            graph.AddVertex(i);
        }

        // Add edges
        for (int i = 0; i < amount * 2; i++)
        {
            int vertex1 = random.Next(amount);
            int vertex2 = random.Next(amount);

            while (vertex1 == vertex2)
            {
                vertex2 = random.Next(amount);
            }

            int weight = random.Next(1, 101);

            graph.AddEdge(vertex1, vertex2, weight);
        }

        Stopwatch stopwatch = new();

        for (int i = 0; i < iterations; i++)
        {
            int edgeVertex1 = random.Next(amount);
            int edgeVertex2 = random.Next(amount);

            while (edgeVertex1 == edgeVertex2)
            {
                edgeVertex2 = random.Next(amount);
            }

            stopwatch.Start();

            graph.RemoveEdge(edgeVertex1, edgeVertex2);

            stopwatch.Stop();
        }

        // Assert
        Console.WriteLine(TimeSpan.FromTicks(stopwatch.ElapsedTicks / iterations));
    }

    /*
    Execution time:
    |--------------------------------|
    | N          | Time              |
    |--------------------------------|
    | 10         | 00:00:00.0000853  |
    | 100        | 00:00:00.0001749  |
    | 1000       | 00:00:00.0020721  |
    | 10_000     | 00:00:00.0151289  |
    |--------------------------------|
    1. Linear time complexity due to single for loop
    */
    [TestMethod]
    [DataRow(10)]
    [DataRow(100)]
    [DataRow(1000)]
    [DataRow(10_000)]
    public void TestBuildFromEdgeList(int amount)
    {
        // Arrange
        int numVertices = amount;

        int numEdges = amount * 5;

        var edgeList = GraphGenerator.GenerateEdgeList(numVertices, numEdges);

        var iterations = 100;

        Stopwatch stopwatch = new();

        // Act
        for (int i = 0; i < iterations; i++)
        {
            var graph = new Graaf();

            stopwatch.Start();

            graph.BuildFromEdgeList(edgeList);

            stopwatch.Stop();
        }

        // Assert
        Console.WriteLine(TimeSpan.FromTicks(stopwatch.ElapsedTicks / iterations));
    }

    /*
    Execution time:
    |--------------------------------|
    | N          | Time              |
    |--------------------------------|
    | 10         | 00:00:00.0000724  |
    | 100        | 00:00:00.0000997  |
    | 1000       | 00:00:00.0013458  |
    | 10_000     | 00:00:00.0095922  |
    |--------------------------------|
    1. Time complexity: O(n + m) due to for loop for finding each vertex 
       and then second loop for finding neigbor of each vertex.
    */
    [TestMethod]
    [DataRow(10)]
    [DataRow(100)]
    [DataRow(1000)]
    [DataRow(10_000)]
    public void TestBuildFromAdjacencyList(int amount)
    {
        // Arrange
        int numVertices = amount;

        int numEdges = amount * 5;

        var edgeList = GraphGenerator.GenerateAdjacencyList(numVertices, numEdges);

        var iterations = 10;

        Stopwatch stopwatch = new();

        // Act
        for (int i = 0; i < iterations; i++)
        {
            var graph = new Graaf();

            stopwatch.Start();

            graph.BuildFromAdjacencyList(edgeList);

            stopwatch.Stop();
        }

        // Assert
        Console.WriteLine(TimeSpan.FromTicks(stopwatch.ElapsedTicks / iterations));
    }

    /*
    Execution time:
    |--------------------------------|
    | N          | Time              |
    |--------------------------------|
    | 10         | 00:00:00.0000785  |
    | 100        | 00:00:00.0001251  |
    | 1000       | 00:00:00.0013351  |
    | 10_000     | 00:00:00.0155428  |
    |--------------------------------|
    1. Time complexity: O(n + m) due to for loop for finding each vertex 
       and then second loop for finding neigbor of each vertex.
    */
    [TestMethod]
    [DataRow(10)]
    [DataRow(100)]
    [DataRow(1000)]
    [DataRow(10_000)]
    public void TestBuildFromAdjacencyListWeighted(int amount)
    {
        // Arrange
        int numVertices = amount;

        int numEdges = amount * 5;

        var edgeList = GraphGenerator.GenerateAdjacencyListWeighted(numVertices, numEdges);

        var iterations = 10;

        Stopwatch stopwatch = new();

        // Act
        for (int i = 0; i < iterations; i++)
        {
            var graph = new Graaf();

            stopwatch.Start();

            graph.BuildFromAdjacencyListWeighted(edgeList);

            stopwatch.Stop();
        }

        // Assert
        Console.WriteLine(TimeSpan.FromTicks(stopwatch.ElapsedTicks / iterations));
    }

    /*
    Execution time:
    |--------------------------------|
    | N          | Time              |
    |--------------------------------|
    | 10         | 00:00:00.0000890  |
    | 100        | 00:00:00.0001533  |
    | 1000       | 00:00:00.0032709  |
    | 10_000     | 00:00:00.2984430  |
    |--------------------------------|
    1. Quadratic time complexity due to nested for loop.
    */
    [TestMethod]
    [DataRow(10)]
    [DataRow(100)]
    [DataRow(1000)]
    [DataRow(10_000)]
    public void TestBuildFromAdjacencyMatrix(int amount)
    {
        // Arrange
        int numVertices = amount;

        int numEdges = amount * 5;

        var edgeList = GraphGenerator.GenerateAdjacencyMatrix(numVertices, numEdges);

        var iterations = 10;

        Stopwatch stopwatch = new();

        // Act
        for (int i = 0; i < iterations; i++)
        {
            var graph = new Graaf();

            stopwatch.Start();

            graph.BuildFromAdjacencyMatrix(edgeList);

            stopwatch.Stop();
        }

        // Assert
        Console.WriteLine(TimeSpan.FromTicks(stopwatch.ElapsedTicks / iterations));
    }
}