using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 归并排序
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 23, 21, 9, 12, 55 };
            MergeSort(array);
            for(int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.ReadKey();
        }
        //递归调用每一次分区
        public static void MergeSort(int[] array)
        {
            MergeSort(array, 0, array.Length - 1);
        }
        public static void MergeSort(int[] array,int left,int rightEnd)
        {
            if (left < rightEnd)
            {
                int right = (left + rightEnd) / 2;
                MergeSort(array, left, right);//左边分区
                MergeSort(array, right + 1, rightEnd);//右边分区
                Merge(array, left, right, rightEnd);//对分区归并排序
            }
        }
        public static void Merge(int[] array,int left,int right,int rightEnd)
        {
            int[] leftArray = new int[right - left + 2];//下标-1所以容量+2
            int[] rightArray = new int[rightEnd - right + 1];
            leftArray[right - left + 1] = int.MaxValue;
            rightArray[rightEnd - right] = int.MaxValue;
            //对每一个分区赋值
            for(int i = 0; i < right - left + 1; i++)
            {
                leftArray[i] = array[left + i];
            }
            for(int i = 0; i < rightEnd - right; i++)
            {
                rightArray[i] = array[right + i + 1];
            }

            int j = 0, k = 0;

            for(int i = 0; i < rightEnd - left + 1; i++)
            {
                if (leftArray[j] < rightArray[k])
                {
                    array[left + i] = leftArray[j];
                    j++;
                }
                else
                {
                    array[left + i] = rightArray[k];
                    k++;
                }
            }
        }
    }
}
