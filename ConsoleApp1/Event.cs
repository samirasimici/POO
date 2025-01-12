namespace ConsoleApp1;

public class Event
{
    
    public int Id { get; set; }
    public string Nume { get; set; }
    public string Descriere { get; set; }
    public int Capacitate { get; set; }
    public DateTime Data { get; set; }
    public List<int> Participanti { get; set; } = new List<int>();
    public List<string> Reviewuri { get; set; } = new List<string>();
}