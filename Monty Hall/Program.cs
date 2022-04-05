using System;

namespace Monty_Hall
{
    class Program
    {
        static void Main(string[] args)
        {
            OneGame();
            AiGame();
        }

        static void OneGame()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            IInterface userInterface = new CommandLineInterface();
            //the usage of UI is flexible here. As long as the UI implements the IInterface interface, it should work, even if you use the AI interface here.
            Game game = new Game(random);

            userInterface.DisplayPrompt("WELCOME to player who is playing to win a BRAND NEW CAR!");
            userInterface.DisplayPrompt("We have 3 doors today. Hidden behind 1 will be the AMAZING CAR! However, behind the other 2 will be GOATS! Pick wisely");
            userInterface.DisplayDoors(game.Doors);

            int firstChoice = userInterface.ChooseDoor(game.DoorChoices);

            userInterface.DisplayPrompt(game.PickFirstDoor(firstChoice));
            userInterface.DisplayDoors(game.Doors);

            int lastChoice = userInterface.ChooseDoor(game.DoorChoices);
            userInterface.DisplayPrompt(game.FinalPick(lastChoice));
        }

        static void AiGame()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int noSwapWins = 0;
            int swapWins = 0;
            for (int i = 0; i < 1000; i++)
            {
                IInterface aiInterface = new AiInterface(false, random);
                Game game = new Game(random);

                game.PickFirstDoor(aiInterface.ChooseDoor(game.DoorChoices));
                string outcome = game.FinalPick(aiInterface.ChooseDoor(game.DoorChoices));

                if (outcome == "YOU HAVE WON A BRAND NEW CAR!") noSwapWins++;
            }
            for (int i = 0; i < 1000; i++)
            {
                IInterface aiInterface = new AiInterface(true, random);
                Game game = new Game(random);

                game.PickFirstDoor(aiInterface.ChooseDoor(game.DoorChoices));
                string outcome = game.FinalPick(aiInterface.ChooseDoor(game.DoorChoices));

                if (outcome == "YOU HAVE WON A BRAND NEW CAR!") swapWins++;
            }

            Console.WriteLine("No swap win percentage: " + noSwapWins/10.0 + "%");
            Console.WriteLine("Always swap win percentage: " + swapWins / 10.0 + "%");
        }
    }
}
