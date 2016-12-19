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
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RationalReconstruction.Calculate(7197183, 1000));
        }
    }
}
