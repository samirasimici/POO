namespace ConsoleApp1;

public class App
{
    private EventManager eventManager;
    private List<User> utilizatori = new List<User>();

    public App(EventManager eventManager)
    {
        this.eventManager = eventManager;
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("1. Logare");
            Console.WriteLine("2. Iesire");

            int optiune = int.Parse(Console.ReadLine());

            switch (optiune)
            {
                case 1:
                    Logare();
                    break;
                case 2:
                    return;
                default:
                    Console.WriteLine("Opțiune invalidă.");
                    break;
            }
        }
    }

    private void Logare()
    {
        Console.WriteLine("Introdu email-ul:");
        string email = Console.ReadLine();
        Console.WriteLine("Introdu parola:");
        string parola = Console.ReadLine();

        User user = utilizatori.FirstOrDefault(u => u.Email == email && u.Parola == parola);
        if (user != null)
        {
            Console.WriteLine($"Bun venit, {user.Nume}");
            user.Meniu();
        }
        else
        {
            Console.WriteLine("Email sau parolă greșită.");
        }
    }

    public void AdaugaUtilizator(User user)
    {
        utilizatori.Add(user);
    }
}