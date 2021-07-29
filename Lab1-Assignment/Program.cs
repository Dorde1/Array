using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Xml.Schema;

namespace Lab1_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"C:\Users\djole\Desktop\1.txt"); //Save the content into an array

                if (lines.Length > 0) //Error handling for empty list
                {
                    if (lines.Length != 20)
                    {
                        Console.WriteLine("Text file does not contains 20 numbers, error!!! "); //Display error message for if arrray has more than 20 numbers
                        Console.ReadKey();
                        return;
                    }

                    int[] list;

                    try
                    {
                        list = Array.ConvertAll(lines, int.Parse);
                        foreach (string line in lines) //Error handling for length of array
                        {
                            System.Console.WriteLine(line);
                        }
                        PrintPrimes(list);
                        Console.ReadKey();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Conversion fail, error!!! ");
                        Console.ReadLine();
                    }
                }
                Console.WriteLine("File is empty, error!!! "); //Dispaly message for empty file
                Console.ReadLine();
            }
            catch (FileNotFoundException) //Error handling for file location with try/catch
            {
                Console.WriteLine("File not found, error!!! "); //Dispaly message for file not found
                Console.ReadLine();
            }
        }

        public static bool IsPrime(int n) //Method to check prime numbers
        {
            int i;
            if (!(n <= 1))
            {
                for (i = 2; i <= Math.Sqrt(n); i++)
                {
                    if ((n % i) == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public static void PrintPrimes(int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (IsPrime(array[i]))
                {
                    count += 1;
                }
            }
            Console.WriteLine("Count: " + count);
        }
    }
}