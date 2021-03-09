using System;

namespace projeMain
{
    class Breadth
    {
        public struct Vertex
        {
            public char Label;
            public bool Visited;
        }
        private static int queueItemCount = 0;
        private static int vertexCount = 0;
        private static int rear = -1;
        private static int front = 0;

        private static void Insert(int[] queue, int data)
        {
            queue[++rear] = data;
            queueItemCount++;       //Kuyruğa ekleme
        }

        private static int Remove(int[] queue)
        {
            queueItemCount--;
            return queue[front++];      //Kuyruktan silme
        }

        private static bool IsQueueEmpty()
        {
            return queueItemCount == 0;  //Kuyruk Boş mu
        }

        public static void VertexEkleme(Vertex[] arrVertices, char label)
        {
            Vertex vertex = new Vertex();   //Vertex ekleme visited değerini false yapma
            vertex.Label = label;
            vertex.Visited = false;
            arrVertices[vertexCount++] = vertex;
        }

        public static void EdgeEkleme(int[,] adjacencyMatrix, int start, int end)
        {
            adjacencyMatrix[start, end] = 1;    //Kenar ekleme
            adjacencyMatrix[end, start] = 1;
        }

        private static void DisplayVertex(Vertex[] arrVertices, int vertexIndex)
        {
            Console.Write( arrVertices[vertexIndex].Label + "   "); //Label için verdiğimiz isimlerin bastırılması
        }

        private static int GetAdjacentUnvisitedVertex(Vertex[] arrVertices, int[,] adjacencyMatrix, int vertexIndex)
        {
            int i;
            for (i = 0; i < vertexCount; i++) //Ziyaret edilip edilmediği bilgi veya indexinin yollanması
            {
                if (adjacencyMatrix[vertexIndex, i] == 1 && arrVertices[i].Visited == false)
                    return i;
            }
            return -1;
        }

        public static void BreadthFirstSearch(Vertex[] arrVertices, int[,] adjacencyMatrix, int[] queue)
        {
            int i;
            arrVertices[0].Visited = true;
            DisplayVertex(arrVertices, 0);
            Insert(queue, 0);
            int unvisitedVertex;
            while (!IsQueueEmpty())
            {
                int tempVertex = Remove(queue);
                while ((unvisitedVertex = GetAdjacentUnvisitedVertex(arrVertices, adjacencyMatrix, tempVertex)) != -1)
                {
                    arrVertices[unvisitedVertex].Visited = true;  //Zıyaret edilmemişşe ziyaret et ve onu sergile, kuyruğa ekle
                    DisplayVertex(arrVertices, unvisitedVertex);
                    Insert(queue, unvisitedVertex);
                }
            }
            for (i = 0; i < vertexCount; i++)
            {
                arrVertices[i].Visited = false;         //visited değeri false yapma son olarak
            }
        }
	}
}
