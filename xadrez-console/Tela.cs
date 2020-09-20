using System;
using System.Collections.Generic;
using Xadrez.Tabuleiro;
using Xadrez.Tabuleiro.Enums;
using xadrez_console.JogoXadrez;

namespace Game.Tela
{
    class Tela
    {
        public static void ImprimirPartida(PartidaDeXadrez partidaDeXadrez)
        {
            Tela.ImprimirTabuleiro(partidaDeXadrez.Tabuleiro);

            Console.WriteLine();
            ImprimiPecasCapturadas(partidaDeXadrez);

            Console.WriteLine();
            Console.WriteLine("Turno: " + partidaDeXadrez.Turno);
            Console.WriteLine("Aguardando Jogada: " + partidaDeXadrez.JogadorAtual);

            if (partidaDeXadrez.Xeque)
            {
                Console.WriteLine("Xeque!");
            }
        }

        public static void ImprimiPecasCapturadas(PartidaDeXadrez partidaDeXadrez)
        {
            Console.WriteLine("Pecas capturadas: ");

            Console.Write("Brancas: ");
            ImprimirConjunto(partidaDeXadrez.PecasCapturadas(Cor.Branca));

            Console.WriteLine();

            ConsoleColor corOriginal = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write("Pretas: ");
            ImprimirConjunto(partidaDeXadrez.PecasCapturadas(Cor.Preta));

            Console.ForegroundColor = corOriginal;

            Console.WriteLine();
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");

            foreach(Peca peca in conjunto)
            {
                Console.Write(peca + " ");
            }

            Console.Write("] ");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int linhas = 0; linhas < tabuleiro.Linhas; linhas++)
            {
                System.Console.Write(8 - linhas + " ");
                for (int colunas = 0; colunas < tabuleiro.Colunas; colunas++)
                {
                    imprimirPeca(tabuleiro.Peca(linhas, colunas));
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int linhas = 0; linhas < tabuleiro.Linhas; linhas++)
            {
                System.Console.Write(8 - linhas + " ");
                for (int colunas = 0; colunas < tabuleiro.Colunas; colunas++)
                {
                    if (posicoesPossiveis[linhas, colunas])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tabuleiro.Peca(linhas, colunas));
                    Console.BackgroundColor = fundoOriginal;
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");

            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor consoleColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = consoleColor;
                }
                Console.Write(" ");
            }
        }
    }
}
