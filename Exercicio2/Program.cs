
        int[,] matriz = new int[3, 3];
        double[] media = new double[3];

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"Digite um valor para a posição [{i}, {j}]: ");
                matriz[i, j] = int.Parse(Console.ReadLine());
            }
        }
        for (int j = 0; j < 3; j++)
        {
            double soma = 0;
            for (int i = 0; i < 3; i++)
            {
                soma += matriz[i, j];
            }
            media[j] = soma / 3;
        }

        Console.WriteLine("\n A Médias das colunas é:\n");
        for (int j = 0; j < 3; j++)
        {
            Console.WriteLine("A Coluna {0}: {1}", j + 1, media[j]);
        }
