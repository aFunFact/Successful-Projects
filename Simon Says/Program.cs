string[] Renders = new string[]
{
	#region Frames
	// 0
	@"           ╔══════╗        " + '\n' +
	@"           ║      ║        " + '\n' +
	@"           ╚╗    ╔╝        " + '\n' +
	@"    ╔═══╗   ╚╗  ╔╝   ╔═══╗ " + '\n' +
	@"    ║   ╚═══╗╚══╝╔═══╝   ║ " + '\n' +
	@"    ║       ║    ║       ║ " + '\n' +
	@"    ║   ╔═══╝╔══╗╚═══╗   ║ " + '\n' +
	@"    ╚═══╝   ╔╝  ╚╗   ╚═══╝ " + '\n' +
	@"           ╔╝    ╚╗        " + '\n' +
	@"           ║      ║        " + '\n' +
	@"           ╚══════╝        ",
	// 1
	@"           ╔══════╗        " + '\n' +
	@"           ║██████║        " + '\n' +
	@"           ╚╗████╔╝        " + '\n' +
	@"    ╔═══╗   ╚╗██╔╝   ╔═══╗ " + '\n' +
	@"    ║   ╚═══╗╚══╝╔═══╝   ║ " + '\n' +
	@"    ║       ║    ║       ║ " + '\n' +
	@"    ║   ╔═══╝╔══╗╚═══╗   ║ " + '\n' +
	@"    ╚═══╝   ╔╝  ╚╗   ╚═══╝ " + '\n' +
	@"           ╔╝    ╚╗        " + '\n' +
	@"           ║      ║        " + '\n' +
	@"           ╚══════╝        ",
	// 2
	@"           ╔══════╗        " + '\n' +
	@"           ║      ║        " + '\n' +
	@"           ╚╗    ╔╝        " + '\n' +
	@"    ╔═══╗   ╚╗  ╔╝   ╔═══╗ " + '\n' +
	@"    ║   ╚═══╗╚══╝╔═══╝███║ " + '\n' +
	@"    ║       ║    ║███████║ " + '\n' +
	@"    ║   ╔═══╝╔══╗╚═══╗███║ " + '\n' +
	@"    ╚═══╝   ╔╝  ╚╗   ╚═══╝ " + '\n' +
	@"           ╔╝    ╚╗        " + '\n' +
	@"           ║      ║        " + '\n' +
	@"           ╚══════╝        ",
	// 3
	@"           ╔══════╗        " + '\n' +
	@"           ║      ║        " + '\n' +
	@"           ╚╗    ╔╝        " + '\n' +
	@"    ╔═══╗   ╚╗  ╔╝   ╔═══╗ " + '\n' +
	@"    ║   ╚═══╗╚══╝╔═══╝   ║ " + '\n' +
	@"    ║       ║    ║       ║ " + '\n' +
	@"    ║   ╔═══╝╔══╗╚═══╗   ║ " + '\n' +
	@"    ╚═══╝   ╔╝██╚╗   ╚═══╝ " + '\n' +
	@"           ╔╝████╚╗        " + '\n' +
	@"           ║██████║        " + '\n' +
	@"           ╚══════╝        ",
	// 4
	@"           ╔══════╗        " + '\n' +
	@"           ║      ║        " + '\n' +
	@"           ╚╗    ╔╝        " + '\n' +
	@"    ╔═══╗   ╚╗  ╔╝   ╔═══╗ " + '\n' +
	@"    ║███╚═══╗╚══╝╔═══╝   ║ " + '\n' +
	@"    ║███████║    ║       ║ " + '\n' +
	@"    ║███╔═══╝╔══╗╚═══╗   ║ " + '\n' +
	@"    ╚═══╝   ╔╝  ╚╗   ╚═══╝ " + '\n' +
	@"           ╔╝    ╚╗        " + '\n' +
	@"           ║      ║        " + '\n' +
	@"           ╚══════╝        ",
	#endregion
};
List<Direction> pattern = new();
TimeSpan buttonDelay = TimeSpan.FromMilliseconds(500);
TimeSpan animationDelay = TimeSpan.FromMilliseconds(200);
Random Random = new();
int score = 0;
try
{
	Console.Clear();
	Clear();
	Render(Renders[default]);
	Console.CursorVisible = false;
	while (true)
    {
		Thread.Sleep(animationDelay);
		Clear();
		pattern.Add((Direction)Random.Next(1, 5));
		AnimateCurrentPattern();
		for (int i = 0; i < pattern.Count; i++)
        {
GetInput:
			switch (Console.ReadKey(true).Key)
			{
				case ConsoleKey.W:
					if (pattern[i] != Direction.Up)
						goto GameOver; break;

				case ConsoleKey.D:
					if (pattern[i] != Direction.Right)
						goto GameOver; break;

				case ConsoleKey.S:
					if (pattern[i] != Direction.Down)
						goto GameOver; break;

				case ConsoleKey.A:
					if (pattern[i] != Direction.Left)
						goto GameOver; break;

				case ConsoleKey.Escape:
						Console.Clear(); Console.WriteLine("Simon was closed."); return;
				default: goto GetInput;
			}
			score++;
			Clear();
			Thread.Sleep(animationDelay);
			Render(Renders[(int)pattern[i]]);
			Thread.Sleep(buttonDelay);
			Clear();
			Render(Renders[default]);
        }
    }
GameOver:
	Console.Clear();
	Console.Write("Game Over. " + score + " points.");
}
finally
{
	Console.CursorVisible = true;
}

void Clear()
{
	Console.SetCursorPosition(0, 0);
	Console.WriteLine();
	Console.WriteLine("		Simon");
	Console.WriteLine();
	int x = Console.CursorLeft;
	int y = Console.CursorTop;
	Render(Renders[default]);
	Console.SetCursorPosition(x, y);

}
void Render(string @message)
{
	int left = Console.CursorLeft;
	int top = Console.CursorTop; 
	foreach (char c in @message)
    {
		if (c is '\n')
        {
			Console.SetCursorPosition(left, ++top);
        }
		else
        {
			Console.Write(c);
        }
    }
}
void AnimateCurrentPattern()
{
	for (int i = 0; i < pattern.Count; i++)
	{
		Clear();
		Render((Renders[(int)pattern[i]]));
		Thread.Sleep(buttonDelay);
		Clear();
		Render(Renders[default]);
		Thread.Sleep(animationDelay);
	}
	Clear();
	Render(Renders[default]);
}
enum Direction
{
    Up = 1,
	Right = 2,
	Down = 3,
	Left = 4
}
