using System;
using System.Diagnostics;

class BigMersenneNumbers
{
    public static void Test_01()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        BigInteger mersenne = new BigInteger(2);
        mersenne = mersenne.Power(11213);
        mersenne = mersenne - 1;

        sw.Stop();

        Console.WriteLine("Mersenne: {0}", mersenne);
        Console.WriteLine("Number of Digits: {0}", mersenne.Cardinality);
        Console.WriteLine("Computation Time: {0}", sw.ElapsedMilliseconds);
    }

    public static void Test_02()
    {
        Stopwatch sw = new Stopwatch();

        // list of known Mersenne primes
        // see https://en.wikipedia.org/wiki/Mersenne_prime
        int[] power = new int[] {
            2, 3, 5, 7, 13, 17, 19, 31, 61, 89, 107, 127, 521, 607,
            1279, 2203, 2281, 3217, 4253, 4423, 9689, 9941,
            11213, 19937, 21701, 23209, 44497, 86243,
            110503, 132049, 216091, 756839, 859433
        };

        for (int i = 0; i < power.Length; i++)
        {
            int pow = power[i];

            sw.Start(); 
            BigInteger mersenne = new BigInteger(2);
            mersenne = mersenne.Power(pow);
            mersenne = mersenne - 1;
            sw.Stop();

            Console.WriteLine("{0}.th Mersenne Prime:", i+1);
            Console.WriteLine("{0}", mersenne);
            Console.WriteLine("Number of Digits: {0} [Computation time: {1} msecs]",
                mersenne.Cardinality, sw.ElapsedMilliseconds);
            Console.WriteLine();
        }
    }
}





