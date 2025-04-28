namespace L20250428
{

    class Astar
    {
        class AstarNode
        {
            // 정점 데이더
            public int X;
            public int Y;
            
            public int F;
            public AstarNode Path;
        }

        const int MAX_Y = 10;
        const int MAX_X = 10;
        static char[][] map = new char[MAX_Y][];

        // 정점 : 좌표 => x, y
        static int startX, startY, endX, endY;

        // FindStartAndEnd() : 시작 지점과 도착 지점을 찾는 함수
        static void FindStartAndEnd()
        {
            for (int y = 0; y < MAX_Y; y++)
            {
                for(int x = 0; x < MAX_X; x++)
                {
                    if(map[y][x] == 'S')
                    {
                        startX = x;
                        startY = y;
                    }
                    else if (map[y][x] == 'G')
                    {
                        endX = x;
                        endY = y;
                    }
                }
            }
        }

        // 맵을 구성한다.
        static void ConstructMap()
        {
            map[0] = "          ".ToCharArray();
            map[1] = "          ".ToCharArray();
            map[2] = "          ".ToCharArray();
            map[3] = "    #     ".ToCharArray();
            map[4] = " S  #  G  ".ToCharArray();
            map[5] = "    #     ".ToCharArray();
            map[6] = "          ".ToCharArray();
            map[7] = "          ".ToCharArray();
            map[8] = "          ".ToCharArray();
            map[9] = "          ".ToCharArray();
        }

        // 휴리스틱을 구하는 함수 => 맨헤튼 거리
        // 입력 좌표 두개
        static int GetHenuristic(int x1, int y1, int x2, int y2)
        {
            int dx = (int)Math.Abs(x1 - x2);
            int dy = (int)Math.Abs(y1 - y2);

            return dx + dy;
        }

        static void SetPath()
        {
            // 경로 생성
            AstarNode[,] path = new AstarNode[MAX_Y, MAX_X]; // map과 대응되는 path 객체 생성
            for (int y = 0; y < MAX_Y; y++)
            {
                for (int x = 0; x < MAX_X; x++)
                {
                    path[x, y] = new AstarNode() { X = x, Y = y };
                }
            }

            // 우선 순위 큐
            // 원소 : 노드 (AstarNode)
            // 값   : F 값 (int)
            PriorityQueue<AstarNode, int> priorityQueue = new PriorityQueue<AstarNode, int>();
            priorityQueue.Enqueue(path[startX, startY], path[startX, startY].F);

            // 8방향을 탐색한다.
            int[] dy = { -1, -1, -1, 0, 1, 1, 1, 0 };
            int[] dx = { -1, 0, 1, 1, 1, 0, -1, -1 };
            int[] dg = { 14, 10, 14, 10, 14, 10, 14, 10 };

            // 경로를 찾을 때까지 반복
            while (priorityQueue.Count > 0)
            {

                // 다음에 방문할 정점을 가져온다
                AstarNode next = priorityQueue.Dequeue();

                // 8방향으로 탐색 진행
                for (int i = 0; i < 8; i++)
                {
                    int nx = next.X + dx[i];
                    int ny = next.Y + dy[i];

                    // 유효성 검사
                    if (nx < 0 || ny < 0 || nx >= MAX_X || ny >= MAX_Y)
                    {
                        continue;
                    }

                    // 이동 가능한가?
                    if (map[ny][nx] == '#')
                    {
                        continue;
                    }

                    // ㄴ 부분 최단 경로 찾아 큐에 삽입
                    // F(x) = G(x) + H(x)
                    int f = dg[i] + 10 * GetHenuristic(nx, ny, endX, endY);
                    AstarNode newNode = path[ny, ny];
                    if (newNode.F > f)
                    {
                        newNode.F = f;
                        newNode.Path = next;
                        priorityQueue.Enqueue(newNode, newNode.F);
                    }
                }
            }

            AstarNode current = path[endX, endY].Path;
            while(true)
            {
                if(current.X == startX && current.Y == startY)
                {

                }
            }
        }

        static void Main(string[] args)
        {
            ConstructMap();
            FindStartAndEnd();
        }
    }

    #region 다익스트라 알고리즘
    class Dijkstra
    {
        private static int[][] graph;
        static int[] path;

        static void Main1(string[] args)
        {

            ConstructGraph(); // 그래프 초기화

            Console.WriteLine(GetDistance(0, 3));
        }

        public static void ConstructGraph()
        {
            graph = new int[7][];

            graph[0] = new int[] { 0, 7, INF, INF, 3, 10, INF };
            graph[1] = new int[] { 7, 0, 4, 10, 2, 6, INF };
            graph[2] = new int[] { INF, 4, 0, 2, INF, INF, INF };
            graph[3] = new int[] { INF, 10, 2, 0, 11, 9, 4 };
            graph[4] = new int[] { 3, 2, INF, 11, 0, INF, 5 };
            graph[5] = new int[] { 10, 6, INF, 9, INF, 0, INF };
            graph[6] = new int[] { INF, INF, INF, 4, 5, INF, 0 };
        }

        const int INF = 987654321;
        const int Noway = -1;
        public static int GetDistance(int startNode, int endNode)
        {
            // 1. 시작 노드에서 다른 모든 노드까지의 거리를 저장할 배열
            int[] minDistances = new int[7];

            for (int i = 0; i < minDistances.Length; i++)
            {
                minDistances[i] = INF; // INF는 매우 큰 수 (예: int.MaxValue)
            }
            minDistances[startNode] = 0;

            // path[i]는 
            path = new int[7];
            for(int i = 0; i < path.Length; i++)
            {
                path[i] = Noway;
            }
            path[startNode] = 0;

            // 2. 방문할 노드 중 현재 최단 거리를 가진 노드를 선택하기 위한 우선순위 큐
            PriorityQueue<int, int> priorityQueue = new();
            priorityQueue.Enqueue(startNode, minDistances[startNode]);

            // 3. 모든 최단 경로를 찾을 때까지 반복
            while (priorityQueue.Count > 0)
            {
                int currentNode = priorityQueue.Dequeue();

                // 3-2. 현재 노드를 거쳐 다른 노드로 가는 경로를 검사
                for (int neighbor = 0; neighbor < graph[currentNode].Length; neighbor++)
                {
                    int newDistance = minDistances[currentNode] + graph[currentNode][neighbor]; // start -> current -> neighbor 거리

                    // 더 짧은 경로 발견 시 갱신
                    if (minDistances[neighbor] > newDistance)
                    {
                        path[neighbor] = currentNode;
                        minDistances[neighbor] = newDistance;
                        priorityQueue.Enqueue(neighbor, newDistance);
                    }
                }
            }

            // 경로 출력
            Stack<int> stack = new Stack<int>();
            stack.Push(endNode);
            int pathNode = path[endNode];
            while(pathNode > 0)
            {
                stack.Push(pathNode);

                pathNode = path[pathNode];
            }

            stack.Push(startNode);

            for (int i = stack.Count - 1; i >= 0; i--)
            {
                Console.Write(stack.Pop() + " ");
            }

            Console.WriteLine();
            
            return minDistances[endNode];
        }
    }
    #endregion

    #region 힙 구현
    class MinHeap
    {
        List<int> tree = new List<int>();

        // Peek : 최소 원소를 반환
        public int Peek()
        {
            return tree[0];
        }

        // 인큐
        public void Enqueue(int newValue)
        {
            tree.Add(newValue);

            int newNodeIndex = tree.Count - 1;
            int parentsNodeIndex;

            while (newNodeIndex >= 0)
            {

                parentsNodeIndex = (newNodeIndex - 1) / 2;

                if (newNodeIndex >= 0 && tree[parentsNodeIndex] > tree[newNodeIndex]) // 크기 비교 교체
                {
                    int empty = tree[parentsNodeIndex];
                    tree[parentsNodeIndex] = tree[newNodeIndex];
                    tree[newNodeIndex] = empty;

                    newNodeIndex = parentsNodeIndex;
                }
                else
                {
                    return;
                }
            }
        }

        // 디큐
        public int Dequeue()
        {
            int deleteData = tree[0];

            tree[0] = tree[tree.Count - 1];
            tree.RemoveAt(tree.Count - 1);

            int parentsIndex = 1;

            while (parentsIndex * 2 < tree.Count)
            {
                int leftIndex = parentsIndex * 2;
                int rightIndex = parentsIndex * 2 + 1;

                int child = leftIndex;
                if (rightIndex < tree.Count && tree[rightIndex - 1] < tree[child - 1])
                {
                    child = rightIndex;
                }

                if (tree[parentsIndex - 1] < tree[child - 1])
                {
                    break;
                }

                int tmep = tree[parentsIndex - 1];
                tree[parentsIndex - 1] = tree[child - 1];
                tree[child - 1] = tmep;

                parentsIndex = child;
            }

            return deleteData;
        }

    }
    #endregion
}
