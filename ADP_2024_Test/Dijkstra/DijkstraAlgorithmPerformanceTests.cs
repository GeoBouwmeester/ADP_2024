using ADP_2024;
using ADP_2024.Dijkstra;
using ADP_2024.Graph;
using ADP_2024_Test.Graph;
using System.Diagnostics;

namespace ADP_2024_Test.Dijkstra;
   
[TestClass]
public class DijkstraAlgorithmPerformanceTests
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
    | 10         | 00:00:00.0000297  |
    | 100        | 00:00:00.0001057  |
    | 1000       | 00:00:00.0011211  |
    | 10_000     | 00:00:00.0065549  |
    |--------------------------------|
    1. O(E log V), where V is the number of vertices and E is the number of edges in the graph.
    */
    [TestMethod]
    [DataRow(10)]
    [DataRow(100)]
    [DataRow(1000)]
    [DataRow(10_000)]
    public void TestDijkstraAlgorithm(int amount)
    {
        // Arrange
        var graph = new Graaf();

        var iterations = 100;

        int numVertices = amount;

        int numEdges = amount * 5;

        var edgeList = GraphGenerator.GenerateAdjacencyListWeighted(numVertices, numEdges);

        graph.BuildFromAdjacencyListWeighted(edgeList);

        Stopwatch stopwatch = new();

        // Act
        for (int i = 0; i < iterations; i++)
        {
            stopwatch.Start();

            DijkstraAlgorithm.Dijkstra(graph, 0);

            stopwatch.Stop();
        }

        // Assert
        graph.PrintGraph();

        graph.PrintDistances();

        var path = DijkstraAlgorithm.GetShortestPath(graph.Vertices[4]);

        Console.WriteLine(string.Join(" -> ", path));

        Console.WriteLine(TimeSpan.FromTicks(stopwatch.ElapsedTicks / iterations));
    }

    /*
    Execution time:
    |--------------------------------|
    | N          | Time              |
    |--------------------------------|
    | 10         | 00:00:00.0000018  |
    | 100        | 00:00:00.0000012  |
    | 1000       | 00:00:00.0000001  |
    | 10_000     | 00:00:00.0000002  |
    |--------------------------------|
    1. O(P) operation where P is the length of the path
    */
    [TestMethod]
    [DataRow(10)]
    [DataRow(100)]
    [DataRow(1000)]
    [DataRow(10_000)]
    public void TestGetShortestPath(int amount)
    {
        // Arrange
        var graph = new Graaf();

        var iterations = 100;

        int numVertices = amount;

        int numEdges = amount * 5;

        var edgeList = GraphGenerator.GenerateAdjacencyListWeighted(numVertices, numEdges);

        graph.BuildFromAdjacencyListWeighted(edgeList);

        DijkstraAlgorithm.Dijkstra(graph, 0);

        Stopwatch stopwatch = new();

        // Act
        for (int i = 0; i < iterations; i++)
        {
            stopwatch.Start();

            var path = DijkstraAlgorithm.GetShortestPath(graph.Vertices[4]);

            stopwatch.Stop();
        }

        // Assert
        graph.PrintGraph();

        graph.PrintDistances();

        Console.WriteLine(TimeSpan.FromTicks(stopwatch.ElapsedTicks / iterations));
    }
}