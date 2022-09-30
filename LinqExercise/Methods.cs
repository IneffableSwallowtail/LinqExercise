using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExercise
{
    public static class Methods
    {
        public static void PrintCommaed(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                Console.Write($"{list[i]}, ");
            }
            Console.WriteLine(list[list.Count - 1]);
        }
    }
}
