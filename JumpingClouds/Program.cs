using System;

namespace JumpingClouds
{
    class Program
    {
        static int JumpingOnClouds(int[] c)
        {
            int jumps = 0;
            int lastCloudIndex = c.Length - 1;
            int destinationCloud = 0;
            do
            {               
                destinationCloud = JumpCloud(destinationCloud, c);
                jumps++;
            } while (destinationCloud < lastCloudIndex);           


            return jumps;
        }

        private static int JumpCloud(int currentCloudIndex, int[] clouds)
        {
            bool twoJumpsInBounds = currentCloudIndex + 2 <= clouds.Length - 1;
            if (twoJumpsInBounds && clouds[currentCloudIndex + 2] == 0)
            {
                return currentCloudIndex + 2;
            }
            return currentCloudIndex + 1;
        }

        static void Main(string[] args)
        {
            int[] clouds1 = new int[] { 0, 0, 0, 0, 1, 0 };
            int result = JumpingOnClouds(clouds1);
            Console.WriteLine(result);

            clouds1 = new int[] { 0, 0, 1, 0, 0, 1, 0 };
            result = JumpingOnClouds(clouds1);
            //0 0 1 0 0 1 0
            Console.WriteLine(result);
        }
    }
}
