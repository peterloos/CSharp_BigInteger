using System;
using System.Diagnostics;

class Test
{
    public static void Test_Ctors()
    {
        // testing c'tors
        BigInteger n = new BigInteger("12345678901234567890123456789012345678901234567890");
        Console.WriteLine("{0}", n);
        n = new BigInteger("-12345678901234567890123456789012345678901234567890");
        Console.WriteLine("{0}", n);
        n = new BigInteger("-123.456.789.012.345.678");
        Console.WriteLine("{0}", n);

        n = new BigInteger(Int32.MaxValue);
        Console.WriteLine("{0}", n);
        n = new BigInteger(Int64.MaxValue);
        Console.WriteLine("{0}", n);
        n = new BigInteger(Int32.MinValue);
        Console.WriteLine("{0}", n);
        n = new BigInteger(Int64.MinValue);
        Console.WriteLine("{0}", n);
    }

    public static void Test_ToString()
    {
        // testing ToString
        BigInteger n;

        n = new BigInteger("+123.456.789.012");
        Console.WriteLine("{0}", n);
        n = new BigInteger("-123.456.789.012");
        Console.WriteLine("{0}", n);

        n = new BigInteger("123.456.789.012");
        Console.WriteLine("{0}", n);
        n = new BigInteger("12.345.678.901");
        Console.WriteLine("{0}", n);
        n = new BigInteger("1.234.567.890");
        Console.WriteLine("{0}", n);
        n = new BigInteger("123.456.789");
        Console.WriteLine("{0}", n);

        n = new BigInteger("123.456.789.012");
        Console.WriteLine("{0:3}", n);
        n = new BigInteger("+123.456.789.012");
        Console.WriteLine("{0:3}", n);
        n = new BigInteger("-123.456.789.012");
        Console.WriteLine("{0:3}", n);
    }

    public static void Test_Clone()
    {
        BigInteger n1 = new BigInteger("12345");
        Console.WriteLine("n1: {0}", n1);
        BigInteger n2 = (BigInteger) n1.Clone();
        Console.WriteLine("n2: {0}", n2);
        Console.WriteLine("{0}", n1 == n2);
        Console.WriteLine();
    }

    public static void Test_Singletons()
    {
        BigInteger one1 = BigInteger.One;
        BigInteger one2 = BigInteger.One;
        Console.WriteLine("n1: {0}", one1.GetHashCode());
        Console.WriteLine("n2: {0}", one2.GetHashCode());
        Console.WriteLine();
    }

    // ---------------------------------------------------

    public static void Test_Add_01_Unsigned()
    {
        // testing unsigned add operation
        BigInteger n1;
        BigInteger n2;

        n1 = new BigInteger("12345678");
        n2 = new BigInteger("87654321");
        Console.WriteLine("{0} + {1} = {2}", n1, n2, n1 + n2);

        n1 = new BigInteger("99999999999999");
        n2 = new BigInteger("1");
        Console.WriteLine("{0} + {1} = {2}", n1, n2, n1 + n2);
    }

    public static void Test_Add_02_Signed()
    {
        // testing signed add operation
        BigInteger n1;
        BigInteger n2;

        n1 = new BigInteger("333");
        n2 = new BigInteger("222");
        Console.WriteLine("{0} + {1} = {2}", n1, n2, n1 + n2);

        n1 = new BigInteger("-333");
        n2 = new BigInteger("222");
        Console.WriteLine("{0} + {1} = {2}", n1, n2, n1 + n2);

        n1 = new BigInteger("333");
        n2 = new BigInteger("-222");
        Console.WriteLine("{0} + {1} = {2}", n1, n2, n1 + n2);

        n1 = new BigInteger("-333");
        n2 = new BigInteger("-222");
        Console.WriteLine("{0} + {1} = {2}", n1, n2, n1 + n2);
        Console.WriteLine();
    }

    public static void Test_Add_03_Signed()
    {
        // testing signed add operation
        long n1;
        long n2;

        n1 = 98765432123456789;
        n2 = 989898989898;
        Console.WriteLine("{0} + {1} = {2}", n1, n2, n1 + n2);

        n1 = -98765432123456789;
        n2 = 989898989898;
        Console.WriteLine("{0} + {1} = {2}", n1, n2, n1 + n2);

        n1 = 98765432123456789;
        n2 = -989898989898;
        Console.WriteLine("{0} + {1} = {2}", n1, n2, n1 + n2);

        n1 = -98765432123456789;
        n2 = -989898989898;
        Console.WriteLine("{0} + {1} = {2}", n1, n2, n1 + n2);
        Console.WriteLine();

        // testing signed add operation
        BigInteger b1;
        BigInteger b2;

        b1 = 98765432123456789;
        b2 = 989898989898;
        Console.WriteLine("{0} + {1} = {2}", b1, b2, b1 + b2);

        b1 = -98765432123456789;
        b2 = 989898989898;
        Console.WriteLine("{0} + {1} = {2}", b1, b2, b1 + b2);

        b1 = 98765432123456789;
        b2 = -989898989898;
        Console.WriteLine("{0} + {1} = {2}", b1, b2, b1 + b2);

        b1 = -98765432123456789;
        b2 = -989898989898;
        Console.WriteLine("{0} + {1} = {2}", b1, b2, b1 + b2);
        Console.WriteLine();
    }

    // ---------------------------------------------------

    public static void Test_Sub_01_Unsigned()
    {
        // testing unsigned sub operation
        BigInteger b1;
        BigInteger b2;

        b1 = new BigInteger("999");
        b2 = new BigInteger("900");
        Console.WriteLine("{0} - {1} = {2}", b1, b2, b1 - b2);

        b1 = new BigInteger("999");
        b2 = new BigInteger("998");
        Console.WriteLine("{0} - {1} = {2}", b1, b2, b1 - b2);

        b1 = new BigInteger("999");
        b2 = new BigInteger("999");
        Console.WriteLine("{0} - {1} = {2}", b1, b2, b1 - b2);

        b1 = new BigInteger("11111");
        b2 = new BigInteger("222");
        Console.WriteLine("{0} - {1} = {2}", b1, b2, b1 - b2);

        b1 = new BigInteger("1000000");
        b2 = new BigInteger("1");
        Console.WriteLine("{0} - {1} = {2}", b1, b2, b1 - b2);
        Console.WriteLine();
    }

    public static void Test_Sub_02_Signed()
    {
        // testing signed sub operation
        BigInteger n1;
        BigInteger n2;

        n1 = new BigInteger("333");
        n2 = new BigInteger("222");
        Console.WriteLine("{0} - {1} = {2}", n1, n2, n1 - n2);

        n1 = new BigInteger("-333");
        n2 = new BigInteger("222");
        Console.WriteLine("{0} - {1} = {2}", n1, n2, n1 - n2);

        n1 = new BigInteger("333");
        n2 = new BigInteger("-222");
        Console.WriteLine("{0} - {1} = {2}", n1, n2, n1 - n2);

        n1 = new BigInteger("-333");
        n2 = new BigInteger("-222");
        Console.WriteLine("{0} - {1} = {2}", n1, n2, n1 - n2);
        Console.WriteLine();

        // -----------------------------------------------------

        n1 = new BigInteger("222");
        n2 = new BigInteger("333");
        Console.WriteLine("{0} - {1} = {2}", n1, n2, n1 - n2);

        n1 = new BigInteger("-222");
        n2 = new BigInteger("333");
        Console.WriteLine("{0} - {1} = {2}", n1, n2, n1 - n2);

        n1 = new BigInteger("222");
        n2 = new BigInteger("-333");
        Console.WriteLine("{0} - {1} = {2}", n1, n2, n1 - n2);

        n1 = new BigInteger("-222");
        n2 = new BigInteger("-333");
        Console.WriteLine("{0} - {1} = {2}", n1, n2, n1 - n2);
    }

    public static void Test_Sub_03_Signed()
    {
        // testing c'tors
        long n1;
        long n2;

        n1 = 98765432123456789;
        n2 = 989898989898;
        Console.WriteLine("{0} - {1} = {2}", n1, n2, n1 - n2);

        n1 = -98765432123456789;
        n2 = 989898989898;
        Console.WriteLine("{0} - {1} = {2}", n1, n2, n1 - n2);

        n1 = 98765432123456789;
        n2 = -989898989898;
        Console.WriteLine("{0} - {1} = {2}", n1, n2, n1 - n2);

        n1 = -98765432123456789;
        n2 = -989898989898;
        Console.WriteLine("{0} - {1} = {2}", n1, n2, n1 - n2);
        Console.WriteLine();

        BigInteger b1;
        BigInteger b2;

        b1 = 98765432123456789;
        b2 = 989898989898;
        Console.WriteLine("{0} - {1} = {2}", b1, b2, b1 - b2);

        b1 = -98765432123456789;
        b2 = 989898989898;
        Console.WriteLine("{0} - {1} = {2}", b1, b2, b1 - b2);

        b1 = 98765432123456789;
        b2 = -989898989898;
        Console.WriteLine("{0} - {1} = {2}", b1, b2, b1 - b2);

        b1 = -98765432123456789;
        b2 = -989898989898;
        Console.WriteLine("{0} - {1} = {2}", b1, b2, b1 - b2);
        Console.WriteLine();

        // ---------------------------------------------------

        n1 = 989898989898;
        n2 = 98765432123456789;
        Console.WriteLine("{0} - {1} = {2}", n1, n2, n1 - n2);

        n1 = 989898989898;
        n2 = -98765432123456789;
        Console.WriteLine("{0} - {1} = {2}", n1, n2, n1 - n2);

        n1 = -989898989898;
        n2 = 98765432123456789;
        Console.WriteLine("{0} - {1} = {2}", n1, n2, n1 - n2);

        n1 = -989898989898;
        n2 = -98765432123456789;
        Console.WriteLine("{0} - {1} = {2}", n1, n2, n1 - n2);
        Console.WriteLine();

        // ---------------------------------------------------

        b1 = 989898989898;
        b2 = 98765432123456789;
        Console.WriteLine("{0} - {1} = {2}", b1, b2, b1 - b2);

        b1 = 989898989898;
        b2 = -98765432123456789;
        Console.WriteLine("{0} - {1} = {2}", b1, b2, b1 - b2);

        b1 = -989898989898;
        b2 = 98765432123456789;
        Console.WriteLine("{0} - {1} = {2}", b1, b2, b1 - b2);

        b1 = -989898989898;
        b2 = -98765432123456789;
        Console.WriteLine("{0} - {1} = {2}", b1, b2, b1 - b2);
        Console.WriteLine();
    }

    // ---------------------------------------------------

    public static void Test_Mul_01_Unsigned()
    {
        // testing unsigned mul operation
        BigInteger n1;
        BigInteger n2;

        n1 = new BigInteger(99);
        n2 = new BigInteger(99);
        Console.WriteLine("{0} * {1} = {2}", n1, n2, n1 * n2);

        n1 = new BigInteger(9999999999);
        n2 = new BigInteger(9999999999);
        Console.WriteLine("{0} * {1} = {2}", n1, n2, n1 * n2);

        // testing multiplication
        n1 = new BigInteger("1212121212");
        n2 = new BigInteger("4343434343");
        Console.WriteLine("{0} * {1} = {2}", n1, n2, n1 * n2);

        // multiplication example from script
        n1 = new BigInteger("973018");
        n2 = new BigInteger("9758");
        Console.WriteLine("{0} * {1} = {2}", n1, n2, n1 * n2);

        // testing multiplication
        n1 = new BigInteger("3");
        n2 = new BigInteger("50");
        Console.WriteLine("{0} * {1} = {2}", n1, n2, n1 * n2);
        Console.WriteLine();
    }


    public static void Test_Mul_02_Signed()
    {
        // testing signed mul operation
        BigInteger n1;
        BigInteger n2;

        n1 = new BigInteger("333");
        n2 = new BigInteger("222");
        Console.WriteLine("{0} * {1} = {2}", n1, n2, n1 * n2);

        n1 = new BigInteger("-333");
        n2 = new BigInteger("222");
        Console.WriteLine("{0} * {1} = {2}", n1, n2, n1 * n2);

        n1 = new BigInteger("333");
        n2 = new BigInteger("-222");
        Console.WriteLine("{0} * {1} = {2}", n1, n2, n1 * n2);

        n1 = new BigInteger("-333");
        n2 = new BigInteger("-222");
        Console.WriteLine("{0} * {1} = {2}", n1, n2, n1 * n2);
        Console.WriteLine();
    }

    public static void Test_Mul_03_Signed()
    {
        // testing signed mul operation
        BigInteger n1;
        BigInteger n2;

        n1 = 98765432123456789;
        n2 = 989898989898;
        Console.WriteLine("{0} * {1} = {2}", n1, n2, n1 * n2);

        n1 = -98765432123456789;
        n2 = 989898989898;
        Console.WriteLine("{0} * {1} = {2}", n1, n2, n1 * n2);

        n1 = 98765432123456789;
        n2 = -989898989898;
        Console.WriteLine("{0} * {1} = {2}", n1, n2, n1 * n2);

        n1 = -98765432123456789;
        n2 = -989898989898;
        Console.WriteLine("{0} * {1} = {2}", n1, n2, n1 * n2);
        Console.WriteLine();
    }

    // ---------------------------------------------------

    public static void Test_Div_01_Unsigned()
    {
        // testing unsigned div operation
        BigInteger n1;
        BigInteger n2;

        // 10
        n1 = 100;
        n2 = 10;
        Console.WriteLine("{0} / {1} = {2}", n1, n2, n1 / n2);

        // 34.096
        n1 = 6682850;
        n2 = 196;
        Console.WriteLine("{0} / {1} = {2}", n1, n2, n1 / n2);

        // 3003
        n1 = 30027000;
        n2 = 9999;
        Console.WriteLine("{0} / {1} = {2}", n1, n2, n1 / n2);

        // 13.821.503
        n1 = 191033945179009;
        n2 = 13821503;
        Console.WriteLine("{0} / {1} = {2}", n1, n2, n1 / n2);

        // 3707
        n1 = new BigInteger("1234567");
        n2 = new BigInteger("333");
        Console.WriteLine("{0} / {1} = {2}", n1, n2, n1 / n2);

        // 22985
        n1 = new BigInteger("7654321");
        n2 = new BigInteger("333");
        Console.WriteLine("{0} / {1} = {2}", n1, n2, n1 / n2);

        // 33
        n1 = new BigInteger("1111");
        n2 = new BigInteger("33");
        Console.WriteLine("{0} / {1} = {2}", n1, n2, n1 / n2);
    }

    public static void Test_Div_02_Signed()
    {
        // testing signed div operation
        BigInteger n1;
        BigInteger n2;

        n1 = 1000;
        n2 = 33;
        Console.WriteLine("{0} / {1} = {2}", n1, n2, n1 / n2);

        n1 = -1000;
        n2 = 33;
        Console.WriteLine("{0} / {1} = {2}", n1, n2, n1 / n2);

        n1 = 1000;
        n2 = -33;
        Console.WriteLine("{0} / {1} = {2}", n1, n2, n1 / n2);

        n1 = -1000;
        n2 = -33;
        Console.WriteLine("{0} / {1} = {2}", n1, n2, n1 / n2);
    }

    // ---------------------------------------------------

    public static void Test_Mod_01_Signed()
    {
        // testing signed modulus operation
        BigInteger n1;
        BigInteger n2;

        n1 = 1000;
        n2 = 33;
        Console.WriteLine("{0} % {1} = {2}", n1, n2, n1 % n2);

        n1 = -1000;
        n2 = 33;
        Console.WriteLine("{0} % {1} = {2}", n1, n2, n1 % n2);

        n1 = 1000;
        n2 = -33;
        Console.WriteLine("{0} % {1} = {2}", n1, n2, n1 % n2);

        n1 = -1000;
        n2 = -33;
        Console.WriteLine("{0} % {1} = {2}", n1, n2, n1 % n2);
    }

    public static void Test_Mod_02_Signed()
    {
        // testing signed modulus operation - from Wikipedia ("Division mit Rest")
        BigInteger n1;
        BigInteger n2;

        n1 = 7;
        n2 = 3;
        Console.WriteLine("{0} % {1} = {2}", n1, n2, n1 % n2);

        n1 = -7;
        n2 = 3;
        Console.WriteLine("{0} % {1} = {2}", n1, n2, n1 % n2);

        n1 = 7;
        n2 = -3;
        Console.WriteLine("{0} % {1} = {2}", n1, n2, n1 % n2);

        n1 = -7;
        n2 = -3;
        Console.WriteLine("{0} % {1} = {2}", n1, n2, n1 % n2);
    }

    // ---------------------------------------------------

    public static void Test_IncrementDecrement()
    {
        // addition example from script
        BigInteger n1 = 5;
        BigInteger b2;

        b2 = n1;
        Console.WriteLine("{0} [expecting '5']", b2);
        b2 = n1++;
        Console.WriteLine("{0} [expecting '5']", b2);
        b2 = ++n1;
        Console.WriteLine("{0} [expecting '7']", b2);

        Console.WriteLine("{0} [expecting '7']", b2);
        b2 = --n1;
        Console.WriteLine("{0} [expecting '6']", b2);
        b2 = n1--;
        Console.WriteLine("{0} [expecting '5']", b2);
    }

    // ---------------------------------------------------

    public static void Test_Equals()
    {
        BigInteger n1 = new BigInteger("123456789");
        BigInteger n2 = new BigInteger("123456789");
        Console.WriteLine("{0} Equals {1}: {2}", n1, n2, n1.Equals(n2));

        n1++;
        Console.WriteLine("{0} Equals {1}: {2}", n1, n2, n1.Equals(n2));
        n1--;
        Console.WriteLine("{0} Equals {1}: {2}", n1, n2, n1.Equals(n2));
    }
}

