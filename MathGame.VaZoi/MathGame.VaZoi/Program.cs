using System.Diagnostics;

List<string> mathGameHistory = new List<string>();
Random random = new Random();

void Main()
{
    InitializeGame();
}

void Calculate(char operation)
{
    int question = 0;
    string formula;
    int firstValue = random.Next(1, 101);
    int secondValue = random.Next(1, 101);
    switch (operation)
    {
        case '+':
            question = firstValue + secondValue;
            break;
        case '-':
            question = firstValue - secondValue;
            break;
        case '*':
            question = firstValue * secondValue;
            break;
        case '/':
            if (secondValue == 0)
            {
                secondValue = 1;
            }
            question = firstValue / secondValue;
            break;
        default:
            Console.WriteLine("Invalid Operation!");
            break;
    }


    formula = $"{firstValue} {operation} {secondValue} = ";
    Console.WriteLine(formula);
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    string answer = Console.ReadLine();
    stopwatch.Stop();

    int timer = (int)stopwatch.Elapsed.TotalSeconds;

    if (int.TryParse(answer, out int number))
    {
        if (number == question)
        {
            string wholeOperation = $"{formula}{number}\tCorrect\t(Took {timer} seconds)";
            Console.WriteLine(wholeOperation);
            ToList(wholeOperation);
        }
        else
        {
            string wholeOperation = $"{formula}{number}\tIncorrect (Correct answer: {question})\t(Took {timer} seconds)";
            Console.WriteLine(wholeOperation);
            ToList(wholeOperation);
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a number.");
    }

    Console.WriteLine("Press Enter to continue...");
    Console.ReadLine();
}

void ToList(string wholeOperation)
{
    mathGameHistory.Add(wholeOperation);
}

void ChooseGame(string choice)
{
    if (int.TryParse(choice, out int cal))
    {
        switch (cal)
        {
            case 1:
                Calculate('+');
                break;
            case 2:
                Calculate('-');
                break;
            case 3:
                Calculate('*');
                break;
            case 4:
                Calculate('/');
                break;
            case 5:
                ViewHistoryGames();
                break;
            case 6:
                RandomGame();
                break;
            default:
                Console.WriteLine("Invalid choice. Please select a valid option.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
    }
}

void RandomGame()
{
    char[] option = { '+', '-', '*', '/' };
    int randomOption = random.Next(option.Length);
    Calculate(option[randomOption]);
}

void ViewHistoryGames()
{
    Console.WriteLine("MathGame History:");
    if (mathGameHistory.Count == 0)
    {
        Console.WriteLine("No games played yet.");
    }
    else
    {
        foreach (var game in mathGameHistory)
        {
            Console.WriteLine(game);
        }
    }

    Console.WriteLine("Press Enter to continue...");
    Console.ReadLine();
}

void InitializeGame()
{
    string choice;
    do
    {
        Console.Clear();
        Console.WriteLine("Choose an option:\n1. Addition (+)\n2. Subtraction (-)\n3. Multiplication (*)\n4. Division (/)\n5. View Game History\n6. Random game\nType 'exit' to quit.");
        choice = Console.ReadLine().Trim();
        if (choice.ToLower() != "exit")
        {
            ChooseGame(choice);
        }
    } while (choice.ToLower() != "exit");

    Console.WriteLine("Thanks for playing!");
}

Main();
