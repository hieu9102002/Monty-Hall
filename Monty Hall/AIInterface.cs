using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monty_Hall
{
    class AiInterface : IInterface
    {
        private bool _switchDoors;
        private int _doorChosen;
        private Random _random;
        public AiInterface(bool switchDoors, Random rand)
        {
            _switchDoors = switchDoors;
            _random = rand;
        }
        public int ChooseDoor(List<int> choice)
        {
            if (choice.Count==3)
            {
                _doorChosen = choice[_random.Next(choice.Count)];
            }

            if (choice.Count == 2 && _switchDoors)
            {
                _doorChosen = choice.Except(new int[] {_doorChosen}).ElementAt(0);
            }

            return _doorChosen;
        }

        public void DisplayDoors(Door[] doors)
        {
            //can extend to write the choices to a text file
            throw new NotImplementedException();
        }

        public void DisplayPrompt(string prompt)
        {
            //can extend to write the choices to a text file
            Console.WriteLine(prompt);
        }
    }
}
