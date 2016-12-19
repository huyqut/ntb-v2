using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace NumberTheory
{
    public class Helper
    {
        public Helper()
        {

        }

        public static List<Tuple<BigInteger, BigInteger, BigInteger>> EEA(BigInteger a, BigInteger b)
        {
            List<Tuple<BigInteger, BigInteger, BigInteger>> ret = new List<Tuple<BigInteger, BigInteger, BigInteger>>();
            BigInteger r = a;
            BigInteger r_1 = b;
            BigInteger s = 1;
            BigInteger s_1 = 0;
            BigInteger t = 0;
            BigInteger t_1 = 1;
            ret.Add(new Tuple<BigInteger, BigInteger, BigInteger>(r, s, t));
            while (!r_1.IsZero)
            {
                BigInteger q = r / r_1;
                BigInteger r_2 = r % r_1;
                r = r_1;
                r_1 = r_2;
                BigInteger temp_s = s;
                BigInteger temp_t = t;
                s = s_1;
                t = t_1;
                s_1 = temp_s - s_1 * q;
                t_1 = temp_t - t_1 * q;

                ret.Add(new Tuple<BigInteger, BigInteger, BigInteger>(r, s, t));
            }
            ret.Add(new Tuple<BigInteger, BigInteger, BigInteger>(0, s_1, t_1));
            return ret;
        }

        public static BigInteger GCD(BigInteger a, BigInteger b)
        {
            if (a < b)
            {
                BigInteger tmp = b;
                b = a;
                a = tmp;
            }

            BigInteger r = a, r_1 = b, r_2;
            while (!r_1.IsZero)
            {
                r_2 = r % r_1;
                r = r_1;
                r_1 = r_2;
            }

            return r;
        }

        //public static BigInteger ModularInverse(BigInteger a, BigInteger b, BigInteger n)
        //{
        //    BigInteger d = GCD(n, a);
        //    if (d.CompareTo(b) != 0)
        //    {
        //        Console.WriteLine("No solution");
        //        return 0;
        //    }

        //    BigInteger a_1 = a / d, b_1 = b / d, n_1 = n / d;
        //    BigInteger t;
        //    if (n_1.CompareTo(1) <= 0)
        //    {
        //        t = 0;
        //    }
        //    else
        //    {
        //        var tmp = EEA(n_1, a_1);
        //        t = tmp[tmp.Count - 2].Item3;
        //        if (tmp[tmp.Count - 2].Item3.CompareTo(0) < 0)
        //            t += n_1;
        //    }

        //    return (t * b_1) % n_1;
        //}

        public static BigInteger Power(BigInteger n, BigInteger exp)
        {
            byte[] exp_arr = exp.ToByteArray();
            BigInteger result = 1, tmp = n;

            foreach (byte b in exp_arr)
            {
                for (int i = 0; i < 8; ++i)
                {
                    if ((b & (1 << i)) > 0)
                        result = result * tmp;
                    tmp = tmp * tmp;
                }
            }

            return result;
        }

        public static BigInteger Sqrt(BigInteger n)
        {
            byte[] n_arr = n.ToByteArray();
            int j = 0;
            bool flag = false;
            for (int i = n_arr.Length - 1; !flag && i >= 0; --i)
            {
                for (int a = 7; !flag && a >= 0; --a, ++j)
                    if ((n_arr[i] & (1 << a)) > 0)
                        flag = true;
            }

            BigInteger len = n_arr.Length * 8 - j;
            BigInteger k = (len - 1) / 2, m = Power(2, k);

            for (BigInteger i = k - 1; i >= 0; --i)
            {
                BigInteger tmp = m + Power(2, i);
                if (Power(tmp, 2).CompareTo(n) <= 0)
                    m = tmp;
            }

            return m;
        }

        public static bool isPrime(BigInteger n)
        {
            if (n < 2)
                return false;
            else if (n == 2)
                return true;
            else if (n % 2 == 0)
                return false;

            BigInteger tmp = Sqrt(n);
            for (BigInteger i = 3; i <= tmp; i += 2)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FermatsTwoSquares.Calculate(1009));
            Console.WriteLine(RationalReconstruction.Calculate(7197183, 1000));
        }
    }
}
