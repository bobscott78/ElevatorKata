namespace ElevatorKata
{
    public class LiftArrivedEvent 
    {
        public LiftArrivedEvent(Floor floor, Direction direction)
        {
            Direction = direction;
            Floor = floor;
        }

        public Floor Floor { get; private set; }
        public Direction Direction { get; private set; }
    }
}