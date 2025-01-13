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
    
        public void ModificaEveniment(int idEveniment, string numeNou, string descriereNoua, int capacitateNoua, DateTime dataNoua)
    {
        Event eveniment = eventManager.GasesteEveniment(idEveniment);
        if (eveniment != null)
        {
            eveniment.Nume = numeNou;
            eveniment.Descriere = descriereNoua;
            eveniment.Capacitate = capacitateNoua;
            eveniment.Data = dataNoua;
            Console.WriteLine("Evenimentul a fost actualizat cu succes.");
        }
        else
        {
            Console.WriteLine("Evenimentul nu a fost găsit.");
        }
    }

    public void RaportEvenimente()
    {
        var evenimente = eventManager.GetAllEvenimente();
        if (evenimente.Count == 0)
        {
            Console.WriteLine("Nu există evenimente disponibile.");
        }
        else
        {
            foreach (var eveniment in evenimente)
            {
                Console.WriteLine($"Eveniment: {eveniment.Nume}, Data: {eveniment.Data}, Participanți: {eveniment.Participanti.Count}/{eveniment.Capacitate}");
            }
        }
    }

    public void VerificaReviewuri(int idEveniment)
    {
        Event eveniment = eventManager.GasesteEveniment(idEveniment);
        if (eveniment != null)
        {
            Console.WriteLine($"Review-uri pentru evenimentul {eveniment.Nume}:");
            foreach (var review in eveniment.Reviewuri)
            {
                Console.WriteLine(review);
            }
        }
        else
        {
            Console.WriteLine("Evenimentul nu a fost găsit.");
        }
    }

    public override void Meniu()
    {
        while (true)
        {
            Console.WriteLine("1. Lansare eveniment");
            Console.WriteLine("2. Modificare eveniment");
            Console.WriteLine("3. Raport evenimente");
            Console.WriteLine("4. Verificare review-uri");
            Console.WriteLine("5. Iesire");

            int optiune = int.Parse(Console.ReadLine());

            switch (optiune)
            {
                case 1:
                    Console.WriteLine("Introdu detalii despre eveniment:");
                    Console.WriteLine("Nume:");
                    string nume = Console.ReadLine();
                    Console.WriteLine("Descriere:");
                    string descriere = Console.ReadLine();
                    Console.WriteLine("Capacitate:");
                    int capacitate = int.Parse(Console.ReadLine());
                    Console.WriteLine("Data (format: yyyy-MM-dd):");
                    DateTime data = DateTime.Parse(Console.ReadLine());
                    LansareEveniment(nume, descriere, capacitate, data);
                    break;
                case 2:
                    Console.WriteLine("Introdu ID-ul evenimentului de modificat:");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nume nou:");
                    string numeNou = Console.ReadLine();
                    Console.WriteLine("Descriere nouă:");
                    string descriereNoua = Console.ReadLine();
                    Console.WriteLine("Capacitate nouă:");
                    int capacitateNoua = int.Parse(Console.ReadLine());
                    Console.WriteLine("Data nouă (format: yyyy-MM-dd):");
                    DateTime dataNoua = DateTime.Parse(Console.ReadLine());
                    ModificaEveniment(id, numeNou, descriereNoua, capacitateNoua, dataNoua);
                    break;
                case 3:
                    RaportEvenimente();
                    break;
                case 4:
                    Console.WriteLine("Introdu ID-ul evenimentului pentru care vrei să vezi review-uri:");
                    int idEveniment = int.Parse(Console.ReadLine());
                    VerificaReviewuri(idEveniment);
                    break;
                case 5:
                    return; // Iesim din meniu
                default:
                    Console.WriteLine("Opțiune invalidă.");
                    break;
            }
        }
    }
}