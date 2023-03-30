using System;
using System.Linq;

namespace TicTacToe
{
    class Program
    {
        static char[,] board = new char[3, 3];

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1 - Iniciar novo jogo Humano vs Humano");
                Console.WriteLine("2 - Iniciar novo jogo Humano vs Máquina");
                Console.WriteLine("3 - Sair");
                Console.Write("Digite a opção desejada: ");
                int option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    PlayHumanVsHuman();
                }
                else if (option == 2)
                {
                    PlayHumanVsMachine();
                }
                else if (option == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                }
            }
        }

        static void PlayHumanVsHuman()
        {
            InitializeBoard();

            while (true)
            {
                PrintBoard();

                if (IsGameOver())
                {
                    break;
                }

                Console.WriteLine($"Turno do Jogador {currentPlayer}: ");
                MakeMove();
                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
            }
        }

        static void PlayHumanVsMachine()
        {
            InitializeBoard();

            while (true)
            {
                PrintBoard();

                if (IsGameOver())
                {
                    break;
                }

                if (currentPlayer == 'X')
                {
                    Console.WriteLine($"Turno do Jogador {currentPlayer}: ");
                    MakeMove();
                }
                else
                {
                    Console.WriteLine("A Vez do Jogador 0");
                    MakeMachineMove();
                }

                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
            }
        }

        static char currentPlayer = 'O';

        static void InitializeBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = ' ';
                }
            }
        }

        static void PrintBoard()
        {
            Console.WriteLine("  0 1 2");
            for (int row = 0; row < 3; row++)
            {
                Console.Write($"{row} ");
                for (int col = 0; col < 3; col++)
                {
                    Console.Write($"{board[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        static void MakeMove()
        {
            int row, col;

            Console.Write("Escolha a Linha: ");
            row = int.Parse(Console.ReadLine());

            Console.Write("Escolha a Coluna: ");
            col = int.Parse(Console.ReadLine());

            while (!IsValidMove(row, col))
            {
                Console.WriteLine("Escolha invalida, tente novamente!");
                Console.Write("Escolha a Linha: ");
                row = int.Parse(Console.ReadLine());

                Console.Write("Escolha a Coluna: ");
                col = int.Parse(Console.ReadLine());
            }

            board[row, col] = currentPlayer;
        }

        static void MakeMachineMove()
        {
            int bestRow = -1, bestCol = -1;
            int bestScore = int.MinValue;

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == ' ')
                    {
                        int score = 0;

                        // central position
                        if (row == 1 && col == 1)
                        {
                            score += 2;
                        }
                        // corners
                        if ((row == 0 || row == 2) && (col == 0 || col == 2))
                        {
                            score += 1;
                        }

                        // check if there are opponent's pieces in the same row, column, or diagonal
                        if (OpponentHasPieceInRow(row) || OpponentHasPieceInColumn(col) || OpponentHasPieceInDiagonal(row, col))
                        {
                            score -= 2;
                        }

                        // check if the move prevents opponent from winning
                        board[row, col] = 'O';
                        if (IsWinner('O'))
                        {
                            score += 84;
                        }
                        board[row, col] = ' ';

                        // check if the move leads to a win
                        board[row, col] = 'O';
                        if (IsWinner('O'))
                        {
                            score += 4;
                        }
                        board[row, col] = ' ';

                        // update best move
                        if (score > bestScore)
                        {
                            bestRow = row;
                            bestCol = col;
                            bestScore = score;
                        }
                    }
                }
            }

            board[bestRow, bestCol] = 'O';
            Console.WriteLine($"O Jogador 0 jogou na posição ({bestRow}, {bestCol}).");
        }

        static bool IsValidMove(int row, int col)
        {
            if (row < 0 || row > 2 || col < 0 || col > 2)
            {
                return false;
            }

            if (board[row, col] != ' ')
            {
                return false;
            }

            return true;
        }

        static bool IsWinner(char player)
        {
            // check rows
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == player && board[row, 1] == player && board[row, 2] == player)
                {
                    return true;
                }
            }

            // check columns
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] == player && board[1, col] == player && board[2, col] == player)
                {
                    return true;
                }
            }

            // check diagonals
            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
            {
                return true;
            }
            if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
            {
                return true;
            }

            return false;
        }

        static bool IsGameOver()
        {
            if (IsWinner('X'))
            {
                Console.WriteLine("Jogador X Ganhou!");
                return true;
            }

            if (IsWinner('O'))
            {
                Console.WriteLine("Jogador O Ganhou!");
                return true;
            }

            if (board.Cast<char>().All(p => p != ' '))
            {
                Console.WriteLine("Empate!");
                return true;
            }

            return false;
        }

        static bool OpponentHasPieceInRow(int row)
        {
            char opponent = currentPlayer == 'X' ? 'O' : 'X';

            return board[row, 0] == opponent && board[row, 1] == opponent && board[row, 2] == opponent;
        }

        static bool OpponentHasPieceInColumn(int col)
        {
                char opponent = currentPlayer == 'X' ? 'O' : 'X';
            return board[0, col] == opponent && board[1, col] == opponent && board[2, col] == opponent;
        }

        static bool OpponentHasPieceInDiagonal(int row, int col)
        {
            char opponent = currentPlayer == 'X' ? 'O' : 'X';

            // check diagonal \
            if (row == col)
            {
                return board[0, 0] == opponent && board[1, 1] == opponent && board[2, 2] == opponent;
            }

            // check diagonal /
            if (row + col == 2)
            {
                return board[0, 2] == opponent && board[1, 1] == opponent && board[2, 0] == opponent;
            }

            return false;
        }
    }
}