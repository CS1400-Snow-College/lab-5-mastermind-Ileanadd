// Lab 5 Mastermind
// Ileana Gonzalez, 06/10

Console.Clear();
Console.WriteLine("- Welcome to the Guess the Secret String Game! -\n");
Console.Write("How long should the string be? ");
int length = Convert.ToInt32(Console.ReadLine());

Console.Write("How many letters should be used? ");
int letters = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();
Console.WriteLine($"I have chosen {length} between 'a' and '{(char)(96 + letters)}' and have arranged hem in a particular order.");
Console.WriteLine("Your job is to guess the letters and put them in the rigth order.");