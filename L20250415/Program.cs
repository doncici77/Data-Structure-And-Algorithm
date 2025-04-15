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
