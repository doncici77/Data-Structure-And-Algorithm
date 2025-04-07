using System.Collections.Generic;

namespace L20250407
{
    internal class Program
    {
        static int N;

        static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());

            Console.WriteLine("어느 한 컴퓨터공학과 학생이 유명한 교수님을 찾아가 물었다.");
            Msg(0);
        }

        static void Msg(int level)
        {
            _Set(level);
            Console.WriteLine("\"재귀함수가 뭔가요?\"");

            if(level == N)
            {
                _Set(level);
                Console.WriteLine("\"재귀함수는 자기 자신을 호출하는 함수라네\"");
                _Set(level);
                Console.WriteLine("라고 답변하였지.");

                return;
            }

            _Set(level);
            Console.WriteLine("\"잘 들어보게. 옛날옛날 한 산 꼭대기에 이세상 모든 지식을 통달한 선인이 있었어.");
            _Set(level);
            Console.WriteLine("마을 사람들은 모두 그 선인에게 수많은 질문을 했고, 모두 지혜롭게 대답해 주었지.");
            _Set(level);
            Console.WriteLine("그의 답은 대부분 옳았다고 하네. 그런데 어느 날, 그 선인에게 한 선비가 찾아와서 물었어.\"");

            Msg(level + 1);

            _Set(level);
            Console.WriteLine("라고 답변하였지.");
        }

        static void _Set(int level)
        {
            for(int i = 0; i < level; i++)
            {
                Console.Write("____");
            }
        }
    }
}
