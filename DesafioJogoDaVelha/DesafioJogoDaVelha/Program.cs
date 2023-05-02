
using System;
using System.ComponentModel.Design;

namespace DesafioJogoDaVelha {
    internal class Program {
        static string PLAYER1 = "X";
        static string PLAYER2 = "O";

        public static int gameMode() {
            string escolha;
            int escolhaInt = 0;

            Console.WriteLine("MODO DE JOGO");
            do {
                Console.WriteLine("1 - PvP");
                Console.WriteLine("2 - PvE");
                Console.Write("Escolha o modo de jogo: ");
                escolha = Console.ReadLine();
                if (!string.IsNullOrEmpty(escolha) && int.TryParse(escolha, out int teste)) {
                    escolhaInt = int.Parse(escolha);
                    if (escolhaInt != 1 && escolhaInt != 2) {
                        Console.WriteLine("Valor inválido.");
                    }
                }
                else {
                    Console.WriteLine("Valor inválido.");
                }
            } while (escolhaInt != 1 && escolhaInt != 2);
            return escolhaInt;
        }
        public static int gameDifficult() {
            string escolha;
            int escolhaInt = 0;

            Console.WriteLine("DIFICULDADE");
            do {
                Console.WriteLine("1 - Fácil");
                Console.WriteLine("2 - Difícil");
                Console.Write("Escolha a dificuldade: ");
                escolha = Console.ReadLine();
                if (!string.IsNullOrEmpty(escolha) && int.TryParse(escolha, out int teste)) {
                    escolhaInt = int.Parse(escolha);
                    if (escolhaInt != 1 && escolhaInt != 2) {
                        Console.WriteLine("Valor inválido.");
                    }
                }
                else {
                    Console.WriteLine("Valor inválido.");
                }
            } while (escolhaInt != 1 && escolhaInt != 2);
            return escolhaInt;
        }
        public static void resetBoard(string[,] board) { // deixa todas as posições do board vazia
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    board[i, j] = " ";
                }
            }
        }
        public static void printBoard(string[,] board) { // mostra o board na tela
            Console.WriteLine($" {board[0, 0]} | {board[0, 1]} | {board[0, 2]}");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {board[1, 0]} | {board[1, 1]} | {board[1, 2]}");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {board[2, 0]} | {board[2, 1]} | {board[2, 2]}");
        }
        public static int checkFreeSpaces(string[,] board) { // verifica se tem algum espaço vazio que possa ser usado para algum movimento
            int freeSpaces = 9;

            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (board[i, j] != " ") {
                        freeSpaces--;
                    }
                }
            }

            return freeSpaces;

        }
        public static void playerMove(string[,] board, string playerSign) { // solicita e executa o movimento do jogador
            string inputX, inputY;
            int x = 0, y = 0;

            do {
                do {
                    Console.Write("Digite a linha (1 a 3): ");
                    inputX = Console.ReadLine();
                    if (!string.IsNullOrEmpty(inputX) && int.TryParse(inputX, out int teste)) {
                        x = int.Parse(inputX);
                        if (!(x >= 1 && x <= 3)) {
                            Console.WriteLine("Linha inválida.");
                        }
                    }
                    else {
                        Console.WriteLine("Linha inválida.");
                    }
                } while (!(x >= 1 && x <= 3));
                x--;
                do {
                    Console.Write("Digite a coluna (1 a 3): ");
                    inputY = Console.ReadLine();
                    if (!string.IsNullOrEmpty(inputY) && int.TryParse(inputY, out int teste)) {
                        y = int.Parse(inputY);
                        if (!(y >= 1 && x <= 3)) {
                            Console.WriteLine("Coluna inválida.");
                        }
                    }
                    else {
                        Console.WriteLine("Coluna inválida.");
                    }
                } while (!(y >= 1 && y <= 3));
                y--;

                if (board[x, y] != " ") {
                    Console.WriteLine("Movimento inválido.");
                }
                else {
                    board[x, y] = playerSign;
                    break;
                }
            } while (board[x, y] != " ");
        }

        public static void computerEasyMove(string[,] board, string computerSign) {
            Random random = new Random();
            int x, y;
            if (checkFreeSpaces(board) > 0) {
                do {
                    x = random.Next(0, 3);
                    y = random.Next(0, 3);
                } while (board[x, y] != " ");

                board[x, y] = computerSign;
            }
            else {
                printWinner(" ");
            }
        }
        public static int[] minimax(string[,] board, string computerSign) {
            int score;
            int bestScore = int.MinValue;
            int[] bestMove = new int[] { -1, -1, -1};
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (board[i, j] == " ") {
                        board[i, j] = computerSign;

                        if(checkWinner(board) == computerSign) {
                            score = 1;
                        }
                        else if (checkWinner(board) == PLAYER1 || checkFreeSpaces(board) == 0) {
                            score = 0;
                        }
                        else {
                            int[] move = minimax(board, computerSign);
                            score = -move[2];      
                        }

                        board[i, j] = " ";

                        if (score > bestScore) {
                            bestScore = score;
                            bestMove[0] = i;
                            bestMove[1] = j;
                            bestMove[2] = score;
                        }
                    }
                }
            }
            return bestMove;
        }

        public static void computerHardMove(string[,] board, string computerSign) {
            int[] move = minimax(board, PLAYER2);
            board[move[0], move[1]] = computerSign;
        }

        public static string checkWinner(string[,] board) { // verifica qualquer possibilidade de vitoria
            // verificando as linhas
            for (int i = 0; i < board.GetLength(0); i++) {
                if (board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2]) {
                    return board[i, 0];
                }
            }
            // verificando as colunas
            for (int i = 0; i < board.GetLength(1); i++) {
                if (board[0, i] == board[1, i] && board[0, i] == board[2, i]) {
                    return board[0, i];
                }
            }
            // verificando diagonais
            if (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2]) {
                return board[0, 0];
            }
            if (board[2, 0] == board[1, 1] && board[2, 0] == board[0, 2]) {
                return board[2, 0];
            }

            return " ";
        }
        public static void printWinner(string winner) { // mostra no console o vencedor, ou se empatou
            if (winner == PLAYER1) {
                Console.WriteLine("Jogador 1 venceu!");
            }
            else if (winner == PLAYER2) {
                Console.WriteLine("Jogador 2 venceu!");
            }
            else {
                Console.WriteLine("Deu velha!");
            }
        }

        static void Main(string[] args) {

            string[,] board = new string[3, 3];
            string vencedor, jogarDeNovo;
            string titulo = "-------------\n" +
                            "JOGO DA VELHA\n" +
                            "-------------";
            int modoDeJogo, dificuldadePvE;

            do {
                vencedor = " ";
                jogarDeNovo = " ";

                resetBoard(board);

                Console.WriteLine(titulo);
                modoDeJogo = gameMode();
                Console.Clear();
                if (modoDeJogo == 1) {
                    while (vencedor == " " && checkFreeSpaces(board) != 0) {
                        Console.WriteLine(titulo);

                        printBoard(board);

                        Console.WriteLine("Turno do jogador 1");
                        playerMove(board, PLAYER1);
                        vencedor = checkWinner(board);
                        if (vencedor != " " || checkFreeSpaces(board) == 0) {
                            break;
                        }
                        Console.Clear();

                        Console.WriteLine(titulo);
                        printBoard(board);

                        Console.WriteLine("Turno do jogador 2");
                        playerMove(board, PLAYER2);
                        vencedor = checkWinner(board);
                        if (vencedor != " " || checkFreeSpaces(board) == 0) {
                            break;
                        }
                        Console.Clear();
                    }
                }
                else if (modoDeJogo == 2) {
                    Console.WriteLine(titulo);
                    dificuldadePvE = gameDifficult();
                    Console.Clear();
                    if (dificuldadePvE == 1) {
                        while (vencedor == " " && checkFreeSpaces(board) != 0) {
                            Console.WriteLine(titulo);

                            printBoard(board);

                            Console.WriteLine("Turno do jogador 1");
                            playerMove(board, PLAYER1);
                            vencedor = checkWinner(board);
                            if (vencedor != " " || checkFreeSpaces(board) == 0) {
                                break;
                            }
                            Console.Clear();

                            Console.WriteLine(titulo);
                            printBoard(board);


                            Console.WriteLine("Turno do computador");
                            Thread.Sleep(1000);
                            computerEasyMove(board, PLAYER2);

                            vencedor = checkWinner(board);
                            if (vencedor != " " || checkFreeSpaces(board) == 0) {
                                break;
                            }
                            Console.Clear();
                        }
                        
                    }
                    else if (dificuldadePvE == 2) {
                        while (vencedor == " " && checkFreeSpaces(board) != 0) {
                            Console.WriteLine(titulo);
                            printBoard(board);

                            Console.WriteLine("Turno do computador");
                            Thread.Sleep(1000);
                            computerHardMove(board, PLAYER2);

                            vencedor = checkWinner(board);
                            if (vencedor != " " || checkFreeSpaces(board) == 0) {
                                break;
                            }
                            Console.Clear();


                            Console.WriteLine(titulo);
                            printBoard(board);

                            Console.WriteLine("Turno do jogador 1");
                            playerMove(board, PLAYER1);
                            vencedor = checkWinner(board);
                            if (vencedor != " " || checkFreeSpaces(board) == 0) {
                                break;
                            }
                            Console.Clear();
                            
                        }
                    }
                }

                Console.Clear();
                Console.WriteLine(titulo);

                printBoard(board);
                printWinner(vencedor);
                do {
                    Console.Write("Jogar novamente (S/N)? ");
                    jogarDeNovo = Console.ReadLine().ToUpper();
                    if (!string.IsNullOrEmpty(jogarDeNovo)) {
                        if ((jogarDeNovo != "S" && jogarDeNovo != "N") || string.IsNullOrEmpty(jogarDeNovo)) {
                            Console.WriteLine("Resposta inválida.");
                        }
                    }
                    else {
                        Console.WriteLine("Resposta inválida.");
                    }
                } while (jogarDeNovo != "S" && jogarDeNovo != "N");
                Console.Clear();
            } while (jogarDeNovo == "S");


            Console.WriteLine(titulo);
            Console.WriteLine();
            Console.WriteLine("Obrigado por jogar! ;)");

        }
    }
}