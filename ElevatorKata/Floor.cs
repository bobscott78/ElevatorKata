using System;

namespace ElevatorKata
{
    public class Floor : IEquatable<Floor>
    {
        public Floor(int number)
        {
            Number = number;
        }

        public int Number { get; private set; }

        public bool IsBelow(Floor floor)
        {
            return Number < floor.Number;
        }

        public bool Equals(Floor other)
        {
            if ((object)other == null)
            {
                return false;
            }
            return GetHashCode() == other.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Floor);
        }

        public static bool operator ==(Floor a, Floor b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Floor a, Floor b)
        {
            return !(a.Equals(b));
        }
    }
}