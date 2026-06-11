// Lab 5 Mastermind
// Ileana Gonzalez, 06/10

string secret = "";
string guess = "";
int guessCount = 0;
bool validGuess = false;

Random rand = new Random();

Console.Clear();
Console.WriteLine("- Welcome to the Guess the Secret String Game! -\n");
Console.Write("How long should the string be? ");
int length = Convert.ToInt32(Console.ReadLine());

Console.Write("How many letters should be used? ");
int letters = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();
Console.WriteLine($"I have chosen {length} letters between 'a' and '{(char)(96 + letters)}' and have arranged them in a particular order.");
Console.WriteLine("Your job is to guess the letters and put them in the rigth order.");
Console.WriteLine();

while (secret.Length < length)
{
    char temp = (char)rand.Next(97, 97 + letters);

    if (!secret.Contains(temp))
    {
        secret += temp;
    }
}

do
{
    guessCount++;

    Console.WriteLine($"Guess #{guessCount}: Please guess a sequence of {length} lowercase letters with no repeats.");
    guess = Console.ReadLine()!;

    while (!validGuess)
    {
        validGuess = true;

        if (guess.Length != length)
        {
            Console.WriteLine();
            Console.WriteLine($"Your guess must be {length} letters long.");
            validGuess = false;
        }
        for (int i = 0; i < guess.Length; i++)
        {
            if (guess[i] < 'a' || guess[i] > (char)(96 + letters))
            {
                Console.WriteLine();
                Console.WriteLine($"Your guess can only use letters between 'a' and '{(char)(96 + letters)}'.");
                validGuess = false;
            }

            for (int j = i + 1; j < guess.Length; j++)
            {
                if (guess[i] == guess[j])
                {
                    Console.WriteLine();
                    Console.WriteLine("Your guess can't have repeated letters.");
                    validGuess = false;
                }
            }
        }
        if (!validGuess)
        {
            Console.WriteLine("Please try again:");
            guess = Console.ReadLine()!;
        }
    }

    int rightPositions = 0;
    int wrongPositions = 0;

    for (int i = 0; i < secret.Length; i++)
    {
        if (guess[i] == secret[i])
        {
            rightPositions++;
        }
    }
    for (int i = 0; i < guess.Length; i++)
    {
        for (int j = 0; j < secret.Length; j++)
        {
            if (guess[i] == secret[j] && i != j)
            {
                wrongPositions++;
            }
        }
    }
    if (guess != secret)
    {
        Console.WriteLine($"- {rightPositions} lettrs in the right position");
        Console.WriteLine($"- {wrongPositions} letters rigth, but in the wrong position");
        Console.WriteLine();
    }

} while (guess != secret);

Console.WriteLine();
Console.WriteLine($"You did it! You guessed my secret ({secret}) in {guessCount} guesses.");