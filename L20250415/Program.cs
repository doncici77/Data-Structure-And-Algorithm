using System.Collections.Generic;

namespace L20250415
{
    struct Edge
    {
        public int Next
        {
            get;
            set;
        }

        public int Wegit
        {
            get;
            set;
        }

        public Edge(int next, int wegit)
        {
            Next = next;
            Wegit = wegit;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<int>[] neighbors = new List<int>[7];

            for (int i = 0; i < neighbors.Length; i++)
            {
                neighbors[i] = new List<int>();
            }

            #region 그래프 구성
            neighbors[0].Add(1);

            neighbors[1].Add(0);
            neighbors[1].Add(2);
            neighbors[1].Add(3);

            neighbors[2].Add(1);
            neighbors[2].Add(5);
            neighbors[2].Add(6);

            neighbors[3].Add(1);
            neighbors[3].Add(4);
            neighbors[3].Add(5);

            neighbors[4].Add(3);

            neighbors[5].Add(2);
            neighbors[5].Add(3);

            neighbors[6].Add(2);
            #endregion

            Console.WriteLine("깊이 우선 탐색");

            #region 깊이 우선 탐색
            // 각 정점마다 방문 여부 기록
            bool[] isVisited = new bool[7];
            // visited[index] : index번째 방문 여부

            // 2. 스택을 생성한다.
            Stack<int> vertex = new Stack<int>();
            vertex.Push(0);

            // 3. 모든 정점을 방문할때 까지 반복한다.
            while (vertex.Count > 0)
            {
                // 3-1. 다음에 방문할 정점을 가져온다.
                int vertexToVisit = vertex.Pop();

                // 이미 방문 했을 경우
                if (isVisited[vertexToVisit])
                {
                    continue;
                }

                // 3-2. 방문여부를 기록 한다.
                Console.WriteLine(vertexToVisit + " 을 방문함.");
                isVisited[vertexToVisit] = true;

                // 3-3. 주변 노드를 방문한다.

                // vertexToVisit[ 0 ]
                // [0] -> [1]
                for (int i = neighbors[vertexToVisit].Count - 1; i >= 0; i--)
                {
                    int neighbor = neighbors[vertexToVisit][i];

                    // 방문하지 않은 정점만 스택에 추가한다.
                    if (!isVisited[neighbor])
                    {
                        vertex.Push(neighbor);
                    }
                }
            }
            #endregion

            Queue<int> visited = new Queue<int>();
            visited.Peek();

            Console.WriteLine("---------------");
            Console.WriteLine("너비 우선 탐색");

            #region 너비 우선 탐색
            bool[] isVisited2 = new bool[7];

            Queue<int> vertex2 = new Queue<int>();
            vertex2.Enqueue(0);

            while (vertex2.Count > 0)
            {
                int vertexToVisit = vertex2.Dequeue();

                if (isVisited2[vertexToVisit])
                {
                    continue;
                }

                Console.WriteLine(vertexToVisit + " 을 방문함.");
                isVisited2[vertexToVisit] = true;

                foreach (int neighbor in neighbors[vertexToVisit])
                {
                    if (isVisited2[neighbor] == false)
                    {
                        vertex2.Enqueue(neighbor);
                    }
                }
            }
            #endregion

            Console.WriteLine("---------------");
            Console.WriteLine("깊이 우선 탐색(재귀)");

            #region 깊이 우선 탐색(재귀)
            bool[] isVisited3 = new bool[7];
            DFS(0, isVisited3, neighbors);
            #endregion
        }

        /// <summary>
        /// 정점은 방문 하는 일을 함
        /// </summary>
        static void DFS(int vertexToVisit, bool[] isVisited, List<int>[] neighbors)
        {
            if (isVisited[vertexToVisit])
            {
                return;
            }

            Console.WriteLine(vertexToVisit + " 을 방문함.");
            isVisited[vertexToVisit] = true;

            foreach(int neighbor in neighbors[vertexToVisit])
            {
                if (!isVisited[neighbor])
                {
                    DFS(neighbor, isVisited, neighbors);
                }
            }
        }

        /// <summary>
        /// 인접 리스트 예시
        /// </summary>
        /// <param name="args"></param>
        static void Main2(string[] args)
        {
            List<Edge>[] edges = new List<Edge>[7];

            edges[0].Add(new Edge(1, 1));

            edges[1].Add(new Edge(0, 1));
            edges[1].Add(new Edge(2, 2));
            edges[1].Add(new Edge(3, 2));

            edges[2].Add(new Edge(1, 2));
            edges[2].Add(new Edge(5, 6));
            edges[2].Add(new Edge(6, 3));

            edges[3].Add(new Edge(1, 2));
            edges[3].Add(new Edge(4, 1));
            edges[3].Add(new Edge(5, 4));

            edges[4].Add(new Edge(3, 1));

            edges[5].Add(new Edge(3, 4));
            edges[5].Add(new Edge(2, 6));

            edges[6].Add(new Edge(2, 3));
        }
    }

    /// <summary>
    /// 원형 배열 큐
    /// </summary>
    internal class QueueTest
    {
        public int[] queue = new int[5];
        public int front = 0;
        public int back = 0;
        public int size = 0;

        static void Main1(string[] args)
        {
            QueueTest queue = new QueueTest();

            for (int i = 0; i < 20; i++)
            {
                queue.Push(i);
                queue.Push(i + 1);
                queue.Push(i + 2);
                Console.WriteLine(", queue.Pop() : " + queue.Pop());

                for (int j = 0; j < 5; j++)
                {
                    Console.Write($"[{queue.queue[j]}] ");
                }

                Console.WriteLine();
            }
        }

        public void Push(int x)
        {
            if (size != queue.Length)
            {
                if (back >= queue.Length)
                {
                    back = 0;
                }
                Console.Write("queue.back : " + back + " ");
                queue[back++] = x;
                size++;
            }
            else
            {
                Console.Write("큐가 꽉참 ");
            }
        }

        public int Pop()
        {
            if (size != 0)
            {
                if (front >= queue.Length)
                {
                    front = 0;
                }

                size--;
                return queue[front++];
            }

            return -1;
        }
    }
}
