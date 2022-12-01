using CodingTracker;

//Database.InitDatabase();

//MainMenu.Render();

DateOnly GetTimeInput()
{
    Console.WriteLine("\n\nEnter date in the following format: YYYY-MM-DD ");
    string input = Console.ReadLine();
    DateOnly output;
    DateOnly.TryParse(input, out output);
    Console.WriteLine(output);
    return output;
}

GetTimeInput();