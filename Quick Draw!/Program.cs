using System;
using System.Diagnostics;
Console.CursorVisible = false;
Random random = new();

const string menu = @"
  Quick Draw
  Face your opponent and wait for the signal. Once the
  signal is given, shoot your opponent by pressing [space]
  before they shoot you. It's all about your reaction time.
  Choose Your Opponent:
  [1] Easy....1000 milliseconds
  [2] Medium...500 milliseconds
  [3] Hard.....250 milliseconds
  [4] Harder...125 milliseconds
  [escape] give up";

const string wait = @"
  Quick Draw
                                                        
                                                        
                                                        
              _O                          O_            
             |/|_          wait          _|\|           
             /\                            /\           
            /  |                          |  \          
  ------------------------------------------------------";

const string fire = @"
  Quick Draw
                                                        
                         ********                       
                         * FIRE *                       
              _O         ********         O_            
             |/|_                        _|\|           
             /\          spacebar          /\           
            /  |                          |  \          
  ------------------------------------------------------";

const string loseTooSlow = @"
  Quick Draw
                                                        
                                                        
                                                        
                                        > ╗__O          
           //            Too Slow           / \         
          O/__/\         You Lose          /\           
               \                          |  \          
  ------------------------------------------------------";

const string loseTooFast = @"
  Quick Draw
                                                        
                                                        
                                                        
                         Too Fast       > ╗__O          
           //           You Missed          / \         
          O/__/\         You Lose          /\           
               \                          |  \          
  ------------------------------------------------------";

const string win = @"
  Quick Draw
                                                        
                                                        
                                                        
            O__╔ <                                      
           / \                               \\         
             /\          You Win          /\__\O        
            /  |                          /             
  ------------------------------------------------------";

while (true)
{
    Console.Clear();
    Console.WriteLine(menu);
    TimeSpan? reactionSpeed = null;

    while (reactionSpeed is null) 
    { 
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.D1: reactionSpeed = TimeSpan.FromMilliseconds(1000); break;
            case ConsoleKey.D2: reactionSpeed = TimeSpan.FromMilliseconds(0500); break;
            case ConsoleKey.D3: reactionSpeed = TimeSpan.FromMilliseconds(0250); break;
            case ConsoleKey.D4: reactionSpeed = TimeSpan.FromMilliseconds(0125); break;
            case ConsoleKey.Escape: return;
        }
    }
    Console.Clear();
    Console.WriteLine(wait);
    Stopwatch stopwatch = new();
    bool tooFast = false;
    stopwatch.Restart();
    while (stopwatch.Elapsed < TimeSpan.FromMilliseconds(random.Next(5000, 5000)) && !tooFast)
    {
        if (Console.KeyAvailable && Console.ReadKey(true).Key is ConsoleKey)
        {
            tooFast = true;
        }
    }
    Console.Clear();
    Console.WriteLine(fire);
    TimeSpan reactionTime = default;
    stopwatch.Restart();
    bool tooSlow = true;
    while (!tooFast && stopwatch.Elapsed < reactionSpeed && tooSlow)
    {
        if (Console.KeyAvailable && Console.ReadKey(true).Key is ConsoleKey)
        {
            tooSlow = false;
            reactionTime = stopwatch.Elapsed;
        }
    }

    Console.Clear();
    Console.WriteLine(
tooFast ? loseTooFast :
tooSlow ? loseTooSlow :
$"{win}{Environment.NewLine}Reaction Time: {reactionTime.TotalMilliseconds} ms");
    Console.WriteLine("Press [esc] to leave, any other key to restart.");
    switch (Console.ReadKey().Key)
    {
        case ConsoleKey.Escape: return;
        default: break;
    }
}
