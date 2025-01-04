namespace ADP_2024.Graph
{
    public class Graaf
    {
        public Dictionary<int, Vertex> Vertices = [];

        public void AddVertex(int id)
        {
            if (!Vertices.ContainsKey(id))
            {
                Vertices[id] = new Vertex(id);
            }
        }

        public void AddEdge(int id1, int id2, int weight = 0)
        {
            if (!Vertices.ContainsKey(id1))
            {
                AddVertex(id1);
            }

            if (!Vertices.ContainsKey(id2))
            {
                AddVertex(id2);
            }

            Vertex v1 = Vertices[id1];
            Vertex v2 = Vertices[id2];

            Edge edge = new(v2, weight);

            v1.Edges.Add(edge);
        }

        public void RemoveVertex(int id)
        {
            if (Vertices.ContainsKey(id))
            {
                foreach (var vertex in Vertices.Values)
                {
                    vertex.Edges.RemoveAll(e => e.Destination.Id == id);
                }

                Vertices.Remove(id);
            }
        }

        public void RemoveEdge(int id1, int id2)
        {
            if (Vertices.ContainsKey(id1) && Vertices.ContainsKey(id2))
            {
                Vertex v1 = Vertices[id1];

                v1.Edges.RemoveAll(e => e.Destination.Id == id2);
            }
        }

        public void BuildFromEdgeList(List<List<int>> edgeList)
        {
            foreach (var edge in edgeList)
            {
                int vertex1 = edge[0];

                int vertex2 = edge[1];

                int weight;

                try
                {
                    weight = edge[2];
                }
                catch (Exception)
                {
                    weight = 0;
                }

                AddEdge(vertex1, vertex2, weight);
            }
        }

        public void BuildFromAdjacencyList(List<List<int>> edgeList)
        {
            for (int i = 0; i < edgeList.Count; i++)
            {
                var neighbors = edgeList[i];

                foreach (int neighbor in neighbors)
                {
                    AddEdge(i, neighbor);
                }
            }
        }

        public void BuildFromAdjacencyListWeighted(List<List<List<int>>> edgeList)
        {
            for (int i = 0; i < edgeList.Count; i++)
            {
                var neighbors = edgeList[i];

                foreach (var neighbor in neighbors)
                {
                    int destination = neighbor[0];

                    int weight = neighbor[1];

                    AddEdge(i, destination, weight);
                }
            }
        }

        public void BuildFromAdjacencyMatrix(int[,] matrix)
        {
            int size = matrix.GetLength(0);

            for (int i = 0; i < size; i++)
            {
                AddVertex(i);
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        AddEdge(i, j, matrix[i, j]);
                    }
                }
            }
        }

        public void PrintGraph()
        {
            foreach (var vertex in Vertices.Values)
            {
                Console.Write($"Vertex {vertex.Id}: ");
                foreach (var edge in vertex.Edges)
                {
                    Console.Write($"({vertex.Id} -> {edge.Destination.Id}) ");
                }
                Console.WriteLine();
            }
        }

        public void PrintDistances()
        {
            Console.WriteLine("\nShortest Distances:");
            foreach (var vertex in Vertices.Values)
            {
                Console.WriteLine($"To Vertex {vertex.Id}: {(vertex.Distance == int.MaxValue ? "∞" : vertex.Distance)}");
            }
        }
    }

    public class Vertex
    {
        public int Id { get; set; }
        public List<Edge> Edges { get; set; }
        public int Distance { get; set; }
        public Vertex? Previous { get; set; }

        public Vertex(int id)
        {
            Id = id;
            Edges = [];
            Previous = null;
            Distance = int.MaxValue;
        }
    }

    public class Edge
    {
        public Vertex Destination { get; set; }
        public int Weight { get; set; }

        public Edge(Vertex dest, int weight)
        {
            Destination = dest;
            Weight = weight;
        }
    }
}