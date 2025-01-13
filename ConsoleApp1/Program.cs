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
            Nume = "Pruna",
            Prenume = "Sebi",
            Email = "prunasebi@yahoo.com",
            Parola = "Sebi789"
        };
        
        App app = new App(globalEventManager);
        app.AdaugaUtilizator(organizator);
        app.AdaugaUtilizator(client1);
        app.AdaugaUtilizator(client2);
        
        app.Start();
    }
}