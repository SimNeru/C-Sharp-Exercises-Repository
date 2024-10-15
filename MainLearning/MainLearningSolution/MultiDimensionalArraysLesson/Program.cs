using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDimensionalArraysLesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Gli array multidimensionali vengono raramente utilizzati, rispetto alle collections che consentono la gestione di oggetti
             */

            // define multidimensional array, il comma (,) indica quante dimensioni sono definibili
            // 4x3
            int[,] array = new int[4,3] 
            {
                { 10,20,30 },
                { 40,50,60 },
                { 70,80,90 },
                { 100,110,120}
            };

            // read data from multi-dim array
            for (int i = 0; i < 4; i++) 
            { 
                for(int j=0; j < 3; j++)
                {
                    Console.Write(array[i,j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
