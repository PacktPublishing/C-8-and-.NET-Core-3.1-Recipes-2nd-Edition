using System;
using System.Text;

namespace RangesAndIndices
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArr = new int[10];
            for(int i = 0; i < numbersArr.Length; i++)
            {
                numbersArr[i] = i * i;
            }
            Console.WriteLine(arrToString(numbersArr));
            Console.WriteLine(arrToString(numbersArr[..3]));
            Console.WriteLine(arrToString(numbersArr[^3..]));
        }

        static string arrToString(int[] arr)
        {
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < arr.Length; i++)
            {
                builder.Append(arr[i]);
                if (i != arr.Length - 1)
                {
                    builder.Append(",");
                }
            }
            return builder.ToString();
        }
    }
}
