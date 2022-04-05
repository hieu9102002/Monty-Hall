using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monty_Hall
{
    class Game
    {
        private Door[] _doors;
        private int _prizeDoor;
        private Random _rand;
        private int[] _nonPrizeDoors;
        private List<int> _doorChoices;

        public List<int> DoorChoices => _doorChoices;
        public Door[] Doors => _doors;

        public Game(Random random)
        {
            _doors = new Door[] { new Door(1), new Door(2), new Door(3)};
            _rand = random;

            _prizeDoor = _rand.Next(3);

            _doors[_prizeDoor].Prize = true;

            _nonPrizeDoors = new int[] { 0, 1, 2 }.Except(new int[] { _prizeDoor}).ToArray();
            _doorChoices = new List<int> { 1, 2, 3 };
        }

        public string PickFirstDoor(int choice)
        {
            int[] doorsToOpen = _nonPrizeDoors.Except(new int[] { choice-1}).ToArray();
            int doorToOpen = doorsToOpen[_rand.Next(doorsToOpen.Length)];

            _doors[doorToOpen].Opened = true;

            _doorChoices.Remove(doorToOpen + 1);

            return "You have chosen... Door... Number " + choice + "...\nDoor number "
                + _doors[doorToOpen].DoorNo + " has a GOAT! Does that entice you, to change your mind?";
        }

        public string FinalPick(int choice)
        {
            if (_prizeDoor == choice - 1)
                return "YOU HAVE WON A BRAND NEW CAR!";
            return "TOO BAD, HAVE A GOAT!";
        }
    }
}
