using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monty_Hall
{
    class Door
    {
        private bool _prize;
        private int _doorNo;
        private bool _opened;

        public bool Prize { get { return _prize; } set { _prize = value; } }
        public bool Opened { get { return _opened; } set { _opened = value; } }

        public int DoorNo { get { return _doorNo; } }

        public Door(int doorNo)
        {
            _doorNo = doorNo;
            _opened = false;
        }
    }
}
