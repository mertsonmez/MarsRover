using System;
using System.Linq;
using System.Threading;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
        appStart:
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to Mars Rover Tracking System!\n");
            Console.ResetColor();
            Console.WriteLine("Enter the coordinates(x,y) limit : ");
            var coordinatesLimit = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

            Console.WriteLine("\nHow many rovers are there on plateau, please enter?");
            int roversCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < roversCount; i++)
            {
                Console.WriteLine("\nEnter the starting rover of " + (i + 1) + ". Rover and looking way(x,y,direction) : ");
                var startPositions = Console.ReadLine().Trim().Split(' ');
                var rover = new Rover();

                if (startPositions.Count() == 3)
                {
                    rover.X = Convert.ToInt32(startPositions[0]);
                    rover.Y = Convert.ToInt32(startPositions[1]);
                    rover.Direction = (Directions)Enum.Parse(typeof(Directions), startPositions[2]);
                    if (rover.X < 0 || rover.X > coordinatesLimit[0] || rover.Y < 0 || rover.Y > coordinatesLimit[1])
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Rover's initial position can't be outside the (0 , 0) and ({coordinatesLimit[0]} , {coordinatesLimit[1]}) boundaries");
                        Console.ResetColor();
                        Rover.RoversRouteList.Clear();
                        goto appStart;
                    }

                    Rover.RoversRouteList.Add(rover);
                }
                Console.WriteLine("\nEnter the starting rover of " + (i + 1) + ". Rover moves : ");
                Rover.RoversRouteList[i].RoversRoute = Console.ReadLine().ToUpper();
                Console.WriteLine(" ");
            }


            try
            {
                Console.WriteLine("\nLast Locations :\n");
                for (int i = 0; i < Rover.RoversRouteList.Count(); i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green; 
                    Rover.RoversRouteList[i].StartTravel(coordinatesLimit, Rover.RoversRouteList[i].RoversRoute);
                    Console.WriteLine((i + 1) + ".Roves last location :");
                    Console.WriteLine($"{Rover.RoversRouteList[i].X} {Rover.RoversRouteList[i].Y} {Rover.RoversRouteList[i].Direction}");

                    if (i != Rover.RoversRouteList.Count() - 1)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            Thread.Sleep(250);
                            Console.Write(".");
                        }
                        Console.WriteLine(" ");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
