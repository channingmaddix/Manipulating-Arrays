using System;

namespace ManipulatingArrays
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
            if (places < 0)                         //Accounts for if a negative number of places is inputted.
            {
                places = Math.Abs(places);
                direction = !direction;
            }

            if (places > arr.Length)                //This if statement alters the number of places moved if the number is more than 
            {                                       //the array length (i.e. if length is 5 and places is 20, move 0 places).
                places = arr.Length % places;
            }
            int[] newArr = new int[arr.Length];     //newArr created for copying to.
            if (direction == true)
            {
                for (int i = 0; i < arr.Length - places; i++)   //Moves only elements of the array up to the number 
                {                                               //of spaces being moved. Example: Rotate right 2 places.
                    newArr[i + places] = arr[i];                // arr{ 1, 2, 3, 4, 5} => newArr{ , , 1, 2, 3}
                }
                for (int j = 0; j < places; j++)                //Moves remaining elements (4 and 5) to the beginning of newArr:
                {                                               // arr{1, 2, 3, 4, 5} => newArr{ 4, 5, 1, 2, 3 }
                    newArr[j] = arr[arr.Length - places + j];
                }
            }

            if (direction == false)
            {
                for (int i = arr.Length - 1; i >= places; i--)  //To move left, same logic is used, but the array is iterated 
                {                                               //from right to left.
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

            for (int i = 0; i < newArr.Length - 1; i++)     //i moves the search area to the right.
            {
                minIndex = i;
                for (int j = i; j < newArr.Length; j++)     //Iterates through the search area to find the index of the min value.
                {
                    if (newArr[j] < newArr[minIndex])
                    { minIndex = j; }
                }
                temp = newArr[minIndex];                    //Values at the beginning of the search area and index of 
                newArr[minIndex] = newArr[i];               //min value are swapped.
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
