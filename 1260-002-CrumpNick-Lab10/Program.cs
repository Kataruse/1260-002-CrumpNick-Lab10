

using System.Diagnostics.Metrics;
using System.Reflection;
using System.Runtime.CompilerServices;
/**
*--------------------------------------------------------------------
* File name: Program.cs
* Project name: 1260-002-CrumpNick-Lab10
*--------------------------------------------------------------------
* Author’s name and email: Nick Crump, CRUMPNA@ETSU.EDU
* Course-Section: CSCI 1260-002
* Creation Date: 4/17/2023
* -------------------------------------------------------------------
*/
namespace _1260_002_CrumpNick_Lab10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            int arrLength = 0;
            int check = 1;

            while (true)
            {
                try
                {
                    Console.Write("Enter a integer: ");
                    number = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    break;
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Enter how big your array of numbers is: ");
                    arrLength = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    break;
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }

            int[] numArray = new int[arrLength];

            while (check <= arrLength)
            {
                while (true)
                {
                    try
                    {
                        Console.Write($"Enter integer #{check}: ");
                        numArray[check - 1] = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        check++;
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine($"Number: {number}");
            string arrayString = "Number Array: ";
            //Console.WriteLine($"Number Array: ({numArray[0]}, {numArray[1]}, {numArray[2]})\n");
            foreach (int item in numArray)
            {
                arrayString = arrayString + $"{item}, ";
            }
            Console.WriteLine(arrayString);

            Console.WriteLine("Super Digit");
            Console.WriteLine("--------------------");
            Console.WriteLine(SuperDigit(number));

            Console.WriteLine("Minimum Of An Array");
            Console.WriteLine("--------------------");
            Console.WriteLine(MinimumOfAnArray(numArray));
        }
        public static long SuperDigit(int n)
        {
            if (n < 10)
            {
                return n;
            }
            else
            {
                char[] numArr = n.ToString().ToCharArray();
                int firstPos = Convert.ToInt32(numArr[0].ToString());
                
                int counter = 1;
                string newNumString = "";

                while (counter <= numArr.Length - 1)
                {
                    newNumString = newNumString + numArr[counter];
                    counter++;
                }

                int newNum = Convert.ToInt32(newNumString);

                return SuperDigit(firstPos + newNum);
            }
        }

        public static int MinimumOfAnArray(int[] n)
        {
            if (n.Length == 1)
            {
                return n[0];
            }
            else if (n.Length == 2)
            {
                return Math.Min(n[0], n[1]);
            }
            else
            {
                int[] newIntArr = new int[n.Length - 1];

                int counter = 0;

                while (counter < n.Length - 2)
                {
                    newIntArr[counter] = n[counter];
                    counter++;
                }

                newIntArr[newIntArr.Length - 1] = Math.Min(n[n.Length - 2], n[n.Length - 1]);

                return MinimumOfAnArray(newIntArr);
            }
        }
    }
}