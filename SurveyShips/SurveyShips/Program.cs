using System;
using System.Collections.Generic;

namespace SurveyShips
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> ships = new List<string>();
            string gridSize, shipInfo;

            //Get user input
            Console.WriteLine("Please enter the dimensions for the grid");
            gridSize = Console.ReadLine();
            Console.WriteLine("Please enter coordinates and instructions for all ships on separate lines.");
            shipInfo = Console.ReadLine();
            while (!shipInfo.Equals(""))
            {
                ships.Add(shipInfo);
                shipInfo = Console.ReadLine();
            }

            //Format user input
            int.TryParse(gridSize.Split(" ")[0], out int dimensionX);
            int.TryParse(gridSize.Split(" ")[1], out int dimensionY);

            //Array with cardinal points
            string[] cardPoints = {"N", "W", "S", "E"};

            //Array to store location for each ship
            string[] shipLoc;

            string shipCoords, instructions;

            //Move ships
            for(int i=0; i<ships.Count; i += 2)
            {
                shipCoords = ships[i];
                instructions = ships[i + 1];
                shipLoc = shipCoords.Split(" ");
                int.TryParse(shipLoc[0], out int shipX);
                int.TryParse(shipLoc[1], out int shipY);
                int.TryParse(shipLoc[2], out int shipOrientation);
            }
        }
    }
}
