namespace ConsoleApp1;

public class Organizer : User
{
    private EventManager eventManager;

    public Organizer(EventManager eventManager)
    {
        this.eventManager = eventManager;
    }

    public void LansareEveniment(string nume, string descriere, int capacitate, DateTime data)
    {
        Event nouEveniment = new Event
        {
            Id = eventManager.GetNextEventId(),
            Nume = nume,
            Descriere = descriere,
            Capacitate = capacitate,
            Data = data
        };
        eventManager.AdaugareEveniment(nouEveniment);
        Console.WriteLine($"Evenimentul {nume} a fost lansat cu succes.");
    }
}