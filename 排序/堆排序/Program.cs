using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 堆排序
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { -1, 23,  21, 9, 12, 55 };//第一个为哨兵
            Heap<int> heap = new Heap<int>(array);
            heap.BuildHeap(AscComparison);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            heap.Sort(AscComparison);
            for(int i = 0; i < array.Length-1; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.ReadKey();
        }
        //委托
        private static int AscComparison(int x, int y)
        {
            if (x > y)
            {
                return 1;
            }
            else if (x == y)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
    //泛型堆
    public class Heap<T>
    {
        private int _heapSize=0;
        private T[] _array = null;

        public int HeapSize
        {
            get { return _heapSize; }
            set { _heapSize = value; }
        }

        public Heap(T[] array)
        {
            _array = array;
            _heapSize = array.Length;
        }
        //下标1为根节点
        private int Parrent(int i)
        {
            return (i - 1) / 2;
        }
        private int Left(int i)
        {
            return 2 * i + 1;
        }
        private int Right(int i)
        {
            return 2 * i + 2;
        }
        private void MHeapify(int rootIndex,Comparison<T> comparison)
        {
            int leftChildIndex = Left(rootIndex);//左子树点
            int rightChildIndex = Right(rootIndex);//右子树点

            int extremumIndex = rootIndex;//极值点
            //对每一个子树进行排序
            if (leftChildIndex < _heapSize && comparison(_array[leftChildIndex], _array[rootIndex]) > 0)
            {
                extremumIndex = leftChildIndex;
            }
            if (rightChildIndex < _heapSize && comparison(_array[rightChildIndex], _array[extremumIndex]) > 0)
            {
                extremumIndex = rightChildIndex;
            }
            //到根节点前递归排序
            if (extremumIndex != rootIndex)
            {
                Swap(ref _array[extremumIndex],ref _array[rootIndex]);//每次极值点与根节点交换
                MHeapify(extremumIndex, comparison);
            }
        }
        //建立一个最大堆
        public void BuildHeap(Comparison<T> comparison)
        {
            for(int i = _array.Length / 2 - 1; i > 0; i--)
            {
                MHeapify(i, comparison);
            }
        }
        //每次使根节点与最后一位交换便得到升序数组
        public void Sort(Comparison<T> comparison)
        {
            BuildHeap(comparison);
            for(int i = _array.Length - 1; i > 0; i--)
            {
                Swap(ref _array[i], ref _array[0]);
                _heapSize--;//减少子树
                MHeapify(0, comparison);//对新子树排序以确保根节点为最大值
            }
        }
        public void Swap(ref T x,ref T y)
        {
            T temp = x;
            x = y;
            y = temp;   
        }

    }
}
