using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Assignment4A
{
    class Unit4PartB
    {
        static void Main(string[] args)
        {
            //*********************************************************
            //****Assignment 4, Part B, Section 1
            //*********************************************************
            Console.WriteLine();
            Console.WriteLine("**********Section 1 - Bubble Sort **********");
            Console.WriteLine();

            int[] studentGrades = new int [] { 65, 95, 75, 55, 56, 90, 98, 88, 97, 78 };

            Console.WriteLine("The unsorted list of grades is: ");
            printArray(studentGrades); // Printing unsorted student grades
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("The grades in descending order are: ");
            sortArrayDescBS(studentGrades); // Bubble sorting highest to lowest
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("The grades in ascending order are: ");
            sortArrayAscBS(studentGrades); // Bubble sorting lowest to highest
            Console.WriteLine();
            Console.WriteLine();

            //*********************************************************
            //****Assignment 4, Part B, Section 2
            //*********************************************************
            Console.WriteLine();
            Console.WriteLine("**********Section 2 - Quick Sort **********");
            Console.WriteLine();

            int low = 0;
            int high = studentGrades.Length - 1;

            sortArrayDescQS(studentGrades, low, high);
            Console.WriteLine("The grades in descending order are: ");
            printArray(studentGrades);
            Console.WriteLine();
            Console.WriteLine();

            sortArrayAscQS(studentGrades, low, high);
            Console.WriteLine("The grades in ascending order are: ");
            printArray(studentGrades);

            //*********************************************************
            //****Assignment 4, Part B, Section 3
            //*********************************************************
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("**********Section 3 - Sequential Search**********");
            Console.WriteLine();

            Console.WriteLine("The contents of the grade array are: ");
            printArray(studentGrades);
            Console.WriteLine();
            Console.WriteLine();

            int grade = 75;
            string gSearch = seqSearch(studentGrades, grade);
            Console.WriteLine(gSearch);
            Console.WriteLine();

            grade = 60;
            gSearch = seqSearch(studentGrades, grade);
            Console.WriteLine(gSearch);

            //*********************************************************
            //****Assignment 4, Part B, Section 4
            //*********************************************************
            Console.WriteLine();
            Console.WriteLine("**********Section 4 - Binary Search**********");
            Console.WriteLine();

            Console.WriteLine("The contents of the grade array are: ");
            printArray(studentGrades);
            Console.WriteLine();
            Console.WriteLine();

            grade = 56;
            Console.WriteLine(binarySearch(studentGrades, grade));
            Console.WriteLine();

            grade = 50;
            Console.WriteLine(binarySearch(studentGrades, grade));

            Console.ReadKey();
        }

        public static void printArray(int[] arr)
        {
            Console.Write("[");
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                Console.Write(arr[i]);
                if (i != arr.GetUpperBound(0))
                {
                    Console.Write(",");
                }
            }
            Console.Write("]");
        }

        public static void sortArrayAscBS(int[] arr)
        {
            int t;
            for (int j = 0; j <= arr.Length - 2; j++)
            {
                for (int i = 0; i <= arr.Length - 2; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        t = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = t;
                    }
                }
            }
            Console.WriteLine();
            Console.Write("[");
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                Console.Write(arr[i]);
                if (i != arr.GetUpperBound(0))
                {
                    Console.Write(",");
                }
            }
            Console.Write("]");
        }

        public static void sortArrayDescBS(int[] arr)
        {
            int t;
            for (int j = 0; j <= arr.Length - 2; j++)
            {
                for (int i = 0; i <= arr.Length - 2; i++)
                {
                    if (arr[i] < arr[i + 1])
                    {
                        t = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = t;
                    }
                }
            }
            Console.WriteLine();
            Console.Write("[");
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                Console.Write(arr[i]);
                if (i != arr.GetUpperBound(0))
                {
                    Console.Write(",");
                }
            }
            Console.Write("]");
        }

        public static void sortArrayAscQS(int[] arr, int low, int high)
        {
            if (arr == null || arr.Length == 0)
                return;
            if (low >= high)
                return;
            // pick the pivot 
            int middle = low + (high - low) / 2;
            int pivot = arr[middle];
            // make left < pivot and right > pivot 
            int i = low, j = high;
            while (i <= j)
            {
                while (arr[i] < pivot)
                {
                    i++;
                }
                while (arr[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            }
            // recursively sort two sub parts 
            if (low < j)
                sortArrayAscQS(arr, low, j);
            if (high > i)
                sortArrayAscQS(arr, i, high);
        }
        public static void sortArrayDescQS(int[] arr, int low, int high)
        {
            if (arr == null || arr.Length == 0)
                return;
            if (low >= high)
                return;
            // pick the pivot 
            int middle = low + (high - low) / 2;
            int pivot = arr[middle];
            // make left < pivot and right > pivot 
            int i = low, j = high;
            while (i <= j)
            {
                while (arr[i] > pivot)
                {
                    i++;
                }
                while (arr[j] < pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            }
            // recursively sort two sub parts 
            if (low < j)
                sortArrayDescQS(arr, low, j);
            if (high > i)
                sortArrayDescQS(arr, i, high);
        }

        public static string seqSearch(int[] arr, int searchNumber)
        {
            string output = "";
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == searchNumber)
                {
                    return "The grade " + searchNumber + " was found at index " + i + ".";
                }
                else
                {
                    output = "The grade " + searchNumber +  " was not found";
                }
            }
            return output;
        }

        public static string binarySearch(int[] arr, int num)
        {
            string answer = "";
            int first = 0;
            int last = arr.Length - 1;
            int middle = (first + last) / 2;
            while (first <= last)
            {
                if (arr[middle] < num)
                {
                    first = middle + 1;
                }
                else if (arr[middle] == num)
                {
                    answer = "Grade " + num + " was found at index " + middle + ".";
                    break;
                }
                else
                {
                    last = middle - 1;
                }
                middle = (first + last) / 2;
            }
            if (first > last)
            {
                answer = "Grade " + num + " is not present in the list.\n";
            }
            return answer;
        }
    }
}
