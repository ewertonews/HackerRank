using System;
using System.Linq;

namespace RepeatedStrings
{
    class Program
    {
        static long RepeatedString(string s, long n)
        {
            if (s.Length == 1 && s == "a")
            {
                return n;
            }

            int countAs = s.Count(c => c == 'a');
            long result = n / s.Length * countAs;
            long divRest = n % s.Length;
            if (divRest > 0)
            {
                int letterIndex = 0;

                int repetitionFactor = s.Length - 1;
                for (int i = 0; i < divRest; i++)
                {
                    if (s[letterIndex] == 'a')
                    {
                        result++;
                    }
                    if (letterIndex == repetitionFactor)
                    {
                        letterIndex = 0;
                    }
                    else
                    {
                        letterIndex++;
                    }
                }
            }            
            return result;
        }

        static void Main(string[] args)
        {
            var result = RepeatedString("anula", 9);
            Console.WriteLine(result);
        }
    }
}
