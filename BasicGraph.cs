using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjucent_Matrix
{
    class BasicGraph
    {
        //Number of edges in our graph
        private int totalVertices;
        //Contains all information about nodes in our graph
        private LinkedList<int>[] linkedListArray;

        // n => number of nodes in the graph
        public BasicGraph(int n)
        {
            this.totalVertices = n;
            this.linkedListArray = new LinkedList<int>[n];
            for (int i = 0; i < n; i++)
                linkedListArray[i] = new LinkedList<int>();
        }

        // Associating vertex with advartex
        public void addEdge(int vertex, int advertex)
        {
            this.linkedListArray[vertex].AddLast(advertex);
        }

        public void PrintAdjucentList()
        {
            for(int i = 0; i < this.linkedListArray.Length; i++)
            {
                StringBuilder temp = new StringBuilder();
                temp.Append("[ Node value: " + i + " with neighbours");
                foreach (var item in linkedListArray[i])
                {
                    temp.Append(" -> "+ item);
                }
                temp.Append(" ]");
                Console.WriteLine(temp);
            }
        }

        public void CreateAdjucentMatrix(BasicGraph graph)
        {
            int?[,] adjucentMatrix = new int?[graph.totalVertices, graph.totalVertices];
            for(int parentVertex = 0; parentVertex < graph.totalVertices; parentVertex++)
            {
                var parentNode = linkedListArray[parentVertex];
                for(int childNode = 0; childNode < graph.totalVertices; childNode++)
                {
                    if(parentVertex != childNode)
                    {
                        var arc = parentNode.Find(childNode);
                        if(arc != null)
                        {
                            adjucentMatrix[parentVertex, childNode] = 1;
                        }
                    }
                }
            }
            this.PrintAdjucentMatrix(adjucentMatrix, graph.totalVertices);
        }

        public void PrintAdjucentMatrix(int?[,] adjucentMatrix, int count)
        {
            StringBuilder temp = new StringBuilder();
            temp.Append("Nodes ");
            for(int i = 0; i < count; i++)
            {
                temp.Append(string.Format(" {0} ", i));
            }
            temp.Append("\n");
            for(int i = 0; i < count; i++)
            {
                temp.Append(string.Format(" {0} | [", i));
                for(int j = 0; j < count; j++)
                {
                    if(i == j)
                    {
                        temp.Append(" x ");
                    }else if(adjucentMatrix[i, j] == null)
                    {
                        temp.Append(" . ");
                    }
                    else
                    {
                        temp.Append(string.Format(" {0} ", adjucentMatrix[i, j]));
                    }
                }
                temp.Append(" ]\n");
            }
            Console.WriteLine(temp);
        }
    }
}
