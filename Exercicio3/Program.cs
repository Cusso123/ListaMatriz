
        int[,] matriz = new int[3, 3];

        Console.WriteLine("Digite os valores para a Matriz A");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write("A[" + i + ", " + j + "]: ");
                matriz[i, j] = int.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine("A Matriz A é: ");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(matriz[i, j] + " ");
            }
            Console.WriteLine();
        }

        int[,] transpost = new int[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                transpost[j, i] = matriz[i, j];
            }
        }

        Console.WriteLine("A Matriz A trasposta é: ");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(transpost[i, j] + " ");
            }
            Console.WriteLine();
        }