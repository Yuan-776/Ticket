using System;

class Program
{
    static void Main(string[] args)
    {
        string file = "Tickets.csv"; 
        string choice;

        do
        {
            Console.WriteLine("1) Read data from file.");
            Console.WriteLine("2) Create file from data.");
            Console.WriteLine("Enter any other key to exit.");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                ReadDataFromFile(file);
            }
            else if (choice == "2")
            {
                CreateFileFromData(file);
            }
        } while (choice == "1" || choice == "2");
    }

    static void ReadDataFromFile(string file)
    {
        if (File.Exists(file))
        {
            StreamReader sr = new StreamReader(file);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] arr = line.Split(',');
                Console.WriteLine("TicketID: {0}, Summary: {1}, Status: {2}, Priority: {3}, Submitter: {4}, Assigned: {5}, Watching: {6}", 
                                  arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
            }
            sr.Close();
        }
        else
        {
            Console.WriteLine("File does not exist");
        }
    }

    static void CreateFileFromData(string file)
    {
        Console.WriteLine("Enter new ticket details:");

        Console.Write("TicketID: ");
        string ticketID = Console.ReadLine();

        Console.Write("Summary: ");
        string summary = Console.ReadLine();

        Console.Write("Status: ");
        string status = Console.ReadLine();

        Console.Write("Priority: ");
        string priority = Console.ReadLine();

        Console.Write("Submitter: ");
        string submitter = Console.ReadLine();

        Console.Write("Assigned: ");
        string assigned = Console.ReadLine();

        Console.Write("Watching: ");
        string watching = Console.ReadLine();

        string newLine = $"{ticketID},{summary},{status},{priority},{submitter},{assigned},{watching}";

        File.AppendAllText(file, newLine + Environment.NewLine);
    }
}

