using System.Collections.Generic;
using NUnit.Framework;

namespace ElevatorKata.Tests
{
    class LiftTests
    {
        // Given: a stationary lift at ground floor
        // When: it is summoned from the first floor to go down
        // Then: it should notify that it is going down when it arrives
        [Test]
        public void Test1()
        {
            var groundFloor = new Floor(0);
            var lift = new Lift(groundFloor);
            var events = new List<LiftArrivedEvent>();
            lift.ArriveAtFloor += events.Add;
            var firstFloor = new Floor(1);
            lift.Summon(firstFloor, Direction.Down);
            Assert.That(events.Count, Is.EqualTo(1));
            Assert.That(events[0].Direction, Is.EqualTo(Direction.Down));
            Assert.That(events[0].Floor, Is.EqualTo(firstFloor));
        }

        // Given: a stationary lift on ground floor
        // When: it is summoned to the third floor to go up
        // Then: it should notify that it is going up when it arrives
        [Test]
        public void Test2()
        {
            var groundFloor = new Floor(0);
            var lift = new Lift(groundFloor);
            var events = new List<LiftArrivedEvent>();
            lift.ArriveAtFloor += events.Add;
            var thirdFloor = new Floor(3);
            lift.Summon(thirdFloor, Direction.Up);
            Assert.That(events.Count, Is.EqualTo(3));
            Assert.That(events[0].Direction, Is.EqualTo(Direction.Up));
            Assert.That(events[0].Floor, Is.EqualTo(new Floor(1)));
            Assert.That(events[1].Direction, Is.EqualTo(Direction.Up));
            Assert.That(events[1].Floor, Is.EqualTo(new Floor(2)));
            Assert.That(events[2].Direction, Is.EqualTo(Direction.Up));
            Assert.That(events[2].Floor, Is.EqualTo(new Floor(3)));
        }

        // Given: a stationary lift on second floor
        // When: it is summoned to move up from the ground floor
        // Then: it should notify when it moves past each floor in between
        [Test]
        public void Test3()
        {
            var secondFloor = new Floor(2);
            var lift = new Lift(secondFloor);
            var events = new List<LiftArrivedEvent>();
            lift.ArriveAtFloor += events.Add;
            var groundFloor = new Floor(0);
            lift.Summon(groundFloor, Direction.Up);
            Assert.That(events.Count, Is.EqualTo(2));
            Assert.That(events[0].Direction, Is.EqualTo(Direction.Down));
            Assert.That(events[0].Floor, Is.EqualTo(new Floor(1)));
            Assert.That(events[1].Direction, Is.EqualTo(Direction.Up));
            Assert.That(events[1].Floor, Is.EqualTo(new Floor(0)));
        }

        // Given: a stationary lift on ground floor
        // When: it is commanded to move to the third floor
        // Then: it should notify when it moves past each floor in between and when be stationary when it arrives
        [Test]
        public void Test4()
        {
            var groundFloor = new Floor(0);
            var lift = new Lift(groundFloor);
            var events = new List<LiftArrivedEvent>();
            lift.ArriveAtFloor += events.Add;
            var thirdFloor = new Floor(3);
            lift.GoTo(thirdFloor);
            Assert.That(events.Count, Is.EqualTo(3));
            Assert.That(events[0].Direction, Is.EqualTo(Direction.Up));
            Assert.That(events[0].Floor, Is.EqualTo(new Floor(1)));
            Assert.That(events[1].Direction, Is.EqualTo(Direction.Up));
            Assert.That(events[1].Floor, Is.EqualTo(new Floor(2)));
            Assert.That(events[2].Direction, Is.EqualTo(Direction.Stationary));
            Assert.That(events[2].Floor, Is.EqualTo(new Floor(3)));
        }
    }
}
