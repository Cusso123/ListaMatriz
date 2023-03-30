int[,] matriz = new int[3, 3];

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write($"Digite o numero para a posição [{i}, {j}]: ");
        matriz[i, j] = int.Parse(Console.ReadLine());
    }
}

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write(" | " + matriz[i, j] + " | ");

    }
    Console.WriteLine();
}



ChamarMenu menu = new ChamarMenu();
menu.menu();

Console.WriteLine();

int escolha;
escolha= int.Parse(Console.ReadLine());

switch (escolha)
{
    case 1:
        int maior = matriz[0, 0];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (matriz[i, j] > maior)
                {
                    maior = matriz[i, j];
                }
            }
        }

        Console.WriteLine($"O numero maior da matriz é: {maior}");

        return;
    case 2:

        int soma = matriz[0, 0];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                soma += matriz[i, j];
            }
        }

        Console.WriteLine($"A soma dos numeros da matriz é: {soma}");


        return;
    case 3:
        Console.WriteLine("Os Números primos da matriz são: ");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (Primo(matriz[i, j]))
                {
                    Console.WriteLine(matriz[i, j]);
                }
            }
        }
        break;

    case 0:
        Console.WriteLine("Saindo...");
        break;

    default:
        Console.WriteLine("A escolha selecionada é inválida!");
        break;
}

Console.WriteLine();

static bool Primo(int num)
{
    if (num <= 1)
    {
        return false;
    }
    for (int i = 2; i <= Math.Sqrt(num); i++)
    {
        if (num % i == 0)
        {
            return false;
        }
    }
    return true;
}


public class ChamarMenu
{

    public void menu()
    {
        Console.WriteLine("Escolha uma opção: ");
        Console.WriteLine("1 - Maior numero da matriz");
        Console.WriteLine("2 - Soma dos numeros da matriz");
        Console.WriteLine("3 - Numeros primos da matriz");
    }


}
