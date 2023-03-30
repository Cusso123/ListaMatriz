using System;

class JogoDaMemoria
{
    static void Main()
    {
        string[] palavra = { "Marmota", "Esquilo", "Castor", "Cão da Pradaria", "Hamster", "Camundongo",
                              "Ratazana", "Chinchila", "Porquinho da India", "Capivara", "Paca", "Ouriço",
                              "Guaxinim", "Coelho", "Lebre", "Twister", "Furão", "Rato" };

        string[,] jogo = new string[6, 6];

        Random random = new Random();

        int count = 0;
        while (count < 18)
        {
            int i = random.Next(6);
            int j = random.Next(6);

            if (jogo[i, j] == null)
            {
                jogo[i, j] = palavra[count];
                count++;

                int i2, j2;
                do
                {
                    i2 = random.Next(6);
                    j2 = random.Next(6);
                } while (jogo[i2, j2] != null);

                jogo[i2, j2] = palavra[count];
                count++;
            }
        }

        bool[,] revelado = new bool[6, 6];

        while (true)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (revelado[i, j])
                    {
                        Console.Write(jogo[i, j] + " ");
                    }
                    else
                    {
                        Console.Write("* ");
                    }
                }
                Console.WriteLine();
            }

            Console.Write("Digite a linha e a coluna da carta que voce deseja revelar (exemplo: 1 6): ");
            string[] entrada = Console.ReadLine().Split();
            int linha1 = int.Parse(entrada[0]) - 1;
            int coluna1 = int.Parse(entrada[1]) - 1;

            if (revelado[linha1, coluna1])
            {
                Console.WriteLine("Esta carta já foi revelada. Escolha outra.");
                continue;
            }

            Console.WriteLine("A carta escolhida é: " + jogo[linha1, coluna1]);
            revelado[linha1, coluna1] = true;

            Console.Write("Digite a linha e a coluna da próxima carta que deseja revelar: ");
            entrada = Console.ReadLine().Split();
            int linha2 = int.Parse(entrada[0]) - 1;
            int coluna2 = int.Parse(entrada[1]) - 1;

            if (revelado[linha2, coluna2])
            {
                Console.WriteLine("Esta carta já foi revelada. Escolha outra.");
                continue;
            }

            Console.WriteLine("A carta escolhida é: " + jogo[linha2, coluna2]);
            revelado[linha2, coluna2] = true;

            if (jogo[linha1, coluna1] == jogo[linha2, coluna2])
            {
                Console.WriteLine("Par encontrado! Parabéns!");
            }
            else
            {
                Console.WriteLine("Não é um par. Tente novamente.");
                revelado[linha1, coluna1] = false;
                revelado[linha2, coluna2] = false;
            }

            bool termino = true;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (!revelado[i, j])
                    {
                        termino = false;
                        break;
                    }
                }
                if (!termino)
                {
                    break;
                }
            }
            if (termino)
            {
                Console.WriteLine("Parabéns! Você encontrou todos os pares!");
                break;
            }
        }

        Console.WriteLine("Pressione qualquer tecla para sair...");
        Console.ReadKey();
    }
}
