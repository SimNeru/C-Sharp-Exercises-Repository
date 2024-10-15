using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArrayLesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* I jagged arrays sono array di array di array (T_T)
             */

            int[][] a = new int[5][];
            a[0] = new int[3] { 1,2,3 };
            a[1] = new int[4] { 1,2,3,4 };
            a[2] = new int[5] { 1,2,3,4,5 };
            a[3] = new int[6] { 1,2,3,4,5,6 };
            a[4] = new int[7] { 1,2,3,4,5,6,7 };

            // lettura jag arrays
            for (int i = 0; i < a.Length; i++) 
            {
                for (int j = 0; j < a[i].Length; j++) 
                {
                    Console.Write(a[i][j]);
                    Console.Write("");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
