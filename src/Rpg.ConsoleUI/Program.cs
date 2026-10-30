using Rpg.ConsoleUI.Domain;

Player jogador = new Player(nome: "Ronald",vidaMaxima: 100,ataque: 8,defesa: 9,ouro: 50);
Monster goblin = new Monster(nome: "Goblin",vidaMaxima: 30,ataque: 12,defesa: 3,recompensaOuro: 15,recompensaXp: 10);
Weapon adaga = new Weapon(nome: "Adaga enferrujada",preco: 0,bonusAtaque: 100);

goblin.AdicionarDrops(new Drop(new Weapon(nome: "Adaga de ossos", preco: 50, bonusAtaque: 5), chance: 0.30));
goblin.AdicionarDrops(new Drop(new Weapon(nome: "Adaga de ossos 2", preco: 50, bonusAtaque: 5), chance: 0));
goblin.AdicionarDrops(new Drop(new Weapon(nome: "Adaga de ossos 3", preco: 50, bonusAtaque: 5), chance: 1));


jogador.Iventario.Adicionar(new Potion(nome:"Poção pequena",preco: 10,cura: 30));



Console.WriteLine($"{goblin.Nome} ataca {jogador.Nome}!");
int vidaAntes = jogador.Vida;
jogador.ReceberDano(goblin.Ataque);
Console.WriteLine($"Goblin da {vidaAntes - jogador.Vida} de dano. {jogador.Nome}: {jogador.Vida}/{jogador.VidaMaxima}");

Potion? pocao = jogador.Iventario.BuscarPocao();

if (pocao is not null)
{
    pocao.UsarCura(jogador);
    jogador.Iventario.Remover(pocao);
    Console.WriteLine($"{jogador.Nome} bebe a {pocao.Nome}. {jogador.Vida}/{jogador.VidaMaxima}");
}
else
{
    Console.WriteLine("Você não tem poções");
}

Console.WriteLine($"{jogador.Nome} ataca {goblin.Nome}!");
goblin.ReceberDano(jogador.Ataque + adaga.BonusAtaque);
Console.WriteLine($"{goblin.Nome}: {goblin.Vida}/{goblin.VidaMaxima}");

if (!goblin.EstaVivo)
{
    jogador.GanharOuro(goblin.RecompensaOuro);
    Console.WriteLine($"O {goblin.Nome} foi derrotado e foi dropado {goblin.RecompensaOuro} de ouro e de {goblin.RecompensaXp}.");
    foreach(Item item in goblin.SortearDrops(Random.Shared))
    {
        jogador.Iventario.Adicionar(item);
        Console.WriteLine($"Deixou cair: {item.Nome}");
    }
}

Console.WriteLine($"Quantidade atual {jogador.Ouro}.");

foreach(Item item in jogador.Iventario.Itens)
{
    Console.WriteLine($"- {item.Nome} (valor: {item.Preco})");
}











// string localAtual = "SilverPeak";

// Console.WriteLine($"=== Ficha do {jogador.Nome} ===");
// Console.WriteLine($"Local atual: {localAtual}");
// Console.WriteLine($"Vida:        {jogador.Vida}/{jogador.VidaMaxima}");
// Console.WriteLine($"ataque:      {jogador.Ataque}");
// Console.WriteLine($"defesa:      {jogador.Defesa}");
// Console.WriteLine($"Ouro:        {jogador.Ouro}");
// Console.WriteLine("\n");