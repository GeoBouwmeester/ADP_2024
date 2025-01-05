namespace ADP_2024_Test.Graph;

public class GraphGenerator
{
    // Generate a random graph with `numVertices` vertices and `numEdges` edges
    public static List<List<int>> GenerateEdgeList(int numVertices, int numEdges)
    {
        Random rand = new Random();
        List<List<int>> edgeList = new List<List<int>>();

        for (int i = 0; i < numEdges; i++)
        {
            int vertex1 = rand.Next(numVertices);  // Random vertex1
            int vertex2 = rand.Next(numVertices);  // Random vertex2
            int weight = rand.Next(1, 11);         // Random weight between 1 and 10

            // Ensure no self-loops
            while (vertex1 == vertex2)
            {
                vertex2 = rand.Next(numVertices);
            }

            edgeList.Add(new List<int> { vertex1, vertex2, weight });
        }

        return edgeList;
    }

    public static List<List<int>> GenerateAdjacencyList(int numVertices, int numEdges)
    {
        Random rand = new Random();
        List<List<int>> adjacencyList = new List<List<int>>();

        // Initialize adjacency list with empty lists
        for (int i = 0; i < numVertices; i++)
        {
            adjacencyList.Add(new List<int>());
        }

        // Generate edges and populate adjacency list
        for (int i = 0; i < numEdges; i++)
        {
            int vertex1 = rand.Next(numVertices);
            int vertex2 = rand.Next(numVertices);

            // Ensure no self-loops
            while (vertex1 == vertex2)
            {
                vertex2 = rand.Next(numVertices);
            }

            adjacencyList[vertex1].Add(vertex2);
        }

        return adjacencyList;
    }

    public static List<List<List<int>>> GenerateAdjacencyListWeighted(int numVertices, int numEdges)
    {
        Random rand = new Random();
        List<List<List<int>>> adjacencyListWeighted = new List<List<List<int>>>();

        // Initialize adjacency list with empty lists
        for (int i = 0; i < numVertices; i++)
        {
            adjacencyListWeighted.Add(new List<List<int>>());
        }

        // Generate weighted edges
        for (int i = 0; i < numEdges; i++)
        {
            int vertex1 = rand.Next(numVertices);
            int vertex2 = rand.Next(numVertices);
            int weight = rand.Next(1, 11);  // Random weight between 1 and 10

            // Ensure no self-loops
            while (vertex1 == vertex2)
            {
                vertex2 = rand.Next(numVertices);
            }

            adjacencyListWeighted[vertex1].Add(new List<int> { vertex2, weight });
        }

        return adjacencyListWeighted;
    }

    public static int[,] GenerateAdjacencyMatrix(int numVertices, int numEdges)
    {
        Random rand = new Random();
        int[,] adjacencyMatrix = new int[numVertices, numVertices];

        // Initialize adjacency matrix with zeros
        for (int i = 0; i < numVertices; i++)
        {
            for (int j = 0; j < numVertices; j++)
            {
                adjacencyMatrix[i, j] = 0;
            }
        }

        // Generate edges and populate adjacency matrix
        for (int i = 0; i < numEdges; i++)
        {
            int vertex1 = rand.Next(numVertices);
            int vertex2 = rand.Next(numVertices);
            int weight = rand.Next(1, 11);  // Random weight between 1 and 10

            // Ensure no self-loops
            while (vertex1 == vertex2)
            {
                vertex2 = rand.Next(numVertices);
            }

            adjacencyMatrix[vertex1, vertex2] = weight;
        }

        return adjacencyMatrix;
    }
}
