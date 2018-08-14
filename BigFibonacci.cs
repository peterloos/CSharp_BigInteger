using System;
using System.Diagnostics;

class BigFibonacci
{
    public static void Test_01(int max)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        for (int i = 1; i < max; i++)
        {
            long f = Fibonacci_Recursive(i);
            Console.WriteLine("Fibonacci of {0,2}: {1}", i, f);
        }

        sw.Stop();
        Console.WriteLine("[{0} msecs]", sw.ElapsedMilliseconds);
    }

    public static void Test_02(int max)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        for (int i = 1; i < max; i++)
        {
            long f = Fibonacci_Iterative(i);
            Console.WriteLine("Fibonacci of {0,2}: {1}", i, f);
        }

        sw.Stop();
        Console.WriteLine("[{0} msecs]", sw.ElapsedMilliseconds);
    }

    public static void Test_03(int max)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        for (BigInteger n = 2; n < max; n++)
        {
            BigInteger f = Fibonacci_Recursive(n);
            Console.WriteLine("Fibonacci of {0,2}: {1}", n, f);
        }

        sw.Stop();
        Console.WriteLine("[{0} msecs]", sw.ElapsedMilliseconds);
    }

    public static void Test_04(int max)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        for (BigInteger n = 2; n < max; n++)
        {
            BigInteger f = Fibonacci_Iterative(n);
            Console.WriteLine("Fibonacci of {0,2}: {1}", n, f);
        }

        sw.Stop();
        Console.WriteLine("[{0} msecs]", sw.ElapsedMilliseconds);
    }

    private static long Fibonacci_Recursive(long n)
    {
        if (n == 1 || n == 2)
            return 1;
        else
            return Fibonacci_Recursive(n - 1) + Fibonacci_Recursive(n - 2);
    }

    private static BigInteger Fibonacci_Recursive(BigInteger n)
    {
        if (n == 1 || n == 2)
            return 1;
        else
            return Fibonacci_Recursive(n - 1) + Fibonacci_Recursive(n - 2);
    }

    private static long Fibonacci_Iterative(long n)
    {
        if (n == 1)
        {
            return 1;
        }
        else
        {
            int a = 0;
            int b = 1;
            int i = 2;
            while (i <= n)
            {
                int tmp_a = b;
                int tmp_b = a + b;
                a = tmp_a;
                b = tmp_b;
                i++;
            }

            return b;
        }
    }

    private static BigInteger Fibonacci_Iterative(BigInteger n)
    {
        if (n == 1)
        {
            return 1;
        }
        else
        {
            BigInteger a = 0;
            BigInteger b = 1;
            BigInteger i = 2;
            while (i <= n)
            {
                BigInteger tmp_a = b;
                BigInteger tmp_b = a + b;
                a = tmp_a;
                b = tmp_b;
                i++;
            }

            return b;
        }
    }
}
