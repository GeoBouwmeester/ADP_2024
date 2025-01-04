using ADP_2024;
using ADP_2024.Graph;

namespace ADP_2024_Test.Graph;

[TestClass]
public class GraphFunctionalTests
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

        // Act
        graph.BuildFromEdgeList(graphInput);

        // Assert
        graph.PrintGraph();

        Assert.AreEqual(7, graph.Vertices.Count);
        Assert.AreEqual(1, graph.Vertices[4].Edges.Count);
    }

    [TestMethod]
    public void TestLijnlijstRemoveVertex()
    {
        // Arrange
        var graphInput = reader.GraphDatasets.lijnlijst;

        var graph = new Graaf();

        graph.BuildFromEdgeList(graphInput);

        // Act
        graph.RemoveVertex(0);

        // Assert
        graph.PrintGraph();

        Assert.ThrowsException<KeyNotFoundException>(() => graph.Vertices[0]);
        Assert.AreEqual(6, graph.Vertices.Count);
        Assert.AreEqual(1, graph.Vertices[4].Edges.Count);
    }

    [TestMethod]
    public void TestLijnlijstRemoveEdge()
    {
        // Arrange
        var graphInput = reader.GraphDatasets.lijnlijst;

        var graph = new Graaf();

        graph.BuildFromEdgeList(graphInput);

        // Act
        graph.RemoveEdge(0, 1);
        graph.RemoveEdge(0, 2);

        // Assert
        graph.PrintGraph();

        Assert.AreEqual(7, graph.Vertices.Count);
        Assert.AreEqual(0, graph.Vertices[0].Edges.Count);
    }

    [TestMethod]
    public void TestLijnlijstWeighted()
    {
        // Arrange
        var graphInput = reader.GraphDatasets.lijnlijst_gewogen;

        var graph = new Graaf();

        // Act
        graph.BuildFromEdgeList(graphInput);

        // Assert
        graph.PrintGraph();

        Assert.AreEqual(5, graph.Vertices.Count);
        Assert.AreEqual(0, graph.Vertices[4].Edges.Count);
        Assert.AreEqual(99, graph.Vertices[0].Edges[0].Weight);
    }

    [TestMethod]
    public void TestLijnlijstWeightedRemoveVertex()
    {
        // Arrange
        var graphInput = reader.GraphDatasets.lijnlijst_gewogen;

        var graph = new Graaf();

        graph.BuildFromEdgeList(graphInput);

        // Act
        graph.RemoveVertex(1);

        // Assert
        graph.PrintGraph();

        Assert.ThrowsException<KeyNotFoundException>(() => graph.Vertices[1]);
        Assert.AreEqual(4, graph.Vertices.Count);
        Assert.AreEqual(1, graph.Vertices[0].Edges.Count);
    }

    [TestMethod]
    public void TestLijnlijstWeightedRemoveEdge()
    {
        // Arrange
        var graphInput = reader.GraphDatasets.lijnlijst_gewogen;

        var graph = new Graaf();

        graph.BuildFromEdgeList(graphInput);

        // Act
        graph.RemoveEdge(2, 3);

        // Assert
        graph.PrintGraph();

        Assert.AreEqual(5, graph.Vertices.Count);
        Assert.AreEqual(0, graph.Vertices[2].Edges.Count);
    }

    [TestMethod]
    public void TestAdjacencyList()
    {
        // Arrange
        var graphInput = reader.GraphDatasets.verbindingslijst;

        var graph = new Graaf();

        // Act
        graph.BuildFromAdjacencyList(graphInput);

        // Assert
        graph.PrintGraph();

        Assert.AreEqual(7, graph.Vertices.Count);
        Assert.AreEqual(3, graph.Vertices[4].Edges.Count);
    }

    [TestMethod]
    public void TestAdjacencyListRemoveVertex()
    {
        // Arrange
        var graphInput = reader.GraphDatasets.verbindingslijst;

        var graph = new Graaf();

        graph.BuildFromAdjacencyList(graphInput);

        // Act
        graph.RemoveVertex(4);

        // Assert
        graph.PrintGraph();

        Assert.ThrowsException<KeyNotFoundException>(() => graph.Vertices[4]);
        Assert.AreEqual(6, graph.Vertices.Count);
        Assert.AreEqual(1, graph.Vertices[5].Edges.Count);
        Assert.AreEqual(2, graph.Vertices[2].Edges.Count);
    }

    [TestMethod]
    public void TestAdjacencyListRemoveEdge()
    {
        // Arrange
        var graphInput = reader.GraphDatasets.verbindingslijst;

        var graph = new Graaf();

        graph.BuildFromAdjacencyList(graphInput);

        // Act
        graph.RemoveEdge(2, 4);

        // Assert
        graph.PrintGraph();

        Assert.AreEqual(7, graph.Vertices.Count);
        Assert.AreEqual(2, graph.Vertices[2].Edges.Count);
    }

    [TestMethod]
    public void TestAdjacencyListWeighted()
    {
        // Arrange
        var graphInput = reader.GraphDatasets.verbindingslijst_gewogen;

        var graph = new Graaf();

        // Act
        graph.BuildFromAdjacencyListWeighted(graphInput);

        // Assert
        graph.PrintGraph();

        Assert.AreEqual(5, graph.Vertices.Count);
        Assert.AreEqual(2, graph.Vertices[0].Edges.Count);
        Assert.AreEqual(99, graph.Vertices[0].Edges[0].Weight);
        Assert.AreEqual(0, graph.Vertices[4].Edges.Count);
    }

    [TestMethod]
    public void TestAdjacencyListWeightedRemoveVertex()
    {
        // Arrange
        var graphInput = reader.GraphDatasets.verbindingslijst_gewogen;

        var graph = new Graaf();

        graph.BuildFromAdjacencyListWeighted(graphInput);

        // Act
        graph.RemoveVertex(4);

        // Assert
        graph.PrintGraph();

        Assert.ThrowsException<KeyNotFoundException>(() => graph.Vertices[4]);
        Assert.AreEqual(4, graph.Vertices.Count);
        Assert.AreEqual(0, graph.Vertices[3].Edges.Count);
        Assert.AreEqual(2, graph.Vertices[1].Edges.Count);
    }

    [TestMethod]
    public void TestAdjacencyListWeightedRemoveEdge()
    {
        // Arrange
        var graphInput = reader.GraphDatasets.verbindingslijst_gewogen;

        var graph = new Graaf();

        graph.BuildFromAdjacencyListWeighted(graphInput);

        // Act
        graph.RemoveEdge(2, 3);

        // Assert
        graph.PrintGraph();

        Assert.AreEqual(0, graph.Vertices[2].Edges.Count);
    }

    [TestMethod]
    public void TestAdjacencyMatrix()
    {
        // Arrange
        var graphInput = reader.GraphDatasets.verbindingsmatrix;

        var graph = new Graaf();

        // Act
        graph.BuildFromAdjacencyMatrix(graphInput);

        // Assert
        graph.PrintGraph();

        Assert.AreEqual(7, graph.Vertices.Count);
        Assert.AreEqual(2, graph.Vertices[0].Edges.Count);
        Assert.AreEqual(3, graph.Vertices[4].Edges.Count);
    }

    [TestMethod]
    public void TestAdjacencyMatrixRemoveVertex()
    {
        // Arrange
        var graphInput = reader.GraphDatasets.verbindingsmatrix;

        var graph = new Graaf();

        graph.BuildFromAdjacencyMatrix(graphInput);

        // Act
        graph.RemoveVertex(4);

        // Assert
        graph.PrintGraph();

        Assert.ThrowsException<KeyNotFoundException>(() => graph.Vertices[4]);
        Assert.AreEqual(6, graph.Vertices.Count);
        Assert.AreEqual(1, graph.Vertices[3].Edges.Count);
        Assert.AreEqual(1, graph.Vertices[5].Edges.Count);
    }

    [TestMethod]
    public void TestAdjacencyMatrixRemoveEdge()
    {
        // Arrange
        var graphInput = reader.GraphDatasets.verbindingsmatrix;

        var graph = new Graaf();

        graph.BuildFromAdjacencyMatrix(graphInput);

        // Act
        graph.RemoveEdge(2, 4);

        // Assert
        graph.PrintGraph();

        Assert.AreEqual(2, graph.Vertices[2].Edges.Count);
    }

    [TestMethod]
    public void TestAdjacencyMatrixWeighted()
    {
        // Arrange
        var graphInput = reader.GraphDatasets.verbindingsmatrix_gewogen;

        var graph = new Graaf();

        // Act
        graph.BuildFromAdjacencyMatrix(graphInput);

        // Assert
        graph.PrintGraph();

        Assert.AreEqual(5, graph.Vertices.Count);
        Assert.AreEqual(1, graph.Vertices[2].Edges.Count);
        Assert.AreEqual(50, graph.Vertices[1].Edges[0].Weight);
        Assert.AreEqual(0, graph.Vertices[4].Edges.Count);
    }

    [TestMethod]
    public void TestAdjacencyMatrixWeightedRemoveVertex()
    {
        // Arrange
        var graphInput = reader.GraphDatasets.verbindingsmatrix_gewogen;

        var graph = new Graaf();

        graph.BuildFromAdjacencyMatrix(graphInput);

        // Act
        graph.RemoveVertex(3);

        // Assert
        graph.PrintGraph();

        Assert.ThrowsException<KeyNotFoundException>(() => graph.Vertices[3]);
        Assert.AreEqual(4, graph.Vertices.Count);
        Assert.AreEqual(0, graph.Vertices[2].Edges.Count);
        Assert.AreEqual(2, graph.Vertices[1].Edges.Count);
    }

    [TestMethod]
    public void TestAdjacencyMatrixWeightedRemoveEdge()
    {
        // Arrange
        var graphInput = reader.GraphDatasets.verbindingsmatrix_gewogen;

        var graph = new Graaf();

        graph.BuildFromAdjacencyMatrix(graphInput);

        // Act
        graph.RemoveEdge(2, 3);

        // Assert
        graph.PrintGraph();

        Assert.AreEqual(0, graph.Vertices[2].Edges.Count);
    }
}