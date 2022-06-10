bool closeRequested = false;
bool playerTurn = true;
char[,] board;
Random Random = new();
while (!closeRequested)
{
    board = new char[3, 3]
    {
        { ' ', ' ', ' ' },
        { ' ', ' ', ' ' },
        { ' ', ' ', ' ' }
    };
    Console.Clear();
    RenderBoard();
    while (!closeRequested)
    {

        if (playerTurn)
        {
            PlayerTurn();
            if (CheckForThree('X'))
            {
                EndGame("You Win.");
                break;
            }
        }

        else
        {
            ComputerTurn();
            if (CheckForThree('O'))
            {
                EndGame("You lost.");
                break;
            }
        }

        if (CheckForFullBoard())
        {
            EndGame("Draw.");
            break;
        }
        playerTurn = !playerTurn;
    }
    Console.WriteLine();
    Console.WriteLine("[Enter] to play Again \n[Esc] To Leave.");
    if (!closeRequested)
    {
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.Enter: break;
            case ConsoleKey.Escape: closeRequested = true; break;
        }
    }
}
void PlayerTurn()
{
    var (row, column) = (0, 0);
    bool moved = false;
    while (!moved && !closeRequested)
    {
        Console.Clear();
        RenderBoard();
        Console.WriteLine();
        Console.WriteLine("Choose a valid position and press enter.");
        Console.SetCursorPosition(column * 6 + 1, row * 4 + 1);
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.A: column = column <= 0 ? 2 : column - 1; break;
            case ConsoleKey.D: column = column >= 2 ? 0 : column + 1; break;
            case ConsoleKey.S: row = row >= 2 ? 0 : row + 1; break;
            case ConsoleKey.W: row = row <= 0 ? 2 : row - 1; break;
            case ConsoleKey.Enter: if (board[row, column] == ' ')
                {
                    board[row, column] = 'X';
                    moved = true;
                }
                break;
            case ConsoleKey.Escape: Console.Clear(); closeRequested = true; return;
        }
    }
}
void ComputerTurn()
{
    var possibleMoves = new List<(int X, int Y)>();
    for (int i = 0; i < 3; i++)
    {
        for (int j=0; j < 3; j++)
        {
            if (board[i,j] == ' ')
            {
                possibleMoves.Add((i,j));
            }
        }
    }
    int index = Random.Next(0, possibleMoves.Count);
    var (X, Y) = possibleMoves[index];
    board[X, Y] = 'O';
}
bool CheckForThree(char c) =>
    board[0, 0] == c && board[1, 0] == c && board[2, 0] == c ||
    board[0, 1] == c && board[1, 1] == c && board[2, 1] == c ||
    board[0, 2] == c && board[1, 2] == c && board[2, 2] == c ||
    board[0, 0] == c && board[0, 1] == c && board[0, 2] == c ||
    board[1, 0] == c && board[1, 1] == c && board[1, 2] == c ||
    board[2, 0] == c && board[2, 1] == c && board[2, 2] == c ||
    board[0, 0] == c && board[1, 1] == c && board[2, 2] == c ||
    board[0, 2] == c && board[1, 1] == c && board[2, 0] == c;
;
bool CheckForFullBoard() =>
    board[0, 0] != ' ' && board[1, 0] != ' ' && board[2, 0] != ' ' &&
    board[0, 1] != ' ' && board[1, 1] != ' ' && board[2, 1] != ' ' &&
    board[2, 0] != ' ' && board[1, 2] != ' ' && board[2, 2] != ' ';
void RenderBoard()
{
    Console.WriteLine();
    Console.WriteLine($" {board[0, 0]}  ║  {board[0, 1]}  ║  {board[0, 2]}");
    Console.WriteLine("    ║     ║");
    Console.WriteLine(" ═══╬═════╬═══");
    Console.WriteLine("    ║     ║");
    Console.WriteLine($" {board[1, 0]}  ║  {board[1, 1]}  ║  {board[1, 2]}");
    Console.WriteLine("    ║     ║");
    Console.WriteLine(" ═══╬═════╬═══");
    Console.WriteLine("    ║     ║");
    Console.WriteLine($" {board[2, 0]}  ║  {board[2, 1]}  ║  {board[2, 2]}");
}
void EndGame(string message)
{
    Console.Clear();
    RenderBoard();
    Console.WriteLine();
    Console.WriteLine(message);
}
