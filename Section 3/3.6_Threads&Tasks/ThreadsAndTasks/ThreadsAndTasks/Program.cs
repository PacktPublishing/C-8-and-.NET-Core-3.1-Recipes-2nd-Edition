using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsAndTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[10];
            for(int i = 0; i < nums.Length; i++)
            {
                nums[i] = i + 1;
            }
            SqrtArrThread(nums).Wait();
            foreach (var num in nums)
            {
                Console.WriteLine(num);
            }
        }

        private static Task SqrtArrThread(int[] nums)
        {
            return Task.Run(() =>
            {
                Thread th1 = new Thread(() => SqrtArr(nums, 0, 3));
                Thread th2 = new Thread(() => SqrtArr(nums, 4, 6));
                Thread th3 = new Thread(() => SqrtArr(nums, 7, 9));
                th1.Start();
                th2.Start();
                th3.Start();
                th1.Join();
                th2.Join();
                th3.Join();
                return;
            });
        }

        static void SqrtArr(int[] num, int startIndex, int endIndex)
        {
            for(int i = startIndex; i <= endIndex; i++)
            {
                num[i] = num[i] * num[i];
            }
        }
    }
}
