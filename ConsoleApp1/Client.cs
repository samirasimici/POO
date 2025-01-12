namespace ConsoleApp1;

public class Client:User
{
    private EventManager eventManager;
    public List<int> IstoricEvenimente { get; set; } = new List<int>();

    public Client(EventManager eventManager)
    {
        this.eventManager = eventManager;
    }

    public void VizualizareEvenimente()
    {
        var evenimente=eventManager.GetAllEvenimente();
        if (evenimente.Count == 0)
        {
            Console.WriteLine("Nu exista evenimente disponibile");
        }
        else
        {
            foreach (var eveniment in evenimente)
            {
                Console.WriteLine($"Eveniment:{eveniment.Nume},Data:{eveniment.Data},Capacitate:{eveniment.Capacitate},Locuri ocupate:{eveniment.Participanti.Count}");
            }
        }
    }

    public void InscriereEveniment(int idEveniment)
    {
        Event eveniment=eventManager.GasesteEveniment(idEveniment);
        if (eveniment != null)
        {
            if (eveniment.Participanti.Count < eveniment.Capacitate)
            {
                eveniment.Participanti.Add(this.Id);
                IstoricEvenimente.Add(idEveniment);
                Console.WriteLine($"Te-ai inscris cu succes la evenimentul{eveniment.Nume}.");
            }
            else
            {
                Console.WriteLine("Evenimentul este complet.Nu mai sunt locuri disponibile.");
            }
        }
        else
        {
            Console.WriteLine("Evenimentul nu a fost gasit ");
        }
    }

    
}