﻿namespace ConsoleApp1;

public abstract class User
{
    public int Id { get; set; }
    public string Nume { get; set; }
    public string Prenume { get; set; }
    public string Email { get; set; }
    public string Parola { get; set; }

    public abstract void Meniu();
}