using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkOfGoodMan.Tools.Helper
{
    public class SortHelper
    {
        #region 希尔排序
        public static void shell_Sort(int[] array)
        {
            int d, i, j, temp; //d为增量
            for (d = array.Length / 2; d >= 1; d = d / 2) //增量递减到1使完成排序
            {
                for (i = d; i < array.Length; i++)   //插入排序的一轮
                {
                    temp = array[i];
                    for (j = i - d; (j >= 0) && (array[j] > temp); j = j - d)
                    {
                        array[j + d] = array[j];
                    }
                    array[j + d] = temp;
                }
            }
        }
        #endregion

        #region 冒泡排序法
        public static void bubble_Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 1; j < array.Length - i; j++)
                {
                    if (array[j] < array[j - 1])
                    {
                        int tmp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = tmp;
                    }
                }
            }
        }



        public static void bubble_Sort_Optimize1(int[] array)
        {
            bool flag = false;
            for (int i = 0; i < array.Length - 1; flag = false, i++)
            {
                for (int j = 1; j < array.Length - i; j++)
                {
                    if (array[j] < array[j - 1])
                    {
                        int tmp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = tmp;
                        flag = true;
                    }
                }
                if (!flag)
                {
                    break;
                }
            }
        }

        public static void bubble_Sort_Optimize2(int[] array)
        {
            int lastSwap = array.Length;
            for (int i = 0; i < array.Length - 1; i++)
            {
                int j = 1;
                for (; j < lastSwap; j++)
                {
                    if (array[j] < array[j - 1])
                    {
                        int tmp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = tmp;
                    }
                }
                lastSwap = j - 1;
            }
        }

        #endregion

        #region 快速排序法
        public static void QuickSort(int[] R, int low, int high)
        {
            int pivotLoc = 0;

            if (low < high)
            {
                pivotLoc = Partition(R, low, high);
                QuickSort(R, low, pivotLoc - 1);
                QuickSort(R, pivotLoc + 1, high);

            }
        }

        private static int Partition(int[] R, int low, int high)
        {
            int temp = R[low];
            while (low < high)
            {
                while (low < high && temp <= R[high])
                {
                    high--;
                }
                R[low] = R[high];
                while (low < high && temp >= R[low])
                {
                    low++;
                }
                R[high] = R[low];
            }
            R[low] = temp;
            return low;
        }

        //快速非递归排序
        public static void QuickSort(int[] R, int Low, int High, Stack<int> stack)
        {
            int low = Low;
            int high = High;
            int key = R[low];
            while (high > low)
            {
                while (low < high && key <= R[high])
                {
                    high--;
                }
                if (high > low)
                {
                    R[low] = R[high];
                    R[high] = key;
                }
                while (low < high && key >= R[low])
                {
                    low++;
                }
                if (high > low)
                {
                    R[high] = R[low];
                    R[low] = key;
                }

            }
            if (low == high)
            {
                if (Low < low - 1)
                {

                    stack.Push(low - 1);
                    stack.Push(Low);
                }
                if (High > low + 1)
                {

                    stack.Push(High);
                    stack.Push(low + 1);
                }
            }

        }
        #endregion

        #region 选择排序法
        public static void selection_Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int pos = i;
                for (int j = i + 1; j < array.Length; j++)
                    if (array[pos] > array[j])
                    {
                        pos = j;
                    }
                if (pos != i)
                {
                    int tmp = array[i];
                    array[i] = array[pos];
                    array[pos] = tmp;
                }
            }
        }

        #endregion

        #region 插入排序法
        public static void insert_Sort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int data = array[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (data < array[j])
                    {
                        array[j + 1] = array[j];
                        array[j] = data;
                    }
                    else
                    {
                        array[j + 1] = data;
                        break;
                    }

                }
            }
        }
        #endregion

        #region 堆排序
        //堆排序算法（传递待排数组名，即：数组的地址。故形参数组的各种操作反应到实参数组上）
        public static void HeapSortFunction(int[] array)
        {
            try
            {
                BuildMaxHeap(array);    //创建大顶推（初始状态看做：整体无序）
                for (int i = array.Length - 1; i > 0; i--)
                {
                    Swap(ref array[0], ref array[i]); //将堆顶元素依次与无序区的最后一位交换（使堆顶元素进入有序区）
                    MaxHeapify(array, 0, i); //重新将无序区调整为大顶堆
                }
            }
            catch (Exception ex)
            { }
        }

        ///<summary>
        /// 创建大顶推（根节点大于左右子节点）
        ///</summary>
        ///<param name="array">待排数组</param>
        private static void BuildMaxHeap(int[] array)
        {
            try
            {
                //根据大顶堆的性质可知：数组的前半段的元素为根节点，其余元素都为叶节点
                for (int i = array.Length / 2 - 1; i >= 0; i--) //从最底层的最后一个根节点开始进行大顶推的调整
                {
                    MaxHeapify(array, i, array.Length); //调整大顶堆
                }
            }
            catch (Exception ex)
            { }
        }

        ///<summary>
        /// 大顶推的调整过程
        ///</summary>
        ///<param name="array">待调整的数组</param>
        ///<param name="currentIndex">待调整元素在数组中的位置（即：根节点）</param>
        ///<param name="heapSize">堆中所有元素的个数</param>
        private static void MaxHeapify(int[] array, int currentIndex, int heapSize)
        {
            try
            {
                int left = 2 * currentIndex + 1;    //左子节点在数组中的位置
                int right = 2 * currentIndex + 2;   //右子节点在数组中的位置
                int large = currentIndex;   //记录此根节点、左子节点、右子节点 三者中最大值的位置

                if (left < heapSize && array[left] > array[large])  //与左子节点进行比较
                {
                    large = left;
                }
                if (right < heapSize && array[right] > array[large])    //与右子节点进行比较
                {
                    large = right;
                }
                if (currentIndex != large)  //如果 currentIndex != large 则表明 large 发生变化（即：左右子节点中有大于根节点的情况）
                {
                    Swap(ref array[currentIndex], ref array[large]);    //将左右节点中的大者与根节点进行交换（即：实现局部大顶堆）
                    MaxHeapify(array, large, heapSize); //以上次调整动作的large位置（为此次调整的根节点位置），进行递归调整
                }
            }
            catch (Exception ex)
            { }
        }

        ///<summary>
        /// 交换函数
        ///</summary>
        ///<param name="a">元素a</param>
        ///<param name="b">元素b</param>
        private static void Swap(ref int a, ref int b)
        {
            int temp = 0;
            temp = a;
            a = b;
            b = temp;
        }
        #endregion

        #region 并归排序法
        //归并排序（目标数组，子表的起始位置，子表的终止位置）
        public static void MergeSortFunction(int[] array, int first, int last)
        {
            try
            {
                if (first < last)   //子表的长度大于1，则进入下面的递归处理
                {
                    int mid = (first + last) / 2;   //子表划分的位置
                    MergeSortFunction(array, first, mid);   //对划分出来的左侧子表进行递归划分
                    MergeSortFunction(array, mid + 1, last);    //对划分出来的右侧子表进行递归划分
                    MergeSortCore(array, first, mid, last); //对左右子表进行有序的整合（归并排序的核心部分）
                }
            }
            catch (Exception ex)
            { }
        }

        //归并排序的核心部分：将两个有序的左右子表（以mid区分），合并成一个有序的表
        private static void MergeSortCore(int[] array, int first, int mid, int last)
        {
            try
            {
                int indexA = first; //左侧子表的起始位置
                int indexB = mid + 1;   //右侧子表的起始位置
                int[] temp = new int[last + 1]; //声明数组（暂存左右子表的所有有序数列）：长度等于左右子表的长度之和。
                int tempIndex = 0;
                while (indexA <= mid && indexB <= last) //进行左右子表的遍历，如果其中有一个子表遍历完，则跳出循环
                {
                    if (array[indexA] <= array[indexB]) //此时左子表的数 <= 右子表的数
                    {
                        temp[tempIndex++] = array[indexA++];    //将左子表的数放入暂存数组中，遍历左子表下标++
                    }
                    else//此时左子表的数 > 右子表的数
                    {
                        temp[tempIndex++] = array[indexB++];    //将右子表的数放入暂存数组中，遍历右子表下标++
                    }
                }
                //有一侧子表遍历完后，跳出循环，将另外一侧子表剩下的数一次放入暂存数组中（有序）
                while (indexA <= mid)
                {
                    temp[tempIndex++] = array[indexA++];
                }
                while (indexB <= last)
                {
                    temp[tempIndex++] = array[indexB++];
                }

                //将暂存数组中有序的数列写入目标数组的制定位置，使进行归并的数组段有序
                tempIndex = 0;
                for (int i = first; i <= last; i++)
                {
                    array[i] = temp[tempIndex++];
                }
            }
            catch (Exception ex)
            { }
        }

        #endregion

        #region 计数排序法
        //计数排序 
        /// <summary> 
        /// counting sort 
        /// </summary> 
        /// <param name="arrayA">input array</param> 
        /// <param name="arrange">the value arrange in input array</param> 
        /// <returns></returns> 
        public static int[] CountingSort(int[] arrayA, int arrange)
        {
            //array to store the sorted result, 
            //size is the same with input array. 
            int[] arrayResult = new int[arrayA.Length];
            //array to store the direct value in sorting process 
            //include index 0;     
            //size is arrange+1;     
            int[] arrayTemp = new int[arrange + 1];
            //clear up the temp array     
            for (int i = 0; i <= arrange; i++)
            {
                arrayTemp[i] = 0;
            }
            //now temp array stores the count of value equal 
            for (int j = 0; j < arrayA.Length; j++)
            {
                arrayTemp[arrayA[j]] += 1;
            }
            //now temp array stores the count of value lower and equal 
            for (int k = 1; k <= arrange; k++)
            {
                arrayTemp[k] += arrayTemp[k - 1];
            }
            //output the value to result     
            for (int m = arrayA.Length - 1; m >= 0; m--)
            {
                arrayResult[arrayTemp[arrayA[m]] - 1] = arrayA[m];
                arrayTemp[arrayA[m]] -= 1;
            }
            return arrayResult;
        }
        #endregion

        #region 小根堆排序

        /// <summary> 
        /// 小根堆排序 
        /// </summary> 
        /// <param name="dblArray"></param> 
        /// <param name="StartIndex"></param> 
        /// <returns></returns> 

        public static void HeapSort(int[] dblArray)
        {
            for (int i = dblArray.Length - 1; i >= 0; i--)
            {
                if (2 * i + 1 < dblArray.Length)
                {
                    int MinChildrenIndex = 2 * i + 1;
                    //比较左子树和右子树，记录最小值的Index 
                    if (2 * i + 2 < dblArray.Length)
                    {
                        if (dblArray[2 * i + 1] > dblArray[2 * i + 2])
                            MinChildrenIndex = 2 * i + 2;
                    }
                    if (dblArray[i] > dblArray[MinChildrenIndex])
                    {


                        ExchageValue(ref dblArray[i], ref dblArray[MinChildrenIndex]);
                        NodeSort(ref dblArray, MinChildrenIndex);
                    }
                }
            }
        }

        /// <summary> 
        /// 节点排序 
        /// </summary> 
        /// <param name="dblArray"></param> 
        /// <param name="StartIndex"></param> 

        private static void NodeSort(ref int[] dblArray, int StartIndex)
        {
            while (2 * StartIndex + 1 < dblArray.Length)
            {
                int MinChildrenIndex = 2 * StartIndex + 1;
                if (2 * StartIndex + 2 < dblArray.Length)
                {
                    if (dblArray[2 * StartIndex + 1] > dblArray[2 * StartIndex + 2])
                    {
                        MinChildrenIndex = 2 * StartIndex + 2;
                    }
                }
                if (dblArray[StartIndex] > dblArray[MinChildrenIndex])
                {
                    ExchageValue(ref dblArray[StartIndex], ref dblArray[MinChildrenIndex]);
                    StartIndex = MinChildrenIndex;
                }
            }
        }

        /// <summary> 
        /// 交换值 
        /// </summary> 
        /// <param name="A"></param> 
        /// <param name="B"></param> 
        private static void ExchageValue(ref int A, ref int B)
        {
            int Temp = A;
            A = B;
            B = Temp;
        }
        #endregion


        #region 基数排序
        public static int[] RadixSort(int[] ArrayToSort, int digit)
        {
            //low to high digit 
            for (int k = 1; k <= digit; k++)
            {
                //temp array to store the sort result inside digit 
                int[] tmpArray = new int[ArrayToSort.Length];
                //temp array for countingsort 
                int[] tmpCountingSortArray = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                //CountingSort         
                for (int i = 0; i < ArrayToSort.Length; i++)
                {
                    //split the specified digit from the element 
                    int tmpSplitDigit = ArrayToSort[i] / (int)Math.Pow(10, k - 1) - (ArrayToSort[i] / (int)Math.Pow(10, k)) * 10;
                    tmpCountingSortArray[tmpSplitDigit] += 1;
                }
                for (int m = 1; m < 10; m++)
                {
                    tmpCountingSortArray[m] += tmpCountingSortArray[m - 1];
                }
                //output the value to result     
                for (int n = ArrayToSort.Length - 1; n >= 0; n--)
                {
                    int tmpSplitDigit = ArrayToSort[n] / (int)Math.Pow(10, k - 1) - (ArrayToSort[n] / (int)Math.Pow(10, k)) * 10;
                    tmpArray[tmpCountingSortArray[tmpSplitDigit] - 1] = ArrayToSort[n];
                    tmpCountingSortArray[tmpSplitDigit] -= 1;
                }
                //copy the digit-inside sort result to source array     
                for (int p = 0; p < ArrayToSort.Length; p++)
                {
                    ArrayToSort[p] = tmpArray[p];
                }
            }
            return ArrayToSort;
        }
        #endregion

        #region 二分排序法
        public static int BinarySearch(int[] R, int arg)
        {
            int low = 0;
            int high = R.Length - 1;
            while (low < high)
            {
                int middle = (low + high) / 2;
                if (arg == R[middle])
                {
                    return middle;
                }
                else if (arg < R[middle])
                {
                    high = middle - 1;
                }
                else
                {
                    low = middle + 1;
                }
            }
            return -1;
        }
        #endregion
    }
}
