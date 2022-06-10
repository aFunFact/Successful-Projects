using System.Diagnostics;
using System.Threading;
Console.WriteLine("osu! 10 Second BPM Test");
Console.Write("[Enter] ");
switch (Console.ReadKey(true).Key)
{
    case ConsoleKey.Enter: break;
}
Console.Clear();
TimeSpan timeSpan = TimeSpan.FromSeconds(10);
TimeSpan countdown = TimeSpan.FromSeconds(3);
int secondsa = 0;
TimeSpan seconds = TimeSpan.FromSeconds(2);
TimeSpan firsts = TimeSpan.FromSeconds(1);
TimeSpan thirds = TimeSpan.FromSeconds(3);
Stopwatch stopwatch = new();
stopwatch.Restart();
while(stopwatch.Elapsed <= countdown)
{
    if (stopwatch.Elapsed == seconds || stopwatch.Elapsed == firsts || stopwatch.Elapsed == thirds)
    {
        secondsa++;
        Console.WriteLine($"{secondsa}");
    }
}
Thread.Sleep(500);
Console.Clear();
Console.WriteLine("TAP!!!");
stopwatch.Restart();
while (stopwatch.Elapsed < timeSpan)
{
    int mash = 0;
    while (stopwatch.Elapsed < timeSpan)
    {
        ConsoleKey key = Console.ReadKey(true).Key;
        if (key is ConsoleKey.H or ConsoleKey.L)
        {
            mash++;
        }
    }
    Console.Clear();
    Console.WriteLine($"{(mash * 6) / 4} BPM (1/4) ");
    bool enterPressed = false;
    while (!enterPressed)
    {
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.Enter: enterPressed = true; break;
            case ConsoleKey.Escape: return;
        }
    }
}
// ff           
