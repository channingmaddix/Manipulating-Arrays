using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrA = new[] { 0, 2, 4, 6, 8, 10 };
            int[] arrB = new[] { 1, 3, 5, 7, 9 };
            int[] arrC = new[] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 9 };
            Console.WriteLine(ArrayMean(arrA));
            ReverseArray(arrB);
            RotateArray("right", 4, arrB);
            SortArray(arrC);
        }

        static double ArrayMean(int[] arr)
        {
            int length = 0;
            int sum = 0;
            foreach (int number in arr)
            {
                length++;
            }

            for (int i = 0; i < length; i++)
            {
                sum += arr[i];
            }

            double mean = sum / length;
            return mean;

        }

        static void ReverseArray(int[] arr)
        {
            int[] newArr = new int[arr.Length];
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                newArr[arr.Length - 1 - i] = arr[i];
            }
            Console.Write("Reversed Array: ");

            foreach (int number in newArr)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }

        static void RotateArray(string dir, int places, int[] arr)
        {
            bool direction = true;
            if (dir == "right")
            {
                direction = true;
            }
            else if (dir == "left")
            {
                direction = false;
            }
            else Console.WriteLine("Invalid input. Rotating right.");
            if (places < 0)
            {
                places = Math.Abs(places);
                direction = !direction;
            }

            if (places > arr.Length)
            {
                places = arr.Length % places;
            }
            int[] newArr = new int[arr.Length];
            if (direction == true)
            {
                for (int i = 0; i < arr.Length - places; i++)
                {
                    newArr[i + places] = arr[i];
                }
                for (int j = 0; j < places; j++)
                {
                    newArr[j] = arr[arr.Length - places + j];
                }
            }

            if (direction == false)
            {
                for (int i = arr.Length - 1; i >= places; i--)
                {
                    newArr[i - places] = arr[i];
                }
                for (int j = arr.Length - 1; j > places; j--)
                {
                    newArr[j] = arr[j - 1 - places];
                }
            }
            Console.Write("Rotated Array: ");
            foreach (int number in newArr)
            {
                Console.Write(number + " ");
            }

        }

        static void SortArray(int[] arr)
        {
            int[] newArr = new int[arr.Length];
            int minIndex;
            int temp;
            for (int a = 0; a < arr.Length; a++)
            {
                newArr[a] = arr[a];
            }

            for (int i = 0; i < newArr.Length - 1; i++)
            {
                minIndex = i;
                for (int j = i; j < newArr.Length; j++)
                {
                    if (newArr[j] < newArr[minIndex])
                    { minIndex = j; }
                }
                temp = newArr[minIndex];
                newArr[minIndex] = newArr[i];
                newArr[i] = temp;
            }

            Console.Write("\n" + "Sorted Array: ");
            foreach (int number in newArr)
            {
                Console.Write(number + " ");
            }
        }

    }
}
