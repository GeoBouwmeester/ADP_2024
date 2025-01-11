using ADP_2024.Graph;

namespace ADP_2024.Dijkstra;

public class DijkstraAlgorithm
{
    public static void Dijkstra(Graaf graph, int startId)
    {
        if (!graph.Vertices.ContainsKey(startId))
        {
            throw new ArgumentException($"Start vertex with ID {startId} does not exist.");
        }

        foreach (var vertex in graph.Vertices.Values)
        {
            vertex.Distance = int.MaxValue;

            vertex.Previous = null;
        }

        graph.Vertices[startId].Distance = 0;

        PriorityQueue<Vertex, int> priorityQueue = new();

        priorityQueue.Enqueue(graph.Vertices[startId], 0);

        while (priorityQueue.Count > 0)
        {
            Vertex currentVertex = priorityQueue.Dequeue();

            foreach (Edge edge in currentVertex.Edges)
            {
                if (edge.Weight < 0)
                {
                    throw new InvalidOperationException("Graph contains negative edge weights, which cannot be handled by Dijkstra's algorithm.");
                }

                Vertex neighbor = edge.Destination;

                int newDistance = currentVertex.Distance + edge.Weight;

                if (newDistance < neighbor.Distance)
                {
                    neighbor.Distance = newDistance;

                    neighbor.Previous = currentVertex;

                    priorityQueue.Enqueue(neighbor, newDistance);
                }
            }
        }
    }

    public static List<int> GetShortestPath(Vertex target)
    {
        List<int> path = [];

        Vertex? current = target;

        while (current != null)
        {
            path.Insert(0, current.Id);

            current = current.Previous;
        }

        return path;
    }
}
