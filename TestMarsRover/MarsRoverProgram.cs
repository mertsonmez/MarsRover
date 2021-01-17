using MarsRover;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestMarsRover
{
    public class Tests
    {
        [Test]
        public void StartTravel_IsntItGiveExpectedResult_ReturnFalse()
        {
            // Arrange
            Rover rover = new Rover()
            {
                X = 1,
                Y = 2,
                Direction = Directions.N
            };

            var coordinatesLimit = new List<int>() { 8, 8 };
            var roversRoute = "LMLMLMLMM";
            var expected = "2 5 E";

            // Act
            rover.StartTravel(coordinatesLimit, roversRoute);

            // Assert
            var actual = $"{rover.X} {rover.Y} {rover.Direction}";
            Assert.AreNotEqual(expected, actual);
        }        

        [Test]
        public void StartTravel_IsItGiveExpectedResult_ReturnTrue()
        {
            // Arrange
            Rover rover = new Rover()
            {
                X = 3,
                Y = 3,
                Direction = Directions.E
            };

            var coordinatesLimit = new List<int>() { 5, 5 };
            var roversRoute = "MRRMMRMRRM";
            var expected = "2 3 S";

            // Act
            rover.StartTravel(coordinatesLimit, roversRoute);

            // Assert
            var actual = $"{rover.X} {rover.Y} {rover.Direction}";
            Assert.AreEqual(expected, actual);
        }
    }
}