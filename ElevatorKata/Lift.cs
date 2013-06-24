using System;

namespace ElevatorKata
{
    public class Lift
    {
        private Floor _currentFloor;

        public event Action<LiftArrivedEvent> ArriveAtFloor;

        public Lift(Floor floor)
        {
            _currentFloor = floor;
        }

        public void Summon(Floor requestedFloor, Direction requestedDirection)
        {
            Move(requestedFloor, requestedDirection);
        }

        private void Move(Floor requestedFloor, Direction nextDirection)
        {
            Direction direction;
            if (_currentFloor.IsBelow(requestedFloor))
            {
                _currentFloor = new Floor(_currentFloor.Number + 1);
                direction = Direction.Up;
            }
            else
            {
                _currentFloor = new Floor(_currentFloor.Number - 1);
                direction = Direction.Down;
            } 
            OnArriveAtFloor(new LiftArrivedEvent(_currentFloor, _currentFloor.Equals(requestedFloor) ? nextDirection : direction));
            if (!_currentFloor.Equals(requestedFloor))
            {
                Move(requestedFloor, nextDirection);
            }
        }

        private void OnArriveAtFloor(LiftArrivedEvent liftArrivedEvent)
        {
            var handler = ArriveAtFloor;
            if (handler != null)
            {
                handler(liftArrivedEvent);
            }
        }

        public void GoTo(Floor floor)
        {
            Move(floor, Direction.Stationary);
        }
    }
}