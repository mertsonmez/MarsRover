using System.Collections.Generic;

namespace MarsRover.Interface
{
    public interface IRoverPosition
    {
        public void TurnRight();
        public void TurnLeft();
        public void MoveForward();
        public void StartTravel(List<int> coordinatesLimit, string roversRoute);

    }
}
