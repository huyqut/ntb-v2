using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace NumberTheory
{
    class FermatsTwoSquares
    {
        public static Tuple<BigInteger, BigInteger> Calculate(BigInteger p)
        {
            // Check if p is prime
            if (!Helper.isPrime(p))
            {
                Console.WriteLine("No solution.");
                return null;
            }

            // Check if p = 1 (mod 4)
            if ((p % 4).CompareTo(1) != 0)
            {
                Console.WriteLine("No solution.");
                return null;
            }

            Random rand = new Random();
            BigInteger gamma, b;
            Dictionary<int, bool> dict = new Dictionary<int, bool>();

            do
            {
                int next = rand.Next();
                while (dict.ContainsKey(next))
                    next = rand.Next();
                dict[next] = true;

                gamma = new BigInteger(next);
                b = Helper.Power(gamma, (p - 1) / 4) % p;

            } while (((b * b) % p).CompareTo(p - 1) != 0);


            Console.WriteLine("Running EEA on p = {0} and b = {1}", p, b);
            var eea = Helper.EEA(p, b);

            Console.WriteLine(String.Format("{0, -5} | {1, -10} | {2, -10} | {3, -10}", "i", "r", "s", "t"));
            Console.WriteLine(new string('-', 47));
            int i = 0;

            Tuple<BigInteger, BigInteger> result = null;
            BigInteger r_star = Helper.Sqrt(p) + 1;
            foreach (var item in eea)
            {
                Console.WriteLine(String.Format("{0, 5} | {1, 10} | {2, 10} | {3, 10}", i, item.Item1, item.Item2, item.Item3));
                ++i;
            }

            for (i = 0; i < eea.Count; ++i)
            {
                if (eea[i].Item1 < r_star)
                {
                    result = new Tuple<BigInteger, BigInteger>(eea[i].Item1, eea[i].Item3);
                    break;
                }
            }

            return result;
        }
    }
}
