using ADP_2024;
using ADP_2024.Dijkstra;
using ADP_2024.Graph;

namespace ADP_2024_Test.Dijkstra;

[TestClass]
public class DijkstraAlgorithmFunctionalTests
{
    public required DatasetReader reader;

    [TestInitialize]
    public void SetUp()
    {
        reader = new DatasetReader();
    }

    [TestMethod]
    public void TestLijnlijst()
    {
        // Arrange
        var graphInput = reader.GraphDatasets.lijnlijst;

        var graph = new Graaf();

        graph.BuildFromEdgeList(graphInput);

        // Act
        DijkstraAlgorithm.Dijkstra(graph, 0);

        // Assert
        graph.PrintGraph();

        graph.PrintDistances();

        var path = DijkstraAlgorithm.GetShortestPath(graph.Vertices[5]);

        Console.WriteLine(string.Join(" -> ", path));
    }

    [TestMethod]
    public void TestLijnlijstWeighted()
    {
        // Arrange
        var graphInput = reader.GraphDatasets.lijnlijst_gewogen;

        var graph = new Graaf();

        graph.BuildFromEdgeList(graphInput);

        // Act
        DijkstraAlgorithm.Dijkstra(graph, 0);

        // Assert
        graph.PrintGraph();

        graph.PrintDistances();

        var path = DijkstraAlgorithm.GetShortestPath(graph.Vertices[4]);

        Console.WriteLine(string.Join(" -> ", path));
    }

    [TestMethod]
    public void TestAdjacencyList()
    {
        // Arrange
        var graphInput = reader.GraphDatasets.verbindingslijst;

        var graph = new Graaf();

        graph.BuildFromAdjacencyList(graphInput);

        // Act
        DijkstraAlgorithm.Dijkstra(graph, 0);

        // Assert
        graph.PrintGraph();

        graph.PrintDistances();

        var path = DijkstraAlgorithm.GetShortestPath(graph.Vertices[6]);

        Console.WriteLine(string.Join(" -> ", path));
    }

    [TestMethod]
    public void TestAdjacencyListWeighted()
    {
        // Arrange
        var graphInput = reader.GraphDatasets.verbindingslijst_gewogen;

        var graph = new Graaf();

        graph.BuildFromAdjacencyListWeighted(graphInput);

        // Act
        DijkstraAlgorithm.Dijkstra(graph, 0);

        // Assert
        graph.PrintGraph();

        graph.PrintDistances();

        var path = DijkstraAlgorithm.GetShortestPath(graph.Vertices[4]);

        Console.WriteLine(string.Join(" -> ", path));
    }

    [TestMethod]
    public void TestAdjacencyMatrix()
    {
        // Arrange
        var graphInput = reader.GraphDatasets.verbindingsmatrix;

        var graph = new Graaf();

        graph.BuildFromAdjacencyMatrix(graphInput);

        // Act
        DijkstraAlgorithm.Dijkstra(graph, 0);

        // Assert
        graph.PrintGraph();

        graph.PrintDistances();

        var path = DijkstraAlgorithm.GetShortestPath(graph.Vertices[6]);

        Console.WriteLine(string.Join(" -> ", path));
    }

    [TestMethod]
    public void TestAdjacencyMatrixWeighted()
    {
        // Arrange
        var graphInput = reader.GraphDatasets.verbindingsmatrix_gewogen;

        var graph = new Graaf();

        graph.BuildFromAdjacencyMatrix(graphInput);

        // Act
        DijkstraAlgorithm.Dijkstra(graph, 0);

        // Assert
        graph.PrintGraph();

        graph.PrintDistances();

        var path = DijkstraAlgorithm.GetShortestPath(graph.Vertices[4]);

        Console.WriteLine(string.Join(" -> ", path));
    }
}
