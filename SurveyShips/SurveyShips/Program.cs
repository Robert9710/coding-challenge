using System;
using System.Collections.Generic;

namespace SurveyShips
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> shipsInfo = new List<string>();
            string gridSize, shipInfo;

            //Get user input
            Console.WriteLine("Please enter the dimensions for the grid");
            gridSize = Console.ReadLine();
            Console.WriteLine("Please enter coordinates and instructions for all ships on separate lines.");
            shipInfo = Console.ReadLine();
            while (!shipInfo.Equals(""))
            {
                shipsInfo.Add(shipInfo);
                shipInfo = Console.ReadLine();
            }

            //Format user input
            int.TryParse(gridSize.Split(" ")[0], out int dimensionX);
            int.TryParse(gridSize.Split(" ")[1], out int dimensionY);
        }
    }
}
