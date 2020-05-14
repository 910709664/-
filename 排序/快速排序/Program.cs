using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 快速排序
{   

    class Program
    {
        static void QuickSort(int[] array, int left, int right)
        {

            if (left < right)
            {
                int q = Partition(array, left, right);
                QuickSort(array, left, q - 1);
                QuickSort(array, q + 1, right);
            }


        }
        private static int Partition(int[] array, int p, int r)
        {
            int x = array[r];//取最右边点
            int i = p - 1;
            for (int j = p; j < r; j++)
            {
                if (array[j] < x)
                {
                    i++;
                    Swap(ref array[i],ref array[j]);
                }
            }

            i++;//+1使基准数下标在中间
            Swap(ref array[i], ref array[r]);//将基准数放在中间
            return i;
        }
        public static void Swap(ref int x,ref  int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
        static void Main(string[] args)     //分治法  先从后面往前找，在从前面往后找，当第一个数处于中间时则划分了两个区域i==j，在对两个区域分治，以此循环（递归调用）
        {
            int[] array = new int[] { 42, 20, 17, 27, 13, 17, 8, 47 };
            //SelectSort(array);
            QuickSort(array, 0, array.Length - 1);
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();
        }
    }
}
