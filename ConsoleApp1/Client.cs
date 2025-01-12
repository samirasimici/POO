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
            Console.WriteLine("Evenimentul nu a fost gasit .");
        }
    }

    public void VerificareUpdateEvenimente()
    {
        Console.WriteLine("Actualizari pentru evenimentele la care esti inscris:");
        foreach(var id:in IstoricEvenimente)
        {
            Event eveniment = eventManager.GasesteEveniment(id);
            if (eveniment != null)
            {
                Console.WriteLine($"Actualizari pentru evenimentul{eveniment.Nume}:{eveniment.Descriere}");
            }
            else
            {
                Console.WriteLine($"Evenimentul cu ID{id}nu mai exista.");
            }
                
        }
    }

    public override void Meniu()
    {
        while (true)
        {
            Console.WriteLine("1.Vizualizare evenimente");
            Console.WriteLine("2.Inscriere la eveniment");
            Console.WriteLine("3.Istoric participare ");
            Console.WriteLine("4.Review eveniment");
            Console.WriteLine("5.Verificare update-uri");
            Console.WriteLine("6.Iesire");
            
            int optiune=int .Parse(Console.ReadLine());

            switch (optiune)
            {
                case 1:
                    VizualizareEvenimente();
                    break;
                case 2:
                    Console.WriteLine("Introdu ID-ul evenimentului la care vrei sa te inscrii:");
                    int idEveniment=int.Parse(Console.ReadLine());
                    InscriereEveniment(idEveniment);
                    break;
                case 3:
                    Console.WriteLine("Istoricul tau de participare:");
                    foreach (var id in IstoricEvenimente)
                    {
                        Event eveniment=eventManager.GasesteEveniment(id);
                        if (eveniment != null)
                        {
                            Console.WriteLine($"Eveniment:{eveniment.Nume},Date:{eveniment.Data}");
                        }
                    }

                    break;
                case 4:
                    Console.WriteLine("Introdu ID-ul evenimentului penntru review:");
                    int idRev=int.Parse(Console.ReadLine());
                    Console.WriteLine("Introdu review-ul:");
                    string review=Console.ReadLine();
                    ReviewEveniment(idRev,review);
                    break;
                case 5:
                    VerificareUpdateEvenimente();
                    break;
                case 6 :
                    return;
                default:
                    Console.WriteLine("Optiune invalida.");
                    break;
            }
        }
    }
    
}