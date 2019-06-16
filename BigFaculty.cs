using System;
using System.Diagnostics;

class BigFaculty
{
    // faculty
    public static void Test_01(int max)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        for (int i = 1; i < max; i++)
        {
            long f = Faculty(i);
            Console.WriteLine("Faculty of {0,2}: {1}", i, f);
        }

        sw.Stop();
        Console.WriteLine("[{0} msecs]", sw.ElapsedMilliseconds);
    }

    public static void Test_02(int max)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        for (BigInteger n = 1; n < max; n++)
        {
            BigInteger f = Faculty(n);
            Console.WriteLine("Faculty of {0,2}: {1:24}", n, f);
        }

        sw.Stop();
        Console.WriteLine("[{0} msecs]", sw.ElapsedMilliseconds);
    }

    private static long Faculty(long n)
    {
        if (n == 1)
            return 1;
        else
            return n * Faculty(n - 1);
    }

    private static BigInteger Faculty(BigInteger n)
    {
        if (n == 1)
            return 1;
        else
            return n * Faculty(n - 1);
    }
}
