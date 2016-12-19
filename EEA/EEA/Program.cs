using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace EEA
{

    public class Helper
    {
        public Helper()
        {

        }

        public List<Tuple<BigInteger, BigInteger, BigInteger>> EEA(BigInteger a, BigInteger b)
        {
            BigInteger r = a;
            BigInteger r_1 = b;
            BigInteger s = 1;
            BigInteger s_1 = 0;
            BigInteger t = 0;
            BigInteger t_1 = 1;
            List<Tuple<BigInteger, BigInteger, BigInteger>> ret = new List<Tuple<BigInteger, BigInteger, BigInteger>>();
            while (!r_1.IsZero)
            {
                BigInteger q = r / r_1;
                BigInteger r_2 = r % r_1;
                r = r_1;
                s = s_1;
                t = t_1;
                r_1 = r_2;
                s_1 = s - s_1 * q;
                t_1 = t - t_1 * q;
                ret.Add(new Tuple<BigInteger, BigInteger, BigInteger>(r, s, t));
            }
            return ret;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
