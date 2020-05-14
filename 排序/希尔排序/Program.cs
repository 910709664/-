using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 希尔排序
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] iArrary = new int[] { 1, 5, 3, 6, 10, 55, 9, 2, 87, 12, 34, 75, 33, 47 };
            Shell(iArrary);
            for(int i = 0; i < iArrary.Length; i++)
            {
                Console.Write(iArrary[i] + " ");
            }
            Console.ReadKey();
        }

        static public void Shell(int[] array)
        {
            int length = array.Length;//获取数组长度
            for(int d = length / 2; d > 0; d = d / 2)//按Dk增量分组
            {
                for(int i = 0; i < d; i++)
                {
                    for(int j = i + d; j < length; j += d)
                    {
                        if (array[j]< array[j - d])//如果后面的小于前面的
                        {
                            int temp = array[j];//将小数值暂时存储
                            int k = 0;
                            for(k = j - d; k >= i && temp < array[k]; k -= d)//每组从后面开始比较
                            {
                                array[k + d] = array[k];
                            }
                            array[k + d] = temp;//最后k+d=i
                        }
                    }
                }
            }
        }
    }
}
