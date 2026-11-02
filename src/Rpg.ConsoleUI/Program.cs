using Rpg.ConsoleUI;
using Rpg.ConsoleUI.Domain;

Player jogador = new Player(nome: "Ronald",vidaMaxima: 100,ataque: 8,defesa: 9,ouro: 50);
Monster goblin = new Monster(nome: "Goblin",vidaMaxima: 30,ataque: 12,defesa: 3,recompensaOuro: 15,recompensaXp: 10);
//Weapon adaga = new Weapon(nome: "Adaga enferrujada",preco: 0,bonusAtaque: 100);

PrepararCenario(jogador, goblin);

Console.WriteLine($"Um {goblin.Nome} apareceu no seu caminho!");

int turno = 1;
bool fugiu = false;
const double ChanceDeFuga = 0.5;



while (jogador.EstaVivo && goblin.EstaVivo && !fugiu)
{
    ExibirStatus(jogador, goblin, turno);
    AcaoCombate acao = MenuCombate.LerAcao();
    ResultadoAcao resultado = ExecutarAcao(acao, jogador, goblin);

    if (resultado == ResultadoAcao.NaoGastouTurno)
    {
        continue;
    }

    if (resultado == ResultadoAcao.Fugiu)
    {
        fugiu = true;
        break;
    }

    if (!goblin.EstaVivo)
    {
        break;
    }
        
    ExibirAtaque(goblin, jogador, RealizarAtaque(goblin, jogador));
    turno++;
}

ExibirResultadoFinal(jogador, goblin, fugiu);

static void PrepararCenario(Player jogador,Monster monstro)
{
    jogador.Inventario.Adicionar(new Potion(nome:"Poção pequena",preco: 10,cura: 30));
    jogador.Inventario.Adicionar(new Potion(nome:"Poção pequena",preco: 10,cura: 30));
    jogador.Inventario.Adicionar(new Potion(nome:"Poção pequena",preco: 10,cura: 30));

    monstro.AdicionarDrops(new Drop(new Weapon(nome: "Adaga de ossos", preco: 50, bonusAtaque: 5), chance: 0.30));
}

static void ExibirStatus(Player jogador,Monster monstro,int numeroDoTurno)
{
    Console.WriteLine("\n");
    Console.WriteLine($"Turno: {numeroDoTurno}");
    Console.WriteLine($"{jogador.Nome}: {jogador.Vida}/{jogador.VidaMaxima} | {monstro.Nome}: {monstro.Vida}/{monstro.VidaMaxima}");
}

static ResultadoAtaque RealizarAtaque(Character atacante, Character alvo)
{
    return atacante.Atacar(alvo, Random.Shared.NextDouble(), Random.Shared.NextDouble());
}

static void ExibirAtaque(Character atacante, Character alvo, ResultadoAtaque ataque)
{
    if (!ataque.Acertou)
    {
        Console.WriteLine($"{atacante.Nome} ataca, mas erra!");
        return;
    }
    string sufixo = ataque.Critico ? " Golpe crítico" : "";
    Console.WriteLine($"{atacante.Nome} causa {ataque.Dano} de dano em {alvo.Nome}.{sufixo}");
}

ResultadoAcao ExecutarAcao(AcaoCombate acao, Player jogador, Monster monstro)
{
    switch (acao)
    {   
        case AcaoCombate.Atacar:
            ExibirAtaque(jogador, monstro, RealizarAtaque(jogador, monstro));
            return ResultadoAcao.GastouTurno;
        
        case AcaoCombate.BeberPocao:
            return BeberPocao(jogador);
        
        case AcaoCombate.VerInventario:
            ExibirInventario(jogador);
            return ResultadoAcao.NaoGastouTurno;

        case AcaoCombate.Fugir:
            return TentarFugir(jogador, monstro);
        
        default:
            return ResultadoAcao.NaoGastouTurno;
    }
}

static ResultadoAcao BeberPocao(Player jogador)
{
    if (jogador.Vida == jogador.VidaMaxima)
    {
        Console.WriteLine("Sua vida ja esta cheia.");
        return ResultadoAcao.NaoGastouTurno;
    }
    Potion? pocao = jogador.Inventario.BuscarPocao();
    if (pocao is null)
    {
        Console.WriteLine("Você não tem nenhuma poção.");
        return ResultadoAcao.NaoGastouTurno;
    }
    int curado = pocao.UsarCura(jogador);
    jogador.Inventario.Remover(pocao);
    Console.WriteLine($"{jogador.Nome} bebe {pocao.Nome} e recupera {curado} de vida.");
    return ResultadoAcao.GastouTurno;
}

static void ExibirInventario(Player jogador)
{
    if (jogador.Inventario.Quantidade == 0)
    {
        Console.WriteLine("Seu inventário está vazio.");
        return;
    }      
    Console.WriteLine("===Inventário===");
    foreach (Item item in jogador.Inventario.Itens)
    {
        Console.WriteLine($"{item.Nome}");
    }
}

static ResultadoAcao TentarFugir(Player jogador, Monster monstro)
{
    if (Random.Shared.NextDouble() < ChanceDeFuga)
    {
        Console.WriteLine($"{jogador.Nome} fugiu da batalha!");
        return ResultadoAcao.Fugiu;
    }
    Console.WriteLine($"O {jogador.Nome} tenta fugir mas o {monstro.Nome} bloqueia o caminho");
    return ResultadoAcao.GastouTurno;
}

static void ExibirResultadoFinal(Player jogador, Monster monstro, bool fugiu)
{
    if (fugiu)
    {
        Console.WriteLine("Você fugiu com vida... Desta vez.");
    }
    else if (jogador.EstaVivo)
    {
        jogador.GanharOuro(monstro.RecompensaOuro);
        Console.WriteLine($"{monstro.Nome} foi derrotado e deixou cair {monstro.RecompensaOuro} de ouro e {monstro.RecompensaXp}.");

        foreach (Item item in monstro.SortearDrops(Random.Shared))
        {
            jogador.Inventario.Adicionar(item);
            Console.WriteLine($"{monstro.Nome} deixou cair: {item.Nome}!");
        }
    }
    else
    {
        Console.WriteLine($"{jogador.Nome} caiu em batalha...");
    }
}
