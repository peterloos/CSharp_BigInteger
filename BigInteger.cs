using System;
using System.Text;

class BigInteger : Object, IFormattable, ICloneable, IComparable<BigInteger>
{
    private int[] digits;
    private bool sign;

    // c'tors: default c'tor
    public BigInteger()
    {
        this.digits = new int[1];
        this.digits[0] = 0;
        this.sign = true;
    }

    // user-defined c'tor
    public BigInteger(String s)
    {
        // count number of digits
        int count = 0;
        for (int i = 0; i < s.Length; i++)
            if (Char.IsDigit(s[i]))
                count++;

        // set sign
        this.sign = (s[0] == '-') ? false : true;

        // copy digits into array in reverse order
        this.digits = new int[count];
        for (int k = 0, i = s.Length - 1; i >= 0; i--)
        {
            if (Char.IsDigit(s[i]))
            {
                this.digits[k] = s[i] - '0';
                k++;
            }
        }
    }

    // type conversion c'tors
    public BigInteger(int n) : this(n.ToString()) { }
    public BigInteger(long n) : this(n.ToString()) { }

    // internal helper c'tor
    private BigInteger(bool sign, int[] digits)
    {
        this.digits = digits;
        this.sign = sign;
    }

    // properties
    public bool Sign
    {
        get
        {
            return this.sign;
        }
    }

    public int Cardinality
    {
        get
        {
            return this.digits.Length;
        }
    }

    public bool IsNull
    {
        get
        {
            return this.digits.Length == 1 && this.digits[0] == 0;
        }
    }

    // type conversion operators
    public static implicit operator BigInteger(int n)
    {
        return new BigInteger(n);
    }

    public static implicit operator BigInteger(long l)
    {
        return new BigInteger(l);
    }

    public static implicit operator BigInteger(String s)
    {
        return new BigInteger(s);
    }

    public static explicit operator int (BigInteger a)
    {
        long n = (long) a;
        return (int) n;
    }

    public static explicit operator long (BigInteger a)
    {
        long n = 0;
        for (int i = 0; i < a.digits.Length; i++)
            n = (long) 10 * n + (long)a.digits[i];
        return n;
    }

    // unary '+' and '-' operator
    public static BigInteger operator+ (BigInteger a)
    {
        return (BigInteger)a.Clone();
    }

    public static BigInteger operator- (BigInteger a)
    {
        BigInteger tmp = (BigInteger)a.Clone();
        tmp.sign = !a.sign;
        return tmp;
    }

    // binary arithmetic operators
    public static BigInteger operator+ (BigInteger a, BigInteger b)
    {
        // handle sign and change operation, if necessary
        if (a.Sign != b.Sign)
            return (a.Sign) ? a - b.Abs() : b - a.Abs();

        // allocate array
        int[] digits;
        if (a.Cardinality >= b.Cardinality)
            digits = new int[a.Cardinality + 1];
        else
            digits = new int[b.Cardinality + 1];

        // add numbers digit per digit
        int carry = 0;
        for (int i = 0; i < digits.Length; i++)
        {
            if (i < a.Cardinality)
                carry += a.digits[i];
            if (i < b.Cardinality)
                carry += b.digits[i];

            digits[i] = carry % 10;
            carry /= 10;
        }

        BigInteger tmp = new BigInteger(a.Sign, digits);
        tmp.RemoveLeadingZeros();
        return tmp;
    }

    public static BigInteger operator- (BigInteger a, BigInteger b)
    {
        // handle sign and change operation, if necessary
        if (a.Sign != b.Sign)
            return (a.Sign) ? a + b.Abs() : -(a.Abs() + b);

        if (a.Abs() < b.Abs())
            return (a.Sign) ? -(b - a) : b.Abs() - a.Abs();

        // create copy of minuend
        BigInteger tmp = (BigInteger)a.Clone();

        // traverse digits of subtrahend
        for (int i = 0; i < b.Cardinality; i++)
        {
            if (tmp.digits[i] < b.digits[i])
            {
                if (tmp.digits[i + 1] != 0)
                {
                    tmp.digits[i + 1]--;
                    tmp.digits[i] += 10;
                }
                else
                {
                    // preceding digit is zero, cannot borrow directly
                    int pos = i + 1;
                    while (tmp.digits[pos] == 0)
                        pos++;

                    // borrow indirectly
                    for (int k = pos; k >= i + 1; k--)
                    {
                        tmp.digits[k]--;
                        tmp.digits[k - 1] += 10;
                    }
                }
            }

            // subtract current subtrahend digit from minuend digit
            tmp.digits[i] -= b.digits[i];
        }

        tmp.RemoveLeadingZeros();
        return tmp;
    }

    public static BigInteger operator* (BigInteger a, BigInteger b)
    {
        int[] digits = new int[a.Cardinality + b.Cardinality];

        int carry = 0;
        for (int i = 0; i < digits.Length; i++)
        {
            digits[i] = carry;

            for (int j = 0; j < b.Cardinality; j++)
                if (i - j >= 0 && i - j < a.Cardinality)
                    digits[i] += a.digits[i - j] * b.digits[j];

            carry = digits[i] / 10;
            digits[i] %= 10;
        }

        bool sign = (a.Sign == b.Sign) ? true : false;
        BigInteger tmp = new BigInteger(sign, digits);
        tmp.RemoveLeadingZeros();
        return tmp;
    }

    public static BigInteger operator/ (BigInteger a, BigInteger b)
    {
        BigInteger remainder = new BigInteger();
        StringBuilder sbResult = new StringBuilder();

        // need positive divisor
        BigInteger bAbs = b.Abs();

        int pos = a.Cardinality - 1;
        while (pos >= 0)
        {
            // append next digit from dividend to temporary divisor
            int len = (remainder.IsNull) ? 1 : remainder.Cardinality + 1;
            int[] digits = new int[len];

            // copy old digits
            for (int k = 0; k < len - 1; k++)
                digits[k + 1] = remainder.digits[k];

            // fetch digit from dividend
            digits[0] = a.digits[pos];

            remainder = new BigInteger(true, digits);

            // divide current dividend with divisor
            int n = 0;
            while (bAbs <= remainder)
            {
                n++;
                remainder -= bAbs;
            }

            sbResult.Append(n.ToString());

            // fetch next digit from divisor
            pos--;
        }

        BigInteger result = new BigInteger(sbResult.ToString());
        result.sign = (a.Sign == b.Sign) ? true : false;
        result.RemoveLeadingZeros();
        return result;
    }

    public static BigInteger operator% (BigInteger a, BigInteger b)
    {
        return a - b * (a / b);  
    }

    // unary increment and decrement operator ('++' / '--')
    public static BigInteger operator++ (BigInteger a)
    {
        BigInteger tmp = (BigInteger)a.Clone();
        return tmp + 1;
    }

    public static BigInteger operator-- (BigInteger a)
    {
        BigInteger tmp = (BigInteger)a.Clone();
        return tmp - 1;
    }

    // public interface
    public BigInteger Power(int exponent)
    {
        if (exponent == 0)
            return new BigInteger(1);

        BigInteger result = (BigInteger)this.Clone();
        if (exponent == 1)
            return result;

        for (int i = 1; i < exponent; i++)
            result = result * this;
                   
        if (!this.sign && exponent % 2 == 1)
            result.sign = this.sign;

        return result;
    }

    // implementation of interface 'IComparable<BigInteger>'
    public int CompareTo(BigInteger a)
    {
        if (this.sign && !a.sign)
            return 1;
        if (!this.sign && a.sign)
            return -1;

        int order = 0;
        if (this.Cardinality < a.Cardinality)
        {
            order = -1;
        }
        else if (this.Cardinality > a.Cardinality)
        {
            order = 1;
        }
        else
        {
            for (int i = this.Cardinality - 1; i >= 0; i--)
            {
                if (this.digits[i] < a.digits[i])
                {
                    order = -1;
                    break;
                }
                else if (this.digits[i] > a.digits[i])
                {
                    order = 1;
                    break;
                }
            }
        }

        return (this.sign) ? order : -order;
    }

    // public helper methods
    public BigInteger Abs()
    {
        BigInteger tmp = (BigInteger)this.Clone();
        tmp.sign = true;
        return tmp;
    }

    // private helper methods
    private BigInteger PowerOfTen(int factor)
    {
        int[] digits = new int[this.digits.Length + factor];
        for (int i = 0; i < this.digits.Length; i++)
            digits[factor + i] = this.digits[i];
        return new BigInteger(this.sign, digits);
    }

    private void RemoveLeadingZeros()
    {
        // count leading zeros
        int zeros = 0;
        for (int i = this.digits.Length - 1; i >= 0; i--)
        {
            if (this.digits[i] == 0)
            {
                zeros++;
            }
            else
                break;
        }

        // remove leading zeros
        if (zeros > 0)
        {
            if (zeros < this.digits.Length)
            {
                int[] tmp = new int[this.digits.Length - zeros];

                for (int i = 0; i < this.digits.Length - zeros; i++)
                    tmp[i] = this.digits[i];

                this.digits = tmp;
            }
            else
            {
                // create number '0'
                this.digits = new int[1];
                this.digits[0] = 0;
            }
        }
    }

    // comparison operators
    public static bool operator== (BigInteger a, BigInteger b)
    {
        return (a.CompareTo(b) == 0) ? true : false;
    }

    public static bool operator!= (BigInteger a, BigInteger b)
    {
        return !(a == b);
    }

    public static bool operator< (BigInteger a, BigInteger b)
    {
        return (a.CompareTo(b) < 0) ? true : false;
    }

    public static bool operator<= (BigInteger a, BigInteger b)
    {
        return (a.CompareTo(b) <= 0) ? true : false;
    }

    public static bool operator> (BigInteger a, BigInteger b)
    {
        return b < a;
    }

    public static bool operator>= (BigInteger a, BigInteger b)
    {
        return b <= a;
    }

    // overrides
    public override String ToString()
    {
        return this.ToString("8", null);
    }

    public override bool Equals(Object o)
    {
        if (o == null)
            return false;
        if (!(o is BigInteger))
            return false;

        BigInteger tmp = (BigInteger)o;
        return (this == tmp) ? true : false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    // implementation of interface 'ICloneable'
    public Object Clone()
    {
        return new BigInteger(this.ToString());
    }

    // implementation of interface 'IFormattable'
    public String ToString(String format, IFormatProvider formatProvider)
    {
        int blocks;
        if (format != null)
        {
            if (!Int32.TryParse(format, out blocks))
                blocks = 8;

            if (blocks <= 0)
                blocks = 8;
        }
        else
            blocks = 8;

        int linebreak = 0;
        StringBuilder tmp = new StringBuilder();
        if (!this.sign)
            tmp.Append("-");

        // append leading spaces, if necessary
        if (this.Cardinality > 3 * blocks)
        {
            if (this.Cardinality % 3 == 1)
                tmp.Append ((!this.sign) ? " " : "  ");
            else if (this.Cardinality % 3 == 2)
                tmp.Append((!this.sign) ? "" : " ");
            else if (this.Cardinality % 3 == 0)
                tmp.Append((!this.sign) ? Environment.NewLine : "");
        }


        for (int i = this.digits.Length - 1; i >= 0; i--)
        {
            tmp.Append((char)('0' + this.digits[i]));
            if (i > 0 && i % 3 == 0)
            {
                tmp.Append('.');
                linebreak++;
                if (linebreak % blocks == 0)
                    tmp.Append(Environment.NewLine);
            }
        }

        return tmp.ToString();
    }
}

