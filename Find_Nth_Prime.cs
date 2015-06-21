using System;
using System.Collections;
using System.Collections.Generic;

class Find_Nth_Prime
{
    static void Main()
    {
        int maxPrime;
        Console.Write("Enter the maximum number value (0 for default value - 9973): ");
        int maxPrimeEntered = int.Parse(Console.ReadLine());
        if (maxPrimeEntered == 0)
        {
            maxPrime = 9973;
        }
        else
        {
            maxPrime = maxPrimeEntered;
        }

        int primeIndex;
        Console.Write("Enter the index to display(0 for maximum default value - 1229): ");
        int primeIndexEntered = int.Parse(Console.ReadLine());
        if (primeIndexEntered == 0)
        {
            primeIndex = 1229;
        }
        else
        {
            primeIndex = primeIndexEntered;
        }

        List<int> primeList = GetAllPrimesLessThan(maxPrime);

        try
        {
            Console.WriteLine(primeList[primeIndex - 1]);
        }
        catch (Exception)
        {
            Console.WriteLine("You exceed the default or entered value for the maximum prime.");
            Console.WriteLine("Please raise your target!!!");
        }
    }

    //Implementation of Sieve of Eratosthenes algorithm
    private static List<int> GetAllPrimesLessThan(int maxPrime)
    {
        List<int> primes = new List<int>() { 2 };
        double maxSqRoot = Math.Sqrt(maxPrime);
        BitArray eleminated = new BitArray(maxPrime + 1);

        for (int i = 3; i <= maxPrime; i += 2)
        {
            if (!eleminated[i])
            {
                primes.Add(i);
                if (i <= maxSqRoot)
                {
                    for (int j = i * i; j <= maxPrime; j += 2 * i)
                    {
                        eleminated[j] = true;
                    }
                }
            }
        }
        return primes;
    }
}