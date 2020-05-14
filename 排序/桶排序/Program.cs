using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 桶排序
{
    //基数排序和计数排序都可以看作是桶排序。用空间换取时间
    //通过标识放进不同的桶在不同的桶里面进行排序，有点类似分治思想
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = { 0.43, 0.69, 0.11, 0.72, 0.28, 0.21, 0.56, 0.80, 0.48, 0.94, 0.32, 0.08 };
            BucketSort(array,10);
            foreach (var temp in array)
            {
                Console.Write(temp + " ");
            }
            Console.ReadKey();
        }
        public static void BucketSort(double[] array,int bucketNum)
        {
            double[,] bucket = new double[bucketNum, array.Length + 1];//二维数组存放下标
            //求标识个数
            foreach(var temp in array)
            {
                int bit = (int)(temp * 10);
                bucket[bit, (int)++bucket[bit, 0]] = temp;

            }
            //给每个桶声明一个数组，数组个数为标识个数，在桶里面进行排序
            for(int j = 0; j < bucketNum; j++)
            {
                double[] tempArray = new double[(int)bucket[j, 0]];
                for(int k = 0; k < tempArray.Length; k++)
                {
                    tempArray[k] = bucket[j, k + 1];
                }
                //根据情况选择排序
                StraightInsertionSort(tempArray);
                //将排好序的数据赋回给桶
                for(int k = 0; k < tempArray.Length; k++)
                {
                    bucket[j, k + 1] = tempArray[k];
                }

            }
            //将每个桶的数据赋给数组
            for(int count = 0, j = 0; j < bucketNum; j++)
            {
                for(int k = 1; k <= bucket[j, 0]; k++)//k=1为数据所在位置
                {
                    array[count++] = bucket[j, k];
                }
            }
        }
        public static void StraightInsertionSort(double[] array)
        {
            //插入排序
            for (int i = 1; i < array.Length; i++)
            {
                double sentinel = array[i];
                int j = i - 1;
                while (j >= 0 && sentinel < array[j])
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = sentinel;
            }
        }
    }
}
