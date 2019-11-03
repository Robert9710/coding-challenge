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
            string[] cardPoints = {"N", "E", "S", "W"};

            //Array to store location for each ship
            string[] shipLoc;

            string shipCoords, instrs;
            int i = 0;

            //Move ships
            for(int j=0; j<ships.Count; j += 2)
            {
                shipCoords = ships[j];
                instrs = ships[j + 1];
                shipLoc = shipCoords.Split(" ");

                //Format ship location
                int.TryParse(shipLoc[0], out int shipX);
                int.TryParse(shipLoc[1], out int shipY);

                //Set i to current orientation of ship
                switch (shipLoc[2])
                {
                    case "N":
                        i = 0;
                        break;
                    case "E":
                        i = 1;
                        break;
                    case "S":
                        i = 2;
                        break;
                    case "W":
                        i = 3;
                        break;
                }

                foreach(char instr in instrs)
                {
                    if (instr == 'F')
                    {
                        if (i == 0)
                        {
                            shipY += 1;
                        }
                        else if(i == 1)
                        {
                            shipX += 1;
                        }
                        else if (i == 2)
                        {
                            shipY -= 1;
                        }
                        else if (i == 3)
                        {
                            shipX -= 1;
                        }
                    }
                    else if(instr == 'L')
                    {
                        if(i - 1 < 0)
                        {
                            i = 3;
                        }
                        else
                        {
                            i -= 1;
                        }
                    }
                    else if (instr == 'R')
                    {
                        if (i + 1 > 3)
                        {
                            i = 0;
                        }
                        else
                        {
                            i += 1;
                        }
                    }
                }
            }
        }
    }
}
