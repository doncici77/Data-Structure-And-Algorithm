using System.Diagnostics.Metrics;
using System.Text;

namespace L20250421
{
    class BJ2667
    {
        // ref = 값을 "참조로 전달"
        static void DFS(int x, int y, bool[,] isVisited, string[] Map, int N, ref int count1)
        {
            if( x < 0 || x >= N || // 좌표가 유효하지 않거나
                y < 0 || y >= N )
            {
                return;
            }

            if(isVisited[x, y]) // 방문을 이미 했거나
            {
                return;
            }

            if(Map[x][y] != '1') // 집(" 1 ")이 아니라면
            {
                return;
            }

            isVisited[x, y] = true;
            count1++;

            DFS(x - 1, y, isVisited, Map, N, ref count1); // 위

            DFS(x + 1, y, isVisited, Map, N, ref count1); // 아래

            DFS(x, y - 1, isVisited, Map, N, ref count1); // 왼쪽

            DFS(x, y + 1, isVisited, Map, N, ref count1); // 오른쪽
        }

        public static void Main(string[] args)
        {
            int N; // 지도의 크기
            string[] Map = new string[25]; // 맵 데이터
            bool[,] isVisited = new bool[25, 25]; // 방문 여부
            List<int> townData = new List<int>(); // (단지내의 집의 개수)의 집합
            int count1 = 0; // 특정 단지내의 집의 개수

            N = int.Parse(Console.ReadLine());

            for(int i = 0; i < N; i++)
            {
                Map[i] = Console.ReadLine();
            }

            int townCount = 0; // 단지의 개수
            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < N; j++)
                {
                    if (Map[i][j] == '1' && isVisited[i, j] == false)
                    {
                        count1 = 0;

                        DFS(i, j, isVisited, Map, N, ref count1);

                        townData.Add(count1);

                        townCount++;
                    }
                }
            }

            Console.WriteLine(townCount.ToString());
            townData.Sort();

            for(int i = 0; i < townCount; i++)
            {
                Console.WriteLine(townData[i].ToString());
            }
        }
    }
}
