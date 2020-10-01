using System;
using System.Collections.Generic;
using System.Linq;

namespace PairOfSocks
{
    class Program
    {
        static int SockMerchant(int n, int[] ar)
        {

            Dictionary<int, int> socksCount = new Dictionary<int, int>();
            int socksPairs = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (!socksCount.ContainsKey(ar[i]))
                {
                    socksCount[ar[i]] = 1;
                }
                else
                {
                    //can be improved
                    int currentCount = socksCount[ar[i]];
                    currentCount++;
                    socksCount[ar[i]] = currentCount;
                    if (currentCount % 2 == 0)
                    {
                        socksPairs++;
                    }
                }
            }
            
            return socksPairs;
        }

        static void Main(string[] args)
        {
            int[] socks = new int[] { 10, 20, 20, 10, 10, 30, 50, 10, 20 };           
            Console.WriteLine(SockMerchant(9, socks));
        }
    }
}
