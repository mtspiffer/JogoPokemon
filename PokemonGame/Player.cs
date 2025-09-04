using System;
using System.Collections.Generic;

public class Player
{
    public List<string> Mochila { get; } = new();
    public int Energia { get; private set; } = 5;
    public int FugasRestantes { get; private set; } = 5;
    private const int CustoFuga = 1;

    public void Capturar(Pokemon p)
    {
        Mochila.Add(p.Nome);
        Console.WriteLine($"✅ Você capturou {p.Nome}!");
    }

    public bool PodeFugir() => FugasRestantes > 0;

    public void Fugir(Pokemon p)
    {
        FugasRestantes--;
        Energia -= CustoFuga;
        Console.WriteLine($"🏃 Você fugiu do {p.Nome}!");
        Console.WriteLine($"🔄 Fugas restantes: {FugasRestantes}");
        Console.WriteLine($"💥 Isso custou {CustoFuga} de energia! Energia restante: {Energia}");
    }

    public void MostrarMochila()
    {
        Console.WriteLine("🎒 Pokémons capturados:");
        if (Mochila.Count == 0)
            Console.WriteLine(" - Nenhum Pokémon ainda.");
        else
            Mochila.ForEach(p => Console.WriteLine($" - {p}"));
    }

    public void PenalizarSaida(Pokemon p)
    {
        Energia -= CustoFuga;
        Console.WriteLine($"\n⚡ Você saiu enfrentando {p.Nome}!");
        Console.WriteLine($"💥 Perdeu {CustoFuga} de energia. Energia restante: {Energia}");
    }
}
