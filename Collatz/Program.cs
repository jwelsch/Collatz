using System;
using System.Diagnostics;

namespace Collatz
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine($"Enter 'q' to quit");
                    Console.Write("Enter a positive integer: ");
                    var input = Console.ReadLine();

                    input = input.Trim();

                    if (input == "q" || input == "Q")
                    {
                        break;
                    }

                    if (!ulong.TryParse(input, out ulong seed))
                    {
                        Console.WriteLine($"Could not convert '{input}' to an integer.");
                        Console.WriteLine();
                        continue;
                    }

                    if (seed == 0UL)
                    {
                        Console.WriteLine("Please enter a positive integer (must be greater than 0).");
                        Console.WriteLine();
                        continue;
                    }

                    Console.WriteLine($"Starting calculation with seed: {seed}");

                    var number = seed;

                    var cycles = 0UL;
                    var maximum = 0UL;
                    var maximumCycle = 0UL;
                    var evenCount = 0UL;
                    var oddCount = 0UL;

                    var stopwatch = new Stopwatch();
                    stopwatch.Start();

                    do
                    {
                        cycles++;

                        if (number % 2 == 1)
                        {
                            oddCount++;
                            number = 3 * number + 1;
                        }
                        else
                        {
                            evenCount++;
                            number /= 2;
                        }

                        Console.WriteLine($"{number}");

                        if (number > maximum)
                        {
                            maximum = number;
                            maximumCycle = cycles;
                        }
                    }
                    while (number != 1);

                    stopwatch.Stop();

                    Console.WriteLine($"Number of ms:     {stopwatch.ElapsedMilliseconds}");
                    Console.WriteLine($"Number of cycles: {cycles}");
                    Console.WriteLine($"Maximum number:   {maximum} (cycle: {maximumCycle})");
                    Console.WriteLine($"Number of evens:  {evenCount}");
                    Console.WriteLine($"Number of odds:   {oddCount}");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
        }
    }
}
