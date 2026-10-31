using Rpg.ConsoleUI;
using Rpg.ConsoleUI.Domain;

Player jogador = new Player(nome: "Ronald",vidaMaxima: 100,ataque: 8,defesa: 9,ouro: 50);
Monster goblin = new Monster(nome: "Goblin",vidaMaxima: 30,ataque: 12,defesa: 3,recompensaOuro: 15,recompensaXp: 10);
Weapon adaga = new Weapon(nome: "Adaga enferrujada",preco: 0,bonusAtaque: 100);

jogador.Inventario.Adicionar(new Potion(nome:"Poção pequena",preco: 10,cura: 30));
jogador.Inventario.Adicionar(new Potion(nome:"Poção pequena",preco: 10,cura: 30));
jogador.Inventario.Adicionar(new Potion(nome:"Poção pequena",preco: 10,cura: 30));

goblin.AdicionarDrops(new Drop(new Weapon(nome: "Adaga de ossos", preco: 50, bonusAtaque: 5), chance: 0.30));
goblin.AdicionarDrops(new Drop(new Weapon(nome: "Adaga de ossos 2", preco: 50, bonusAtaque: 5), chance: 0));
goblin.AdicionarDrops(new Drop(new Weapon(nome: "Adaga de ossos 3", preco: 50, bonusAtaque: 5), chance: 1));

int turno = 1;
bool fugiu = false;
const double ChanceDeFuga = 0.5;

Console.WriteLine($"Um {goblin.Nome} apareceu no seu caminho!");

while (jogador.EstaVivo && goblin.EstaVivo && !fugiu)
{
    Console.WriteLine("\n");
    Console.WriteLine($"Turno: {turno}");
    Console.WriteLine($"{jogador.Nome}: {jogador.Vida}/{jogador.VidaMaxima} | {goblin.Nome}: {goblin.Vida}/{goblin.VidaMaxima}");

    AcaoCombate acao = MenuCombate.LerAcao();

    switch (acao)
    {
        case AcaoCombate.Atacar:
            {
                int dano = jogador.Atacar(goblin);
                Console.WriteLine($"{jogador.Nome} causa {dano} de dano.");
                break;
            }

        case AcaoCombate.BeberPocao:
            {
                if (jogador.Vida == jogador.VidaMaxima)
                {
                    Console.WriteLine("Sua vida ja esta cheia.");
                    break;
                }
                Potion? pocao = jogador.Inventario.BuscarPocao();
                if (pocao is null)
                {
                    Console.WriteLine("Você não tem nenhuma poção.");
                    break;
                }
                int curado = pocao.UsarCura(jogador);
                jogador.Inventario.Remover(pocao);
                Console.WriteLine($"{jogador.Nome} bebe {pocao.Nome} e recupera {curado} de vida.");
                break;
            }
        case AcaoCombate.VerInventario:
            {
                if (jogador.Inventario.Quantidade == 0)
                {
                    Console.WriteLine("Seu inventário está vazio.");
                    continue;
                }
                
                Console.WriteLine("===Inventário===");
                foreach (Item item in jogador.Inventario.Itens)
                {
                    Console.WriteLine($"{item.Nome}");
                }
                continue;
            }

        case AcaoCombate.Fugir:
            {
                if (Random.Shared.NextDouble() < ChanceDeFuga)
                {
                    fugiu = true;
                    Console.WriteLine($"{jogador.Nome} fugiu da batalha!");    
                }
                else
                {
                    Console.WriteLine($"O {jogador.Nome} tenta fugir mas o {goblin.Nome} bloqueia o caminho");
                }
                break;
            }
        
    }
    if (fugiu || !goblin.EstaVivo)
    {
        break;
    }

    int danoRecebido = goblin.Atacar(jogador);
    Console.WriteLine($"{goblin.Nome} atacou e causou {danoRecebido} de dano.");
    
    turno++;
}
if (fugiu)
{
    Console.WriteLine("Você fugiu com vida... Desta vez.");
}
else if (jogador.EstaVivo)
{
    jogador.GanharOuro(goblin.RecompensaOuro);
    Console.WriteLine($"{goblin.Nome} foi derrotado e deixou cair {goblin.RecompensaOuro} de ouro e {goblin.RecompensaXp}.");

    foreach (Item item in goblin.SortearDrops(Random.Shared))
    {
        jogador.Inventario.Adicionar(item);
        Console.WriteLine($"{goblin.Nome} deixou cair: {item.Nome}!");
    }
}
else
{
    Console.WriteLine($"{jogador.Nome} caiu em batalha...");
}





// string localAtual = "SilverPeak";

// Console.WriteLine($"=== Ficha do {jogador.Nome} ===");
// Console.WriteLine($"Local atual: {localAtual}");
// Console.WriteLine($"Vida:        {jogador.Vida}/{jogador.VidaMaxima}");
// Console.WriteLine($"ataque:      {jogador.Ataque}");
// Console.WriteLine($"defesa:      {jogador.Defesa}");
// Console.WriteLine($"Ouro:        {jogador.Ouro}");
// Console.WriteLine("\n");