using System.Reflection;
using System.Runtime.CompilerServices;

namespace L20250408
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            for (int i = 1; i <= 1_000_000; i++)
            {
                list.Add(i);
            }

            //BinarySearch(list, 200_000);

            List<int> list2 = new List<int>{ 1, 3, 3, 3, 9, 11, 13 };

            //BinarySearch(list2, 2);
            LowerBound(list2, 20);
            UpperBound(list2, 3);
        }

        /// <summary>
        /// 선형 검색
        /// </summary>
        /// <param name="linearList"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool LinearSearch(List<int> linearList, int key)
        {
            foreach (int item in linearList)
            {
                if (item == key)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 이진 검색
        /// </summary>
        /// <param name="binaryList"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool BinarySearch(List<int> binaryList, int key)
        {
            int s = 0;
            int e = binaryList.Count;

            // (시작 + 끝) / 2 => +부분에서 오버 플러우가 발생 가능성이 있음
            // 시작 + (끝 - 시작) * 0.5

            while (s < e)
            {
                int middle = (e + s) / 2;
                Console.WriteLine("middleValue : " + binaryList[middle]);

                if (key < binaryList[middle])
                {
                    Console.WriteLine("왼쪽");
                    e = middle; // 끝 값은 중간 값을 포함 하지 않음
                }
                else if (key == binaryList[middle])
                {
                    Console.WriteLine("값 찾음" + binaryList[middle]);
                    return true;
                }
                else if (key > binaryList[middle])
                {
                    Console.WriteLine("오른쪽");
                    s = middle + 1; // 시작 값은 중간 값을 포함
                }
            }

            Console.WriteLine("값이 없음");
            return false;
        }


        /// <summary>
        /// 로어바운드
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int LowerBound(List<int> list, int key)
        {
            int s = 0;
            int e = list.Count;
            int index = -1;

            while (s < e)
            {
                int middle = (e + s) / 2;
                Console.WriteLine("middle : " + middle);

                if (key <= list[middle]) // 검색 범위를 왼쪽으로
                {
                    Console.WriteLine("왼쪽");
                    e = middle;
                    index = middle;
                }
                else // 검색 범위를 오른쪽으로
                {
                    Console.WriteLine("오른쪽");
                    s = middle + 1;
                }
            }

            Console.WriteLine("Value : " + list[index]);
            Console.WriteLine("index : " + index);
            return index;
        }

        /// <summary>
        /// 어퍼 바운드
        /// </summary>
        /// <param name="list"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int UpperBound(List<int> list, int key)
        {
            int s = 0;
            int e = list.Count;
            int index = -1;

            while (s < e)
            {
                int middle = (e + s) / 2;
                Console.WriteLine("middle : " + middle);

                if (key < list[middle])
                {
                    Console.WriteLine("왼쪽");
                    e = middle;
                    index = middle;
                }
                else
                {
                    Console.WriteLine("오른쪽");
                    s = middle + 1;
                }
            }

            Console.WriteLine("Value : " + list[index]);
            Console.WriteLine("index : " + index);
            return index;
        }
    }
}
