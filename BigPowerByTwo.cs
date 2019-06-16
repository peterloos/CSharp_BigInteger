using System;
using System.Diagnostics;

class BigPowerByTwo
{
    public static void Test_01()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        // testing method 'Power'
        BigInteger n = new BigInteger("2");
        for (int i = 0; i < 128; i++)
        {
            BigInteger m = n.Power(i);
            Console.WriteLine("2 to the power of {0,3}: {1:16}", i, m);
        }

        sw.Stop();
        Console.WriteLine("[{0} msecs]", sw.ElapsedMilliseconds);
    }

    public static void Test_02()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        BigInteger huge = new BigInteger("2.475.880.078.570.760.549.798.248.448");
        while (huge != 1)
        {
            Console.Write("{0} / 2 = ", huge);
            huge = huge / 2;
            Console.WriteLine(huge);
        }

        sw.Stop();
        Console.WriteLine("[{0} msecs]", sw.ElapsedMilliseconds);
    }
}
