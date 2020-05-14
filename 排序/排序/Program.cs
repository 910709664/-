using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 插入排序
{
    class Program
    {   
        static void Insert(int[] array)
        {
            for(int i = 1; i < array.Length; i++)   //选取第一个数字为插入数字
            {
                var temp = array[i];    //储存当前插入的数字 随i值改变
                bool isInsert = false;
                for(int j = i - 1; j >= 0; j--)
                {
                    if (array[j] >temp) //比i大的值移动
                    {
                        array[j + 1] = array[j];
                    }
                    else  //比i小的值不动
                    {
                        array[j + 1] = temp;
                        isInsert = true;    //插入成功
                        break;
                    }
                }
                //最小的在前面
                if (isInsert == false)
                {
                    array[0] = temp;
                }
            }
        }
        //示例：抽牌
        static void Main(string[] args)
        {
            int[] array = new int[] { 42, 20, 17, 27, 13, 17, 8, 47 };
            Insert(array);
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();
        }
    }
}
