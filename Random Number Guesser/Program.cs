namespace RNG
{
    class program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int rng = random.Next(100);
            int ui = 0;
            int i = 0;
            while (true)
            {
                if (rng != ui)
                {
                    Console.Write("Guess: ");
                    string user = Console.ReadLine();
                    ui = Convert.ToInt32(user);
                    i++;
                    Console.WriteLine($"Tries: {i}");

                    if (ui < rng)
                    {
                        Console.WriteLine("Too Low");
                    }
                  else if (ui > rng)
                    {
                        Console.WriteLine("Too High");
                    }
                    else
                    {
                        Console.WriteLine($"Tries: {i}");
                        i++;
                        
                    }
                    
                }
                else if (rng == ui)
                {
                    Console.WriteLine("Congrats you Got it Right");
                    break;
                }
            }
        }
    }
}
//ff
