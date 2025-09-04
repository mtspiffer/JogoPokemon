using System;
using System.Threading;

public class Game
{
    private readonly Player player = new();
    private readonly RegiaoManager regioes = new();
    private Pokemon pokemonAtual = null;
    private string regiaoAtual = "";

    public void Iniciar()
    {
        Console.WriteLine("🧢 Bem-vindo ao Mundo Pokémon!");

        while (true)
        {
            MostrarMenu();

            Console.Write("\nDigite um comando: ");
            string comando = Console.ReadLine().ToLower();

            if (!ExecutarComando(comando))
                break;
        }

        Console.WriteLine("\n👾 Obrigado por jogar Pokémon!");
    }

    private void MostrarMenu()
    {
        Console.WriteLine($"\n🔋 Energia: {player.Energia}");

        if (pokemonAtual == null)
        {
            Console.WriteLine(" - 'regiao'   → Escolher uma região");
        }

        if (!string.IsNullOrEmpty(regiaoAtual))
        {
            if (pokemonAtual != null)
            {
                Console.WriteLine(" - 'capturar' → Capturar Pokémon");
                if (player.PodeFugir())
                    Console.WriteLine(" - 'fugir'    → Fugir");
                else
                    Console.WriteLine(" - 'fugir'    → (Sem fugas restantes)");
            }
            else
            {
                Console.WriteLine(" - 'procurar' → Procurar Pokémon na região");
            }
        }

        Console.WriteLine(" - 'mochila'  → Ver mochila");
        Console.WriteLine(" - 'sair'     → Sair do jogo");
    }

    private bool ExecutarComando(string comando)
    {
        switch (comando)
        {
            case "sair":
                if (pokemonAtual != null)
                    player.PenalizarSaida(pokemonAtual);
                return false;

            case "regiao":
                EscolherRegiao();
                break;

            case "procurar":
                ProcurarPokemon();
                break;

            case "capturar":
                Capturar();
                break;

            case "fugir":
                Fugir();
                break;

            case "mochila":
                player.MostrarMochila();
                break;

            default:
                Console.WriteLine("❓ Comando inválido.");
                break;
        }

        return true;
    }

    private void EscolherRegiao()
    {
        Console.WriteLine("\n🌍 Regiões disponíveis:");
        foreach (var r in regioes.ListarRegioes())
            Console.WriteLine($" - {r}");

        Console.Write("Escolha a região: ");
        string nome = Console.ReadLine().ToLower();

        if (regioes.RegiaoExiste(nome))
        {
            regiaoAtual = nome;
            pokemonAtual = null;
            Console.WriteLine($"🌿 Entrou na região: {regiaoAtual.ToUpper()}");
        }
        else
        {
            Console.WriteLine("⚠️ Região inválida.");
        }
    }

    private void ProcurarPokemon()
    {
        if (string.IsNullOrEmpty(regiaoAtual))
        {
            Console.WriteLine("⚠️ Escolha uma região antes.");
            return;
        }

        if (pokemonAtual != null)
        {
            Console.WriteLine("⚠️ Já há um Pokémon visível.");
            return;
        }

        pokemonAtual = regioes.ProcurarPokemon(regiaoAtual);
        Console.WriteLine($"👀 Um {pokemonAtual.Nome} selvagem apareceu!");
    }

    private void Capturar()
    {
        if (pokemonAtual == null)
        {
            Console.WriteLine("⚠️ Nenhum Pokémon para capturar.");
            return;
        }

        Console.WriteLine($"\n🎯 Lançando Pokébola em {pokemonAtual.Nome}...");
        for (int i = 3; i > 0; i--)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }

        if (new Random().Next(100) < 50)
        {
            player.Capturar(pokemonAtual);
            pokemonAtual = null;
        }
        
        else
        {
            Console.WriteLine($"❌ {pokemonAtual.Nome} escapou!");
            pokemonAtual = null;
        }
    }


    private void Fugir()
    {
        if (pokemonAtual == null)
        {
            Console.WriteLine("⚠️ Nenhum Pokémon visível.");
            return;
        }

        if (player.PodeFugir())
        {
            player.Fugir(pokemonAtual);
            pokemonAtual = null;
        }
        else
        {
            Console.WriteLine("🚫 Você não pode fugir mais.");
        }
    }
}
