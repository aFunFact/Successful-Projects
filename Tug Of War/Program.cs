  try
{
    while (true)
    {

        int position = 0;
        const int displacement = 10;
        string L() => new(' ', displacement + position + 4);
        string R() => new(' ', displacement - position + 4);
        string Ground =
            new string(' ', 2) +
            new string('-', displacement + (15 - displacement) + 2) +
            new string('=', displacement * 2 + 2) +
            new string('-', displacement + (15 - displacement) + 2) +
            new string(' ', 2);
        bool frame_a = false;
        Console.CursorVisible = false;
        Console.Clear();
        Console.WriteLine(@"Tug Of War
[1] 02 Mash
[2] 04 Mash
[3] 08 Mash
[4] 16 Mash");
        int? requiredMash = null;
        while (requiredMash is null)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Escape: return;
                case ConsoleKey.D1: requiredMash = 2; break;
                case ConsoleKey.D2: requiredMash = 4; break;
                case ConsoleKey.D3: requiredMash = 8; break;
                case ConsoleKey.D4: requiredMash = 16; break;
            }
        }
        int mash = 0;
        int presses = 0;
        int sleeps = 0;
        ConsoleKey lastKey = default;
        DateTime start = DateTime.Now;
        while (true)
        {
            while (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key is ConsoleKey.Escape)
                {
                    return;
                }
                else if (lastKey is not default(ConsoleKey) && key is ConsoleKey.A or ConsoleKey.D && key != lastKey)
                {
                    mash++;
                    presses++;
                    lastKey = default;
                }
                else if (key is ConsoleKey.A or ConsoleKey.D)
                {
                    lastKey = key;
                }
            }
            if (sleeps is 2)
            {
                position = mash < requiredMash.Value
                    ? position + 1
                    : position - 1;
                sleeps = 0;
                mash = 0;
                if (Math.Abs(position) >= displacement)
                {
                    break;
                }
            }
            Console.Clear();
            Console.WriteLine("  Tug Of War");
            Console.Write(frame_a
                ?
                $@"{L()}o                             o {R()}{"\n"}" +
                $@"{L()}LL-------------+-------------JJ\{R()}{"\n"}" +
                $@"{L()}\\                            //{R()}{"\n"}" +
                $@"{L()}| \                          / |{R()}{"\n"}"
                :
                $@"{L()} o                             o{R()}{"\n"}" +
                $@"{L()}/LL-------------+-------------JJ{R()}{"\n"}" +
                $@"{L()}\\                            //{R()}{"\n"}" +
                $@"{L()}| \                          / |{R()}{"\n"}");
            Console.WriteLine(Ground);
            Console.WriteLine();
            Console.WriteLine(frame_a
                ? "     *** Mash [A]+[D] or [Left]+[Right] ***"
                : "     ''' Mash [A]+[D] or [Left]+[Right] '''");
            Thread.Sleep(500);
            sleeps++;
            frame_a = !frame_a;
        }
        bool win = position < 0;
        double seconds = (DateTime.Now - start).TotalSeconds;
        double average = presses / seconds;
        Console.Clear();
        Console.WriteLine("  Tug Of War");
        Console.WriteLine();
        Console.Write(win
            ?
            $@"{L()}o                               {R()}{"\n"}" +
            $@"{L()}LL------------+------.  o___    {R()}{"\n"}" +
            $@"{L()}\\                    \//   \\__{R()}{"\n"}" +
            $@"{L()}| \                    \_____\  {R()}{"\n"}"
			:
            $@"{L()}                               o{R()}{"\n"}" +
            $@"{L()}    ___o  .------+------------JJ{R()}{"\n"}" +
            $@"{L()}__//   \\/                    //{R()}{"\n"}" +
            $@"{L()}  /_____/                    / |{R()}{"\n"}");
        Console.WriteLine(Ground);
        Console.WriteLine("You " + (win ? "Win!" : "Lose!"));
        Console.WriteLine($"Average: {average:0.##} mashes per second");
        Console.WriteLine("[Enter]");
        Console.WriteLine("[Escape]");
        bool enterPressed = false;
        while (!enterPressed)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Escape: return;
                case ConsoleKey.Enter: enterPressed = true; break;
            }
        }
    }
        
}
finally
{
    Console.CursorVisible = true;
    Console.Clear();
    Console.WriteLine("Tug Of War was closed.");
}
// ff
