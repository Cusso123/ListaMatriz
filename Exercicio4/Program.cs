
int[,] A = new int[3, 3];
int[,] B = new int[3, 3];


Console.WriteLine("Digite os valores da matriz A: ");
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write("A[{0},{1}]: ", i, j);
        A[i, j] = int.Parse(Console.ReadLine());
    }
}

Console.WriteLine("Digite os valores da matriz B: ");
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write("B[{0},{1}]: ", i, j);
        B[i, j] = int.Parse(Console.ReadLine());
    }
}


int[,] C = new int[3, 3];
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        C[i, j] = A[i, j] + B[i, j];
    }
}


Console.WriteLine("O Calculo das matrizes é: ");
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write("{0} ", " | " + C[i, j] + " | ");
    }
    Console.WriteLine();
}
