*/ !roll (number)
Console.WriteLine("Your username");
string username = Console.ReadLine();
Console.Clear();
/*
Random Random = new();
string a = Console.ReadLine();
int b = Convert.ToInt32(a);
var c = Random.Next(b);
if (Console.ReadLine().Contains("!roll"))
{
    Console.WriteLine($"{username} has rolled {c}");
}
// !roll 10 

/* Add it so you can escape out of launcher in while and if statement, can only exit out on if statement
   Some Pseudocode I thought was making a switch statement that detected if its a KeyPress or Escape
   The reason it wont escape in while loop is because of string command = Console.ReadLine(); */
while (true)
{
    Console.CursorVisible = false;
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("[!roll (number)]");
    Console.ForegroundColor = ConsoleColor.White;
    string command = Console.ReadLine();
    Console.Clear();
    string[] cA = command.Split();
    Random Random = new();

    if (cA[0].Contains("!roll") && (int.TryParse(cA[1], out int result)))
    {
        int x = 0;
        x = Convert.ToInt16(cA[1]);
        int y = Random.Next(x);

        Console.WriteLine("[ESC] Leave.");
        Console.WriteLine($"{username} has rolled {y}");
    }

    else Console.WriteLine("[ESC] Leave.\nInvalid Input.");
    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.Escape:
            return;
    }
            Console.Clear();
}
// how-to-use command
// !roll (number)
