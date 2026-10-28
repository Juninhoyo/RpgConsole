using Rpg.ConsoleUI.Domain;

Player jogador = new Player("Ronald",100,5,10,50);
string localAtual = "SilverPeak";


Console.WriteLine($"=== Ficha do   {jogador.Nome} ===");
Console.WriteLine($"Local atual:   {localAtual}");
Console.WriteLine($"Vida:          {jogador.Vida}/{jogador.VidaMaxima}");
Console.WriteLine($"ataque:        {jogador.Ataque}");
Console.WriteLine($"defesa:        {jogador.Defesa}");
Console.WriteLine($"Ouro:          {jogador.Ouro}");
Console.WriteLine("\n");


const int PrecoPocao = 10;
int pocoes = 0;

Console.WriteLine($"Quantidade de ouro {jogador.Ouro}");
Console.WriteLine($"Quantas poçoes gostaria de comprar cada poção custa {PrecoPocao}");

if(!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
{
    Console.WriteLine("Quantidade invalida");
}
else
{
    int custo = PrecoPocao * quantidade;

    if (jogador.GastarOuro(custo))
    {
        pocoes += quantidade;
        Console.WriteLine($"Você comprou {quantidade} poçõe(s) por {custo} de ouro");
        Console.WriteLine($"Ouro restante {jogador.Ouro} | poções restantes {pocoes}");
    }
    else
    {
        Console.WriteLine("Ouro insuficiente");
    }
}