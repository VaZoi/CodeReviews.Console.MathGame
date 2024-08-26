List<string> mathGameHistory = new List<string>();

void Main()
{
    InitializeGame();
}

void Calculate(char operation)
{
    int firstNum = GetValidatedNumber($"Enter the first number for {operation}: ");
    int secondNum = GetValidatedNumber($"Enter the second number for {operation}: ");

    string formula;
    int? answer = null;
    string errorMessage = null;

    switch (operation)
    {
        case '+':
            answer = firstNum + secondNum;
            break;
        case '-':
            answer = firstNum - secondNum;
            break;
        case '*':
            answer = firstNum * secondNum;
            break;
        case '/':
            if (secondNum == 0)
            {
                errorMessage = "Division by zero is not allowed.";
            }
            else
            {
                answer = firstNum / secondNum;
                if (answer < 0 || answer > 100)
                {
                    errorMessage = "Result out of allowed range (0-100).";
                }
            }
            break;
        default:
            errorMessage = "Invalid operation.";
            break;
    }

    if (answer.HasValue)
    {
        formula = $"{firstNum} {operation} {secondNum}";
        string wholeOperation = $"{formula} = {answer}";
        Console.WriteLine(wholeOperation);
        ToList(wholeOperation);
    }
    else
    {
        Console.WriteLine(errorMessage);
    }

    Console.WriteLine("Press Enter to continue...");
    Console.ReadLine();
}

int GetValidatedNumber(string prompt)
{
    int number;
    while (true)
    {
        Console.Write(prompt);
        string input = Console.ReadLine();
        if (int.TryParse(input, out number))
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
    return number;
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
        Console.WriteLine("Choose an option:\n1. Addition (+)\n2. Subtraction (-)\n3. Multiplication (*)\n4. Division (/)\n5. View Game History\nType 'exit' to quit.");
        choice = Console.ReadLine().Trim();
        if (choice.ToLower() != "exit")
        {
            ChooseGame(choice);
        }
    } while (choice.ToLower() != "exit");

    Console.WriteLine("Thanks for playing!");
}

Main();
