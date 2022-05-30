string CPU = "Rival";
int rounds = 10;
Random Random = new();
int enemyDice = 0;
int playerDice = 0;
int cpuScore = 0;
int playerScore = 0;
Console.WriteLine("Dice Game");
Console.WriteLine();
Console.WriteLine($"In this game you and a computer {CPU} will play {rounds} rounds\nwhere you will each roll a 6-sided dice, and the player \nwith the highest dice value will win the round. The player \nwho wins the most rounds wins the game. Good luck!");
Console.WriteLine();

Console.Write("Press any key to start...");
Console.ReadKey(true);
Console.WriteLine();
Console.WriteLine();

for (int i = 1; i <= 10; i++)
{

    enemyDice = Random.Next(1, 7);
    playerDice = Random.Next(1, 7);
    Console.WriteLine($"Round {i}");
    Console.WriteLine($"{CPU} rolled a {enemyDice}");
    Console.Write("Press any key to roll the dice...");

    Console.ReadKey(true);
    Console.WriteLine();

    Console.WriteLine($"You rolled a {playerDice}");
    if (enemyDice > playerDice)
    {
        cpuScore++;
        Console.WriteLine($"The {CPU} won this round.");
    }
    else if (enemyDice == playerDice)
    {
        Console.WriteLine("This round is a draw!");
    }
    else 
        playerScore++;
    Console.WriteLine($"The score is now - You : {playerScore}. {CPU} : {cpuScore}");
    Console.Write("Press any key to continue...");
    Console.ReadKey(true);
    Console.WriteLine();
    Console.WriteLine();
}
