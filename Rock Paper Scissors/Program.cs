string Loop = "";
int winScore = 0;
int lossScore = 0;
int draws = 0;
do
{
    Console.WriteLine("Rock, Paper, Scissors");
    Console.WriteLine("");
    Console.Write("Choose Rock, Paper, Scissors, or Exit: ");

    string userTurn = Console.ReadLine();
    string[] computerTurn = { "Rock", "Paper", "Scissors" };
    Random Random = new Random();
    int computerObject = Random.Next(0, 3);
    string com = computerTurn[computerObject];
    Console.WriteLine($"The Computer chose {com}.");

    if ((userTurn == "Rock") && (com == "Scissors"))
    {
        Console.WriteLine("You win.");
        winScore++;
    }
    else if ((userTurn == "Rock") && (com == "Rock"))
    {
        Console.WriteLine("This game was a draw.");
        draws++;
    }
    else if ((userTurn == "Rock") && (com == "Paper"))
    {
        Console.WriteLine("You lose.");
        lossScore++;
    }
    else if ((userTurn == "Paper") && (com == "Scissors"))
    {
        Console.WriteLine("You lose.");
        lossScore++;
    }
    else if ((userTurn == "Paper") && (com == "Rock"))
    {
        Console.WriteLine("You win.");
        winScore++;
    }
    else if ((userTurn == "Paper") && (com == "Paper"))
    {
        Console.WriteLine("This game was a draw.");
        draws++;
    }
    else if ((userTurn == "Scissors") && (com == "Scissors"))
    {
        Console.WriteLine("This game was a draw.");
        draws++;
    }
    else if ((userTurn == "Scissors") && (com == "Rock"))
    {
        Console.WriteLine("You lose.");
        lossScore++;
    }
    else if ((userTurn == "Scissors") && (com == "Paper"))
    {
        Console.WriteLine("You win.");
        winScore++;
    }

    Console.WriteLine($"Scores: {winScore} wins, {lossScore} losses, {draws} draws");
    Console.WriteLine($"Enter anything ");
    Loop = "Hi";
} while (Loop != "Restart");


/*
for (int i = 0; i < computerTurn.Length; i++)
{
    Console.WriteLine($"The computer chose {computerTurn[i]}");
}

foreach (int i in computerTurn)
{
    Console.WriteLine($"The computer chose {computerTurn[i]}");
}
*/
