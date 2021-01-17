using MarsRover.Interface;
using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class Rover : IRoverPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Directions Direction { get; set; }
        public string RoversRoute { get; set; }

        public static List<Rover> RoversRouteList = new List<Rover>();

        public Rover()
        {

        }

        public void TurnRight()
        {
            switch (Direction)
            {
                case Directions.N:
                    Direction = Directions.E;
                    break;
                case Directions.S:
                    Direction = Directions.W;
                    break;
                case Directions.E:
                    Direction = Directions.S;
                    break;
                case Directions.W:
                    Direction = Directions.N;
                    break;
                default:
                    break;
            }
        }

        public void TurnLeft()
        {
            switch (Direction)
            {
                case Directions.N:
                    Direction = Directions.W;
                    break;
                case Directions.S:
                    Direction = Directions.E;
                    break;
                case Directions.E:
                    Direction = Directions.N;
                    break;
                case Directions.W:
                    Direction = Directions.S;
                    break;
                default:
                    break;
            }
        }

        public void MoveForward()
        {
            switch (Direction)
            {
                case Directions.N:
                    Y = Y + 1;
                    break;
                case Directions.S:
                    Y = Y - 1;
                    break;
                case Directions.E:
                    X = X + 1;
                    break;
                case Directions.W:
                    X = X - 1;
                    break;
                default:
                    break;
            }
        }

        public void StartTravel(List<int> coordinatesLimit, string roversRoute)
        {

            foreach (var movement in roversRoute)
            {
                switch (movement)
                {
                    case 'M':
                        MoveForward();
                        break;
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    default:
                        Console.WriteLine($"Invalid Character {movement}");
                        break;
                }                
            }
        }
    }
}
