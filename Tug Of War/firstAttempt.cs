using System.Diagnostics;

Console.WriteLine(@"                                                           
Tug Of War                                                
                                                            
Out pull your opponent in a rope pulling                  
competition. Mash the [left]+[right] arrow                
keys and/or the [A]+[D] keys to pull on the               
rope. First player to pull the center of the              
rope into their boundary wins.                            
                                                            
Choose Your Opponent:                                     
[1] Easy.......2 mashes per second                        
[2] Medium.....4 mashes per second                        
[3] Hard.......8 mashes per second                        
[4] Harder....16 mashes per second                        
[escape] give up                                          
                     ");

string board = @"




    
  -----------------======================-----------------  
                                                            
           *** Mash [A] +[D] or[Left] +[Right] * **";
string line = "-------------+-------------";
string player = @"
o                              o 
LL----------------------------JJ\
\\                            // 
| \                          / | ";
string Empty = @"
                                  
                                  
                                  
                                 ";
if (OperatingSystem.IsWindows())
{
    Console.WindowWidth = Math.Max(Console.WindowWidth, 22);
    Console.WindowHeight = Math.Max(Console.WindowHeight, 50);
}
while (true)
{
    int buttonMash = 0;
    Loop:
    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.D1: buttonMash = 2; break;
        case ConsoleKey.D2: buttonMash = 4; break;
        case ConsoleKey.D3: buttonMash = 8; break;
        case ConsoleKey.D4: buttonMash = 16; break;
        case ConsoleKey.Escape:
            Console.Clear();
            Console.WriteLine("Tug of War was closed.");
            Environment.Exit(0);
            break;
        default: goto Loop;
    }
    play();
}
void play() 
{
    while (true)
    {
        Console.CursorVisible = false;
        Console.Clear();
        Console.WriteLine("Tug of War");
        Console.WriteLine();
        Console.WriteLine(board);
        int x = 1;
        var (left, top) = Map(x);
        Console.SetCursorPosition(left, top);
        Render(player);
        Stopwatch stopwatch = new();
        TimeSpan timeSpan = TimeSpan.FromSeconds(1);
        int mash = 0;
        int lefty = left;
        while (true)
        {
            loop:
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.A or ConsoleKey.D: mash++; break;
                case ConsoleKey.Escape:
                    Console.Clear();
                    Console.WriteLine("Tug a war was closed.");
                    Environment.Exit(0);
                    break;
                default: goto loop;
            }
            stopwatch.Restart();
            while (stopwatch.Elapsed < timeSpan)
            {
                if (mash >= 2)
                {
                 
                    Console.SetCursorPosition(lefty++, top);
                    
                    break;
                }
                else
                {
                    Console.SetCursorPosition(left -1, top);
                }
                
            }
            Render(Empty);
            Render(player);
        }
        if (lefty == 26)
        {
            Console.Clear();
            Console.WriteLine("You Win.");
            Environment.Exit(0);
        }
    }
}
(int left, int top) Map(int hole) =>
    hole switch
    {
        1 => (14,0),
    };
void Render(string @string)
{
    int x = Console.CursorLeft;
    int y = Console.CursorTop;
    foreach (char c in @string)
    {
        if (c is '\n')
        {
            Console.SetCursorPosition(x, ++y);
        }
        else
        {
            Console.Write(c);
        }
    }
}

/* 
 switch keyread
a or d; mash++; break;

while (time.Elapsed < Seconds(1))
{
    if (mash = 2)
    { 
    Render(Left);
    }
    else 
    {
    Render(Right);
    }
}
 */
