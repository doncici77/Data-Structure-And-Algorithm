using System;

namespace SandBox_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] a = new string[10];
            a[0] = "test";

            memo[1] = 1;
            memo[2] = 1;

            int i = Fibo(40);
            Console.WriteLine(i);
        }

        static int[] memo = new int[100];
        static int Fibo(int n)
        {
            if(memo[n] != 0)
            {
                return memo[n];
            }

            memo[n] = Fibo(n - 2) + Fibo(n - 1);
            return memo[n];
        }

        static void Test(int num)
        {
            if(num < 0)
            {
                return;
            }

            Test(num - 1);

            Console.WriteLine(num);
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
