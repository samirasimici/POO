namespace ConsoleApp1;

public class Program
{
    public static void Main(string[] args)
    {
        EventManager globalEventManager = new EventManager();
        Organizer organizator = new Organizer(globalEventManager)
        {
            Id = 1,
            Nume = "Andrei",
            Prenume = "Aldulescu",
            Email = "andreialdulescu@yahoo.com",
            Parola = "Andrei123"
        };
        Client client1 = new Client(globalEventManager)
        {
            Id = 2,
            Nume = "Samira",
            Prenume = "Simici",
            Email = "samirasimici@yahoo.com",
            Parola = "Samira456"
        };

        Client client2 = new Client(globalEventManager)
        {
            Id = 3,
            Nume = "Andrei",
            Prenume = "Pruna",
            Email = "andreipruna@yahoo.com",
            Parola = "Pruna789"
        };
    }
}