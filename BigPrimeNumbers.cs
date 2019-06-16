using System;
using System.Diagnostics;

class BigPrimeNumbers
{
    public static void Test_01 ()
    {
        // some examples for prime numbers
        TestRange(1000);
        TestRange("1000");
        TestRange(10000);
        TestRange("10000");
    }

    public static void Test_02()
    {
        Factorize_01();
        Factorize_02();
    }

    private static void TestRange(int max)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        int found = 0;
        for (int i = 2; i < max; i++)
        {
            if (IsPrime(i))
                found++;
        }

        sw.Stop();
        Console.WriteLine("Number of Primes up to {0}: {1}", max, found);
        Console.WriteLine("[{0} msecs]", sw.ElapsedMilliseconds);
    }

    private static void TestRange(BigInteger max)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        BigInteger found = 0;
        for (BigInteger i = 2; i < max; i++)
        {
            if (IsPrime(i))
                found++;

            if (i % 1000 == 0)
                Console.Write(".");

        }

        sw.Stop();
        Console.WriteLine("Number of Primes up to {0}: {1}", max, found);
        Console.WriteLine("[{0} msecs]", sw.ElapsedMilliseconds);
    }

    private static void Factorize_01()
    {
        long number = ((long)13821503) * ((long)13821503);
        long[] result = Factorize(number);

        if (result[0] != 1)
        {
            Console.WriteLine("found factors {0} and {1}.",
                result[0], result[1]);
        }
        else
        {
            Console.WriteLine("{0} is prime.", number);
        }
    }

    private static void Factorize_02()
    {
        BigInteger n = new BigInteger("21089");
        BigInteger number = n * n;
        BigInteger[] result = Factorize(number);

        if (result[0] != 1)
        {
            Console.WriteLine("found factors {0} and {1}.",
                result[0], result[1]);
        }
        else
        {
            Console.WriteLine("{0} is prime.", number);
        }
    }

    private static long[] Factorize(long number)
    {
        long[] result = new long[2];
        result[0] = 1;
        result[1] = number;

        // factorizing a long variable using a very simple approach
        for (long i = 2; i < number; i++)
        {
            if ((number % i) == 0)
            {
                result[0] = i;
                result[1] = number / i;
                break;
            }
        }

        return result;
    }

    private static BigInteger[] Factorize(BigInteger number)
    {
        BigInteger[] result = new BigInteger[2];
        result[0] = 1;
        result[1] = number;

        // factorizing a big integer object using a very simple approach
        for (BigInteger i = 2; i < number; i++)
        {
            if ((number % i) == 0)
            {
                result[0] = i;
                result[1] = number / i;
                break;
            }
        }

        return result;
    }

    private static bool IsPrime(int number)
    {
        // the smallest prime number is 2
        if (number <= 2)
            return number == 2;

        // even numbers other than 2 are not prime
        if (number % 2 == 0)
            return false;

        // check odd divisors from 3 to the half of the number
        // (in lack of a high precision sqare root function) 
        int end = number / 2 + 1;
        for (long i = 3; i <= end; i += 2)
            if (number % i == 0)
                return false;

        // found prime number
        return true;
    }

    private static bool IsPrime(BigInteger number)
    {
        // the smallest prime number is 2
        if (number <= BigInteger.Two)
            return number == BigInteger.Two;

        // even numbers other than 2 are not prime
        if (number % BigInteger.Two == 0)
            return false;

        // check odd divisors from 3 to the half of the number
        // (in lack of a high precision sqare root function) 
        BigInteger end = number / BigInteger.Two + BigInteger.One;
        for (BigInteger i = 3; i <= end; i += BigInteger.Two)
            if (number % i == BigInteger.Zero)
                return false;

        // found prime number
        return true;
    }
}

