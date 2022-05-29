Random Random = new();

int win = 0;
int loss = 0;
int draw = 0;
string outcome = "";


while (true) 
{
    Move PlayerMove;
    Console.Clear();
    Console.WriteLine($"Scores: {win} wins, {loss} losses, {draw} draws");
    Console.WriteLine("Rock, Paper, Scissors");
    Console.WriteLine(outcome);
    Console.WriteLine();
RestartLoop:
    Console.Write("Choose [r]ock, [p]aper, [s]cissors, or [e]xit:");

    switch (Console.ReadLine()!.ToLower())
    {
    
        case "rock" or "r": PlayerMove = Move.Rock; break;
        case "paper" or "p": PlayerMove = Move.Paper; break;
        case "scissors" or "s": PlayerMove = Move.Scissors; break;
        case "exit" or "e": return;
        default: Console.WriteLine("Invalid Input. Try Again."); goto RestartLoop;
    }
    Move ComputerMove = (Move)Random.Next(3);
    Console.WriteLine($"The computer chose {ComputerMove}");
    switch (PlayerMove, ComputerMove)
    {
        case (Move.Rock, Move.Paper):
        case (Move.Paper, Move.Scissors):
        case (Move.Scissors, Move.Rock):
            outcome = "You lost.";
            loss++;
            break;
        case (Move.Rock, Move.Scissors):
        case (Move.Paper, Move.Rock):
        case (Move.Scissors, Move.Paper):
            outcome = "You win.";
            win++;
            break;
        default: draw++; outcome = "Draw!"; break;
    }
}


enum Move
{
Rock = 0,
Scissors = 1,
Paper = 2,
}
