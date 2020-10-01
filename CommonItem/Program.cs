using System;
using System.Collections.Generic;

namespace CommonItem
{
    
    class Program
    {
        public static bool HasCommonElement(List<string> listOne, List<string> listTwo)
        {
            HashSet<string> values = new HashSet<string>();
            
            foreach (var item in listOne)
            {
                if (!values.Contains(item))
                {
                    values.Add(item);
                }
            }

            foreach (var item in listTwo)
            {
                if (values.Contains(item))
                {
                    return true;
                }
            }

            return false;
        }


        static void Main(string[] args)
        {
            List<string> list1 = new List<string>(){ "a", "b", "x", "y" };
            List<string> list2 = new List<string>() { "f", "z", "p", "q" };

            //HasCommonElement(list1, list2);
            Console.WriteLine(HasCommonElement(list1, list2));
        }
    }
}
