using System;

namespace projeMain
{
    class Dijkstra
    {
        private static int MinKey(int[] mesafe, bool[] shortestPathTreeSet, int verticesCount)
        {
            int minIndex = 0;
            int minumum = int.MaxValue;

            for (int v = 0; v < verticesCount; ++v)     //min indexi dönmek için fonksiyon
            {
                if (shortestPathTreeSet[v] == false && mesafe[v] <= minumum)
                {
                    minumum = mesafe[v];            
                    minIndex = v;
                }
            }

            return minIndex;
        }

        private static void Printf(int[] mesafe, int verticesCount)
        {
            Console.WriteLine("Vertex\t  Distance from source");        //Mesafeleri ve vertexleri bastırma
            for (int i = 0; i < verticesCount; ++i)
                Console.WriteLine("{0}\t  {1}", i, mesafe[i]);
        }

        public static void DijkstraMethod(int[,] graph, int kaynak, int verticesCount)
        {
            int[] mesafe = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {                               //hepsine maxvalue ve false değerleriyle dolduruyoruz
                mesafe[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            mesafe[kaynak] = 0;

            for (int count = 0; count < verticesCount - 1; ++count)     //minkey fonk yolluyoruz
            {
                int u = MinKey(mesafe, shortestPathTreeSet, verticesCount); //gelen minimumu true yapıp
                shortestPathTreeSet[u] = true;                              //diğer vertexlerle mesafelerine bakacağız

                for (int v = 0; v < verticesCount; ++v)
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && mesafe[u] + graph[u, v] < mesafe[v] && mesafe[u] != int.MaxValue)
                        mesafe[v] = mesafe[u] + graph[u, v];
            }

            Printf(mesafe, verticesCount);
        }
	}
}
