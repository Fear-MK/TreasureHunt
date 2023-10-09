using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace TreasureHunt
{
    internal class Program
    {

        static void DisplayGrid(int[] treasure, Char[,] Island)
        {
            for (int i = 0; i < Island.Length; i++)
            {
                for (int j = 0; j < Island.GetLength(1); j++) //gets collumn length.
                {
                    if (Island[i, j] == '\x0000')
                    {
                        string character = "0";
                    }
                }
            }
        }
        static double MetresAway(int[] coordinates)
        {
            double x = Math.Pow(coordinates[0], 2);
            double y = Math.Pow(coordinates[1], 2);
            return Math.Pow(0.5, x+y);
        }
        static void Main(string[] args)
        {
            Char[,] Island = new char[20, 20];
            Random R = new Random(0);
            int PosRow = R.Next(0, 20);
            int PosCol = R.Next(0, 20);
            Island[PosRow, PosCol] = 'X';
            int[] coordinates = { PosRow, PosCol };
            List<int[]> guesses = new List<int[]>();

            DisplayGrid(coordinates, Island);

            Console.WriteLine("Ahoy blud, tell mans where the ice is styll (in the form x,y): ");
            string guess;
            while (true)
            {
                guess = Console.ReadLine();
                Regex regex = new Regex(@"^[0-9]+, [0-9]+$");

                // Match the regular expression against the input string.
                Match match = regex.Match(guess);

                if (!match.Success)
                {
                    Console.WriteLine("Argh, thats in the wrong format matey, try again.");
                    continue;
                }
                else
                {
                    break;
                }
            }
            int[] guess_coordinates = guess.Split(',').Select(x => int.Parse(x)).ToArray();
            if (guess_coordinates == coordinates)
            {
                Console.WriteLine("ARGH, YOU FOUND ME TREASURE, KILL YOURSELF.");
            }
            else
            {
                Console.WriteLine("Nice one loser, you didnt find it.");
            }

        }
    }
}
