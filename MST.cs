using System;
using System.Collections.Generic;

public class Edge : IComparable<Edge>
{
    public int Source { get; }
    public int Destination { get; }
    public int Weight { get; }

    public Edge(int source, int destination, int weight)
    {
        Source = source;
        Destination = destination;
        Weight = weight;
    }

    public int CompareTo(Edge other)
    {
        return Weight.CompareTo(other.Weight);
    }
}

public class DisjointSet
{
    private int[] parent;
    private int[] rank;

    public DisjointSet(int size)
    {
        parent = new int[size];
        rank = new int[size];
        for (int i = 0; i < size; i++)
        {
            parent[i] = i;
            rank[i] = 0;
        }
    }

    public int Find(int u)
    {
        if (parent[u] != u)
        {
            parent[u] = Find(parent[u]);
        }
        return parent[u];
    }

    public void Union(int u, int v)
    {
        int rootU = Find(u);
        int rootV = Find(v);

        if (rootU != rootV)
        {
            if (rank[rootU] > rank[rootV])
            {
                parent[rootV] = rootU;
            }
            else if (rank[rootU] < rank[rootV])
            {
                parent[rootU] = rootV;
            }
            else
            {
                parent[rootV] = rootU;
                rank[rootU]++;
            }
        }
    }
}

public class KruskalMST
{
    public static List<Edge> FindMST(int vertices, List<Edge> edges)
    {
        List<Edge> result = new List<Edge>();
        edges.Sort();

        DisjointSet ds = new DisjointSet(vertices);

        foreach (var edge in edges)
        {
            int rootU = ds.Find(edge.Source);
            int rootV = ds.Find(edge.destination);

            if (rootU != rootV)
            {
                result.Add(edge);
                ds.Union(rootU, rootV);
            }
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        int vertices = 4;
        List<Edge> edges = new List<Edge>
        {
            new Edge(0, 1, 10),
            new Edge(0, 2, 6),
            new Edge(0, 3, 5),
            new Edge(1, 3, 15),
            new Edge(2, 3, 4)
        };

        List<Edge> mst = KruskalMST.FindMST(vertices, edges);

        Console.WriteLine("Edges in the Minimum Spanning Tree:");
        foreach (var edge in mst)
        {
            Console.WriteLine($"{edge.Source} -- {edge.Destination} == {edge.Weight}");
        }
    }
}