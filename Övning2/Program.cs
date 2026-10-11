
// Läser in ett icke-negativt heltal och kontrollerar att inmatningen är giltig.
uint? ReadUInt(string prompt)
{
    while (true)
    {
        string? input = ReadText(prompt);

        if (input == null)
            return null;

        if (uint.TryParse(input, out uint number))
            return number;

        Console.WriteLine("Invalid input. Please enter a valid non-negative whole number.");
    }
}

// Läser in en ålder från användaren med hjälp av ReadUInt().
uint? ReadAge()
{
    return ReadUInt("Please input an age:");
}

// Läser in en sträng och kontrollerar att den inte är tom eller bara innehåller mellanslag.
string? ReadText(string prompt)
{
    while (true)
    {
        Console.WriteLine(prompt);
        string? input = Console.ReadLine();

        if (input == null)
            return null;

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid input. Text cannot be empty.");
            continue;
        }

        return input;
    }
}

// Beräkna priset för en person baserat på ålder.
uint CalculateTicketPrice(uint age)
{
    if (age < 20)
        return 80;
    else if (age > 64)
        return 90;
    else
        return 120;
}

// Läs in ålder och beräkna priset för en person, skriv ut priset.
void IndividualTicket()
{
    Console.WriteLine("You selected option 1: individual ticket.");

    uint? age = ReadAge();

    if (age == null)
        return;

    Console.WriteLine($"Ticket price: {CalculateTicketPrice(age.Value)} kr");
}

// Läs in antal personer och ålder för varje person, beräkna priset för varje person och skriv ut totalpriset.
void GroupTickets()
{
    Console.WriteLine("You selected option 2: group tickets.");

    uint? members = ReadUInt("How many people are going to the cinema?");

    if (members == null)
        return;

    if (members == 0)
    {
        Console.WriteLine("Booking cancelled. Have a nice day!");
        return;
    }

    uint totalPrice = 0;

    for (uint i = 0; i < members.Value; i++)
    {
        Console.WriteLine($"Person {i + 1} of {members}:");

        uint? memberAge = ReadAge();

        if (memberAge == null)
            return;

        uint price = CalculateTicketPrice(memberAge.Value);

        totalPrice += price;
        Console.WriteLine($"Ticket price: {price} kr");
    }

    Console.WriteLine($"\nNumber of people: {members}");
    Console.WriteLine($"Total cost: {totalPrice} kr");
}

// Läs en sträng och skriv ut den tio gånger, med numrering och utan radbrytning mellan utskrifterna.
void RepeatTextTenTimes()
{
    Console.WriteLine("You selected option 3: Repeat text ten times.");

    string? userInput = ReadText("Please input a string:");

    if (userInput == null)
        return;

    for (int i = 1; i <= 10; i++)
    {
        Console.Write($"{i}. {userInput} ");
    }

    Console.WriteLine();
}

// Läs en sträng och skriv ut det tredje ordet i strängen. Om strängen innehåller färre än tre ord, skriv ut ett felmeddelande.
void PrintThirdWord()
{
    Console.WriteLine("You selected option 4: Print the third word.");

    while (true)
    {
        string? input = ReadText("Please enter a sentence with at least 3 words:");

        if (input == null)
            return;

        // StringSplitOptions.RemoveEmptyEntries: multiple spaces in a row will not lead to empty elements
        string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (words.Length < 3)
        {
            Console.WriteLine("Invalid input. Please enter at least 3 words.");
            continue;
        }
        Console.WriteLine($"The third word is: {words[2]}");
        return;
    }
}

// Program-loop: Hantera navigation och anropa resterande funktioner
void Program()
{
    Console.WriteLine("This is a simple C# program.");
    bool isRunning = true;

    while (isRunning)
    {
        Console.WriteLine("\nWelcome to main menu. Menu options:");
        Console.WriteLine("0. Exit");
        Console.WriteLine("1. Calculate individual ticket price");
        Console.WriteLine("2. Calculate group ticket price");   
        Console.WriteLine("3. Repeat text ten times");
        Console.WriteLine("4. Print the third word");

        uint? parsedOption = ReadUInt("Please select a menu option:");

        if (parsedOption == null)
            return;

        switch (parsedOption)
        {
            case 0:
                Console.WriteLine("You selected option 0: exit");
                isRunning = false;
                break;

            case 1:
                IndividualTicket();
                break;

            case 2:
                GroupTickets();
                break;

            case 3:
                RepeatTextTenTimes();
                break;

            case 4:
                PrintThirdWord();
                break;

            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
}

Program();