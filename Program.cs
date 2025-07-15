using System;
using System.Collections.Generic;
using System.Threading; // Para Thread.Sleep

class Pokemon
{
    public string Nome { get; set; }
    public string Tipo { get; set; }

    public Pokemon(string nome, string tipo)
    {
        Nome = nome;
        Tipo = tipo;
    }
}

class Program
{
    static void Main()
    {
        Dictionary<string, List<Pokemon>> regioes = new Dictionary<string, List<Pokemon>>()
        {
            { "fogo", new List<Pokemon> {
                new Pokemon("Charmander", "agua"),
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
            { "agua", new List<Pokemon> {
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
        };

        List<string> mochila = new List<string>();
        string regiaoAtual = "";
        string comando = "";
        Random random = new Random();
        Pokemon pokemonVisivel = null;
        int fugasRestantes = 5;
        int energia = 5;
        int custoFuga = 1;

        Console.WriteLine("🧢 Bem-vindo ao Mundo Pokémon!");

        while (true)
        {
            Console.WriteLine($"\n🔋 Energia: {energia}");
            Console.WriteLine("\nComandos disponíveis:");

            if (pokemonVisivel == null)
            {
                Console.WriteLine(" - 'regiao'   → Escolher uma região para explorar");
            }

            if (!string.IsNullOrEmpty(regiaoAtual))
            {
                if (pokemonVisivel != null)
                {
                    Console.WriteLine(" - 'capturar' → Lançar Pokébola e tentar capturar");

                    if (fugasRestantes > 0)
                        Console.WriteLine($" - 'fugir'    → Fugir do Pokémon atual ({fugasRestantes}/5 restantes)");
                    else
                        Console.WriteLine(" - 'fugir'    → (Limite de fugas atingido)");
                }
                else
                {
                    Console.WriteLine(" - 'procurar'    → Procurar por um Pokémon selvagem na região");
                }
            }

            Console.WriteLine(" - 'mochila'  → Ver Pokémons capturados");
            Console.WriteLine(" - 'sair'     → Sair do jogo");

            Console.Write("\nDigite um comando: ");
            comando = Console.ReadLine().ToLower();

            if (comando == "sair")
            {
                if (pokemonVisivel != null)
                {
                    energia -= custoFuga;
                    Console.WriteLine($"\n⚡ Você saiu enquanto enfrentava {pokemonVisivel.Nome}!");
                    Console.WriteLine($"💥 Isso custou {custoFuga} de energia!");
                    Console.WriteLine($"🔋 Energia restante: {energia}");
                }
                else
                {
                    Console.WriteLine("\n👋 Você saiu do jogo calmamente.");
                }
                break;
            }
            else if (comando == "regiao")
            {
                Console.WriteLine("\n🌍 Regiões disponíveis:");
                foreach (var nomeRegiao in regioes.Keys)
                    Console.WriteLine($" - {nomeRegiao}");

                Console.Write("Digite o nome da região: ");
                string novaRegiao = Console.ReadLine().ToLower();

                if (regioes.ContainsKey(novaRegiao))
                {
                    regiaoAtual = novaRegiao;
                    pokemonVisivel = null;
                    Console.WriteLine($"✅ Você está agora na região: {regiaoAtual.ToUpper()}");
                    Console.WriteLine("🌿 Use o comando 'procurar' para procurar Pokémons.");
                }
                else
                {
                    Console.WriteLine("⚠️ Região inválida. Tente novamente.");
                }
            }
            else if (comando == "capturar")
            {
                if (pokemonVisivel == null)
                {
                    Console.WriteLine("⚠️ Nenhum Pokémon visível agora. Use o comando 'procurar'.");
                    continue;
                }

                Console.WriteLine($"\n🎯 Lançando Pokébola em {pokemonVisivel.Nome}...");
                for (int i = 3; i > 0; i--)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(1000);
                }

                int chance = random.Next(100);
                if (chance < 50)
                {
                    Console.WriteLine($"✅ Você capturou {pokemonVisivel.Nome}!");
                    mochila.Add(pokemonVisivel.Nome);
                    pokemonVisivel = null;
                }
                else
                {
                    Console.WriteLine($"❌ O {pokemonVisivel.Nome} escapou!");
                }

                /*if (pokemonVisivel == null && regioes.ContainsKey(regiaoAtual))
                {
                    List<Pokemon> pokemonsDisponiveis = regioes[regiaoAtual];
                    pokemonVisivel = pokemonsDisponiveis[random.Next(pokemonsDisponiveis.Count)];
                    Console.WriteLine($"\n👀 Um novo {pokemonVisivel.Nome} selvagem apareceu!");
                }*/
            }
            else if (comando == "fugir")
            {
                if (pokemonVisivel == null)
                {
                    Console.WriteLine("⚠️ Nenhum Pokémon visível para fugir.");
                    continue;
                }

                if (fugasRestantes <= 0)
                {
                    Console.WriteLine("🚫 Limite de fugas atingido. Tente capturar ou sair.");
                    continue;
                }

                fugasRestantes--;
                energia -= custoFuga;

                Console.WriteLine($"🏃 Você fugiu do {pokemonVisivel.Nome}!");
                Console.WriteLine($"🔄 Fugas restantes: {fugasRestantes}");
                Console.WriteLine($"💥 Isso custou {custoFuga} de energia!");

                pokemonVisivel = null;
            }
            else if (comando == "procurar")
            {
                if (string.IsNullOrEmpty(regiaoAtual))
                {
                    Console.WriteLine("⚠️ Você precisa escolher uma região antes de caçar.");
                    continue;
                }

                if (pokemonVisivel != null)
                {
                    Console.WriteLine("⚠️ Já há um Pokémon visível. Tente capturar ou fugir.");
                    continue;
                }

                List<Pokemon> pokemonsDisponiveis = regioes[regiaoAtual];
                pokemonVisivel = pokemonsDisponiveis[random.Next(pokemonsDisponiveis.Count)];
                Console.WriteLine($"👀 Um {pokemonVisivel.Nome} selvagem apareceu!");
            }
            else if (comando == "mochila")
            {
                if (mochila.Count == 0)
                {
                    Console.WriteLine("🎒 Sua mochila está vazia.");
                }
                else
                {
                    Console.WriteLine("🎒 Pokémons capturados:");
                    foreach (var p in mochila)
                        Console.WriteLine($" - {p}");
                }
            }
            else
            {
                Console.WriteLine("❓ Comando inválido. Tente novamente.");
            }
        }

        Console.WriteLine("\n👾 Obrigado por jogar Pokémon! Até a próxima!");
    }
}