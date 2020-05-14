using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基数排序
{   
    //通过键值方式进行排序
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 43, 69, 11, 72, 28, 212, 56, 80, 483, 94, 32, 8, 8 };
            RadixSort(array, 10);//多少进制放多少桶
            foreach (var temp in array)
            {
                Console.Write(temp + " ");
            }
            Console.ReadKey();
        }
        public static void RadixSort(int[] array,int bucketNum)
        {
            int maxLength = MaxLength(array);
            int[,] bucket = new int[bucketNum, array.Length + 1];//创建桶的二维数组，增加一组标识符，其中bucket[i,0]表示这一维所含数字个数
            for(int i = 0; i < maxLength; i++)//从个位数开始排序
            {
                foreach(var num in array)
                {
                    int bit = (int)(num / Math.Pow(10, i) % 10);//求位数
                    bucket[bit, ++bucket[bit, 0] ]= num;//存储到该位数下标处，数据从[bit,1]开始存储
                }
                //根据位数排序，从个位数开始
                for (int count = 0, j = 0; j < bucketNum; j++)
                {
                    for (int k = 1; k <= bucket[j, 0]; k++)//k=1为取实际数据
                    {
                        array[count++] = bucket[j, k];//直接将桶中存储数据赋给数组
                    }
                }
                //将每位数标识清零，重新计数新的位数
                for (int j = 0; j < bucketNum; j++)
                {
                    bucket[j, 0] = 0;
                }
            }


        }
        //求几位数
        private static int MaxLength(int[] array)
        {
            if (array.Length == 0) return 0;
            int max = array[0];
            //先求最大值
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max) max = array[i];
            }
            int count = 0;
            //再求位数
            while (max != 0)
            {
                max /= 10;
                count++;
            }
            return count;
        }
    }
}
