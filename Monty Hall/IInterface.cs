using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monty_Hall
{
    interface IInterface
    //Interface for user interfaces. All Graphic UI or Command line UI or even AI UI must implements these functions, allows to switch interfaces. 
    {
        public void DisplayDoors(Door[] doors);
        public void DisplayPrompt(string prompt);
        public int ChooseDoor(List<int> choice);
    }
}
