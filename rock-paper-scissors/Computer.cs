using System;

namespace rock_paper_scissors
{
    class Computer
    {
        public Choice Pick {get; set;}

        public Random Rand {get; set;}

        public Computer()
        {
            Rand = new Random();
        }
        public void Move()
        {
            int pick = Rand.Next(9);
            if(pick < 3)
            {
                Pick = Choice.Rock;
            }
            else if (pick > 5)
            {
                Pick = Choice.Paper;
            }
            else
            {
                Pick = Choice.Scissors;
            }
        }
    }
}