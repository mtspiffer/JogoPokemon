
using System;
using System.Collections.Generic;
using System.Threading;
public class Pokemon
{
    public string Nome { get; set; }
    public string Tipo { get; set; }

    public Pokemon(string nome, string tipo)
    {
        Nome = nome;
        Tipo = tipo;
    }

    public override string ToString()
    {
        return $"{Nome} ({Tipo})";
    }
}


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


public class RegiaoManager
{
    private readonly Dictionary<string, List<Pokemon>> regioes;
    private readonly Random random = new();

    public RegiaoManager()
    {
        regioes = CarregarRegioes();
    }

    public bool RegiaoExiste(string nome) => regioes.ContainsKey(nome);

    public List<string> ListarRegioes() => new List<string>(regioes.Keys);

    public Pokemon ProcurarPokemon(string regiao)
    {
        var lista = regioes[regiao];
        return lista[random.Next(lista.Count)];
    }

    private Dictionary<string, List<Pokemon>> CarregarRegioes()
    {
        return new Dictionary<string, List<Pokemon>>
        {
            { "fogo", new List<Pokemon>{
                new Pokemon("Charmander", "fogo"),
                new Pokemon("Charmeleon", "fogo"),
                new Pokemon("Charizard", "fogo"),
                new Pokemon("Vulpix", "fogo"),
                new Pokemon("Ninetales", "fogo"),
                new Pokemon("Growlithe", "fogo"),
                new Pokemon("Arcanine", "fogo"),
                new Pokemon("Ponyta", "fogo"),
                new Pokemon("Rapidash", "fogo"),
                new Pokemon("Magmar", "fogo"),
                new Pokemon("Flareon", "fogo")
            }},
            { "agua", new List<Pokemon>{
                new Pokemon("Squirtle", "agua"),
                new Pokemon("Psyduck", "agua"),
                new Pokemon("Poliwag", "agua"),
                new Pokemon("Poliwhirl", "agua"),
                new Pokemon("Poliwrath", "agua"),
                new Pokemon("Tentacool", "agua"),
                new Pokemon("Tentacruel", "agua"),
                new Pokemon("Slowpoke", "agua"),
                new Pokemon("Seel", "agua"),
                new Pokemon("Shellder", "agua"),
                new Pokemon("Krabby", "agua"),
                new Pokemon("Horsea", "agua"),
                new Pokemon("Goldeen", "agua"),
                new Pokemon("Staryu", "agua"),
                new Pokemon("Magikarp", "agua"),
                new Pokemon("Lapras", "agua"),
                new Pokemon("Vaporeon", "agua")
            }},
            { "planta", new List<Pokemon> {
                new Pokemon("Bulbasaur", "planta"),
                new Pokemon("Oddish", "planta"),
                new Pokemon("Gloom", "planta"),
                new Pokemon("Vileplume", "planta"),
                new Pokemon("Bellsprout", "planta"),
                new Pokemon("Weepinbell", "planta"),
                new Pokemon("Victreebel", "planta"),
                new Pokemon("Exeggcute", "planta"),
                new Pokemon("Exeggutor", "planta")
            }},
            { "eletrico", new List<Pokemon> {
                new Pokemon("Pikachu", "eletrico"),
                new Pokemon("Raichu", "eletrico"),
                new Pokemon("Magnemite", "eletrico"),
                new Pokemon("Magneton", "eletrico"),
                new Pokemon("Voltorb", "eletrico"),
                new Pokemon("Electabuzz", "eletrico"),
                new Pokemon("Jolteon", "eletrico")
            }},
            { "fantasma", new List<Pokemon> {
                new Pokemon("Gastly", "fantasma"),
                new Pokemon("Haunter", "fantasma"),
                new Pokemon("Gengar", "fantasma")
            }},
            { "pedra", new List<Pokemon> {
                new Pokemon("Geodude", "pedra"),
                new Pokemon("Graveler", "pedra"),
                new Pokemon("Golem", "pedra"),
                new Pokemon("Onix", "pedra"),
                new Pokemon("Rhyhorn", "pedra"),
                new Pokemon("Rhydon", "pedra")
            }},
            { "normal", new List<Pokemon> {
                new Pokemon("Rattata", "normal"),
                new Pokemon("Raticate", "normal"),
                new Pokemon("Pidgey", "normal"),
                new Pokemon("Pidgeotto", "normal"),
                new Pokemon("Pidgeot", "normal"),
                new Pokemon("Spearow", "normal"),
                new Pokemon("Fearow", "normal"),
                new Pokemon("Jigglypuff", "normal"),
                new Pokemon("Wigglytuff", "normal"),
                new Pokemon("Meowth", "normal"),
                new Pokemon("Persian", "normal"),
                new Pokemon("Farfetch'd", "normal"),
                new Pokemon("Doduo", "normal"),
                new Pokemon("Dodrio", "normal"),
                new Pokemon("Lickitung", "normal"),
                new Pokemon("Chansey", "normal"),
                new Pokemon("Kangaskhan", "normal"),
                new Pokemon("Tauros", "normal"),
                new Pokemon("Ditto", "normal"),
                new Pokemon("Eevee", "normal"),
                new Pokemon("Snorlax", "normal"),
                new Pokemon("Porygon", "normal")
            }},
            { "venenoso", new List<Pokemon> {
                new Pokemon("Zubat", "venenoso"),
                new Pokemon("Golbat", "venenoso"),
                new Pokemon("Nidoran♀", "venenoso"),
                new Pokemon("Nidorina", "venenoso"),
                new Pokemon("Nidoqueen", "venenoso"),
                new Pokemon("Nidoran♂", "venenoso"),
                new Pokemon("Nidorino", "venenoso"),
                new Pokemon("Nidoking", "venenoso"),
                new Pokemon("Ekans", "venenoso"),
                new Pokemon("Arbok", "venenoso"),
                new Pokemon("Oddish", "venenoso"),
                new Pokemon("Gloom", "venenoso"),
                new Pokemon("Vileplume", "venenoso"),
                new Pokemon("Paras", "venenoso"),
                new Pokemon("Venonat", "venenoso"),
                new Pokemon("Venomoth", "venenoso"),
                new Pokemon("Koffing", "venenoso"),
                new Pokemon("Weezing", "venenoso"),
                new Pokemon("Grimer", "venenoso"),
                new Pokemon("Muk", "venenoso")
            }},
            { "inseto", new List<Pokemon> {
                new Pokemon("Caterpie", "inseto"),
                new Pokemon("Metapod", "inseto"),
                new Pokemon("Butterfree", "inseto"),
                new Pokemon("Weedle", "inseto"),
                new Pokemon("Kakuna", "inseto"),
                new Pokemon("Beedrill", "inseto"),
                new Pokemon("Paras", "inseto"),
                new Pokemon("Parasect", "inseto"),
                new Pokemon("Venonat", "inseto"),
                new Pokemon("Venomoth", "inseto"),
                new Pokemon("Scyther", "inseto"),
                new Pokemon("Pinsir", "inseto")
            }},
            { "lutador", new List<Pokemon> {
                new Pokemon("Machop", "lutador"),
                new Pokemon("Machoke", "lutador"),
                new Pokemon("Machamp", "lutador"),
                new Pokemon("Hitmonlee", "lutador"),
                new Pokemon("Hitmonchan", "lutador")
            }},
            { "psiquico", new List<Pokemon> {
                new Pokemon("Abra", "psiquico"),
                new Pokemon("Kadabra", "psiquico"),
                new Pokemon("Alakazam", "psiquico"),
                new Pokemon("Drowzee", "psiquico"),
                new Pokemon("Hypno", "psiquico"),
                new Pokemon("Mr. Mime", "psiquico"),
                new Pokemon("Exeggcute", "psiquico"),
                new Pokemon("Exeggutor", "psiquico")
            }},
            { "voador", new List<Pokemon> {
                new Pokemon("Pidgey", "voador"),
                new Pokemon("Pidgeotto", "voador"),
                new Pokemon("Pidgeot", "voador"),
                new Pokemon("Spearow", "voador"),
                new Pokemon("Fearow", "voador"),
                new Pokemon("Zubat", "voador"),
                new Pokemon("Golbat", "voador"),
                new Pokemon("Farfetch'd", "voador"),
                new Pokemon("Doduo", "voador"),
                new Pokemon("Dodrio", "voador"),
                new Pokemon("Scyther", "voador"),
                new Pokemon("Gyarados", "voador")
            }},
            { "terra", new List<Pokemon> {
                new Pokemon("Sandshrew", "terra"),
                new Pokemon("Sandslash", "terra"),
                new Pokemon("Diglett", "terra"),
                new Pokemon("Dugtrio", "terra"),
                new Pokemon("Geodude", "terra"),
                new Pokemon("Graveler", "terra"),
                new Pokemon("Golem", "terra"),
                new Pokemon("Onix", "terra")
            }},
            { "gelo", new List<Pokemon> {
                new Pokemon("Dewgong", "gelo"),
                new Pokemon("Cloyster", "gelo"),
                new Pokemon("Jynx", "gelo"),
                new Pokemon("Lapras", "gelo"),
                new Pokemon("Articuno", "gelo")
            }},
            { "dragao", new List<Pokemon> {
                new Pokemon("Dratini", "dragao"),
                new Pokemon("Dragonair", "dragao"),
                new Pokemon("Dragonite", "dragao")
            }}
            // Adicione outras regiões conforme desejar...
        };
    }
}


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

class Program
{
    static void Main()
    {
        Game jogo = new Game();
        jogo.Iniciar();
    }
}
