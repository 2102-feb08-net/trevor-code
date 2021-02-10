using System;

namespace rock_paper_scissors
{
    class Player
    {
        int _wins;
        int _losses;
        Choice _pick;
        public int Wins{
            get { return _wins; }

            set { _wins = value; }
        }
        public int Losses
        {
            get { return _losses; }
            
            set { _losses = value; }
        }
        public Choice Pick
        {
            get { return _pick; }

            set { _pick = value; }
        }

        public Player()
        {
            Wins = 0;
            Losses = 0;
        }
        public void Move()
        {
            int choice = 0;
            int num = 0;
            while (choice == 0)
            {
                Console.WriteLine("Please enter a number for your turn or \'Q\' to quit\n[1] Rock\n[2] Paper\n[3] Scissors\n");
                string input = Console.ReadLine();
                if(input == "Q" || input == "q")
                {
                    Pick = Choice.Quit;
                    return;
                }
                try
                {
                    num = int.Parse(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }
                if(num != 1 && num != 2 && num != 3)
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }
                choice = num;
            }
            switch (choice)
            {
                case 1:
                    Pick = Choice.Rock;
                    break;
                case 2:
                    Pick = Choice.Paper;
                    break;
                case 3:
                    Pick = Choice.Scissors;
                    break;
            }
        }
    }
}