using System;
using System.Collections.Generic;

namespace SurveyShips
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> ships = new List<string>();
            /*
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
            */

            int dimensionX = 5, dimensionY = 3;
            ships.Add("1 1 E");
            ships.Add("RFRFRFRF");
            ships.Add("3 2 N");
            ships.Add("FRRFLLFFRRFLL");
            ships.Add("0 3 W");
            ships.Add("LLFFFLFLFL");
            

            //Array with cardinal points
            string[] cardPoints = {"N", "E", "S", "W"};

            //Array to store location for each ship
            string[] shipLoc;

            string shipCoords, instrs;
            int i = 0;

            IList<KeyValuePair<int, int>> lostShips = new List<KeyValuePair<int, int>>();
            KeyValuePair<int, int> shipXY;

            //Move ships
            for (int j=0; j<ships.Count; j += 2)
            {
                bool lost = false;
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

                //Execute instructions
                foreach(char instr in instrs)
                {
                    shipXY = new KeyValuePair<int, int>(shipX, shipY);
                    if (instr == 'F')
                    {
                        if (i == 0)
                        {
                            if(shipY + 1 > dimensionY)
                            {
                                if (lostShips.Contains(shipXY))
                                {
                                    continue;
                                }
                                else
                                {
                                    lostShips.Add(shipXY);
                                    Console.WriteLine(shipX + " " + shipY + " " + cardPoints[i] + " LOST");
                                    lost = true;
                                    break;
                                }
                            }
                            shipY += 1;
                        }
                        else if(i == 1)
                        {
                            if (shipX + 1 > dimensionX)
                            {
                                if (lostShips.Contains(shipXY))
                                {
                                    continue;
                                }
                                else
                                {
                                    lostShips.Add(shipXY);
                                    Console.WriteLine(shipX + " " + shipY + " " + cardPoints[i] + " LOST");
                                    lost = true;
                                    break;
                                }
                            }
                            shipX += 1;
                        }
                        else if (i == 2)
                        {
                            if (shipY - 1 < 0)
                            {
                                if (lostShips.Contains(shipXY))
                                {
                                    continue;
                                }
                                else
                                {
                                    lostShips.Add(shipXY);
                                    Console.WriteLine(shipX + " " + shipY + " " + cardPoints[i] + " LOST");
                                    lost = true;
                                    break;
                                }
                            }
                            shipY -= 1;
                        }
                        else if (i == 3)
                        {
                            if (shipX - 1 < 0)
                            {
                                if (lostShips.Contains(shipXY))
                                {
                                    continue;
                                }
                                else
                                {
                                    lostShips.Add(shipXY);
                                    Console.WriteLine(shipX + " " + shipY + " " + cardPoints[i] + " LOST");
                                    lost = true;
                                    break;
                                }
                            }
                            shipX -= 1;
                        }
                    }
                    //Update i to indicate current ship orientation
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
                if (!lost)
                {
                    Console.WriteLine(shipX + " " + shipY + " " + cardPoints[i]);
                }
            }
        }
    }
}
