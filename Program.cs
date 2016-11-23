using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace array_test
{
	class Program
	{
        static void Main(string[] args)
		{
			int width = int.Parse(Console.ReadLine());      // Number of cells in each row : provided by the puzzle.
			int height = int.Parse(Console.ReadLine());     // Number of cells in each column : provided by the puzzle.

			char[,] array = new char[width, height];        // An array to hold the characters in each line.

			for (int i = 0; i < height; i++)
			{
				string line = Console.ReadLine();           // Each iteration is a new string of characters made up of 0 or . : provided by the puzzle.
				for (int k = 0; k < line.Length; k++)
				{
					array[k, i] = line[k];                  // First we will parse the lines provided by the puzzle into an array
				}
			}

			Console.WriteLine(array.Length);
			Console.ReadLine();

			string answer = "";

			for (int i = 0; i < height; i++)                // Now we will loop through the array searching for all the '0' characters
			{
				for (int k = 0; k < array.GetLength(0); k++)
				{
					if (array[k, i] != '0')
					{
						continue;                           // We can skip over any non '0' character in the array
					}
					else                                    // Whenever we find a '0' we will need to output a string that contains three values
					{
						answer = k + " " + i + " " + findNextXNode(k, i, array) + " " + findNextYNode(k, i, array);
					}           // The coordinates      The coordinates of the          The coordinates of the
								// of the '0' we        next '0' on the x axis          next '0' on the y axis
								// just found.          of the array.                   of the array.

					Console.WriteLine(answer);
					Console.ReadLine();
				}
			}
		}

		public static string findNextXNode(int xPosition, int yPosition, char[,] arr)   // A function that will locate the next '0' along the x axis of the grid
		{
			for (int i = xPosition + 1; i < arr.GetLength(0); i++)                      // Loop through the remainder of the x axis looking for another '0'
			{
				if (arr[i, yPosition] == '0')
				{
					return i + " " + yPosition;
				}
			}
			return "-1 -1";
		}

		public static string findNextYNode(int xPosition, int yPosition, char[,] arr)   // A function that will locate the next '0' along the y 
		{
			for (int i = yPosition + 1; i < arr.GetLength(1); i++)                      // Loop through the remainder of the y axis looking for another '0'
			{
				if (arr[xPosition, i] == '0')
				{
					return xPosition + " " + i;
				}
			}
			return "-1 -1";
		}
	}
}