using System;
using Xadrez.Tabuleiro;
using Xadrez.Tabuleiro.Enums;

namespace Game.Tela
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for(int linhas = 0; linhas < tabuleiro.Linhas; linhas++)
            {
                System.Console.Write(8 - linhas + " ");
                for (int colunas = 0; colunas < tabuleiro.Colunas; colunas++)
                {                    
                    if(tabuleiro.Peca(linhas, colunas) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        imprimirPeca(tabuleiro.Peca(linhas, colunas));
                        Console.Write(" ");
                    }
                    
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirPeca(Peca peca)
        {
            if(peca.Cor == Cor.Branca)
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
        }
    }
}
