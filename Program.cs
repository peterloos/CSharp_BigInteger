class Program
{
    public static void Main()
    {
        GeneralTest();
        MathTest();
    }

    private static void GeneralTest()
    {
        Test.Test_Ctors();
        Test.Test_ToString();

        Test.Test_Add_01_Unsigned();
        Test.Test_Add_02_Signed();
        Test.Test_Add_03_Signed();

        Test.Test_Sub_01_Unsigned();
        Test.Test_Sub_02_Signed();
        Test.Test_Sub_03_Signed();

        Test.Test_Mul_01_Unsigned();
        Test.Test_Mul_02_Signed();
        Test.Test_Mul_03_Signed();

        Test.Test_Div_01_Unsigned();
        Test.Test_Div_02_Signed();

        Test.Test_Mod_01_Signed();
        Test.Test_Mod_02_Signed();

        Test.Test_IncrementDecrement();
        Test.Test_Equals();

        Test.Test_Power_01();
        Test.Test_Power_02();
    }

    private static void MathTest()
    {
        // testing prime numbers
        BigPrimeNumbers.Test_01();
        BigPrimeNumbers.Test_02();

        // testing faculties
        BigFaculty.Test_01(40);  // using built-in data types (partially wrong results)
        BigFaculty.Test_02(40);  // using BigInteger

        // testing fibonacci numbers
        BigFibonacci.Test_01(30); // built-in data types, recursive
        BigFibonacci.Test_02(30); // built-in data types, iterative
        BigFibonacci.Test_03(30); // using BigInteger, recursive
        BigFibonacci.Test_04(30); // using BigInteger, iterative

        // testing mersenne prime numbers
        BigMersenneNumbers.Test_01();
        BigMersenneNumbers.Test_02();

        // testing perfect numbers
        BigPerfectNumbers.Test_01();
        BigPerfectNumbers.Test_02();
        BigPerfectNumbers.Test_03();
    }
}
