using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2_PP3_JaggedArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            int num = 0;
            bool isNum = false;

            int[][] theArray = new int[][] { };

            double[] rows = { };
            double[] cols = { };
            double[] avg = { 0, 0 }; // row, col

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This demonstration is written by Julian Antonio Laspona for Programming 2");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("The submission date is on 06 March 2023\n\n");
            
            // generating the array section (user input)
            do
            {
                Console.ResetColor();
                Console.Write("Please input the number of rows you want to have : ");
                Console.ForegroundColor = ConsoleColor.Green;
                isNum = int.TryParse(Console.ReadLine(), out num);
                if (isNum && num <= 0)
                    isNum = false;
            } while (!isNum);
            rows = new double[num];

            isNum = false;
            do
            {
                Console.ResetColor();
                Console.Write("Please input the number of columns you want to have : ");
                Console.ForegroundColor = ConsoleColor.Green;
                isNum = int.TryParse(Console.ReadLine(), out num);
                if (isNum && num <= 0)
                    isNum = false;
            } while (!isNum);
            cols = new double[num];

            theArray = new int[rows.Length][];
            for (int x = 0; x < theArray.Length; x++)
                theArray[x] = new int[cols.Length];

            // filling up the array with numbers
            // for this example im just going to display using random numbers
            // but you may approach this in a similar way as above
            for (int x = 0; x < theArray.Length; x++)
            {
                for (int y = 0; y < theArray[x].Length; y++)
                {
                    theArray[x][y] = rnd.Next(0, 100) + 1;
                }
            }

            // I could have made things alot shorter in terms of code
            // I chose to do them in separate functions so that it just makes
            // more sense for you guys
            // this sections adds all the values in the columns and the rows
            for (int x = 0; x < theArray.Length; x++)
            {
                for (int y = 0; y < theArray[x].Length; y++)
                {
                    rows[x] += theArray[x][y];
                    cols[y] += theArray[x][y];
                }
            }

            // get the average per row
            // the number of elements in each row is how many columns
            for (int x = 0; x < rows.Length; x++)
                rows[x] /= cols.Length;

            // get the average per columns
            // the number of elements in each column is now many rows
            for (int x = 0; x < cols.Length; x++)
                cols[x] /= rows.Length;

            // getting the average value of the rows and columns
            // rows
            for (int x = 0; x < rows.Length; x++)
                avg[0] += rows[x];
            avg[0] /= rows.Length;

            // cols
            for (int x = 0; x < cols.Length; x++)
                avg[1] += cols[x];
            avg[1] /= cols.Length;

            // displaying all the things
            for (int x = 0; x < theArray.Length; x++)
            {
                Console.ResetColor();
                for (int y = 0; y < theArray[x].Length; y++)
                {
                    Console.Write(theArray[x][y] + "\t");
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(rows[x]);
            }

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            for (int x = 0; x < cols.Length; x++)
                Console.Write(cols[x] + "\t");

            Console.ResetColor();
            Console.WriteLine("\n");
            Console.WriteLine("The average sum for rows is : " + avg[0]);
            Console.WriteLine("The average sum for columns is : " + avg[1]);
            Console.ReadKey();
        }
    }
}
