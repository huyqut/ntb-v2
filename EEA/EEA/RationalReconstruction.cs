using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace NumberTheory
{
    class RationalReconstruction
    {
        public static Tuple<BigInteger, BigInteger> Calculate(BigInteger digits, BigInteger threshold)
        {
            int power = 0;
            for (BigInteger i = digits; i > 0; i /= 10, ++power);
            BigInteger tenPower = BigInteger.Pow(10, power);
            var possibleResults = Helper.EEA(tenPower, digits);
            Tuple<BigInteger, BigInteger, BigInteger> result = possibleResults.First();
            BigInteger previous = possibleResults.First().Item2;
            int index = 0;
            Console.WriteLine("{0, 21} | {1, 21} | {2, 21} |", "r", "s", "t");
            Console.WriteLine("{0, 21} | {1, 21} | {2, 21} |", " ", " ", " ");
            foreach (var eea in possibleResults)
            {
                if (BigInteger.Abs(eea.Item2) >= threshold)
                {
                    result = possibleResults.ElementAt(index - 1);
                    break;
                }
                Console.WriteLine("{0, 21} | {1, 21} | {2, 21} |", eea.Item1, eea.Item2, eea.Item3);
                ++index;
            }
            if (result.Item2 < 0)
            {
                return new Tuple<BigInteger, BigInteger>(-result.Item2, result.Item3);
            }
            else
            {
                return new Tuple<BigInteger, BigInteger>(result.Item2, -result.Item3);
            }
        }
    }
}
