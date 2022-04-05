using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monty_Hall
{
    class CommandLineInterface : IInterface
    {
        public int ChooseDoor(List<int> choice)
        {
            Console.Write("Pick a door to open!\n(");
            foreach (int _choice in choice)
                Console.Write(_choice + " ");
            Console.WriteLine(")");

            Console.Write("Which door will you choose: ");
            int userChoice = Convert.ToInt32(Console.ReadLine());

            while(!choice.Contains(userChoice))
            {
                Console.Write("Invalid door, choose again: ");
                userChoice = Convert.ToInt32(Console.ReadLine());
            }

            return userChoice;
        }

        public void DisplayDoors(Door[] doors)
        {
            Console.WriteLine("Here are our doors: ");
            string output = "";
            foreach(Door door in doors)
            {
                if (door.Opened)
                {
                    output += door.Prize ? "CAR" : "GOAT";
                }
                else output += door.DoorNo;
                output += "\t";
            }
            Console.WriteLine(output);
        }

        public void DisplayPrompt(string prompt)
        {
            Console.WriteLine(prompt);
        }
    }
}
