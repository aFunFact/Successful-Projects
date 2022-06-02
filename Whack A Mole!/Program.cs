using System;

string Board =
	@" ╔═══╦═══════╗ ╔═══╦═══════╗ ╔═══╦═══════╗" + '\n' +
	@" ║ 7 ║       ║ ║ 8 ║       ║ ║ 9 ║       ║" + '\n' +
	@" ╚═══╣       ║ ╚═══╣       ║ ╚═══╣       ║" + '\n' +
	@"     ║       ║     ║       ║     ║       ║" + '\n' +
	@"     ║       ║     ║       ║     ║       ║" + '\n' +
	@"     ╚═══════╝     ╚═══════╝     ╚═══════╝" + '\n' +
	@" ╔═══╦═══════╗ ╔═══╦═══════╗ ╔═══╦═══════╗" + '\n' +
	@" ║ 4 ║       ║ ║ 5 ║       ║ ║ 6 ║       ║" + '\n' +
	@" ╚═══╣       ║ ╚═══╣       ║ ╚═══╣       ║" + '\n' +
	@"     ║       ║     ║       ║     ║       ║" + '\n' +
	@"     ║       ║     ║       ║     ║       ║" + '\n' +
	@"     ╚═══════╝     ╚═══════╝     ╚═══════╝" + '\n' +
	@" ╔═══╦═══════╗ ╔═══╦═══════╗ ╔═══╦═══════╗" + '\n' +
	@" ║ 1 ║       ║ ║ 2 ║       ║ ║ 3 ║       ║" + '\n' +
	@" ╚═══╣       ║ ╚═══╣       ║ ╚═══╣       ║" + '\n' +
	@"     ║       ║     ║       ║     ║       ║" + '\n' +
	@"     ║       ║     ║       ║     ║       ║" + '\n' +
	@"     ╚═══════╝     ╚═══════╝     ╚═══════╝";

string JavaNoob =
	@" ╔══─┐ " + '\n' +
	@" │o-o│ " + '\n' +
	@"┌└───┘┐" + '\n' +
	@"││ J ││";

string Empty =
	@"       " + '\n' +
	@"       " + '\n' +
	@"       " + '\n' +
	@"       ";

TimeSpan playTime = TimeSpan.FromSeconds(5);
if (OperatingSystem.IsWindows())
{
	Console.WindowHeight = Math.Max(Console.WindowHeight, 22);
	Console.WindowWidth = Math.Max(Console.WindowWidth, 50);
}
while (true)
{
	Console.Clear();
	Console.WriteLine("Whack A Mole (Java Noob Edition)");
	Console.WriteLine();
	Console.WriteLine(
		$"You have {(int)playTime.TotalSeconds} seconds to whack as many Java noobs as you " +
		"can before the timer runs out. Use the number keys 1-9 to whack. Are you ready? ");
	Console.WriteLine();
	Console.WriteLine("Play [enter], or quit [escape]?");
GetInput:
	while(true)
    {
        switch (Console.ReadKey(true).Key)
        {
			case ConsoleKey.Escape: Console.Clear(); Console.WriteLine("Whack a mole was closed"); Environment.Exit(0); break;
			case ConsoleKey.Enter: Play(); break;
			default: goto GetInput;
        }
    }
}
void Play()
{
	int score = 0;
	Random Random = new();
	int moleLocation = Random.Next(1, 10);
	Console.Clear();
	Console.WriteLine("Whack a Mole");
	Console.WriteLine();
	Console.WriteLine(Board);
	DateTime start = DateTime.Now;
	while (DateTime.Now - start < playTime)
	{
		Console.CursorVisible = false;
		var (left, top) = Map(moleLocation);
		Console.SetCursorPosition(left, top);
		Render(JavaNoob);
		int selection = 0;
	GetInput:
		switch (Console.ReadKey(true).Key)
		{
			case ConsoleKey.D1: selection = 1; break;
			case ConsoleKey.D2: selection = 2; break;
			case ConsoleKey.D3: selection = 3; break;
			case ConsoleKey.D4: selection = 4; break;
			case ConsoleKey.D5: selection = 5; break;
			case ConsoleKey.D6: selection = 6; break;
			case ConsoleKey.D7: selection = 7; break;
			case ConsoleKey.D8: selection = 8; break;
			case ConsoleKey.D9: selection = 9; break;
			case ConsoleKey.Escape: Console.Clear(); Console.WriteLine("Whack a mole was closed"); Environment.Exit(0); break;
			default: goto GetInput;
		}
		if (moleLocation == selection)
		{
			score++;
			int newMoleLocation = Random.Next(1, 9);
			Console.SetCursorPosition(left, top);
			Render(Empty);
			moleLocation = newMoleLocation >= moleLocation + 1 ? newMoleLocation : newMoleLocation;
		}
	}
	Console.CursorVisible = true;
	Console.Clear();
	Console.WriteLine("Whack A Mole (Java Noob Edition)");
	Console.WriteLine();
	Console.WriteLine(Board);
	Console.WriteLine();
	Console.WriteLine("Game Over. Score: " + score);
	Console.WriteLine("Hopefully those Java noobs will learn their lesson and start using C#.");
	Console.WriteLine();
	Console.WriteLine("Press [Enter] To Continue...");
	Console.ReadLine();
}
(int left, int top) Map(int hole) =>
	hole switch
	{
		1 => (06, 15),
		2 => (20, 15),
		3 => (34, 15),
		4 => (06, 9),
		5 => (20, 9),
		6 => (34, 9),
		7 => (06, 3),
		8 => (20, 3),
		9 => (34, 3),
		_ => throw new NotImplementedException()
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
