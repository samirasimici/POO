namespace ConsoleApp1;

public class EventManager
{
    private List<Event> evenimente = new List<Event>();
    private List<Client> clienti = new List<Client>();

    public int GetNextEventId()
    {
        return evenimente.Count + 1;
    }

    public void AdaugareEveniment(Event eveniment)
    {
        evenimente.Add(eveniment);
    }

    public Event GasesteEveniment(int id)
    {
        return evenimente.FirstOrDefault(e=> e.Id == id);
    }

    public List<Event> GetAllEvenimente()
    {
        return evenimente;
    }

    public Client GasesteClient(int id)
    {
        return clienti.FirstOrDefault(c => c.Id == id);
    }

    public void AdaugaClient(Client client)
    {
        clienti.Add(client);
    }
}