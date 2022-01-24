using System;

namespace Adjucent_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicGraph graph = new BasicGraph(8);
            graph.addEdge(0, 1);
            graph.addEdge(1, 3);
            graph.addEdge(1, 4);
            graph.addEdge(2, 5);
            graph.addEdge(3, 5);
            graph.addEdge(4, 6);
            graph.addEdge(6, 7);

            graph.PrintAdjucentList();
            Console.WriteLine("\n\n");
            graph.CreateAdjucentMatrix(graph);

        }
    }
}
