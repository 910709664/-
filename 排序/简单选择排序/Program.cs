using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单选择排序
{
    class Program
    {
        static void SelectSort(int[] arrary)
        {
            for(int i = 0; i < arrary.Length - 1; i++)
            {
                int min = arrary[i];    //选择第一个为最小值，则先排序最小值，若选择最大值，则先排序最大值
                int minIndex = i;
                for (int j = i + 1; j < arrary.Length; j++)
                {
                    if (arrary[j] < min)    //如果后面的数更小则重新给min赋值
                    {
                        min = arrary[j];
                        minIndex = j;
                    }
                }
                //使最小值在前面
                if (minIndex != i)
                {
                    int temp = arrary[i];
                    arrary[i] = arrary[minIndex];
                    arrary[minIndex] = temp;
                }
            }
        }
        static void Main(string[] args)
        {
            int[] array = new int[] { 42, 20, 17, 27, 13, 17, 8, 47 };
            SelectSort(array);
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();
        }
    }
}
