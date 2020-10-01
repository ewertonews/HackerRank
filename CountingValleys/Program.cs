using System;
using System.Collections.Generic;

namespace CountingValleys
{
    class Program
    {
        public static int CountingValleys(int steps, string path)
        {
            int seaLevel = 0;
            int letfValley = 0;
            for (int i = 0; i < steps; i++)
            {

                if (path[i] == 'D')
                {
                    seaLevel--;                  
                }
                else 
                {
                    seaLevel++; 
                    if (seaLevel == 0)
                    {
                        letfValley++;
                    }
                }
            }
            return letfValley;
        }
        static void Main(string[] args)
        {
            var result = CountingValleys(3, "DDU");
            Console.WriteLine(result);

            var result2 = CountingValleys(4, "DDUU");
            Console.WriteLine(result2);

            var result3 = CountingValleys(6, "DDUDUU");
            Console.WriteLine(result3);

            var result4 = CountingValleys(8, "UDDDUDUU");
            Console.WriteLine(result4);
        }
    }
}
