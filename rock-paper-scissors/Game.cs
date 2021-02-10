using System;

namespace rock_paper_scissors
{
    class Game
    {
        public static void RunGame()
        {
            bool running = true;
            Player p = new Player();
            Computer c = new Computer();
            Result result;
            while(running)
            {
                Console.WriteLine($"Wins: {p.Wins}\tLosses:{p.Losses}");
                p.Move();
                c.Move();
                if(p.Pick == Choice.Quit)
                {
                    running = false;
                    break;
                }
                Console.WriteLine($"You picked {p.Pick} and computer picked {c.Pick}!");
                if(p.Pick == Choice.Rock)
                {
                    if(c.Pick == Choice.Rock)
                    {
                        result = Result.Draw;
                    }
                    else if(c.Pick == Choice.Paper)
                    {
                        result = Result.Lose;
                    }
                    else
                    {
                        result = Result.Win;
                    }
                }
                else if(p.Pick == Choice.Paper)
                {
                    if(c.Pick == Choice.Rock)
                    {
                        result = Result.Win;
                    }
                    else if(c.Pick == Choice.Paper)
                    {
                        result = Result.Draw;
                    }
                    else
                    {
                        result = Result.Lose;
                    }
                }
                else
                {
                    if(c.Pick == Choice.Rock)
                    {
                        result = Result.Lose;
                    }
                    else if(c.Pick == Choice.Paper)
                    {
                        result = Result.Win;
                    }
                    else
                    {
                        result = Result.Draw;
                    }
                }
                switch (result)
                {
                    case Result.Win:
                        Console.WriteLine("You won!");
                        p.Wins++;
                        break;
                    case Result.Lose:
                        Console.WriteLine("You Lost!");
                        p.Losses++;
                        break;
                    default:
                        Console.WriteLine("Game was a draw!");
                        break;
                }
            }
            Console.WriteLine($"Thanks for playing! You won {p.Wins} times and lost {p.Losses} times!");
        }
    }
}