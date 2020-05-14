using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 计数排序
{   
    //基于 整数 的排序，先求出整数数组的最大值与最小值，相减得计数空间，然后计算每个数字出现得频率，然后根据频率排序
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 43, 69, 11, 72, 28, 21, 56, 80, 48, 94, 32, 8,8 };

            CounterArray(array);
            foreach(var temp in array)
            {
                Console.Write(temp + " ");
            }
            Console.ReadKey();
        }

        public static void CounterArray(int[] array)
        {
            if (array.Length == 0) return;
            int min = array[0];
            int max = min;
            //找出最大值与最小值
            foreach(var temp in array)
            {
                if (temp > max) max = temp;
                else if (temp < min) min = temp;
            }
            int[] counting = new int[max - min + 1];
            //记录每个数字出现的频率
            for(int i = 0; i < array.Length; i++)
            {
                counting[array[i] - min] += 1;//-min使下标从0开始计数，下标+min便是数组中所拥有得数字
            }
            int index = -1;//下标从0开始记录
            for(int i = 0; i < counting.Length; i++)
            {
                for(int j = 0; j < counting[i]; j++)
                {
                    index++;
                    array[index] = i + min;//根据频率排序，下标+min即为index所需要数字
                }
            }
        }
    }
}
