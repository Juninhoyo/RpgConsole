using Rpg.ConsoleUI.Domain;

Player jogador = new Player(nome: "Ronald",vidaMaxima: 100,ataque: 8,defesa: 9,ouro: 50);
Monster goblin = new Monster(nome: "Goblin",vidaMaxima: 30,ataque: 12,defesa: 3,recompensaOuro: 15,recompensaXp: 10);
Weapon adaga = new Weapon(nome: "Adaga enferrujada",preco: 0,bonusAtaque: 100);
Potion pocaoPequena = new Potion(nome:"Poção pequena",preco: 10,cura: 30);

string localAtual = "SilverPeak";

Console.WriteLine($"=== Ficha do {jogador.Nome} ===");
Console.WriteLine($"Local atual: {localAtual}");
Console.WriteLine($"Vida:        {jogador.Vida}/{jogador.VidaMaxima}");
Console.WriteLine($"ataque:      {jogador.Ataque}");
Console.WriteLine($"defesa:      {jogador.Defesa}");
Console.WriteLine($"Ouro:        {jogador.Ouro}");
Console.WriteLine("\n");

Console.WriteLine($"{goblin.Nome} ataca {jogador.Nome}!");
int vidaAntes = jogador.Vida;
jogador.ReceberDano(goblin.Ataque);
int danoCausado = vidaAntes - jogador.Vida;
Console.WriteLine($"Goblin da {danoCausado} de dano.");
Console.WriteLine($"{jogador.Nome}: {jogador.Vida}/{jogador.VidaMaxima}");

Console.WriteLine($"{jogador.Nome} bebe a {pocaoPequena.Nome}.");
pocaoPequena.UsarCura(jogador);
Console.WriteLine($"{jogador.Nome}: {jogador.Vida}/{jogador.VidaMaxima}");

Console.WriteLine($"{jogador.Nome} ataca {goblin.Nome}!");
goblin.ReceberDano(jogador.Ataque + adaga.BonusAtaque);
Console.WriteLine($"{goblin.Nome}: {goblin.Vida}/{goblin.VidaMaxima}");

if (!goblin.EstaVivo)
{
    jogador.GanharOuro(goblin.RecompensaOuro);
    Console.WriteLine($"O {goblin.Nome} foi derrotado e foi dropado {goblin.RecompensaOuro} de ouro e de {goblin.RecompensaXp}.");
}

Console.WriteLine($"Quantidade atual {jogador.Ouro}.");