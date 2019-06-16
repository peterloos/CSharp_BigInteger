using System;
using System.Diagnostics;

class BigPerfectNumbers
{
    public static void Test_01()
    {
        for (int i = 2; i < 500; i++)
        {
            if (IsPerfectNumber (i))
                Console.WriteLine("The value {0} is PERFECT", i);
        }
    }

    public static void Test_02(int max)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        for (BigInteger n = 2; n < max; n++)
        {
            if (IsPerfectNumber(n))
                Console.WriteLine("The value {0} is PERFECT", n);
        }

        sw.Stop();
        Console.WriteLine("Computation Time: {0}", sw.ElapsedMilliseconds);
    }

    public static void Test_03()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        // https://en.wikipedia.org/wiki/List_of_perfect_numbers
        String[] perfectCandidates =
        {
            "6",
            "28",
            "496",
            "8.128",
            "33.550.336",
            "8.589.869.056",
            "137.438.691.328",
            "2.305.843.008.139.952.128",
            "2.658.455.991.569.831.744.654.692.615.953.842.176",
            "191.561.942.608.236.107.294.793.378.084.303.638.130.997.321.548.169.216"
        };

        for (int i = 0; i < perfectCandidates.Length; i++)
        {
            BigInteger n = new BigInteger(perfectCandidates[i]);
            if (IsPerfectNumber(n))
                Console.WriteLine("The value {0} is PERFECT", n);
        }

        sw.Stop();
        Console.WriteLine("Computation Time: {0}", sw.ElapsedMilliseconds);
    }

    private static bool IsPerfectNumber(int n)
    {
        int sumOfDivisors = 1;
        for (int i = 2; i < n / 2 + 1; i = i + 1)
        {
            if (n % i == 0)
            {
                sumOfDivisors = sumOfDivisors + i;
            }
        }

        return (n == sumOfDivisors) ? true : false;
    }

    private static bool IsPerfectNumber(BigInteger n)
    {
        BigInteger sumOfDivisors = 1;
        BigInteger limit = n / 2 + 1;
        for (BigInteger i = 2; i < limit; i++)
        {
            if (n % i == 0)
            {
                sumOfDivisors = sumOfDivisors + i;
            }
        }

        return (n == sumOfDivisors) ? true : false;
    }
}