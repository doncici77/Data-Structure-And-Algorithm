using System;

namespace SandBox_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                for(int j = 0; j < i + 1; j++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }

            A(1);
        }

        static void A(int num)
        {
            // 기저 조건
            if(num > 5)
            {
                return;
            }

            // 반복 구문
            B(num);
            if(num < 5)
            {
                Console.WriteLine();
            }
            num++;

            // 재귀 조건
            A(num);
        }

        static void B(int num)
        {
            if(1 > num)
            {
                return;
            }

            Console.Write('+');
            num--;

            B(num);
        }
    }
}
