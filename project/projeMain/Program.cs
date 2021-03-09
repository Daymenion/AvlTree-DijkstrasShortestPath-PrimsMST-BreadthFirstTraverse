using System;

namespace projeMain
{

    class Program
    {
        static void Main(string[] args)
        {
            AvlTree tree = new AvlTree();

            tree.Add(16);
            tree.Add(29820);
            tree.Add(3621);
            tree.Add(401);
            tree.Add(50);
            tree.Add(254);

            tree.DisplayTree(); 

            /* The constructed AVL Tree would be when input 30 45 35 25 15 55
                35 
                / \ 
               25  45 
               / \  \ 
              15 30  55 
            */

            int[,] graph = {
                { 0, 4, 0, 5, 0, 4, 0, 8, 0 },
                { 4, 0, 8, 0, 6, 0, 0, 11, 0 },
                { 0, 8, 0, 7, 0, 4, 0, 2, 2 },
                { 5, 0, 7, 0, 9, 0, 14, 5, 0 },
                { 0, 6, 0, 9, 0, 10, 0, 3, 1 },
                { 4, 0, 4, 0, 10, 0, 2, 0, 5 },
                { 0, 0, 0, 14, 0, 2, 0, 1, 6 },
                { 8, 11, 2, 5, 3, 0, 1, 0, 7 },
                { 0, 0, 2, 0, 1, 5, 6, 7, 0 }
            };
            Console.WriteLine("\n\nDijkstra Method Output:");
            Dijkstra.DijkstraMethod(graph, 0, 9);
            Console.WriteLine("\nPrims Method Output:");
            Prims.Prim(graph, 9);
            Console.WriteLine();
            int max = 9;
            int[] queue = new int[max];
            Breadth.Vertex[] arrVertices = new Breadth.Vertex[max];

            Breadth.VertexEkleme(arrVertices, 'A');
            Breadth.VertexEkleme(arrVertices, 'B');
            Breadth.VertexEkleme(arrVertices, 'C');
            Breadth.VertexEkleme(arrVertices, 'D');
            Breadth.VertexEkleme(arrVertices, 'E');
            Breadth.VertexEkleme(arrVertices, 'F');
            Breadth.VertexEkleme(arrVertices, 'G');
            Breadth.VertexEkleme(arrVertices, 'H');
            Breadth.VertexEkleme(arrVertices, 'I');

            Breadth.EdgeEkleme(graph, 0, 1);
            Breadth.EdgeEkleme(graph, 8, 2);
            Breadth.EdgeEkleme(graph, 0, 3);
            Breadth.EdgeEkleme(graph, 8, 4);
            Breadth.EdgeEkleme(graph, 0, 5);
            Breadth.EdgeEkleme(graph, 5, 6);
            Breadth.EdgeEkleme(graph, 6, 7);
            Breadth.EdgeEkleme(graph, 3, 8);

            Console.Write("Breadth First Search: ");
            Breadth.BreadthFirstSearch(arrVertices, graph, queue);
            Console.ReadLine();
        }
    }
    
}
